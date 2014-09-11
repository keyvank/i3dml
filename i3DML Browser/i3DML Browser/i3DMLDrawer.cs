/**
 * The i3DML Project
 * Author:  Keyvan M. Kambakhsh
 * 
 * UNDER GPL V3 LICENSE
 **/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace i3DML_Browser
{
    /// <summary>
    /// A simple implementation of Ii3DMLDrawer for using by the XNA implementation of i3DML.
    /// </summary>
    class i3DMLDrawer : i3DML.Xna.Ii3DMLDrawer
    {
        private const int MaxLights = 4;
        public GraphicsDevice Device { get; private set; }
        public Effect Effect { get; private set; }
        public Matrix World { get; set; }
        public Matrix Projection { get; set; }
        public Matrix View { get; set; }
        public Vector3 Diffuse { get; set; }
        public Texture2D Texture { get; set; }
        public bool Lighting { get; set; }
        public Vector3[] LightPositions { get; private set; }
        public Vector3[] LightColors { get; private set; }
        public float[] LightPowers { get; private set; }
        public void DrawIndexedTriangleList(i3DML.Xna.VertexPositionNormalTextureColor[] vertices, int[] indices)
        {
            Effect.CurrentTechnique = Effect.Techniques["Colored"];
            Effect.Parameters["xWorld"].SetValue(World);
            Effect.Parameters["xView"].SetValue(View);
            Effect.Parameters["xProjection"].SetValue(Projection);
            Effect.Parameters["xTexture"].SetValue(Texture);
            Effect.Parameters["Textured"].SetValue(Texture != null);
            Effect.Parameters["Lighting"].SetValue(Lighting);
            Effect.Parameters["Ambient"].SetValue(0.2f);
            Effect.Parameters["Diffuse"].SetValue(Diffuse);
            Effect.Parameters["LightPositions"].SetValue(LightPositions);
            Effect.Parameters["LightPowers"].SetValue(LightPowers);
            Effect.Parameters["LightColors"].SetValue(LightColors);
            foreach (EffectPass pass in Effect.CurrentTechnique.Passes)
                pass.Apply();
            Device.DrawUserIndexedPrimitives(PrimitiveType.TriangleList, vertices, 0, vertices.Length, indices, 0, indices.Length / 3);
        }

        public void Clear(Color color)
        {
            Device.Clear(color);
        }

        public i3DMLDrawer(GraphicsDevice device, Effect effect)
        {
            LightPositions = new Vector3[MaxLights];
            LightPowers = new float[MaxLights];
            LightColors = new Vector3[MaxLights];
            Device = device;
            Effect = effect;
        }
    }
}




