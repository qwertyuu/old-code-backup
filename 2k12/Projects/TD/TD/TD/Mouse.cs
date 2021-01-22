using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TD
{
    class MouseHandler
    {
        public ClickState LeftClickState { get; set; }
        public ClickState RightClickState { get; set; }
        MouseState oldMouseState;
        public Point position { get; set; }
        public void Update()
        {
            MouseState currentMouseState = Mouse.GetState();
            position = new Point(currentMouseState.X, currentMouseState.Y);
            if (currentMouseState.LeftButton == ButtonState.Pressed)
            {
                if (oldMouseState.LeftButton == ButtonState.Released)
                {
                    LeftClickState = ClickState.Clicked;
                }
                else
                {
                    LeftClickState = ClickState.Held;
                }
            }
            else
            {
                if (oldMouseState.LeftButton == ButtonState.Released)
                {
                    LeftClickState = ClickState.Released;
                }
                else
                {
                    LeftClickState = ClickState.Releasing;
                }
            }
            oldMouseState = currentMouseState;
        }
    }
}
