/**
 * The i3DML Project
 * Author:  Keyvan M. Kambakhsh
 * 
 * UNDER GPL V3 LICENSE
 **/

using System;
using System.Linq;
using System.Reflection;
using i3DML.Parser;

namespace i3DML.ObjectModel.Components
{
    /// <summary>
    /// Type provider interface
    /// </summary>
    [i3DMLReaderIgnore]
    public interface Ii3DMLTypeProvider
    {
        /// <summary>
        /// Find the type in the object model from its name.
        /// </summary>
        /// <param name="name">Type's name</param>
        /// <returns>The type</returns>
        Type FindType(string name);

        /// <summary>
        /// Find a property of a type from its name.
        /// </summary>
        /// <param name="type">The type</param>
        /// <param name="name">Property's name</param>
        /// <returns>The property</returns>
        PropertyInfo FindProperty(Type type,string name);

        /// <summary>
        /// Create an instance of a type in the object model from its name.
        /// </summary>
        /// <param name="name">Type's name</param>
        /// <returns>The instaniated object</returns>
        object CreateInstance(string name);
    }

    /// <summary>
    /// Provides a set of types used in base object model.
    /// </summary>
    [i3DMLReaderIgnore]
    public class i3DMLTypeProvider : Ii3DMLTypeProvider
    {
        private readonly Type[] ExportedTypes;

        public bool CaseSensetive { get; private set; }
        public i3DMLTypeProvider()
        {
            this.ExportedTypes = GetType().Assembly.GetExportedTypes().Where(t=>t.Namespace.Contains("i3DML.ObjectModel")).ToArray();
            CaseSensetive = true;
        }
        public i3DMLTypeProvider(bool caseSensetive)
            : this()
        {
            CaseSensetive = caseSensetive;
        }
        public Type FindType(string name)
        {
            if (CaseSensetive)
                return ExportedTypes.FirstOrDefault(t => t.Name == name && !t.IsAbstract && !t.HasAttribute(typeof(i3DMLReaderIgnoreAttribute)));
            else
                return ExportedTypes.FirstOrDefault(t => t.Name.ToLower() == name.ToLower() && !t.IsAbstract && !t.HasAttribute(typeof(i3DMLReaderIgnoreAttribute)));
        }
        public PropertyInfo FindProperty(Type type, string name)
        {
            if (CaseSensetive)
                return type.GetProperties().FirstOrDefault(p => p.Name == name && p.CanWrite && !type.HasAttribute(typeof(i3DMLReaderIgnoreAttribute)));
            else
                return type.GetProperties().FirstOrDefault(p => p.Name.ToLower() == name.ToLower() && p.CanWrite && !type.HasAttribute(typeof(i3DMLReaderIgnoreAttribute)));
        }

        public object CreateInstance(string name)
        {
            Type t = FindType(name);
            if (t == null)
                return null;
            else
                return Activator.CreateInstance(FindType(name));
        }
    }
}




