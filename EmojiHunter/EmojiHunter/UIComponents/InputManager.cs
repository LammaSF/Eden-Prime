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
            this.prevKeyState = this.currentKeyState;
            this.currentKeyState = Keyboard.GetState();
        }
       
        // check for one time key pressed
        public bool IsKeyPressed(params Keys[] keys)
        {
            foreach (var key in keys)
            {
                if (this.currentKeyState.IsKeyDown(key) && this.prevKeyState.IsKeyUp(key))
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
                if (this.currentKeyState.IsKeyUp(key) && this.prevKeyState.IsKeyDown(key))
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
                if (this.currentKeyState.IsKeyDown(key))
                {
                    return true;
                }
            }

            return false;
        }
    }
}
