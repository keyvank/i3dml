/**
 * The i3DML Project
 * Author:  Keyvan M. Kambakhsh
 * 
 * UNDER GPL V3 LICENSE
 **/

namespace i3DML.ObjectModel
{
    /// <summary>
    /// Provides a XY based 2D size with a third parameter W as additional data.
    /// </summary>
    public class Size2D
    {
        public double X { get; set; }
        public double Y { get; set; }
        public double W { get; set; }

        public Size2D()
        {
            X = 1;
            Y = 1;
            W = 1;
        }

        #region Operators
        public static Size2D operator +(Size2D a, Size2D b)
        {
            return new Size2D() { X = a.X + b.X, Y = a.Y + b.Y, W = a.W + b.W };
        }
        public static Size2D operator -(Size2D a, Size2D b)
        {
            return new Size2D() { X = a.X - b.X, Y = a.Y - b.Y, W = a.W - b.W };
        }
        public static Size2D operator -(Size2D a)
        {
            return new Size2D() { X = -a.X, Y = -a.Y, W = -a.W };
        }
        public static Size2D operator *(Size2D a, Size2D b)
        {
            return new Size2D() { X = a.X * b.X, Y = a.Y * b.Y, W = a.W * b.W };
        }
        public static Size2D operator *(Size2D a, Ratio b)
        {
            return new Size2D() { X = a.X * b.X, Y = a.Y * b.Y };
        }
        public static Size2D operator *(Size2D a, double b)
        {
            return new Size2D() { X = a.X * b, Y = a.Y * b, W = a.W + b };
        }
        public static Size2D operator /(Size2D a, Size2D b)
        {
            return new Size2D() { X = a.X / b.X, Y = a.Y / b.Y, W = a.W / b.W };
        }
        public static Size2D operator /(Size2D a, Ratio b)
        {
            return new Size2D() { X = a.X / b.X, Y = a.Y / b.Y };
        }
        public static Size2D operator /(Size2D a, double b)
        {
            return new Size2D() { X = a.X / b, Y = a.Y / b, W = a.W / b };
        }
        #endregion
    }
}




