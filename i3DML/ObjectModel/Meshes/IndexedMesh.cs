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
    /// Provides a indexed mesh.
    /// </summary>
    public class IndexedMesh : Mesh
    {
        #region Fields
        private i3DMLCollection<int> _Indices;
        #endregion
        #region Properties

        /// <summary>
        /// The mesh's indices.
        /// </summary>
        public i3DMLCollection<int> Indices { get { return _Indices; } set { if (value != null) _Indices = value; } }

        /// <summary>
        /// Is this mesh an area?
        /// </summary>
        public bool IsArea { get; set; }

        #endregion
        public IndexedMesh()
            : base()
        {
            Indices = new i3DMLCollection<int>();
        }

        public override void Build()
        {
            // Calculating normals.
            for (int i = 0; i < Indices.Length / 3; i++)
            {
                if (IsArea)
                {
                    int temp = Indices[i * 3];
                    Indices[i * 3] = Indices[i * 3 + 1];
                    Indices[i * 3 + 1] = temp;
                }

                int index1 = Indices[i * 3];
                int index2 = Indices[i * 3 + 1];
                int index3 = Indices[i * 3 + 2];

                Point side1 = Vertices[index1].Position - Vertices[index3].Position;
                Point side2 = Vertices[index1].Position - Vertices[index2].Position;
                Point normal = MathOperations.PointCross(side1, side2);

                Vertices[index1].Normal += normal;
                Vertices[index2].Normal += normal;
                Vertices[index3].Normal += normal;
            }

            for (int i = 0; i < Vertices.Length; i++)
                Vertices[i].Normal = MathOperations.PointNormalize(Vertices[i].Normal);
        }
    }
}




