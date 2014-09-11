/**
 * The i3DML Project
 * Author:  Keyvan M. Kambakhsh
 * 
 * UNDER GPL V3 LICENSE
 **/

namespace i3DML.ObjectModel
{
    /// <summary>
    /// Provides a XY based 2D point in a 2D space.
    /// </summary>
    public class Point2D
    {
        public double X { get; set; }
        public double Y { get; set; }
        public Point2D()
        {
            X = 0;
            Y = 0;
        }
        public Point2D(double x, double y) { X = x; Y = y; }
        #region Operators
        public static Point2D operator +(Point2D a, Point2D b)
        {
            return new Point2D() { X = a.X + b.X, Y = a.Y + b.Y};
        }
        public static Point2D operator -(Point2D a, Point2D b)
        {
            return new Point2D() { X = a.X - b.X, Y = a.Y - b.Y};
        }
        public static Point2D operator *(Point2D a, Point2D b)
        {
            return new Point2D() { X = a.X * b.X, Y = a.Y * b.Y};
        }
        public static Point2D operator *(Point2D a, double b)
        {
            return new Point2D() { X = a.X * b, Y = a.Y * b};
        }
        public static Point2D operator /(Point2D a, Point2D b)
        {
            return new Point2D() { X = a.X / b.X, Y = a.Y / b.Y};
        }
        public static Point2D operator /(Point2D a, double b)
        {
            return new Point2D() { X = a.X / b, Y = a.Y / b};
        }
        #endregion
    }
}




