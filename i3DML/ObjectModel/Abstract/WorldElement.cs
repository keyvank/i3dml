/**
 * The i3DML Project
 * Author:  Keyvan M. Kambakhsh
 * 
 * UNDER GPL V3 LICENSE
 **/

namespace i3DML.ObjectModel
{
    /// <summary>
    /// Base class for all i3DML elements.
    /// </summary>
    public abstract class WorldElement
    {
        #region Properties
        /// <summary>
        /// Name of the element.
        /// </summary>
        public string Name { get; internal set; }
        #endregion

        public WorldElement()
        {
        }
    }
}



