/**
 * The i3DML Project
 * Author:  Keyvan M. Kambakhsh
 * 
 * UNDER GPL V3 LICENSE
 **/

using System;
using System.Linq;
using i3DML.ObjectModel.Components;

namespace i3DML.ObjectModel
{
    public class RedirectedEventArgs : EventArgs
    {
        public string NewUrl { get; private set; }
        public RedirectedEventArgs(string newUrl) { NewUrl = newUrl; }
    }

    /// <summary>
    /// World (container) element.
    /// </summary>
    public class World : Place
    {
        public event EventHandler<RedirectedEventArgs> Redirected;

        #region Fields
        private Point _CameraPosition;
        private Rotation _CameraRotation;
        private Color _Background;
        #endregion
        #region Properties
        /// <summary>
        /// Camera position in the World.
        /// </summary>
        public Point CameraPosition { get { return _CameraPosition; } set { if (value != null) _CameraPosition = value; } }

        /// <summary>
        /// Camera rotation in the world.
        /// </summary>
        public Rotation CameraRotation { get { return _CameraRotation; } set { if (value != null) _CameraRotation = value; } }

        /// <summary>
        /// Screen's background color.
        /// </summary>
        public Color Background { get { return _Background; } set { if (value != null) _Background = value; } }

        /// <summary>
        /// is default camera enabled?
        /// </summary>
        public bool DefaultCamera { get; set; }

        /// <summary>
        /// Camera target position.
        /// </summary>
        [i3DMLReaderIgnore]
        public Point CameraTarget
        {
            get
            {
                return CameraPosition + Matrix.Transform(new Point() { X = 0, Y = 0, Z = 1 }, Matrix.Rotate(CameraRotation));
            }
        }

        #endregion

        /// <summary>
        /// Redirects the engine to a new World by its its url.
        /// </summary>
        /// <param name="newUrl">Url of the new World</param>
        public void Redirect(string newUrl)
        {
            if (Redirected != null)
                Redirected(this, new RedirectedEventArgs(newUrl));
        }

        public World()
        {
            CameraPosition = new Point() { X = 0, Y = 0, Z = 0 };
            CameraRotation = new Rotation() { X = 0, Y = 0, Z = 0 };
            Background = new Color() { R = 0, G = 0, B = 0 };
            DefaultCamera = true;
        }
    }
}




