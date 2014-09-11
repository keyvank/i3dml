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
    /// Abstract base class for representing a mesh with vertices and texture.
    /// </summary>
    public abstract class Mesh:Drawable
    {
        #region Fields
        private Ratio _Diffuse;
        private i3DMLCollection<Vertex> _Vertices;
        private string _TextureSource;
        #endregion
        #region Properties
        /// <summary>
        /// The mesh's vertices collection.
        /// </summary>
        public i3DMLCollection<Vertex> Vertices { get { return _Vertices; } set { if (value != null) _Vertices = value; } }

        /// <summary>
        /// Mesh's texture data.
        /// </summary>
        [i3DMLReaderIgnore]
        public Resource TextureResource { get; private set; }

        /// <summary>
        /// Mesh's texture address.
        /// </summary>
        public string TextureSource { get { return _TextureSource; } set { _TextureSource = value; TextureResource.Url = _TextureSource; } }

        /// <summary>
        /// Mesh's diffuse color.
        /// </summary>
        public Ratio Diffuse { get { return _Diffuse; } set { if (value != null) _Diffuse = value; } }

        /// <summary>
        /// Mesh's lighting enabled.
        /// </summary>
        public bool Lighting { get; set; }
        #endregion
        public Mesh()
            :base()
        {
            Diffuse = new Ratio() { X = 1, Y = 1, Z = 1 };
            Lighting = true;
            Vertices = new i3DMLCollection<Vertex>();
            TextureResource = new Resource();
            TextureResource.ResourceType = ResourceType.Texture;
        }

        /// <summary>
        /// Abstract method for preparing and building a mesh.
        /// </summary>
        public abstract void Build();

        public override void Initialize()
        {
            Build();
            base.Initialize();
        }
    }
}




