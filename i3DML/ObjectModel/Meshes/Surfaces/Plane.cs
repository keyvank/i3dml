/**
 * The i3DML Project
 * Author:  Keyvan M. Kambakhsh
 * 
 * UNDER GPL V3 LICENSE
 **/

namespace i3DML.ObjectModel
{
    public class Plane : Surface
    {
        public override void Build()
        {
            Vertices.Clear();
            Indices.Clear();
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
            base.Build();
        }
    }
}




