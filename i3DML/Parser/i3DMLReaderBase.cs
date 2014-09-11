/**
 * The i3DML Project
 * Author:  Keyvan M. Kambakhsh
 * 
 * UNDER GPL V3 LICENSE
 **/

using System.IO;
using i3DML.ObjectModel.Components;

namespace i3DML.Parser
{
    /// <summary>
    /// Abstract i3DML reader class.
    /// </summary>
    /// <typeparam name="T">Reader's root type</typeparam>
    public abstract class i3DMLReaderBase<T> where T : class
    {
        #region Namespace Strings
        public string i3DMLNamespace
        {
            get { return "http://www.i3dml.org/i3DML2014"; }
        }
        public string i3DMLInstanceNamespace
        {
            get { return "http://www.i3dml.org/i3DML2014Instance"; }
        }
        #endregion
        #region Types Management
        protected readonly Ii3DMLTypeProvider TypeProvider;
        protected readonly Ii3DMLConverter Converter;
        #endregion
        #region Parsing Section
        public abstract T Read(TextReader stream);
        #endregion
        public i3DMLReaderBase(Ii3DMLTypeProvider typeProvider)
        {
            TypeProvider = typeProvider;
            Converter = new i3DMLConverter();
        }
    }
}




