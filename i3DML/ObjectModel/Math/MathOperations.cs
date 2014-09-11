/**
 * The i3DML Project
 * Author:  Keyvan M. Kambakhsh
 * 
 * UNDER GPL V3 LICENSE
 **/

using System;

namespace i3DML.ObjectModel
{
    /// <summary>
    /// 3D Geometrical math operations.
    /// </summary>
    public static class MathOperations
    {

        /// <summary>
        /// Distance between the point and the origin of coordinates.
        /// </summary>
        /// <param name="p">The point</param>
        /// <returns>Length of the point</returns>
        public static double PointLength(Point p)
        {
            return Math.Sqrt(p.X * p.X + p.Y * p.Y + p.Z * p.Z);
        }

        /// <summary>
        /// Sets the point length to 1.
        /// </summary>
        /// <param name="p">The point</param>
        /// <returns>Normalized point</returns>
        public static Point PointNormalize(Point p)
        {
            double len = PointLength(p);
            return new Point(p.X / len, p.Y / len, p.Z / len);
        }

        /// <summary>
        /// Cross product of two points.
        /// </summary>
        /// <param name="a">Point A</param>
        /// <param name="b">Point B</param>
        /// <returns>Cross product of A and B</returns>
        public static Point PointCross(Point a, Point b)
        {
            return new Point(a.Y * b.Z - a.Z * b.Y,
                    a.Z * b.X - a.X * b.Z,
                    a.X * b.Y - a.Y * b.X);
        }
    }
}




