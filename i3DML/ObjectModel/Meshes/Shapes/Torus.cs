/**
 * The i3DML Project
 * Author:  Keyvan M. Kambakhsh
 * 
 * UNDER GPL V3 LICENSE
 **/

using System;

namespace i3DML.ObjectModel
{
    public class Torus:Shape
    {
        #region Fields
        private Ratio2D _Arc;
        #endregion
        public double StartAngle { get; set; }
        public int Density { get; set; }
        public int TubeDensity { get; set; }
        public Ratio2D Arc { get { return _Arc; } set { if (value != null) _Arc = value; } }
        public Torus()
        {
            Size = new ObjectModel.Size() { X = 1, Y = 1d / 3, Z = 1, W = 1d / 3 };
            StartAngle = 0d;
            Density = 10;
            TubeDensity = 10;
            Arc = new Ratio2D() { X = 1, Y = 1 };
        }
        public override void Build()
        {
            Vertices.Clear();
            Indices.Clear();
            double stepd = Math.PI*2/Density;
            double steptd = Math.PI*2/TubeDensity;
            double stepd0 = 0d;
            double steptd0 = StartAngle*Math.PI/180d;
            int DenY = (int)(Arc.Y * (TubeDensity==2?1:TubeDensity));
            int DenX = (int)(Arc.X * Density);
            for (int i = 0; i <= DenY; i++)
            {
                for (int j = 0; j <= DenX; j++)
                {
                    Vertices.Add(new Vertex()
                    {
                        Position = new Point(Math.Sin(stepd0) * (Size.X - Size.W + Size.W * Math.Cos(steptd0)) / 2 + Size.X / 2,
                                            Math.Sin(steptd0) * Size.Y / 2 + Size.Y / 2,
                                            Math.Cos(stepd0) * (Size.Z - Size.W + Size.W * Math.Cos(steptd0)) / 2 + Size.Z / 2),
                        TextureCoordinate = new Point2D((double)i / TubeDensity/TextureSize.X,(double)j / Density/TextureSize.Y),
                        Color = Color
                    });
                    stepd0 += stepd;
                }
                stepd0 = 0d;
                steptd0 += steptd;
            }
            for (int i = 0; i < DenY; i++)
            {
                for (int j = 0; j < DenX; j++)
                {
                    int jj = j + 1;
                    int ii = i + 1;
                    Indices.Add(jj + i * (DenX + 1));
                    Indices.Add(j + i * (DenX + 1));
                    Indices.Add(jj + ii * (DenX + 1));
                    Indices.Add(j + i * (DenX + 1));
                    Indices.Add(j + ii * (DenX + 1));
                    Indices.Add(jj + ii * (DenX + 1));
                }
            }
            base.Build();
        }
    }
}




