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
        //si le leftclickstate est get pendant que c'est cliqué, changer en held
        private ClickState _left;
        public ClickState LeftClickState
        {
            get
            {
                var toReturn = _left;
                if (_left == ClickState.Clicked)
                {
                    _left = ClickState.Held;
                }
                return toReturn;
            }
            set
            {
                _left = value;
            }
        }
        public ClickState RightClickState
        {
            get
            {
                var toReturn = _right;
                if (_right == ClickState.Clicked)
                {
                    _right = ClickState.Held;
                }
                return toReturn;
            }
            set
            {
                _right = value;
            }
        }
        MouseState oldMouseState;
        public Point fakePos;
        private ClickState _right;
        public Point position { get; set; }
        public void Update(Camera cam, IMenu menu)
        {
            MouseState currentMouseState = Mouse.GetState();
            if (menu == null)
            {
                if (currentMouseState.X >= GraphicsDeviceManager.DefaultBackBufferWidth)
                {
                    Mouse.SetPosition(GraphicsDeviceManager.DefaultBackBufferWidth, currentMouseState.Y);
                }
                else if (currentMouseState.X <= 0)
                {
                    Mouse.SetPosition(0, currentMouseState.Y);
                }
                else if (currentMouseState.Y >= GraphicsDeviceManager.DefaultBackBufferHeight)
                {
                    Mouse.SetPosition(currentMouseState.X, GraphicsDeviceManager.DefaultBackBufferHeight);
                }
                else if (currentMouseState.Y <= 0)
                {
                    Mouse.SetPosition(currentMouseState.X, 0);
                }
                fakePos = new Point((int)cam.position.X + currentMouseState.X, (int)cam.position.Y + currentMouseState.Y);
            }
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
            if (currentMouseState.RightButton == ButtonState.Pressed)
            {
                if (oldMouseState.RightButton == ButtonState.Released)
                {
                    RightClickState = ClickState.Clicked;
                }
                else
                {
                    RightClickState = ClickState.Held;
                }
            }
            else
            {
                if (oldMouseState.RightButton == ButtonState.Released)
                {
                    RightClickState = ClickState.Released;
                }
                else
                {
                    RightClickState = ClickState.Releasing;
                }
            }
            oldMouseState = currentMouseState;
        }
    }
}
