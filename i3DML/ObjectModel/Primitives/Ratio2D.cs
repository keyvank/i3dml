/**
 * The i3DML Project
 * Author:  Keyvan M. Kambakhsh
 * 
 * UNDER GPL V3 LICENSE
 **/

namespace i3DML.ObjectModel
{
    /// <summary>
    /// Provides a XY based 2D ratio.
    /// </summary>
    public class Ratio2D
    {
        public double X { get; set; }
        public double Y { get; set; }
        public Ratio2D()
        {
            X = 1;
            Y = 1;
        }
        public Ratio2D(double x, double y) { X = x; Y = y; }
        #region Operators
        public static Ratio2D operator +(Ratio2D a, Ratio2D b)
        {
            return new Ratio2D() { X = a.X + b.X, Y = a.Y + b.Y };
        }
        public static Ratio2D operator -(Ratio2D a, Ratio2D b)
        {
            return new Ratio2D() { X = a.X - b.X, Y = a.Y - b.Y };
        }
        public static Ratio2D operator *(Ratio2D a, Ratio2D b)
        {
            return new Ratio2D() { X = a.X * b.X, Y = a.Y * b.Y };
        }
        public static Ratio2D operator *(Ratio2D a, double b)
        {
            return new Ratio2D() { X = a.X * b, Y = a.Y * b };
        }
        public static Ratio2D operator /(Ratio2D a, Ratio2D b)
        {
            return new Ratio2D() { X = a.X / b.X, Y = a.Y / b.Y };
        }
        public static Ratio2D operator /(Ratio2D a, double b)
        {
            return new Ratio2D() { X = a.X / b, Y = a.Y / b };
        }
        #endregion
    }
}




