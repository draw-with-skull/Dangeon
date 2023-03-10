using DangeonMaster.Engine.Enums;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dangeon.Engine.Managers
{
    internal class InputManager
    {
        private KeyboardState kb;
        private MouseState ms;
        private Vector2 direction;
        private GameActions state;
        public InputManager()
        {
            state = GameActions.NONE;
        }
        public void Update()
        {
            kb = Keyboard.GetState();
            ms = Mouse.GetState();
            state = GameActions.IDLE;
            //movement
            if (kb.IsKeyDown(Keys.W)) { state = GameActions.RUN; direction.Y = -1; }
            if (kb.IsKeyDown(Keys.A)) { state = GameActions.RUN; direction.X = -1; }
            if (kb.IsKeyDown(Keys.S)) { state = GameActions.RUN; direction.Y = 1; }
            if (kb.IsKeyDown(Keys.D)) { state = GameActions.RUN; direction.X = 1; }
            //attack
            if (ms.LeftButton == ButtonState.Pressed) { state = GameActions.ATTACK; direction = Vector2.Zero; }
            if (ms.RightButton == ButtonState.Pressed) { state = GameActions.HEAVY_ATTACK; direction = Vector2.Zero; }
            //
            if (kb.IsKeyDown(Keys.Enter)) { state = GameActions.ENTER; }

            if (state == GameActions.IDLE) { direction = Vector2.Zero; }
        }
        public Vector2 GetDirection()
        {
            return direction;
        }
        public GameActions GetState()
        {
            return state;
        }
    }
}
