/**
 * The i3DML Project
 * Author:  Keyvan M. Kambakhsh
 * 
 * UNDER GPL V3 LICENSE
 **/

using System;

namespace i3DML.ObjectModel
{
    public class Cylinder : Shape
    {
        public double Arc { get; set; }
        public int Density { get; set; }
        public Cylinder()
        {
            Arc = 1;
            Density = 10;
        }
        public override void Build()
        {
            Vertices.Clear();
            Indices.Clear();
            double step = Math.PI * 2 / Density;
            double s = 0;
            int Den = (int)(Density * Arc);
            for (int i = 0; i <= Den; i++)
            {
                Vertices.Add(new Vertex()
                {
                    Position = new Point(Math.Sin(s) * Size.X / 2 + Size.X / 2, 0d, Math.Cos(s) * Size.Z / 2 + Size.Z / 2),
                    TextureCoordinate = new Point2D((double)i / Density / TextureSize.X, 1d/TextureSize.Y),
                    Color = Color
                });
                Vertices.Add(new Vertex()
                {
                    Position = new Point(Math.Sin(s) * Size.X / 2 + Size.X / 2, Size.Y, Math.Cos(s) * Size.Z / 2 + Size.Z / 2),
                    TextureCoordinate = new Point2D((double)i / Density / TextureSize.X, 0d),
                    Color = Color
                });
                Vertices.Add(new Vertex()
                {
                    Position = new Point(Size.X / 2, 0, Size.Z / 2),
                    TextureCoordinate = new Point2D(0.5d/TextureSize.X, 0.5d/TextureSize.Y),
                    Color = Color
                });
                Vertices.Add(new Vertex()
                {
                    Position = new Point(Math.Sin(s) * Size.X / 2 + Size.X / 2, 0d, Math.Cos(s) * Size.Z / 2 + Size.Z / 2),
                    TextureCoordinate = new Point2D((0.5d + Math.Sin(s) / 2d)/TextureSize.X, (0.5d + Math.Cos(s) / 2d)/TextureSize.Y),
                    Color = Color
                });
                Vertices.Add(new Vertex()
                {
                    Position = new Point(Size.X / 2, Size.Y, Size.Z / 2),
                    TextureCoordinate = new Point2D(0.5d/TextureSize.X, 0.5d/TextureSize.Y),
                    Color = Color
                });
                Vertices.Add(new Vertex()
                {
                    Position = new Point(Math.Sin(s) * Size.X / 2 + Size.X / 2, Size.Y, Math.Cos(s) * Size.Z / 2 + Size.Z / 2),
                    TextureCoordinate = new Point2D((0.5d + Math.Sin(s) / 2d)/TextureSize.X, (0.5d + Math.Cos(s) / 2d)/TextureSize.Y),
                    Color = Color
                });

                s += step;
            }
            for (int i = 0; i < Den * 6; i += 6)
            {
                Indices.Add(i);
                Indices.Add(i + 1);
                Indices.Add(i + 6);
                Indices.Add(i + 1);
                Indices.Add(i + 7);
                Indices.Add(i + 6);
                Indices.Add(i + 2);
                Indices.Add(i + 3);
                Indices.Add(i + 9);
                Indices.Add(i + 5);
                Indices.Add(i + 4);
                Indices.Add(i + 11);
            }
            base.Build();
        }
    }
}




