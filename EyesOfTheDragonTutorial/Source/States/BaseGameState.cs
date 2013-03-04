using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using XRpgLibrary.Source.States;

namespace EyesOfTheDragonTutorial.Source.States
{
    public abstract partial class BaseGameState : GameState
    {
        #region Fields

        protected Game1 Game;

        #endregion

        #region Constructor

        public BaseGameState(Game1 game, GameStateManager stateManager)
            : base(game, stateManager)
        {
            this.Game = game;
        }

        #endregion
    }
}
