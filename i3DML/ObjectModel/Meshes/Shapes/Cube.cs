/**
 * The i3DML Project
 * Author:  Keyvan M. Kambakhsh
 * 
 * UNDER GPL V3 LICENSE
 **/

namespace i3DML.ObjectModel
{
    public class Cube : Shape
    {
        public override void Build()
        {
            Vertices.Clear();
            Indices.Clear();
            Vertex F1A = new Vertex(){Position= new Point(0, 0, 0), TextureCoordinate=new Point2D(0, 1 / TextureSize.Y),Color=Color};
            Vertex F1C = new Vertex(){Position= new Point(Size.X, Size.Y, 0), TextureCoordinate=new Point2D(1 / TextureSize.X, 0), Color=Color};
            Vertex F1B = new Vertex(){Position= new Point(Size.X, 0, 0), TextureCoordinate=new Point2D(1 / TextureSize.X, 1 / TextureSize.Y), Color=Color};
            Vertex F2A = new Vertex(){Position= new Point(0, 0, 0), TextureCoordinate=new Point2D(0, 1 / TextureSize.Y), Color=Color};
            Vertex F2C = new Vertex(){Position= new Point(0, Size.Y, 0), TextureCoordinate=new Point2D(0, 0), Color=Color};
            Vertex F2B = new Vertex(){Position= new Point(Size.X, Size.Y, 0), TextureCoordinate=new Point2D(1 / TextureSize.X, 0), Color=Color};
            Vertex B1A = new Vertex(){Position= new Point(0, 0, Size.Z), TextureCoordinate=new Point2D(0, 1 / TextureSize.Y), Color=Color};
            Vertex B1B = new Vertex(){Position= new Point(Size.X, Size.Y, Size.Z), TextureCoordinate=new Point2D(1 / TextureSize.X, 0), Color=Color};
            Vertex B1C = new Vertex(){Position= new Point(Size.X, 0, Size.Z), TextureCoordinate=new Point2D(1 / TextureSize.X, 1 / TextureSize.Y), Color=Color};
            Vertex B2A = new Vertex(){Position= new Point(0, 0, Size.Z), TextureCoordinate=new Point2D(0, 1 / TextureSize.Y), Color=Color};
            Vertex B2B = new Vertex(){Position= new Point(0, Size.Y, Size.Z), TextureCoordinate=new Point2D(0, 0), Color=Color};
            Vertex B2C = new Vertex(){Position= new Point(Size.X, Size.Y, Size.Z), TextureCoordinate=new Point2D(1 / TextureSize.X, 0), Color=Color};
            Vertex R1A = new Vertex(){Position= new Point(Size.X, 0, 0), TextureCoordinate=new Point2D(0, 1 / TextureSize.Y), Color=Color};
            Vertex R1B = new Vertex(){Position= new Point(Size.X, Size.Y, Size.Z), TextureCoordinate=new Point2D(1 / TextureSize.X, 0), Color=Color};
            Vertex R1C = new Vertex(){Position= new Point(Size.X, Size.Y, 0), TextureCoordinate=new Point2D(0, 0), Color=Color};
            Vertex R2A = new Vertex(){Position= new Point(Size.X, 0, 0), TextureCoordinate=new Point2D(0, 1 / TextureSize.Y), Color=Color};
            Vertex R2B = new Vertex(){Position= new Point(Size.X, 0, Size.Z), TextureCoordinate=new Point2D(1 / TextureSize.X, 1 / TextureSize.Y), Color=Color};
            Vertex R2C = new Vertex(){Position= new Point(Size.X, Size.Y, Size.Z), TextureCoordinate=new Point2D(1 / TextureSize.X, 0), Color=Color};
            Vertex L1A = new Vertex(){Position= new Point(0, 0, 0), TextureCoordinate=new Point2D(0, 1 / TextureSize.Y), Color=Color};
            Vertex L1C = new Vertex(){Position= new Point(0, Size.Y, Size.Z), TextureCoordinate=new Point2D(1 / TextureSize.X, 0), Color=Color};
            Vertex L1B = new Vertex(){Position= new Point(0, Size.Y, 0), TextureCoordinate=new Point2D(0, 0), Color=Color};
            Vertex L2A = new Vertex(){Position= new Point(0, 0, 0), TextureCoordinate=new Point2D(0, 1 / TextureSize.Y), Color=Color};
            Vertex L2C = new Vertex(){Position= new Point(0, 0, Size.Z), TextureCoordinate=new Point2D(1 / TextureSize.X, 1 / TextureSize.Y), Color=Color};
            Vertex L2B = new Vertex(){Position= new Point(0, Size.Y, Size.Z), TextureCoordinate=new Point2D(1 / TextureSize.X, 0), Color=Color};
            Vertex D1A = new Vertex(){Position= new Point(0, 0, 0), TextureCoordinate=new Point2D(0, 0), Color=Color};
            Vertex D1B = new Vertex(){Position= new Point(Size.X, 0, Size.Z), TextureCoordinate=new Point2D(1 / TextureSize.X, 1 / TextureSize.X), Color=Color};
            Vertex D1C = new Vertex(){Position= new Point(Size.X, 0, 0), TextureCoordinate=new Point2D(0, 1 / TextureSize.X), Color=Color};
            Vertex D2A = new Vertex(){Position= new Point(0, 0, 0), TextureCoordinate=new Point2D(0, 0), Color=Color};
            Vertex D2B = new Vertex(){Position= new Point(0, 0, Size.Z), TextureCoordinate=new Point2D(1 / TextureSize.X, 0), Color=Color};
            Vertex D2C = new Vertex(){Position= new Point(Size.X, 0, Size.Z), TextureCoordinate=new Point2D(1 / TextureSize.X, 1 / TextureSize.X), Color=Color};
            Vertex U1A = new Vertex(){Position= new Point(0, Size.Y, 0), TextureCoordinate=new Point2D(0, 0), Color=Color};
            Vertex U1C = new Vertex(){Position= new Point(Size.X, Size.Y, Size.Z), TextureCoordinate=new Point2D(1 / TextureSize.X, 1 / TextureSize.X), Color=Color};
            Vertex U1B = new Vertex(){Position= new Point(Size.X, Size.Y, 0), TextureCoordinate=new Point2D(0, 1 / TextureSize.X), Color=Color};
            Vertex U2A = new Vertex(){Position= new Point(0, Size.Y, 0), TextureCoordinate=new Point2D(0, 0), Color=Color};
            Vertex U2C = new Vertex(){Position= new Point(0, Size.Y, Size.Z), TextureCoordinate=new Point2D(1 / TextureSize.X, 0), Color=Color};
            Vertex U2B = new Vertex(){Position= new Point(Size.X, Size.Y, Size.Z), TextureCoordinate=new Point2D(1 / TextureSize.X, 1 / TextureSize.X), Color=Color};
            Vertices.Add(F1A);
            Vertices.Add(F1B);
            Vertices.Add(F1C);
            Vertices.Add(F2A);
            Vertices.Add(F2B);
            Vertices.Add(F2C);
            Vertices.Add(B1A);
            Vertices.Add(B1B);
            Vertices.Add(B1C);
            Vertices.Add(B2A);
            Vertices.Add(B2B);
            Vertices.Add(B2C);
            Vertices.Add(R1A);
            Vertices.Add(R1B);
            Vertices.Add(R1C);
            Vertices.Add(R2A);
            Vertices.Add(R2B);
            Vertices.Add(R2C);
            Vertices.Add(L1A);
            Vertices.Add(L1B);
            Vertices.Add(L1C);
            Vertices.Add(L2A);
            Vertices.Add(L2B);
            Vertices.Add(L2C);
            Vertices.Add(D1A);
            Vertices.Add(D1B);
            Vertices.Add(D1C);
            Vertices.Add(D2A);
            Vertices.Add(D2B);
            Vertices.Add(D2C);
            Vertices.Add(U1A);
            Vertices.Add(U1B);
            Vertices.Add(U1C);
            Vertices.Add(U2A);
            Vertices.Add(U2B);
            Vertices.Add(U2C);
            for (int i = 0; i < Vertices.Length; i++)
                Indices.Add(i);
            base.Build();
        }
    }
}




