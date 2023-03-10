using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System.Diagnostics;

namespace DangeonMaster.Engine
{
    public static class Globals
    {
        public static SpriteBatch SpriteBatch;
        public static ContentManager Content;
        public static GraphicsDeviceManager GraphicsManager;
        public static GraphicsDevice GraphicsDevice;
        public static GameTime Time;
        public static GameWindow Window;
        public static Vector2 WindowSize = new Vector2(1600, 900);
        public static int scale = 4;
        public static void InitContent(ContentManager gameContent)
        {
            Content = gameContent;
        }
        public static void InitWindow(GameWindow window)
        {
            Window = window;
        }
        public static void Update(GameTime gameTime)
        {
            Time = gameTime;
        }
    }
}
