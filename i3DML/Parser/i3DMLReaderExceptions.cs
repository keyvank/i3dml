/**
 * The i3DML Project
 * Author:  Keyvan M. Kambakhsh
 * 
 * UNDER GPL V3 LICENSE
 **/

using System;

namespace i3DML.Parser
{
    public class i3DMLException : Exception
    {
        public i3DMLException(string msg)
            : base(msg)
        {
        }
        public i3DMLException(string msg, Exception inner)
            : base(msg, inner)
        {
        }
    }
    public class i3DMLReaderException<T> : Exception where T : class
    {
        public int LineNumber { get; private set; }
        public i3DMLReader<T> Reader { get; private set; }
        public i3DMLReaderException(string message, i3DMLReader<T> reader, int ln) : base(message) { Reader = Reader; LineNumber = ln; }
        public i3DMLReaderException(string message, i3DMLReader<T> reader, int ln, Exception innerException) : base(message, innerException) { Reader = reader; LineNumber = ln; }
    }
    public class i3DMLReaderUnexpectedException<T> : i3DMLReaderException<T> where T : class
    {
        public i3DMLReaderUnexpectedException(string message, i3DMLReader<T> reader, int ln) : base(message, reader, ln) { }
        public i3DMLReaderUnexpectedException(string message, i3DMLReader<T> reader, int ln, Exception innerException) : base(message, reader, ln, innerException) { }
    }
}




