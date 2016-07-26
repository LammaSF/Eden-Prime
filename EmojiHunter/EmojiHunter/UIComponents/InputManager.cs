using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Xna.Framework.Input;

namespace EmojiHunter.UIComponents
{
    // check for keys pressed and released
    public class InputManager
    {
        private KeyboardState currentKeyState, prevKeyState;
        private static InputManager instance;

        public static InputManager Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new InputManager();
                }

                return instance;
            }
        }

        public void Update()
        {
            prevKeyState = currentKeyState;
            currentKeyState = Keyboard.GetState();
        }
       
        // check for one time key pressed
        public bool IsKeyPressed(params Keys[] keys)
        {
            foreach (var key in keys)
            {
                if (currentKeyState.IsKeyDown(key) && prevKeyState.IsKeyUp(key))
                {
                    return true;
                }
            }

            return false;
        }

        public bool IsKeyReleased(params Keys[] keys)
        {
            foreach (var key in keys)
            {
                if (currentKeyState.IsKeyUp(key) && prevKeyState.IsKeyDown(key))
                {
                    return true;
                }
            }

            return false;
        }
       
        // check for continues key pressind
        public bool KeyDown(params Keys[] keys)
        {
            foreach (var key in keys)
            {
                if (currentKeyState.IsKeyDown(key))
                {
                    return true;
                }
            }

            return false;
        }
    }
}
