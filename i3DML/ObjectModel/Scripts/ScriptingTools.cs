/**
 * The i3DML Project
 * Author:  Keyvan M. Kambakhsh
 * 
 * UNDER GPL V3 LICENSE
 **/

using System;
using i3DML.ObjectModel.Components;

namespace i3DML.ObjectModel
{
    /// <summary>
    /// Provides some scripting tools
    /// </summary>
    [i3DMLReaderIgnore]
    public class ScriptingTools
    {
        public Matrix Rotate(double x, double y, double z)
        {
            return Matrix.Rotate(new Rotation() { X = x, Y = y, Z = z });
        }
        public Matrix Translate(double x, double y, double z)
        {
            return Matrix.Translate(x, y, z);
        }
        public Matrix Scale(double x, double y, double z)
        {
            return Matrix.Scale(x, y, z);
        }
        public Point Transform(Point p, Matrix m)
        {
            return Matrix.Transform(p, m);
        }
    }
}
