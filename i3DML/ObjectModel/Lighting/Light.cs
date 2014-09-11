/**
 * The i3DML Project
 * Author:  Keyvan M. Kambakhsh
 * 
 * UNDER GPL V3 LICENSE
 **/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace i3DML.ObjectModel
{
    /// <summary>
    /// Abstract base class for a light source.
    /// </summary>
    public abstract class Light:Drawable
    {
        #region Fields
        private Color _Color;
        #endregion
        #region Properties
        public Color Color { get { return _Color; } set { if (value != null) _Color = value; } }
        public double Power { get; set; }
        #endregion
        public Light()
        {
            Color = new Color(255, 255, 255);
            Power = 1d;
        }
    }
}




