/**
 * The i3DML Project
 * Author:  Keyvan M. Kambakhsh
 * 
 * UNDER GPL V3 LICENSE
 **/

namespace i3DML.ObjectModel
{
    /// <summary>
    /// Provides a XYZ based point in the space;
    /// </summary>
    public class Point
    {
        public double X { get; set; }
        public double Y { get; set; }
        public double Z { get; set; }

        public Point()
        {
            X = 0;
            Y = 0;
            Z = 0;
        }
        public Point(double x, double y, double z) { X = x; Y = y; Z = z; }

        #region Operators
        public static Point operator +(Point a, Point b)
        {
            return new Point() { X = a.X + b.X, Y = a.Y + b.Y, Z = a.Z + b.Z };
        }
        public static Point operator -(Point a, Point b)
        {
            return new Point() { X = a.X - b.X, Y = a.Y - b.Y, Z = a.Z - b.Z };
        }
        public static Point operator -(Point a)
        {
            return new Point() { X = -a.X, Y = -a.Y, Z = -a.Z };
        }
        public static Point operator *(Point a, Point b)
        {
            return new Point() { X = a.X * b.X, Y = a.Y * b.Y, Z = a.Z * b.Z };
        }
        public static Point operator *(Point a, Ratio b)
        {
            return new Point() { X = a.X * b.X, Y = a.Y * b.Y, Z = a.Z * b.Z };
        }
        public static Point operator *(Point a, double b)
        {
            return new Point() { X = a.X * b, Y = a.Y * b, Z = a.Z * b };
        }
        public static Point operator /(Point a, Point b)
        {
            return new Point() { X = a.X / b.X, Y = a.Y / b.Y, Z = a.Z / b.Z };
        }
        public static Point operator /(Point a, Ratio b)
        {
            return new Point() { X = a.X / b.X, Y = a.Y / b.Y, Z = a.Z / b.Z };
        }
        public static Point operator /(Point a, double b)
        {
            return new Point() { X = a.X / b, Y = a.Y / b, Z = a.Z / b };
        }
        #endregion
    }
}




