/**
 * The i3DML Project
 * Author:  Keyvan M. Kambakhsh
 * 
 * UNDER GPL V3 LICENSE
 **/

namespace i3DML.Parser
{
    struct i3DMLNestedAttribute
    {
        public string ElementName { get; private set; }
        public string AttributeName { get; private set; }

        /// <summary>
        /// Checks if the string is formatted like a nested attribute.
        /// </summary>
        /// <param name="s">Input string</param>
        /// <param name="element">Output attribute</param>
        /// <returns>Returns true if the input string represents a nested attribute</returns>
        public static bool Isi3DMLNestedAttribute(string s, out i3DMLNestedAttribute element)
        {
            string[] parse = s.Split('.');
            if (parse.Length == 2)
            {
                element = new i3DMLNestedAttribute() { ElementName = parse[0], AttributeName = parse[1] };
                return true;
            }
            else
            {
                element = default(i3DMLNestedAttribute);
                return false;
            }
        }
    }
}




