/**
 * The i3DML Project
 * Author:  Keyvan M. Kambakhsh
 * 
 * UNDER GPL V3 LICENSE
 **/

using i3DML.ObjectModel.Components;

namespace i3DML.ObjectModel
{
    /// <summary>
    /// Base class for all heightmap elements (HeightMap, Plot and etc.)
    /// </summary>
    public abstract class HeightMapBase : Surface
    {
        public int Density { get; set; }

        /// <summary>
        /// Get height at (x,y)
        /// </summary>
        /// <param name="x">X</param>
        /// <param name="y">Y</param>
        /// <returns>Height at (x,y)</returns>
        public double GetHeightAt(int x, int y)
        {
            return HeightMapData[x, y];
        }

        /// <summary>
        /// Stores the elevation data as doubles
        /// </summary>
        [i3DMLReaderIgnore]
        public double[,] HeightMapData { get; protected set; }

        public HeightMapBase()
        {
            Density = 10;
        }
        public override void Build()
        {
            Vertices.Clear();
            Indices.Clear();
            if (HeightMapData != null)
            {
                double step = 1f / (Density - 1);
                double curry = 0d;
                for (int y = 0; y < Density; y++, curry += Size.Y * step)
                {
                    double currx = 0;
                    for (int x = 0; x < Density; x++, currx += Size.X * step)
                    {
                        Vertices.Add(new Vertex()
                        {
                            Position = new Point(currx, ((double)HeightMapData[x, y]) * Size.W, curry),
                            TextureCoordinate = new Point2D(1d / TextureSize.X * step * x, 1d / TextureSize.Y * step * y),
                            Color = Color
                        });
                    }
                }
                for (int y = 0; y < Density - 1; y++)
                    for (int x = 0; x < Density - 1; x++)
                    {
                        Indices.Add(x + y * Density);
                        Indices.Add(x + 1 + y * Density);
                        Indices.Add(x + 1 + (y + 1) * Density);
                        Indices.Add(x + (y + 1) * Density);
                        Indices.Add(x + y * Density);
                        Indices.Add(x + 1 + (y + 1) * Density);
                    }
            }
            else
            {
                Vertex v1 = new Vertex() { Position = new Point(0, 0, 0), TextureCoordinate = new Point2D(0, 0), Color = Color };
                Vertex v2 = new Vertex() { Position = new Point(Size.X, 0, 0), TextureCoordinate = new Point2D(1 / TextureSize.X, 0), Color = Color };
                Vertex v3 = new Vertex() { Position = new Point(Size.X, 0, Size.Y), TextureCoordinate = new Point2D(1 / TextureSize.X, 1 / TextureSize.Y), Color = Color };
                Vertex v4 = new Vertex() { Position = new Point(0, 0, Size.Y), TextureCoordinate = new Point2D(0, 1 / TextureSize.Y), Color = Color };
                Vertices.Add(v1);
                Vertices.Add(v2);
                Vertices.Add(v3);
                Vertices.Add(v4);
                Indices.Add(0);
                Indices.Add(1);
                Indices.Add(2);
                Indices.Add(0);
                Indices.Add(2);
                Indices.Add(3);
            }
            base.Build();
        }
    }
}




