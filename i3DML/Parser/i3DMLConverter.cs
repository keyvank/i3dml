/**
 * The i3DML Project
 * Author:  Keyvan M. Kambakhsh
 * 
 * UNDER GPL V3 LICENSE
 **/

using System;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;
using i3DML.ObjectModel;
using i3DML.ObjectModel.Components;

namespace i3DML.Parser
{
    /// <summary>
    /// A struct which represents a pair of types.
    /// </summary>
    struct TypePair
    {
        public Type A;
        public Type B;
        public TypePair(Type a, Type b) { A = a; B = b; }
    }
    /// <summary>
    /// i3DML converter interface.
    /// </summary>
    public interface Ii3DMLConverter
    {
        object Convert(object obj, Type to);
        bool CanConvert(object obj, Type to);
    }
    public delegate object Converter(object from);
    /// <summary>
    /// i3DML's base type converter.
    /// </summary>
    public class i3DMLConverter : Ii3DMLConverter
    {
        Dictionary<TypePair, Converter> Converters;
        public i3DMLConverter()
        {
            Converters = new Dictionary<TypePair, Converter>();
            InitializeConverters();
        }
        /// <summary>
        /// Initializes the default converters.
        /// </summary>
        protected void InitializeConverters()
        {
            AddConverter(typeof(string), typeof(int), s => int.Parse(s as string));
            AddConverter(typeof(int), typeof(string), i => i.ToString());
            AddConverter(typeof(string), typeof(double), s => double.Parse(s as string));
            AddConverter(typeof(double), typeof(string), i => i.ToString());
            AddConverter(typeof(string), typeof(bool), s => s.ToString().ToLower() == bool.TrueString.ToLower());
            AddConverter(typeof(bool), typeof(string), b => b.ToString().ToLower());
            #region Color Converter
            AddConverter(typeof(string), typeof(Color), obj =>
            {
                try
                {
                    string s = obj as string;
                    if (s.Count(c => c == ',') == 2)
                    {
                        string[] split = s.Split(',');
                        return new Color() { R = int.Parse(split[0]), G = int.Parse(split[1]), B = int.Parse(split[2]) };
                    }
                    else if (!s.Contains(','))
                    {
                        int val ;
                        if (int.TryParse(s, out val))
                        {
                            return new Color() { R = val, G = val, B = val };
                        }
                        else
                            return Color.FromName(s);
                    }
                    else
                        throw new i3DMLException("Color not correctly formated.");
                }
                catch
                {
                    throw new i3DMLException("Color not correctly formated.");
                }
            });
            #endregion
            #region Point Converter
            AddConverter(typeof(string), typeof(Point), obj =>
            {
                try
                {
                    string s = obj as string;
                    if (s.Count(c => c == ',') == 2)
                    {
                        string[] split = s.Split(',');
                        return new Point() { X = double.Parse(split[0]), Y = double.Parse(split[1]), Z = double.Parse(split[2]) };
                    }
                    else if (!s.Contains(','))
                    {
                        double val = double.Parse(s);
                        return new Point() { X = val, Y = val, Z = val };
                    }
                    else
                        throw new i3DMLException("Point not correctly formated.");
                }
                catch
                {
                    throw new i3DMLException("Point not correctly formated.");
                }
            });
            #endregion
            #region Point2D Converter
            AddConverter(typeof(string), typeof(Point2D), obj =>
            {
                try
                {
                    string s = obj as string;
                    if (s.Count(c => c == ',') == 1)
                    {
                        string[] split = s.Split(',');
                        return new Point2D() { X = double.Parse(split[0]), Y = double.Parse(split[1]) };
                    }
                    else if (!s.Contains(','))
                    {
                        double val = double.Parse(s);
                        return new Point2D() { X = val, Y = val };
                    }
                    else
                        throw new i3DMLException("2D Point not correctly formated.");
                }
                catch
                {
                    throw new i3DMLException("2D Point not correctly formated.");
                }
            });
            #endregion
            #region Rotation Converter
            AddConverter(typeof(string), typeof(Rotation), obj =>
            {
                try
                {
                    string s = obj as string;
                    if (s.Count(c => c == ',') == 2)
                    {
                        string[] split = s.Split(',');
                        return new Rotation() { X = double.Parse(split[0]), Y = double.Parse(split[1]), Z = double.Parse(split[2]) };
                    }
                    else if (!s.Contains(','))
                    {
                        double val = double.Parse(s);
                        return new Rotation() { X = val, Y = val, Z = val };
                    }
                    else
                        throw new i3DMLException("Eulerian Rotation not correctly formated.");
                }
                catch
                {
                    throw new i3DMLException("Eulerian Rotation not correctly formated.");
                }
            });
            #endregion
            #region Ratio Converter
            AddConverter(typeof(string), typeof(Ratio), obj =>
            {
                try
                {
                    string s = obj as string;
                    if (s.Count(c => c == ',') == 2)
                    {
                        string[] split = s.Split(',');
                        return new Ratio() { X = double.Parse(split[0]), Y = double.Parse(split[1]), Z = double.Parse(split[2]) };
                    }
                    else if (!s.Contains(','))
                    {
                        double val = double.Parse(s);
                        return new Ratio() { X = val, Y = val, Z = val };
                    }
                    else
                        throw new i3DMLException("Ratio not correctly formated.");
                }
                catch
                {
                    throw new i3DMLException("Ratio not correctly formated.");
                }
            });
            #endregion
            #region Ratio2D Converter
            AddConverter(typeof(string), typeof(Ratio2D), obj =>
            {
                try
                {
                    string s = obj as string;
                    if (s.Count(c => c == ',') == 1)
                    {
                        string[] split = s.Split(',');
                        return new Ratio2D() { X = double.Parse(split[0]), Y = double.Parse(split[1]) };
                    }
                    else if (!s.Contains(','))
                    {
                        double val = double.Parse(s);
                        return new Ratio2D() { X = val, Y = val };
                    }
                    else
                        throw new i3DMLException("2D Ratio not correctly formated.");
                }
                catch
                {
                    throw new i3DMLException("2D Ratio not correctly formated.");
                }
            });
            #endregion
            #region Size Converter
            AddConverter(typeof(string), typeof(Size), obj =>
            {
                try
                {
                    string s = obj as string;
                    if (s.Count(c => c == ',') == 2)
                    {
                        string[] split = s.Split(',');
                        return new Size() { X = double.Parse(split[0]), Y = double.Parse(split[1]), Z = double.Parse(split[2]) };
                    }
                    else if (s.Count(c => c == ',') == 3)
                    {
                        string[] split = s.Split(',');
                        return new Size() { X = double.Parse(split[0]), Y = double.Parse(split[1]), Z = double.Parse(split[2]),W=double.Parse(split[3]) };
                    }
                    else if (!s.Contains(','))
                    {
                        double val = double.Parse(s);
                        return new Size() { X = val, Y = val, Z = val };
                    }
                    else
                        throw new i3DMLException("Size not correctly formated.");
                }
                catch
                {
                    throw new i3DMLException("Size not correctly formated.");
                }
            });
            #endregion
            #region Size2D Converter
            AddConverter(typeof(string), typeof(Size2D), obj =>
            {
                try
                {
                    string s = obj as string;
                    if (s.Count(c => c == ',') == 2)
                    {
                        string[] split = s.Split(',');
                        return new Size2D() { X = double.Parse(split[0]), Y = double.Parse(split[1]),W=double.Parse(split[2])};
                    }
                    else if (!s.Contains(','))
                    {
                        double val = double.Parse(s);
                        return new Size2D() { X = val, Y = val,W=val};
                    }
                    else
                        throw new i3DMLException("Size 2D not correctly formated.");
                }
                catch
                {
                    throw new i3DMLException("Size 2D not correctly formated.");
                }
            });
            #endregion
            #region Integer Collection Converter
            AddConverter(typeof(string), typeof(i3DMLCollection<int>), obj =>
            {
                string str = obj as string;
                i3DMLCollection<int> ret = new i3DMLCollection<int>();
                string[] ints = str.Split(',');
                foreach(string s in ints)
                {
                    int i;
                    if (int.TryParse(s, out i))
                        ret.Add(i);
                    else
                        throw new i3DMLException("Integer collection not correctly formated.");
                }
                return ret;
            });
            #endregion
        }

        /// <summary>
        /// Add a new converter.
        /// </summary>
        /// <param name="from">Type A</param>
        /// <param name="to">Type B</param>
        /// <param name="converter">The Converter</param>
        public void AddConverter(Type from, Type to, Converter converter)
        {
            Converters.Add(new TypePair(from, to), converter);
        }

        /// <summary>
        /// Is it possible to convert object A to type B?
        /// </summary>
        /// <param name="A">Source object</param>
        /// <param name="B">Target type</param>
        /// <returns>Conversion possibility</returns>
        public bool CanConvert(object obj, Type to)
        {
            return to.IsAssignableFrom(obj.GetType()) ||
                (obj is string && to.IsEnum && Enum.GetNames(to).Contains(obj as string)) ||
                Converters.ContainsKey(new TypePair(obj.GetType(), to));
        }

        /// <summary>
        /// Converts the obj to target type.
        /// </summary>
        /// <param name="obj">The object</param>
        /// <param name="to">Target type</param>
        /// <returns>Converted object</returns>
        public object Convert(object obj, Type to)
        {
            try
            {
                if (to.IsAssignableFrom(obj.GetType())) // If the object can be assigned to the target type, return the object without making changes.
                    return obj;
                if (obj is string && to.IsEnum)
                {
                    // If the object is a string and the target type is an enum, parse the string with Enum.Parse() method.
                    return Enum.Parse(to, obj as string);
                }
                // Check if there is a converter for converting the object to the target type.
                TypePair pair = new TypePair(obj.GetType(), to);
                if (Converters.ContainsKey(pair))
                    return Converters[pair](obj);
                else
                    throw new i3DMLException("Converter not found.");
            }
            catch (TargetInvocationException inv)
            {
                throw inv.InnerException;
            }
        }
    }
}
