/**
 * The i3DML Project
 * Author:  Keyvan M. Kambakhsh
 * 
 * UNDER GPL V3 LICENSE
 **/

using System;
using i3DML.ObjectModel.Components;

namespace i3DML.ObjectModel
{
    /// <summary>
    /// Resource data type.
    /// </summary>
    /// 
    public enum ResourceType { Texture, Model, HeightMap }

    /// <summary>
    /// Provides a resource.
    /// </summary>
    [i3DMLReaderIgnore]
    public class Resource
    {
        [i3DMLReaderIgnore]
        internal event EventHandler Downloaded;
        #region Fields
        private string _Url;
        #endregion
        #region Properties
        public ResourceType ResourceType { get; internal set; }
        public string Url { get { return _Url; } set { _Url = value; ResourceManager.Download(this); } }
        public object Data { get; internal set; }
        #endregion
        public Resource() { }
        internal void AlertDownloaded()
        {
            if(Downloaded!=null)
                Downloaded(this, new EventArgs());
        }
    }
}




