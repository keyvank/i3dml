/**
 * The i3DML Project
 * Author:  Keyvan M. Kambakhsh
 * 
 * UNDER GPL V3 LICENSE
 **/

namespace i3DML.ObjectModel
{
    /// <summary>
    /// Provides a XYZ based ratio.
    /// </summary>
    public class Ratio
    {
        public double X { get; set; }
        public double Y { get; set; }
        public double Z { get; set; }

        public Ratio()
        {
            X = 1; Y = 1; Z = 1;
        }
        #region Operators
        public static Ratio operator +(Ratio a, Ratio b)
        {
            return new Ratio() { X = a.X + b.X, Y = a.Y + b.Y, Z = a.Z + b.Z };
        }
        public static Ratio operator -(Ratio a, Ratio b)
        {
            return new Ratio() { X = a.X - b.X, Y = a.Y - b.Y, Z = a.Z - b.Z };
        }
        public static Ratio operator -(Ratio a)
        {
            return new Ratio() { X = -a.X, Y = -a.Y, Z = -a.Z };
        }
        public static Ratio operator *(Ratio a, Ratio b)
        {
            return new Ratio() { X = a.X * b.X, Y = a.Y * b.Y, Z = a.Z * b.Z };
        }
        public static Ratio operator *(Ratio a, double b)
        {
            return new Ratio() { X = a.X * b, Y = a.Y * b, Z = a.Z * b };
        }
        public static Ratio operator /(Ratio a, Ratio b)
        {
            return new Ratio() { X = a.X / b.X, Y = a.Y / b.Y, Z = a.Z / b.Z };
        }
        public static Ratio operator /(Ratio a, double b)
        {
            return new Ratio() { X = a.X / b, Y = a.Y / b, Z = a.Z / b };
        }
        #endregion
    }
}




