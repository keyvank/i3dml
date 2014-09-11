/**
 * The i3DML Project
 * Author:  Keyvan M. Kambakhsh
 * 
 * UNDER GPL V3 LICENSE
 **/

namespace i3DML.ObjectModel
{
    /// <summary>
    /// Provides a colored vertex in the space with normal and texture coordinate.
    /// </summary>
    public class Vertex
    {
        #region Fields
        private Point _Position;
        private Color _Color;
        private Point2D _TextureCoordinate;
        private Point _Normal;
        #endregion
        public Point Position { get { return _Position; } set { if (value != null) _Position = value; } }
        public Color Color { get { return _Color; } set { if (value != null) _Color = value; } }
        public Point2D TextureCoordinate { get { return _TextureCoordinate; } set { if (value != null) _TextureCoordinate = value; } }
        public Point Normal { get { return _Normal; } set { if (value != null) _Normal = value; } }
        public Vertex()
        {
            Position = new Point() { X = 0, Y = 0, Z = 0 };
            Color = new Color() { R = 255, G = 255, B = 255 };
            TextureCoordinate = new Point2D() { X = 0, Y = 0 };
            Normal = new Point() { X = 0, Y = 0, Z = 0 };
        }
    }
}




