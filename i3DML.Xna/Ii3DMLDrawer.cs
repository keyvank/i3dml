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

namespace i3DML.Xna
{
    /// <summary>
    /// The implementor class can define the way which the engine uses to draws primitives.
    /// </summary>
    public interface Ii3DMLDrawer
    {
        GraphicsDevice Device { get; }
        Effect Effect { get; }
        Matrix World { get; set; }
        Matrix Projection { get; set; }
        Matrix View { get; set; }
        Texture2D Texture { get; set; }
        Vector3 Diffuse { get; set; }
        bool Lighting { get; set; }
        Vector3[] LightPositions { get; }
        Vector3[] LightColors { get; }
        float[] LightPowers { get; }
        void DrawIndexedTriangleList(VertexPositionNormalTextureColor[] vertices, int[] indices);
        void Clear(Color color);
    }
}




