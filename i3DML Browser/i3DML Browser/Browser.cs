/**
 * The i3DML Project
 * Author:  Keyvan M. Kambakhsh
 * 
 * UNDER GPL V3 LICENSE
 **/

using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using System.IO;

namespace i3DML_Browser
{
    /// <summary>
    /// Main class for the browser application.
    /// </summary>
    public class Browser : Microsoft.Xna.Framework.Game
    {

        GraphicsDeviceManager graphics;
        public string CurrentUrl { get; private set; }
        public i3DML.Xna.i3DMLEngine WorldBrowser { get; private set; }
        private i3DMLDrawer Drawer; 
        public Browser(string url)
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            CurrentUrl = url;
            LogService.WriteLine("Browser Started.");
        }
        protected override void Initialize()
        {
            Drawer = new i3DMLDrawer(GraphicsDevice, Content.Load<Effect>("i3DMLEffect"));
            Drawer.Projection = Matrix.CreatePerspectiveFieldOfView(MathHelper.PiOver4, (float)Window.ClientBounds.Width / (float)Window.ClientBounds.Height, 0.01f, 100000f);
            WorldBrowser = new i3DML.Xna.i3DMLEngine(Drawer);
            if (File.Exists(CurrentUrl))
            {
                LogService.WriteLine("Navigating to: {0}", CurrentUrl);
                try
                {
                    WorldBrowser.Navigate(CurrentUrl);
                }
                catch (Exception ex) { LogService.WriteLine(ex.Message); Exit(); }
            }
            else
            {
                LogService.WriteLine("Url not exists.");
                Exit();
            }
            i3DML.Xna.CameraManager cm = new i3DML.Xna.CameraManager(WorldBrowser, this);
            Components.Add(cm);
            base.Initialize();
        }
        protected override void OnExiting(object sender, EventArgs args)
        {
            LogService.WriteLine("i3DML Engine terminated. Press any key to exit.");
            Console.ReadKey();
            base.OnExiting(sender, args);
        }
        protected override void Draw(GameTime gameTime)
        {
            WorldBrowser.UpdateAndDraw();
            base.Draw(gameTime);
        }
    }
}



