/**
 * The i3DML Project
 * Author:  Keyvan M. Kambakhsh
 * 
 * UNDER GPL V3 LICENSE
 **/

namespace i3DML.ObjectModel
{
    /// <summary>
    /// Abstract base class for i3DML surfaces.
    /// </summary>
    public abstract class Surface : PrimitiveMesh
    {
        #region Fields
        private Size2D _Size;
        #endregion
        #region Properties
        /// <summary>
        /// Surface's size.
        /// </summary>
        public Size2D Size { get { return _Size; } set { if (value != null) _Size = value; } }
        #endregion
        public Surface()
        {
            Size = new Size2D();
        }
    }
}




