/**
 * The i3DML Project
 * Author:  Keyvan M. Kambakhsh
 * 
 * UNDER GPL V3 LICENSE
 **/

using System;
using i3DML.ObjectModel.Components;

namespace i3DML.ObjectModel
{
    /// <summary>
    /// Provides a drawable or a container element.
    /// </summary>
    public abstract class Drawable : WorldElement,Ii3DMLInitializable,IDisposable
    {
        #region Fields
        private ScriptManager _ScriptManager;
        private Point _Position;
        private Rotation _Rotation;
        private Ratio _RotationOrigin;
        private Ratio _Scale;
        #endregion
        #region Properties
        #region Parents

        /// <summary>
        /// Root element.
        /// </summary>
        [i3DMLReaderIgnore]
        public World World { get; internal set; }

        /// <summary>
        /// Parent element.
        /// </summary>
        [i3DMLReaderIgnore]
        public PlaceBase Parent { get; internal set; }

        #endregion
        #region Visiblity

        /// <summary>
        /// Is the element visible on the screen?
        /// </summary>
        public bool Visible { get; set; }

        #endregion
        #region Position

        /// <summary>
        /// Position of element in the element's local space.
        /// </summary>
        public Point Position { get { return _Position; } set { if (value != null) _Position = value; } }

        /// <summary>
        /// Absolute position of element in the root element.
        /// </summary>
        [i3DMLReaderIgnore]
        public Point AbsolutePosition
        {
            get
            {
                Point absRot = new Point();
                absRot.X = OriginPosition.X;
                absRot.Y = OriginPosition.Y;
                absRot.Z = OriginPosition.Z;
                Drawable parent = this.Parent;
                Drawable lastParent = null;
                while (parent.Parent != null)
                {
                    absRot += parent.OriginPosition;
                    absRot = Matrix.Transform(absRot, Matrix.Rotate(parent.Rotation));
                    lastParent = parent;
                    parent = parent.Parent;
                }
                if (lastParent != null)
                {
                    Point lp = Matrix.Transform(lastParent.OriginPosition, Matrix.Rotate(lastParent.Rotation));
                    return (absRot - lp + lastParent.OriginPosition);
                }
                else
                    return absRot;
            }
        }

        /// <summary>
        /// The element's center position in the element's local space (Before scaling).
        /// </summary>
        [i3DMLReaderIgnore]
        public Point CenterPosition
        {
            get
            {
                Point ret;
                if (this is Shape)
                    ret = (this as Shape).Size * RotationOrigin;
                else if (this is Surface)
                {
                    Size2D s = (this as Surface).Size * RotationOrigin;
                    ret = new Point(s.X, 0, s.Y);
                }
                else ret = new Point(0, 0, 0);
                ret = Matrix.Transform(ret, Matrix.Rotate(Rotation));
                return ret;
            }
        }

        /// <summary>
        /// The element's center position in the element's local space (After scaling).
        /// </summary>
        [i3DMLReaderIgnore]
        public Point OriginPosition
        {
            get { return (Position * AbsoluteScale / Scale) - CenterPosition * AbsoluteScale; }
        }
        #endregion
        #region Rotation

        /// <summary>
        /// The element's rotation in the element's local space.
        /// </summary>
        public Rotation Rotation { get { return _Rotation; } set { if (value != null)_Rotation = value; } }

        /// <summary>
        /// The element's absolute rotation matrix in the root element.
        /// </summary>
        [i3DMLReaderIgnore]
        public Matrix AbsoluteRotationMatrix
        {
            get
            {
                Matrix ret = Matrix.Rotate(Rotation);
                Drawable parent=Parent;
                while (parent != null)
                {
                    ret *= Matrix.Rotate(parent.Rotation);
                    parent = parent.Parent;
                }
                return ret;
            }
        }

        /// <summary>
        /// The element's rotation origin point ratio.
        /// </summary>
        public Ratio RotationOrigin { get { return _RotationOrigin; } set { if (value != null)_RotationOrigin = value; } }
        #endregion
        #region Scale
        /// <summary>
        /// The element's scale in the element's local space.
        /// </summary>
        public Ratio Scale { get { return _Scale; } set { if (value != null) _Scale = value; } }

        /// <summary>
        /// The element's absolute scale in the root element.
        /// </summary>
        [i3DMLReaderIgnore]
        public Ratio AbsoluteScale
        {
            get
            {
                Ratio absScale = new Ratio() { X = Scale.X, Y = Scale.Y, Z = Scale.Z };
                Drawable parent = Parent;
                while (parent != null)
                {
                    absScale *= parent.Scale;
                    parent = parent.Parent;
                }
                return absScale;
            }
        }
        #endregion
        #region Scripts
        
        /// <summary>
        /// Corresponding ScriptManager for this drawable.
        /// </summary>
        [i3DMLReaderIgnore]
        protected ScriptManager ScriptManager { get { return _ScriptManager; } private set { _ScriptManager = value; } }

        /// <summary>
        /// Contains drawable scripts.
        /// </summary>
        public string Script { get; set; }

        #region Events

        public string OnUpdate { get; set; }

        #endregion

        #endregion
        #endregion
        public Drawable()
        {
            this.ScriptManager = new ScriptManager(this);
            this.RotationOrigin = new Ratio() { X = 0.5d, Y = 0.5d, Z = 0.5d };
            this.Position = new Point() { X = 0d, Y = 0d, Z = 0d };
            this.Rotation = new Rotation { X = 0d, Y = 0d, Z = 0d };
            this.Scale = new Ratio() { X = 1, Y = 1, Z = 1 };
            this.Visible = true;
        }

        /// <summary>
        /// Find an element with a specified name by looking to the descendants of this element.
        /// </summary>
        /// <param name="Name">Name of the element we are looking for</param>
        /// <returns>The found element</returns>
        public Drawable FindElement(string Name)
        {
            if (this.Name == Name)
                return this;
            var plcs=new System.Collections.Generic.Stack<PlaceBase>();
            if (this is PlaceBase)
                plcs.Push(this as PlaceBase);
            while (plcs.Count != 0)
            {
                PlaceBase pop=plcs.Pop();
                if (pop.Name == Name)
                    return pop;
                for (int i = 0; i < pop.Length; i++)
                {
                    if (pop[i] is PlaceBase)
                        plcs.Push(pop[i] as PlaceBase);
                    else if (pop[i].Name == Name)
                        return pop[i];
                }
            }
            return null;
        }
        public virtual void Update() { ScriptManager.Run(OnUpdate); }

        public virtual void Initialize()
        {
            ScriptManager.Run(Script); // Run the scripts when initialize.
        }

        public virtual void Dispose()
        {
        }
    }
}


