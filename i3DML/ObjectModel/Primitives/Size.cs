/**
 * The i3DML Project
 * Author:  Keyvan M. Kambakhsh
 * 
 * UNDER GPL V3 LICENSE
 **/

namespace i3DML.ObjectModel
{
    /// <summary>
    /// Provides a XYZ based size with a fourth parameter W as additional data.
    /// </summary>
    public class Size
    {
        public double X { get; set; }
        public double Y { get; set; }
        public double Z { get; set; }
        public double W { get; set; }

        public Size()
        {
            X = 1;
            Y = 1;
            Z = 1;
            W = 1;
        }

        #region Operators
        public static Size operator +(Size a, Size b)
        {
            return new Size() { X = a.X + b.X, Y = a.Y + b.Y, Z = a.Z + b.Z, W = a.W + b.W };
        }
        public static Size operator -(Size a, Size b)
        {
            return new Size() { X = a.X - b.X, Y = a.Y - b.Y, Z = a.Z - b.Z, W = a.W - b.W };
        }
        public static Size operator -(Size a)
        {
            return new Size() { X = -a.X, Y = -a.Y, Z = -a.Z, W = -a.W };
        }
        public static Size operator *(Size a, Size b)
        {
            return new Size() { X = a.X * b.X, Y = a.Y * b.Y, Z = a.Z * b.Z, W = a.W * b.W };
        }
        public static Size operator *(Size a, Ratio b)
        {
            return new Size() { X = a.X * b.X, Y = a.Y * b.Y, Z = a.Z * b.Z };
        }
        public static Size operator *(Size a, double b)
        {
            return new Size() { X = a.X * b, Y = a.Y * b, Z = a.Z * b, W = a.W + b };
        }
        public static Size operator /(Size a, Size b)
        {
            return new Size() { X = a.X / b.X, Y = a.Y / b.Y, Z = a.Z / b.Z, W = a.W / b.W };
        }
        public static Size operator /(Size a, Ratio b)
        {
            return new Size() { X = a.X / b.X, Y = a.Y / b.Y, Z = a.Z / b.Z };
        }
        public static Size operator /(Size a, double b)
        {
            return new Size() { X = a.X / b, Y = a.Y / b, Z = a.Z / b, W = a.W / b };
        }
        public static implicit operator Point(Size s)
        {
            return new Point(s.X, s.Y, s.Z);
        }
        #endregion
    }
}




