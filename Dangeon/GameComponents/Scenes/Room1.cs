using Dangeon.Engine.Debug;
using Dangeon.Engine.Managers;
using DangeonMaster.Engine;
using DangeonMaster.Engine.Components;
using DangeonMaster.Engine.Enums;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace DangeonMaster.GameComponents.Scenes
{
    /*
        var t = new Texture2D(Globals.GraphicsDevice, 1, 1);
        t.SetData(new[] { Color.White
        Globals.SpriteBatch.Draw(t, wall, Color.Red); 
     */
    internal class Room1 : AbstractScene
    {
        private Texture2D background;
        private List<Rectangle> doors;
        private List<Rectangle> walls;
        private Player player;
        private Matrix transformation;
        Texture2D t = new Texture2D(Globals.GraphicsDevice, 1, 1);
        

        
        public Room1()
        {
            Init();
        }
        public override void Draw()
        {
            Globals.GraphicsDevice.Clear(Color.Wheat);
            Globals.SpriteBatch.Begin(SpriteSortMode.BackToFront, null, SamplerState.PointClamp, null, null, null, transformMatrix: transformation);
            Globals.SpriteBatch.Draw(background, background.Bounds, Color.White);
            player.Draw();
            //RectangleDebug.Draw(walls, Color.Green);
            //RectangleDebug.Draw(doors, Color.Pink);
            Globals.SpriteBatch.End();
        }
        public override void Update()
        {
            player.Update(ref walls);
            int dx = (int)(Globals.WindowSize.X / 2 / Globals.scale - player.GetPosition().X);
            int dy = (int)(Globals.WindowSize.Y / 2 / Globals.scale - player.GetPosition().Y);
            if (dx > 0) dx = 0;
            if (dy > 0) dy = 0;
            if (dx < -background.Bounds.Width / 2) {dx = (int)-background.Bounds.Width / 2; }
            if (dy < -background.Bounds.Height / 2) { dy = (int)-background.Bounds.Height / 2; }
            transformation = Matrix.CreateTranslation(dx, dy, 0);
        }

        public override void Init()
        {
            background = Globals.Content.Load<Texture2D>("Rooms/Room1");
            player = new Player(200,200);
            doors = new()
            {
                new(336, 64, 80, 64),
                new(416, 64, 80, 64),
                new(496, 64, 64, 64),
                new(560, 64, 80, 64),
                new(640, 64, 80, 64),
                new(368, 368, 80, 64),
                new(608, 368, 80, 64)
            };
            walls = new()
            {
                new(0,0,336,144),
                new(720,0,320,144),
                new(352,272,352,96),
                new(0,144,96,496),
                new(96,544,848,96),
                new(944,144,96,496),
                new(352,368,16,80),
                new(688,368,16,80),
                new(448,368,160,64),
                new(336,0,384,64),
            };
        }
        

    }
}
