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
using OM=i3DML.ObjectModel;

namespace i3DML.Xna
{
    static class Extensions
    {
        public static Vector3 ToXNAVector3(this OM.Point p)
        {
            return new Vector3((float)p.X, (float)p.Y, (float)p.Z);
        }
        public static Vector3 ToXNAVector3(this OM.Ratio r)
        {
            return new Vector3((float)r.X, (float)r.Y, (float)r.Z);
        }
        public static Vector3 ToXNAVector3(this OM.Color r)
        {
            return new Vector3((float)r.R/255f, (float)r.G/255f, (float)r.B/255f);
        }
        public static Vector2 ToXNAVector2(this OM.Point2D p)
        {
            return new Vector2((float)p.X, (float)p.Y);
        }
        public static Color ToXNAColor(this OM.Color c)
        {
            return new Color((float)c.R/255f, (float)c.G/255f, (float)c.B/255f);
        }
        public static Matrix ToXNAMatrix(this OM.Matrix m)
        {
            return new Matrix((float)m.M11, (float)m.M12, (float)m.M13, (float)m.M14,
                            (float)m.M21, (float)m.M22, (float)m.M23, (float)m.M24,
                            (float)m.M31, (float)m.M32, (float)m.M33, (float)m.M34,
                            (float)m.M41, (float)m.M42, (float)m.M43, (float)m.M44);
        }

        public static int[] ToXNAIndices(this OM.Components.i3DMLCollection<int> coll)
        {
            int[] ret = new int[coll.Length];
            for (int i = 0; i < coll.Length; i++)
                ret[i] = coll[i];
            return ret;
        }
        public static VertexPositionNormalTextureColor[] ToXNAVertexArray(this OM.Components.i3DMLCollection<OM.Vertex> coll)
        {
            VertexPositionNormalTextureColor[] ret = new VertexPositionNormalTextureColor[coll.Length];
            for (int i = 0; i < coll.Length; i++)
            {
                ret[i] = new VertexPositionNormalTextureColor(coll[i].Position.ToXNAVector3(), coll[i].Normal.ToXNAVector3(), coll[i].TextureCoordinate.ToXNAVector2(), coll[i].Color.ToXNAColor());
            }
            return ret;
        }
        public static System.Collections.Generic.List<i3DML.ObjectModel.Light> GetWorldLights(this i3DML.ObjectModel.World w)
        {
            var ret = new System.Collections.Generic.List<i3DML.ObjectModel.Light>();
            var stack = new System.Collections.Generic.Stack<i3DML.ObjectModel.PlaceBase>();
            stack.Push(w);
            while (stack.Count > 0)
            {
                i3DML.ObjectModel.PlaceBase p = stack.Pop();
                for (int i = 0; i < p.Length; i++)
                {
                    if (p[i] is i3DML.ObjectModel.Light)
                        ret.Add(p[i] as i3DML.ObjectModel.Light);
                    if (p[i] is i3DML.ObjectModel.PlaceBase)
                        stack.Push(p[i] as i3DML.ObjectModel.PlaceBase);
                }
            }
            return ret;
        }
    }
}




