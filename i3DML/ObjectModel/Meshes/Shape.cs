/**
 * The i3DML Project
 * Author:  Keyvan M. Kambakhsh
 * 
 * UNDER GPL V3 LICENSE
 **/

namespace i3DML.ObjectModel
{
    /// <summary>
    /// Abstract base class for i3DML Shapes.
    /// </summary>
    public abstract class Shape:PrimitiveMesh
    {
        #region Fields
        private Size _Size;
        #endregion
        #region Properties
        /// <summary>
        /// Shape's size.
        /// </summary>
        public Size Size { get { return _Size; } set { if (value != null) _Size = value; } }
        #endregion
        public Shape()
        {
            Size = new Size();
        }
    }
}




