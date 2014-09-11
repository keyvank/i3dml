/**
 * The i3DML Project
 * Author:  Keyvan M. Kambakhsh
 * 
 * UNDER GPL V3 LICENSE
 **/

using System.Collections.Generic;

namespace i3DML.ObjectModel.Components
{
    /// <summary>
    /// Interface for represeting i3DML arrays and collections.
    /// </summary>
    /// <typeparam name="T">Collection items type.</typeparam>
    [i3DMLReaderIgnore]
    public interface Ii3DMLCollection<T>
    {
        T this[int index] { get; set; }

        /// <summary>
        /// the collection's items count.
        /// </summary>
        int Length { get; }

        /// <summary>
        /// Add an object to the collection.
        /// </summary>
        /// <param name="obj">The object</param>
        void Add(T obj);

        /// <summary>
        /// Remove an object from the collection.
        /// </summary>
        /// <param name="obj">The object</param>
        void Remove(T obj);

        /// <summary>
        /// Remove all objects in the collection.
        /// </summary>
        void Clear();
    }

    /// <summary>
    /// Simple i3DML collection.
    /// </summary>
    /// <typeparam name="T">Collection items type.</typeparam>
    [i3DMLReaderIgnore]
    public class i3DMLCollection<T> : Ii3DMLCollection<T>
    {
        private List<T> Items;

        public i3DMLCollection()
        {
            Items = new List<T>();
        }

        public int Length
        {
            get
            {
                return Items.Count;
            }
        }

        public void Add(T obj)
        {
            Items.Add(obj);
        }

        public void Remove(T obj)
        {
            Items.Remove(obj);
        }

        public void Clear()
        {
            Items.Clear();
        }

        public T this[int index]
        {
            get
            {
                return Items[index];
            }
            set
            {
                Items[index] = value;
            }
        }
    }
}


