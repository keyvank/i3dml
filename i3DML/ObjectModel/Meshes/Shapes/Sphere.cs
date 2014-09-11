/**
 * The i3DML Project
 * Author:  Keyvan M. Kambakhsh
 * 
 * UNDER GPL V3 LICENSE
 **/

using System;

namespace i3DML.ObjectModel
{
    public class Sphere:Shape
    {
        #region Fields
        private Ratio2D _Arc;
        #endregion
        public int Density { get; set; }
        public Ratio2D Arc { get { return _Arc; } set { if (value != null) _Arc = value; } }
        public Sphere()
        {
            Density = 10;
            Arc=new Ratio2D(){X=1,Y=1};
        }

        public override void Build()
        {
            Vertices.Clear();
            Indices.Clear();
            double step = (double)Math.PI * 2 / Density;
            double stepx = 0;
            double stepy = 0;
            double tex = 1f / Density;
            int DenY = (int)(Arc.Y * Density);
            int DenX = (int)(Arc.X * Density);
            for (int i = 0; i <= DenY; i++)
            {
                double rad = (double)Math.Sin(stepy);
                for (int j = 0; j <= DenX; j++)
                {
                    Vertices.Add(new Vertex()
                    {
                        Position = new Point(rad * Math.Sin(stepx) * Size.X / 2d + Size.X / 2, Math.Cos(stepy) * Size.Y / 2d + Size.Y / 2, rad * Math.Cos(stepx) * Size.Z / 2d + Size.Z / 2),
                        TextureCoordinate = new Point2D(tex * j / TextureSize.X, tex * i / TextureSize.Y),
                        Color = Color
                    });
                    stepx += step;
                }
                stepx = 0;
                stepy += step / 2;
            }
            for (int i = 0; i < DenY; i++)
            {
                for (int j = 0; j < DenX; j++)
                {
                    int ii = i+1;
                    int jj = j+1;
                    Indices.Add(j + i * (DenX + 1));
                    Indices.Add(jj + i * (DenX + 1));
                    Indices.Add(jj + ii * (DenX + 1));
                    Indices.Add(j + ii * (DenX + 1));
                    Indices.Add(j + i * (DenX + 1));
                    Indices.Add(jj + ii * (DenX + 1));
                }
            }
            base.Build();
        }
    }
}




