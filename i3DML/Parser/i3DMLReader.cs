/**
 * The i3DML Project
 * Author:  Keyvan M. Kambakhsh
 * 
 * UNDER GPL V3 LICENSE
 **/

using System;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Xml.XPath;
using i3DML.ObjectModel.Components;
using OM=i3DML.ObjectModel;

namespace i3DML.Parser
{
	/// <summary>
	/// Base i3DML reader class using XPath technique.
	/// </summary>
    public class i3DMLReader<T> : i3DMLReaderBase<T> where T : class
    {
        #region Default Readers
        public static i3DMLReader<T> DefaultReader
        {
            get { return new i3DMLReader<T>(new i3DMLTypeProvider()); }
        }
        #endregion
        #region Document Components
        XPathDocument Document;
        XPathNavigator DocumentNavigator;
        #endregion
        #region Document Information
        public Type RootType { get; private set; }
        #endregion
        #region Constructors
        public i3DMLReader(Ii3DMLTypeProvider typeProvider)
            : base(typeProvider)
        {
            RootType = typeof(T);
        }
        #endregion
        #region Managing Exceptions
        private void ThrowException(string format, Exception inner, params object[] objs)
        {
            string msg = string.Format(format, objs);
            Exception innertemp = inner;
            while (innertemp != null)
            {
                msg += " " + innertemp.Message;
                innertemp = innertemp.InnerException;
            }
            msg += string.Format(" (Line: {0})", DocumentNavigator.LineNumber());
            throw new i3DMLReaderException<T>(msg, this, DocumentNavigator.LineNumber(), inner);
        }
        private void ThrowUnexpectedException(string format,Exception inner, params object[] objs)
        {
            string msg = string.Format(format, objs);
            Exception innertemp = inner;
            while (innertemp.InnerException != null)
            {
                msg += " " + innertemp.Message;
                innertemp = innertemp.InnerException;
            }
            msg += string.Format(" (Line: {0})", DocumentNavigator.LineNumber());
            throw new i3DMLReaderUnexpectedException<T>(msg, this, DocumentNavigator.LineNumber(), inner);
        }
        #endregion
        #region Parsing Section

        /// <summary>
        /// Converts the object to the target type.
        /// </summary>
        /// <param name="obj">The object</param>
        /// <param name="to">Target type</param>
        /// <returns>Converted object</returns>
        private object Convert(object obj, Type to)
        {
            try
            {
                return Converter.Convert(obj, to);
            }
            catch (Exception ex)
            {
                ThrowException("Failed on converting \"{0}\" to \"{1}\".", ex, obj.GetType().Name, to.Name);
                return null;
            }
        }

        /// <summary>
        /// Tries to convert the object to the target type.
        /// </summary>
        /// <param name="obj">The object</param>
        /// <param name="to">Target type</param>
        /// <returns>Converted object</returns>
        private object TryConvert(object obj, Type to)
        {
            try
            {
                return Converter.Convert(obj, to);
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// Tries to invoke the Initiliaze() method. 
        /// </summary>
        /// <param name="o">The object</param>
        private void TryInitialize(object o)
        {
            if (o.GetType().GetInterfaces().Contains(typeof(Ii3DMLInitializable)))
            {
                MethodInfo init = o.GetType().GetMethod("Initialize");
                init.Invoke(o, null);
            }
        }

        /// <summary>
        /// Reads the TextReader based stream as an i3DML Document
        /// </summary>
        /// <param name="stream">The TextReader based stream</param>
        /// <returns>Deserialized i3DML Document></returns>
        public override T Read(TextReader stream)
        {
            Document = new XPathDocument(stream);
            DocumentNavigator = Document.CreateNavigator();
            DocumentNavigator.MoveToRoot();
            DocumentNavigator.MoveToFirstChild();
            if (DocumentNavigator.LocalName != RootType.Name)
            {
                ThrowException("Root node mismatch.",null);
            }
            T ret = RecursiveParser(null) as T;
            if (ret == null)
            {
                ThrowUnexpectedException("Unexpected exception occurred.",null, true);
                return null;
            }
            else
            {
                return ret;
            }
        }

        /// <summary>
        /// Adds the object to the collection.
        /// </summary>
        /// <param name="collection">The object</param>
        /// <param name="theobj">The collection</param>
        /// <returns>Returns true if the object successfully added to the collection</returns>
        private bool AddIfArray(object collection, object theobj)
        {
            if (collection == null)
                return false;
            // If the instance is a collection or dictionary
            Type resultType = collection.GetType();
            Type coltype;
            if (resultType.IsDictionary(out coltype))
            {
                object obj = TryConvert(theobj, coltype);
                if (obj == null)
                    return false;
                string key = DocumentNavigator.GetAttribute("Key", i3DMLInstanceNamespace);
                if (key == null)
                    ThrowException("Key not available for element \"{0}\".",null, resultType.Name);
                MethodInfo inf = resultType.GetMethod("Add");
                inf.Invoke(collection, new object[] { key, obj });
                return true;
            }
            else if (resultType.IsCollection(out coltype))
            {
                object obj = TryConvert(theobj, coltype);
                if (obj == null)
                    return false;
                MethodInfo inf = resultType.GetMethod("Add");
                inf.Invoke(collection, new object[] { obj });
                return true;
            }
            return false;
        }

        /// <summary>
        /// Recursive-based i3DML Reader function
        /// </summary>
        /// <returns>Navigator's current node as Object</returns>
        private object RecursiveParser(OM.PlaceBase parent)
        {
            // Check if the current node is text.
            if (DocumentNavigator.NodeType == XPathNodeType.Text)
                return DocumentNavigator.Value;

            // Check if the current node is comment.
            if (DocumentNavigator.NodeType == XPathNodeType.Comment)
                return null;

            // Check if the element has defined i3DML as its namespace.
            if (DocumentNavigator.NamespaceURI != i3DMLNamespace)
                ThrowException("Invalid namespace for element \"{0}\".",null, DocumentNavigator.LocalName);

            // Find the element's type and create an instance of it.
            Type resultType = TypeProvider.FindType(DocumentNavigator.LocalName);
            if (resultType == null)
                ThrowException("Element \"{0}\" not found.",null, DocumentNavigator.LocalName);
            object result = Activator.CreateInstance(resultType);

            // Set parents.
            if (parent == null && result is OM.World) { (result as OM.Drawable).World = (result as OM.World); }
            else if (result is OM.Drawable) { (result as OM.Drawable).Parent = parent; if (parent != null) { (result as OM.Drawable).World = parent.World; } }

            PropertyInfo[] properties = resultType.GetProperties();

            // Set instance properties with element's attributes.
            if (DocumentNavigator.HasAttributes)
            {
                DocumentNavigator.MoveToFirstAttribute();
                do
                {
                    PropertyInfo pinf = TypeProvider.FindProperty(resultType, DocumentNavigator.LocalName);
                    if (pinf != null)
                        pinf.SetValue(result, Convert(DocumentNavigator.Value, pinf.PropertyType),null);
                    else
                        ThrowException("Invalid attribute \"{0}\" for element \"{1}\".",null, DocumentNavigator.LocalName, resultType.Name);
                } while (DocumentNavigator.MoveToNextAttribute());
                DocumentNavigator.MoveToParent();
            }

            if (DocumentNavigator.HasChildren)
            {
                DocumentNavigator.MoveToFirstChild();
                do
                {
                    // Skip comments
                    if (DocumentNavigator.NodeType == XPathNodeType.Comment)
                        continue;

                    // Set instance properties with element's nested attributes.
                    i3DMLNestedAttribute eba;
                    if (i3DMLNestedAttribute.Isi3DMLNestedAttribute(DocumentNavigator.LocalName, out eba) && eba.ElementName == resultType.Name)
                    {
                        PropertyInfo pinf = TypeProvider.FindProperty(resultType, eba.AttributeName);
                        if (pinf != null)
                        {
                            if (DocumentNavigator.HasChildren)
                            {
                                DocumentNavigator.MoveToFirstChild();
                                do
                                {
                                    object rp = RecursiveParser(result as OM.PlaceBase);
                                    if (!AddIfArray(pinf.GetValue(result, null), rp))
                                    {
                                        if (DocumentNavigator.NodeType == XPathNodeType.Text)
                                            pinf.SetValue(result, Convert(DocumentNavigator.Value, pinf.PropertyType), null);
                                        else
                                            pinf.SetValue(result, Convert(RecursiveParser(null), pinf.PropertyType), null);
                                    }
                                } while (DocumentNavigator.MoveToNext());
                                DocumentNavigator.MoveToParent();
                            }
                        }
                        else
                        {
                            ThrowException("Invalid nested attribute \"{0}\" for element \"{1}\".",null, eba.AttributeName, resultType.Name);
                        }
                    }
                    else // Process the exceptions
                    {
                        object rp = RecursiveParser(result as OM.PlaceBase);
                        if (!AddIfArray(result, rp))
                        {
                            result= Convert(rp, resultType);
                            if (result == null)
                                ThrowException("Invalid child element for element \"{0}\".",null, DocumentNavigator.Name);
                        }
                    }
                } while (DocumentNavigator.MoveToNext());
                DocumentNavigator.MoveToParent();
            }
            if (result == null)
            {
                ThrowUnexpectedException("Cannot create element {0}.",null, resultType.Name);
            }
            return result;
        }

        #endregion
    }
}

