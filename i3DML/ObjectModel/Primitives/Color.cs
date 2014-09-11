/**
 * The i3DML Project
 * Author:  Keyvan M. Kambakhsh
 * 
 * UNDER GPL V3 LICENSE
 **/

namespace i3DML.ObjectModel
{
    /// <summary>
    /// Provides a RGB based color.
    /// </summary>
    public class Color
    {
        public int R { get; set; }
        public int G { get; set; }
        public int B { get; set; }
        public static Color FromName(string name)
        {
            switch (name.ToLower())
            {
                case "black": return new Color(0, 0, 0);
                case "white": return new Color(255, 255, 255);
                case "red": return new Color(255, 0, 0);
                case "green": return new Color(0, 255, 0);
                case "blue": return new Color(0, 0, 255);
                case "magenta": return new Color(255, 0, 255);
                case "yellow": return new Color(255, 255, 0);
                case "cyan": return new Color(0, 255, 255);
                default: return null;
            }
        }
        public Color()
        {
            R = 0;
            G = 0;
            B = 0;
        }
        public Color(int r,int g,int b)
        {
            R = r;
            G = g;
            B = b;
        }
    }
}



