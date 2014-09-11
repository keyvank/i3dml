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
    /// Provides a model.
    /// </summary>
    public class Model : IndexedMesh
    {
        #region Fields
        private string _ModelSource;
        #endregion
        #region Properties

        /// <summary>
        /// Model's source address.
        /// </summary>
        public string ModelSource { get { return _ModelSource; } set { _ModelSource = value; ModelResource.Url = _ModelSource; } }
        
        /// <summary>
        /// Model's source data.
        /// </summary>
        [i3DMLReaderIgnore]
        public Resource ModelResource { get; private set; }
        #endregion
        public Model()
        {
            ModelResource = new Resource();
            ModelResource.ResourceType = ResourceType.Model;
        }
    }
}




