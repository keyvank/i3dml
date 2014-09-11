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

namespace i3DML.Xna
{
    public struct VertexPositionNormalTextureColor : IVertexType
    {
        public Vector3 Position;
        public Vector3 Normal;
        public Vector2 TexCoord;
        public Microsoft.Xna.Framework.Color Color;
        public VertexPositionNormalTextureColor(Vector3 position, Vector3 normal, Vector2 texcoord, Microsoft.Xna.Framework.Color color)
        {
            this.Position = position; this.Normal = normal; this.TexCoord = texcoord; this.Color = color;
        }
        public static VertexDeclaration _VertexDeclaration = new VertexDeclaration(
            new VertexElement(0, VertexElementFormat.Vector3, VertexElementUsage.Position, 0),
            new VertexElement(3 * sizeof(float), VertexElementFormat.Vector3, VertexElementUsage.Normal, 0),
            new VertexElement(6 * sizeof(float), VertexElementFormat.Vector2, VertexElementUsage.TextureCoordinate, 0),
            new VertexElement(8 * sizeof(float), VertexElementFormat.Color, VertexElementUsage.Color, 0)
            );
        public static int SizeInBytes = 12 * sizeof(float);

        public VertexDeclaration VertexDeclaration
        {
            get { return _VertexDeclaration; }
        }
    }
}



