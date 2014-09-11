/**
 * The i3DML Project
 * Author:  Keyvan M. Kambakhsh
 * 
 * UNDER GPL V3 LICENSE
 **/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace i3DML.ObjectModel
{
    public class Disk:Surface
    {
        public double Arc { get; set; }
        public int Density { get; set; }
        public Disk()
        {
            Density = 10;
            Arc = 1;
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
                    Position = new Point(Size.X / 2, 0, Size.Y / 2),
                    TextureCoordinate = new Point2D(0.5d / TextureSize.X, 0.5d / TextureSize.Y),
                    Color = Color
                });
                Vertices.Add(new Vertex()
                {
                    Position = new Point(Math.Sin(s) * Size.X / 2 + Size.X / 2, 0d, Math.Cos(s) * Size.Y / 2 + Size.Y / 2),
                    TextureCoordinate = new Point2D((0.5d + Math.Sin(s) / 2d) / TextureSize.X, (0.5d + Math.Cos(s) / 2d) / TextureSize.Y),
                    Color = Color
                });
                s += step;
            }
            for (int i = 0; i < Den * 2; i += 2)
            {
                Indices.Add(i + 1);
                Indices.Add(i);
                Indices.Add(i + 3);
            }
            base.Build();
        }
    }
}




