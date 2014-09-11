/**
 * The i3DML Project
 * Author:  Keyvan M. Kambakhsh
 * 
 * UNDER GPL V3 LICENSE
 **/

using System.IO;

namespace i3DML.ObjectModel
{
    /// <summary>
    /// Interface for working with URLs
    /// </summary>
    public interface Ii3DMLUrlManager
    {
        Stream GetStream(string url);
    }
}
