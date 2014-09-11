/**
 * The i3DML Project
 * Author:  Keyvan M. Kambakhsh
 * 
 * UNDER GPL V3 LICENSE
 **/

using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using OM=i3DML.ObjectModel;

namespace i3DML.Xna
{
    /// <summary>
    /// The default camera controller (Uses mouse and keyboard for controlling the camera)
    /// </summary>
    public class CameraManager : Microsoft.Xna.Framework.GameComponent
    {
        i3DMLEngine Browser;
        public CameraManager(i3DMLEngine browser,Game game)
            : base(game)
        {
            Browser = browser;
        }

        OM.Rotation MouseChange()
        {
            OM.Rotation ret = new OM.Rotation() { Y = Mouse.GetState().X - Game.Window.ClientBounds.Width / 2, X = Mouse.GetState().Y - Game.Window.ClientBounds.Height / 2, Z = 0 };
            ret /= 10d;
            Mouse.SetPosition(Game.Window.ClientBounds.Width / 2, Game.Window.ClientBounds.Height / 2);
            return ret;
        }

        public override void Update(GameTime gameTime)
        {
            if (Browser.CurrentWorld == null)
                return;
            KeyboardState keystate = Keyboard.GetState();
            if (keystate.IsKeyDown(Keys.W))
            {
                OM.Point forward = OM.Matrix.Transform(new OM.Point() { X = 0, Y = 0, Z = 1 }, OM.Matrix.Rotate(Browser.CurrentWorld.CameraRotation));
                Browser.CurrentWorld.CameraPosition += forward;
            }
            if (keystate.IsKeyDown(Keys.S))
            {
                OM.Point forward = OM.Matrix.Transform(new OM.Point() { X = 0, Y = 0, Z = 1 }, OM.Matrix.Rotate(Browser.CurrentWorld.CameraRotation));
                Browser.CurrentWorld.CameraPosition -= forward;
            }
            Browser.CurrentWorld.CameraRotation += MouseChange();
            if (Browser.CurrentWorld.CameraRotation.X > 89.99d)
                Browser.CurrentWorld.CameraRotation.X = 89.99d;
            if (Browser.CurrentWorld.CameraRotation.X < -89.99d)
                Browser.CurrentWorld.CameraRotation.X = -89.99d;
            base.Update(gameTime);
        }
    }
}



