/**
 * The i3DML Project
 * Author:  Keyvan M. Kambakhsh
 * 
 * UNDER GPL V3 LICENSE
 **/

namespace i3DML.ObjectModel
{
    /// <summary>
    /// Abstract base class for primitive meshes.
    /// </summary>
    public abstract class PrimitiveMesh : IndexedMesh
    {
        #region Fields
        private Color _Color;
        private Ratio2D _TextureSize;
        #endregion
        #region Properties
        /// <summary>
        /// Mesh's color.
        /// </summary>
        public Color Color { get { return _Color; } set { if (value != null) _Color = value; } }

        /// <summary>
        /// Mesh's texture size.
        /// </summary>
        public Ratio2D TextureSize { get { return _TextureSize; } set { if (value != null) _TextureSize = value; } }
        #endregion
        public PrimitiveMesh()
        {
            Color = new Color() { R = 255, G = 255, B = 255 };
            TextureSize = new Ratio2D();
        }
    }
}




