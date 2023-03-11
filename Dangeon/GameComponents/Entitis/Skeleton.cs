using Dangeon.Engine.Components;
using Dangeon.Engine.Debug;
using DangeonMaster.Engine;
using DangeonMaster.Engine.Enums;
using DangeonMaster.Engine.Managers;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dangeon.GameComponents.Entitis
{
    internal class Skeleton : Entity
    {
        private Texture2D spriteSheet;
        private AnimationManager animation;
        private Rectangle hitbox;
        private Vector2 position;
        private Vector2 direction = new(1, 1);
        private readonly int speed = 100;

        public Skeleton(int x, int y)
        {
            Init();
            InitAnimations();
            InitHitboxs(x, y);
        }
        public override void Draw()
        {
            RectangleDebug.Draw(hitbox, Color.Red);
            animation.Draw();
        }
        #region Update
        public override void Update()
        {
            
            animation.Update(GameActions.WALK, direction, position);
        }
        public void UpdatePosition(ref List<Rectangle> walls)
        {

            Rectangle temp = hitbox;
            Vector2 moveAmount = Vector2.One* speed * Globals.Time.ElapsedGameTime.Milliseconds / 1000;
            temp.X += (int)moveAmount.X;
            temp.Y += (int)moveAmount.Y;
            walls.ForEach((wall) =>
            {
                if (wall.Intersects(hitbox))
                {
                    if ((wall.X - position.X) > (wall.Y - position.Y))
                    {
                        direction.X *= -1;
                    }
                    else
                    {
                        direction.Y *= -1;
                    }
                }
            });
            
            position.X += (int)(moveAmount.X* direction.X);
            position.Y += (int)(moveAmount.Y*direction.Y);
            hitbox.X = (int)position.X+15;
            hitbox.Y = (int)position.Y+24;
        }
        #endregion

        #region Init
        public void SetDirection(Vector2 direction) {
            this.direction.X = direction.X > 0 ? 1 : -1;
            this.direction.Y = direction.Y > 0 ? 1 : -1;
        }
        private void Init() 
        {
            spriteSheet = Globals.Content.Load<Texture2D>("SpriteSheet/Skeleton");
            animation = new AnimationManager();

        }

        private void InitAnimations()
        {
            animation.SetDefault(ref spriteSheet,70,48,48);
            animation.AddAnimation(GameActions.IDLE,11,3,true);
            animation.AddAnimation(GameActions.ATTACK, 10, 0, true);
            animation.AddAnimation(GameActions.WALK, 13, 1, false);
            animation.AddAnimation(GameActions.DEATH, 15, 2, true);
        }

        private void InitHitboxs(int x, int y)
        {
            position = new(x, y);
            hitbox.X = x;
            hitbox.Y = y;
            hitbox.Width = 18;
            hitbox.Height = 24;
        }
        #endregion 
    }
}
