/**
 * The i3DML Project
 * Author:  Keyvan M. Kambakhsh
 * 
 * UNDER GPL V3 LICENSE
 **/

using System;
using System.Reflection;
using System.Linq;

namespace i3DML.Parser
{
    static class Extensions
    {
        public static int LineNumber(this System.Xml.XPath.XPathNavigator nav)
        {
            return (nav as System.Xml.IXmlLineInfo).LineNumber;
        }
        public static bool HasAttribute(this PropertyInfo inf, Type attribute)
        {
            return inf.GetCustomAttributes(false).Count((c) => c.GetType() == attribute) >= 1;
        }
        public static bool HasAttribute(this Type type, Type attribute)
        {
            return type.GetCustomAttributes(false).Count((c) => c.GetType() == attribute) >= 1;
        }
        public static bool HasAttribute(this MethodInfo inf, Type attribute)
        {
            return inf.GetCustomAttributes(false).Count((c) => c.GetType() == attribute) >= 1;
        }
        public static bool IsCollection(this Type type, out Type coltype)
        {
            Type valid = type.GetInterfaces().FirstOrDefault((t) => t.Name.Contains("Ii3DMLCollection") && t.IsGenericType);
            if (valid != null)
                coltype = valid.GetGenericArguments()[0];
            else coltype = null;
            return coltype != null;
        }
        public static bool IsDictionary(this Type type, out Type coltype)
        {
            Type valid = type.GetInterfaces().FirstOrDefault((t) => t.Name.Contains("Ii3DMLDictionary") && t.IsGenericType);
            if (valid != null)
                coltype = valid.GetGenericArguments()[1];
            else coltype = null;
            return coltype != null;
        }
    }
}


