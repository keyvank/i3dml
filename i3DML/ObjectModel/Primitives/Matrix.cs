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
    /// Provides a 4x4 matrix with some geometric operations.
    /// </summary>
    public class Matrix
    {
        private const double DegreeToRadians = Math.PI / 180d;
        public double M11 { get; set; }
        public double M12 { get; set; }
        public double M13 { get; set; }
        public double M14 { get; set; }
        public double M21 { get; set; }
        public double M22 { get; set; }
        public double M23 { get; set; }
        public double M24 { get; set; }
        public double M31 { get; set; }
        public double M32 { get; set; }
        public double M33 { get; set; }
        public double M34 { get; set; }
        public double M41 { get; set; }
        public double M42 { get; set; }
        public double M43 { get; set; }
        public double M44 { get; set; }
        public Matrix()
        {
            M11 = 0; M12 = 0; M13 = 0; M14 = 0;
            M21 = 0; M22 = 0; M23 = 0; M24 = 0;
            M31 = 0; M32 = 0; M33 = 0; M34 = 0;
            M41 = 0; M42 = 0; M43 = 0; M44 = 0;
        }
        public static Matrix operator *(Matrix a, Matrix b)
        {
            Matrix mul = new Matrix();
            mul.M11 = a.M11 * b.M11 + a.M12 * b.M21 + a.M13 * b.M31 + a.M14 * b.M41;
            mul.M12 = a.M11 * b.M12 + a.M12 * b.M22 + a.M13 * b.M32 + a.M14 * b.M42;
            mul.M13 = a.M11 * b.M13 + a.M12 * b.M23 + a.M13 * b.M33 + a.M14 * b.M43;
            mul.M14 = a.M11 * b.M14 + a.M12 * b.M24 + a.M13 * b.M34 + a.M14 * b.M44;

            mul.M21 = a.M21 * b.M11 + a.M22 * b.M21 + a.M23 * b.M31 + a.M24 * b.M41;
            mul.M22 = a.M21 * b.M12 + a.M22 * b.M22 + a.M23 * b.M32 + a.M24 * b.M42;
            mul.M23 = a.M21 * b.M13 + a.M22 * b.M23 + a.M23 * b.M33 + a.M24 * b.M43;
            mul.M24 = a.M21 * b.M14 + a.M22 * b.M24 + a.M23 * b.M34 + a.M24 * b.M44;

            mul.M31 = a.M31 * b.M11 + a.M32 * b.M21 + a.M33 * b.M31 + a.M34 * b.M41;
            mul.M32 = a.M31 * b.M12 + a.M32 * b.M22 + a.M33 * b.M32 + a.M34 * b.M42;
            mul.M33 = a.M31 * b.M13 + a.M32 * b.M23 + a.M33 * b.M33 + a.M34 * b.M43;
            mul.M34 = a.M31 * b.M14 + a.M32 * b.M24 + a.M33 * b.M34 + a.M34 * b.M44;

            mul.M41 = a.M41 * b.M11 + a.M42 * b.M21 + a.M43 * b.M31 + a.M44 * b.M41;
            mul.M42 = a.M41 * b.M12 + a.M42 * b.M22 + a.M43 * b.M32 + a.M44 * b.M42;
            mul.M43 = a.M41 * b.M13 + a.M42 * b.M23 + a.M43 * b.M33 + a.M44 * b.M43;
            mul.M44 = a.M41 * b.M14 + a.M42 * b.M24 + a.M43 * b.M34 + a.M44 * b.M44;
            return mul;
        }
        public static Matrix Scale(double x, double y, double z)
        {
            Matrix scale = new Matrix();
            scale.M11 = x;
            scale.M22 = y;
            scale.M33 = z;
            scale.M44 = 1d;
            return scale;
        }
        public static Matrix RotateByX(double x)
        {
            Matrix ret = new Matrix();
            ret.M11 = 1d;
            ret.M22 = Math.Cos(x * DegreeToRadians);
            ret.M23 = Math.Sin(x * DegreeToRadians);
            ret.M32 = -Math.Sin(x * DegreeToRadians);
            ret.M33 = Math.Cos(x * DegreeToRadians);
            ret.M44 = 1d;
            return ret;
        }
        public static Matrix RotateByY(double y)
        {
            Matrix ret = new Matrix();
            ret.M11 = Math.Cos(y * DegreeToRadians);
            ret.M13 = Math.Sin(y * DegreeToRadians);
            ret.M22 = 1d;
            ret.M31 = -Math.Sin(y * DegreeToRadians);
            ret.M33 = Math.Cos(y * DegreeToRadians);
            ret.M44 = 1d;
            return ret;
        }
        public static Matrix RotateByZ(double z)
        {
            Matrix ret = new Matrix();
            ret.M11 = Math.Cos(z * DegreeToRadians);
            ret.M12 = Math.Sin(z * DegreeToRadians);
            ret.M21 = -Math.Sin(z * DegreeToRadians);
            ret.M22 = Math.Cos(z * DegreeToRadians);
            ret.M33 = 1d;
            ret.M44 = 1d;
            return ret;
        }
        public static Matrix Rotate(Rotation rot)
        {
            return RotateByX(rot.X) * RotateByY(rot.Y) * RotateByZ(rot.Z);
        }
        public static Matrix Translate(double x, double y, double z)
        {
            Matrix translate = new Matrix();
            translate.M11 = 1d;
            translate.M22 = 1d;
            translate.M33 = 1d;
            translate.M44 = 1d;
            translate.M41 = x;
            translate.M42 = y;
            translate.M43 = z;
            return translate;
        }
        public static Point Transform(Point p, Matrix m)
        {
            Point transformed = new Point();
            transformed.X = p.X * m.M11 + p.Y * m.M21 + p.Z * m.M31 + 1 * m.M41;
            transformed.Y = p.X * m.M12 + p.Y * m.M22 + p.Z * m.M32 + 1 * m.M42;
            transformed.Z = p.X * m.M13 + p.Y * m.M23 + p.Z * m.M33 + 1 * m.M43;
            return transformed;
        }

    }
}




