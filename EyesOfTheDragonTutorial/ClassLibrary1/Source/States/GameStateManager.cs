using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XRpgLibrary.Source.States
{

    public class GameStateManager : GameComponent
    {

        #region Event

        public event EventHandler OnStateChange;

        #endregion

        #region Fields and Properties

        Stack<GameState> gameStates = new Stack<GameState>();

        const int startDrawOrder = 5000;
        const int drawOrderInc = 100;
        int drawOrder;

        public GameState CurrentState
        {
            get { return gameStates.Peek(); }
        }

        #endregion

        #region Constructor

        public GameStateManager(Game game)
            : base(game)
        {
            drawOrder = startDrawOrder;
        }

        #endregion

        #region XNA methods

        public override void Initialize()
        {
            base.Initialize();
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }

        #endregion

        #region Methods

        public void PopState()
        {
            if (gameStates.Count > 0)
            {
                RemoveState();
                drawOrder -= drawOrderInc;

                if (OnStateChange != null)
                {
                    OnStateChange(this, null);
                }
            }
        }

        private void RemoveState()
        {
            GameState state = gameStates.Peek();

            OnStateChange -= state.StateChange;
            Game.Components.Remove(state);
            gameStates.Pop();
        }

        public void PushState(GameState newState)
        {
            drawOrder += drawOrderInc;
            newState.DrawOrder = drawOrder;

            AddState(newState);

            if (OnStateChange != null)
            {
                OnStateChange(this, null);
            }
        }

        private void AddState(GameState newState)
        {
            gameStates.Push(newState);

            Game.Components.Add(newState);

            OnStateChange += newState.StateChange;
        }

        public void ChangeState(GameState newState)
        {
            while (gameStates.Count > 0)
            {
                RemoveState();
            }

            newState.DrawOrder = startDrawOrder;
            drawOrder = startDrawOrder;

            AddState(newState);

            if (OnStateChange != null)
            {
                OnStateChange(this, null);
            }
        }

        #endregion

    }
}
