/**
 * The i3DML Project
 * Author:  Keyvan M. Kambakhsh
 * 
 * UNDER GPL V3 LICENSE
 **/

using System.Collections.Generic;

namespace i3DML.ObjectModel.Components
{
    [i3DMLReaderIgnore]
    public interface Ii3DMLDictionary<TKey, TValue>
    {
        TValue this[TKey key] { get; set; }

        /// <summary>
        /// Items count.
        /// </summary>
        int Length { get; }
        
        /// <summary>
        /// Add an key value pair to the dictionary.
        /// </summary>
        /// <param name="key">The key</param>
        /// <param name="value">The value</param>
        void Add(TKey key, TValue value);

        /// <summary>
        /// Remove an key value pair from the dictionary.
        /// </summary>
        /// <param name="key">The key</param>
        void Remove(TKey key);
    }

    /// <summary>
    /// A simple i3DML dictionary.
    /// </summary>
    /// <typeparam name="TKey">Key type</typeparam>
    /// <typeparam name="TValue">Value type</typeparam>
    [i3DMLReaderIgnore]
    public class i3DMLDictionary<TKey, TValue> : Ii3DMLDictionary<TKey, TValue>
    {
        private Dictionary<TKey, TValue> Dict = new Dictionary<TKey, TValue>();

        public i3DMLDictionary()
        {
            Dict = new Dictionary<TKey, TValue>();
        }

        public int Length
        {
            get
            {
                return Dict.Count;
            }
        }

        public void Add(TKey key, TValue value)
        {
            Dict.Add(key, value);
        }
        public void Remove(TKey key)
        {
            Dict.Remove(key);
        }
        public TValue this[TKey key]
        {
            get
            {
                return Dict[key];
            }
            set
            {
                Dict[key] = value;
            }
        }
    }
}


