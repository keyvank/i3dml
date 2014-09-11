/**
 * The i3DML Project
 * Author:  Keyvan M. Kambakhsh
 * 
 * UNDER GPL V3 LICENSE
 **/

using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using OM = i3DML.ObjectModel;
using PA = i3DML.Parser;
using System.IO;

namespace i3DML.Xna
{
    /// <summary>
    /// Wrapping all needed stuff for running an i3DML application (Under the XNA API)
    /// </summary>
    public class i3DMLEngine
    {
        public OM.World CurrentWorld { get; private set; }
        private PA.i3DMLReader<OM.World> Reader;
        private Ii3DMLDrawer Drawer;
        private i3DMLUrlManager UrlManager = new i3DMLUrlManager();
        public i3DMLEngine(Ii3DMLDrawer drawer)
        {
            OM.ResourceManager.SetUrlManager(UrlManager);
            OM.ResourceManager.SetResourceConverter(OM.ResourceType.Texture, new OM.ResourceConverter(s =>
                {
                    return Texture2D.FromStream(drawer.Device, s);
                }));
            OM.ResourceManager.SetResourceConverter(OM.ResourceType.HeightMap, new OM.ResourceConverter(s =>
                {
                    Texture2D tex = Texture2D.FromStream(drawer.Device, s);
                    Color[] dat=new Color[tex.Height*tex.Width];
                    tex.GetData(dat);
                    double[,] ret = new double[tex.Width, tex.Height];
                    for(int y=0;y<tex.Height;y++)
                        for (int x = 0; x < tex.Width; x++)
                        {
                            Color c=dat[x+y*tex.Width];
                            ret[x, y] = ((c.R + c.G + c.B) / 3)/255d;
                        }
                    return ret;
                }));
            OM.ScriptManager.GlobalFunctions.Add(new OM.ScriptFunction("getPressedKeys", new Func<string>(() =>
            {
                string ret="";
                var pressed=Microsoft.Xna.Framework.Input.Keyboard.GetState().GetPressedKeys();
                foreach (var k in pressed)
                {
                    ret += k;
                }
                return ret;
            })));
            OM.ScriptManager.GlobalFunctions.Add(new OM.ScriptFunction("isPressed", new Func<string,bool>((key) =>
            {
                return Microsoft.Xna.Framework.Input.Keyboard.GetState().IsKeyDown((Microsoft.Xna.Framework.Input.Keys)Enum.Parse(typeof(Microsoft.Xna.Framework.Input.Keys),key));
            })));
            OM.ScriptManager.GlobalFunctions.Add(new OM.ScriptFunction("redirect", new Action<string>((url) =>
            {
                Navigate(url);
            })));
            Reader = PA.i3DMLReader<OM.World>.DefaultReader;
            Drawer = drawer;
        }
        public void Navigate(string url)
        {
            // REVISE
            Directory.SetCurrentDirectory(new FileInfo(url).Directory.FullName);
            // REVISE

            StreamReader rdr = new StreamReader(url);
            string code = rdr.ReadToEnd();
            Navigate(new StringReader(code));
            rdr.Close();
            rdr.Dispose();
        }
        public void Navigate(TextReader text)
        {
            if (CurrentWorld != null)
            {
                CurrentWorld.Redirected -= CurrentWorld_Redirected;
                CurrentWorld.Dispose();
            }
            CurrentWorld = Reader.Read(text);
            CurrentWorld.Redirected += CurrentWorld_Redirected;
            CurrentWorld.Initialize();
        }

        void CurrentWorld_Redirected(object sender, OM.RedirectedEventArgs e)
        {
            Navigate(e.NewUrl);
        }
        private void DrawMesh(OM.IndexedMesh mesh)
        {
            if (mesh.Indices.Length < 3 || mesh.Vertices.Length == 0)
                return;

            Drawer.Texture = mesh.TextureResource.Data as Texture2D;
            Drawer.World = Matrix.CreateScale(mesh.AbsoluteScale.ToXNAVector3()) * mesh.AbsoluteRotationMatrix.ToXNAMatrix() * Matrix.CreateTranslation(mesh.AbsolutePosition.ToXNAVector3());
            Drawer.View = Matrix.CreateLookAt(CurrentWorld.CameraPosition.ToXNAVector3(), CurrentWorld.CameraTarget.ToXNAVector3(), Vector3.Up);
            Drawer.Diffuse = mesh.Diffuse.ToXNAVector3();
            Drawer.Lighting = mesh.Lighting;

            VertexPositionNormalTextureColor[] varr = mesh.Vertices.ToXNAVertexArray();
            int[] iarr = mesh.Indices.ToXNAIndices();

            Drawer.DrawIndexedTriangleList(varr,iarr);
        }
        private void DrawModel(OM.Model m)
        {
            throw new NotImplementedException();
        }
        private void RecursiveDraw(OM.Drawable drawable)
        {
            if (!drawable.Visible)
                return;
            if (drawable is OM.Model)
            {
                DrawModel(drawable as OM.Model);
            }
            else if (drawable is OM.IndexedMesh)
            {
                DrawMesh(drawable as OM.IndexedMesh);
            }
            else if (drawable is OM.PlaceBase)
            {
                OM.PlaceBase place = drawable as OM.PlaceBase;
                for (int i = 0; i < place.Length; i++)
                    RecursiveDraw(place[i]);
            }
        }
        public void UpdateAndDraw()
        {
            var l = CurrentWorld.GetWorldLights();
            for (int i = 0; i < Drawer.LightPositions.Length; i++)
            {
                if (i < l.Count)
                {
                    Drawer.LightPositions[i] = l[i].AbsolutePosition.ToXNAVector3();
                    Drawer.LightPowers[i] = (float)l[i].Power;
                    Drawer.LightColors[i] = l[i].Color.ToXNAVector3();
                }
                else
                {
                    Drawer.LightPositions[i] = Vector3.Zero;
                    Drawer.LightPowers[i] = 0f;
                    Drawer.LightColors[i] = Vector3.Zero;
                }
            }
            Drawer.Clear(CurrentWorld.Background.ToXNAColor());
            CurrentWorld.Update();
            if (CurrentWorld.Visible)
                RecursiveDraw(CurrentWorld);
        }
    }
}




