using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XRpgLibrary.Source
{
    public class InputHandler : GameComponent
    {
        #region Fields

        static KeyboardState keyboardState;
        static KeyboardState lastKeyboardState;

        #endregion

        #region Properties

        public static KeyboardState KeyboardState
        {
            get { return keyboardState; }
        }

        public static KeyboardState LastKeyboardState
        {
            get { return lastKeyboardState; }
        }

        #endregion

        #region Constructors

        public InputHandler(Game game) : base(game)
        {
            keyboardState = Keyboard.GetState();
        }

        #endregion

        #region XNA methods

        public override void Initialize()
        {
            base.Initialize();
        }

        public override void Update(GameTime gameTime)
        {
            lastKeyboardState = keyboardState;
            keyboardState = Keyboard.GetState();
            
            base.Update(gameTime);
        }

        #endregion

        #region Other methods

        public static void Flush(){
            lastKeyboardState = keyboardState;
        }

        #endregion

        #region Keyboard methods

        public static bool KeyReleased(Keys key)
        {
            return keyboardState.IsKeyUp(key) && lastKeyboardState.IsKeyDown(key);
        }

        public static bool KeyPressed(Keys key)
        {
            return keyboardState.IsKeyDown(key) && lastKeyboardState.IsKeyUp(key);
        }

        public static bool KeyDown(Keys key)
        {
            return keyboardState.IsKeyDown(key);
        }

        #endregion

    }
}
