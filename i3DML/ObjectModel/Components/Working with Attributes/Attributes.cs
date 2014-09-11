/**
 * The i3DML Project
 * Author:  Keyvan M. Kambakhsh
 * 
 * UNDER GPL V3 LICENSE
 **/

using System;

namespace i3DML.ObjectModel.Components
{
    public abstract class i3DMLAttribute : Attribute { }
    [i3DMLReaderIgnore]
    public class i3DMLAttributesTypes
    {
        public static readonly Type i3DMLReaderIgnore = typeof(i3DMLReaderIgnoreAttribute);
    }
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Interface|AttributeTargets.Event)]
    [i3DMLReaderIgnore]
    public class i3DMLReaderIgnoreAttribute : i3DMLAttribute { }
}




