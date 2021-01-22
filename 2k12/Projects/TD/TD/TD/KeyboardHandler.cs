using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TD
{
    class KeyboardHandler
    {
        public List<Keys> pressedKeysList, heldKeysList, releasedKeysList;
        KeyboardState oldKeyboardState;
        public void Update()
        {
            KeyboardState currentKeyboardState = Keyboard.GetState();
            Keys[] pressedKeys = currentKeyboardState.GetPressedKeys();
            Keys[] getOldPressedKeys = oldKeyboardState.GetPressedKeys();
            pressedKeysList.Clear();
            heldKeysList.Clear();
            releasedKeysList.Clear();
            foreach (var item in pressedKeys)
            {
                if (oldKeyboardState.IsKeyUp(item))
                {
                    pressedKeysList.Add(item);
                }
                else
                {
                    heldKeysList.Add(item);
                }
            }
            foreach (var item in getOldPressedKeys)
            {
                if (currentKeyboardState.IsKeyUp(item))
                {
                    releasedKeysList.Add(item);
                }
            }
            oldKeyboardState = currentKeyboardState;
        }
        public KeyboardHandler()
        {
            pressedKeysList = new List<Keys>();
            heldKeysList = new List<Keys>();
            releasedKeysList = new List<Keys>();
        }
    }
}
