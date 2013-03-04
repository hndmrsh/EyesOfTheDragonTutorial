using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using XRpgLibrary.Source.States;

namespace EyesOfTheDragonTutorial.Source.States
{
    public class TitleScreen : BaseGameState
    {
        #region Fields

        Texture2D backgroundImage;

        #endregion

        #region Constructor

        public TitleScreen(Game1 game, GameStateManager stateManager)
            : base(game, stateManager)
        {
        }

        #endregion

        #region XNA methods

        protected override void LoadContent()
        {
            ContentManager content = Game.Content;

            backgroundImage = content.Load<Texture2D>(@"Backgrounds\titlescreen");
            
            base.LoadContent();
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            Game.SpriteBatch.Begin();
            
            base.Draw(gameTime);

            Game.SpriteBatch.Draw(backgroundImage, Game.ScreenBounds, Color.White);
            
            Game.SpriteBatch.End();
        }

        #endregion

    }
}
