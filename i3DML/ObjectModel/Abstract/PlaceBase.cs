/**
 * The i3DML Project
 * Author:  Keyvan M. Kambakhsh
 * 
 * UNDER GPL V3 LICENSE
 **/

using i3DML.ObjectModel.Components;

namespace i3DML.ObjectModel
{
    /// <summary>
    /// Abstract base class for container elements.
    /// </summary>
    [i3DMLReaderIgnore]
    public abstract class PlaceBase : Drawable, Ii3DMLCollection<Drawable>
    {
        /// <summary>
        /// Drawables collection field.
        /// </summary>
        i3DMLCollection<Drawable> Drawables;

        /// <summary>
        /// Add the drawable to collection. (Also set its parent to current object)
        /// </summary>
        /// <param name="obj">The drawable</param>
        public void Add(Drawable obj)
        {
            obj.Parent = this;
            obj.World = this.World;
            Drawables.Add(obj);
        }

        /// <summary>
        /// Remove the drawable from collection. (Also set its parent to null)
        /// </summary>
        /// <param name="obj">The drawable</param>
        public void Remove(Drawable obj)
        {
            obj.Parent = null;
            Drawables.Remove(obj);
        }

        /// <summary>
        /// Remove all drawables.
        /// </summary>
        public void Clear()
        {
            for (int i = 0; i < Length; i++)
                Drawables[i].Parent = null;
            Drawables.Clear();
        }

        /// <summary>
        /// Integer indexer.
        /// </summary>
        /// <param name="index">Integer index</param>
        /// <returns>Corresponding drawable</returns>
        public Drawable this[int index]
        {
            get
            {
                return Drawables[index];
            }
            set
            {
                Drawables[index] = value;
            }
        }

        /// <summary>
        /// Number of elements in the drawable collection.
        /// </summary>
        public int Length
        {
            get
            {
                return Drawables.Length;
            }
        }

        /// <summary>
        /// Update all elements in the collection.
        /// </summary>
        public override void Update()
        {
            for (int i = 0; i < Length; i++)
                this[i].Update();
            base.Update();
        }

        /// <summary>
        /// Initialize all elements in the collection.
        /// </summary>
        public override void Initialize()
        {
            for (int i = 0; i < Length; i++)
                this[i].Initialize();
            base.Initialize();
        }

        /// <summary>
        /// Finalize all elements in this collection.
        /// </summary>
        public override void Dispose()
        {
            for (int i = 0; i < Length; i++)
                this[i].Dispose();
            base.Dispose();
        }

        public PlaceBase()
        {
            Drawables = new i3DMLCollection<Drawable>();
        }
    }
}



