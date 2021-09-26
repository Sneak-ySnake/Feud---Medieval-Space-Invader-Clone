using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace FJunkie.MouseEntity
{
    class MouseEnt
    {

        static MouseState currentMouseState;
        static MouseState previousMouseState;

        public static bool LeftButtonPressed()
        {
            if (currentMouseState.LeftButton == ButtonState.Pressed
                && previousMouseState.LeftButton == ButtonState.Released)
                return true;
            else return false;
        }

        public static bool LeftButtonReleased()
        {
            if (currentMouseState.LeftButton == ButtonState.Released
                && previousMouseState.LeftButton == ButtonState.Pressed)
                return true;
            else return false;
        }

        public static bool LeftButtonDrop()
        {
            if ((currentMouseState.LeftButton == ButtonState.Released)
                && (previousMouseState.LeftButton == ButtonState.Pressed))
                return true;
            else return false;
        }

    }
}
