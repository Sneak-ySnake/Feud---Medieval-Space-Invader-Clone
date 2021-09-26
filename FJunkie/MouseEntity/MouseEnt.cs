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

        public static MouseState GetState()
        {
            previousMouseState = currentMouseState;
            currentMouseState = Microsoft.Xna.Framework.Input.Mouse.GetState();
            return currentMouseState;
        }

        public static bool IsPressed()
        {
            if (currentMouseState.LeftButton == ButtonState.Pressed)
                return true;
            else return false;
        }

     

    }
}
