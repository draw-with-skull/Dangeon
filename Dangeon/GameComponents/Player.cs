using Dangeon.Engine.Debug;
using Dangeon.Engine.Managers;
using DangeonMaster.Engine;
using DangeonMaster.Engine.Components;
using DangeonMaster.Engine.Managers;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using GameActions = DangeonMaster.Engine.Enums.GameActions;
namespace DangeonMaster.GameComponents
{
    internal class Player
    {
        private Texture2D spriteSheet;
        private Vector2 position;
        private readonly float speed=500;
        private AnimationManager animation;
        private InputManager input;
        private int direction=1;
        private Rectangle hitbox;
        private Rectangle legsHitbox;
        private Rectangle attakHitbox;
        private bool isContinuous;
        private GameActions currentAction;
        private readonly GameActions[] attackActions = { GameActions.ATTACK,GameActions.HEAVY_ATTACK };

        public Player(int x,int y)
        {
            position = new(x, y);
            Init();
        }
        #region Update
        public void Update(ref List<Rectangle> collisions)
        {
            input.Update();
            UpdatePosition(ref collisions);

            animation.Update(input.GetState(), input.GetDirection(), position);

            isContinuous = animation.IsContinuous();
            if (!isContinuous){currentAction = input.GetState();}

            if (direction != input.GetDirection().X && input.GetDirection().X != 0) direction = (int)input.GetDirection().X;
        }
        private void UpdatePosition(ref List<Rectangle> collisions)
        {
            if (animation.IsContinuous()) return;

            bool collision = false;
            Vector2 moveAmount = input.GetDirection() * speed * Globals.Time.ElapsedGameTime.Milliseconds / 1000;

            Rectangle temp = new(legsHitbox.X + (int)moveAmount.X, legsHitbox.Y + (int)moveAmount.Y, legsHitbox.Width, legsHitbox.Height);
            collisions.ForEach((rec) => { if (rec.Intersects(temp)) collision = true; });

            if (!collision)
            {
                legsHitbox.X += (int)moveAmount.X;
                legsHitbox.Y += (int)moveAmount.Y;
                position.X = legsHitbox.X - 17;
                position.Y = legsHitbox.Y - 43;
                hitbox.X = legsHitbox.X;
                hitbox.Y = legsHitbox.Y - 25;
                attakHitbox.X = hitbox.X + (15 * direction);
                attakHitbox.Y = hitbox.Y;
            }
        }
        #endregion


        public void Draw()
        {
            animation.Draw();
        }
        public Vector2 GetPosition()
        {
            return position;
        }

        
        private void Init()
        {
            //player hitbox
            hitbox.Width = 14;
            hitbox.Height = 30;
            hitbox.X = (int)position.X ;
            hitbox.Y = (int)position.Y;
            //legs hitbox
            legsHitbox.Width = 14;
            legsHitbox.Height = 5;
            legsHitbox.X = (int)position.X + 17;
            legsHitbox.Y = (int)position.Y + 43;
            //attach hitbox
            attakHitbox.Width = 14;
            attakHitbox.Height = 30;
            attakHitbox.X = (int)position.X;
            attakHitbox.Y = (int)position.Y;

            spriteSheet = Globals.Content.Load<Texture2D>("SpriteSheet/Player_sprite");
            input = new InputManager();
            animation = new AnimationManager();

            //animations
            animation.SetDefault(ref spriteSheet, 75, 48, 48);
            animation.AddAnimation(GameActions.IDLE,new(ref spriteSheet, 3,100,48,48,0,false));
            animation.AddAnimation(GameActions.RUN, 6, 1, false);
            animation.AddAnimation(GameActions.ATTACK, new(ref spriteSheet,7,60,48,48,2,true));
            animation.AddAnimation(GameActions.HEAVY_ATTACK, new(ref spriteSheet, 13, 50, 48, 48, 3, true));


        }
    }
}
