/**
 * The i3DML Project
 * Author:  Keyvan M. Kambakhsh
 * 
 * UNDER GPL V3 LICENSE
 **/

namespace i3DML.ObjectModel
{
    /// <summary>
    /// Provides a XYZ based rotation.
    /// </summary>
    public class Rotation
    {
        public double X { get; set; }
        public double Y { get; set; }
        public double Z { get; set; }

        public Rotation()
        {
            X = 0; Y = 0; Z = 0;
        }
        #region Operators
        public static Rotation operator +(Rotation a, Rotation b)
        {
            return new Rotation() { X = a.X + b.X, Y = a.Y + b.Y, Z = a.Z + b.Z };
        }
        public static Rotation operator -(Rotation a, Rotation b)
        {
            return new Rotation() { X = a.X - b.X, Y = a.Y - b.Y, Z = a.Z - b.Z };
        }
        public static Rotation operator -(Rotation a)
        {
            return new Rotation() { X = -a.X, Y = -a.Y, Z = -a.Z };
        }
        public static Rotation operator *(Rotation a, Rotation b)
        {
            return new Rotation() { X = a.X * b.X, Y = a.Y * b.Y, Z = a.Z * b.Z };
        }
        public static Rotation operator *(Rotation a, double b)
        {
            return new Rotation() { X = a.X * b, Y = a.Y * b, Z = a.Z * b };
        }
        public static Rotation operator /(Rotation a, Rotation b)
        {
            return new Rotation() { X = a.X / b.X, Y = a.Y / b.Y, Z = a.Z / b.Z };
        }
        public static Rotation operator /(Rotation a, double b)
        {
            return new Rotation() { X = a.X / b, Y = a.Y / b, Z = a.Z / b };
        }
        #endregion
    }
}


