using DangeonMaster.Engine;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Dangeon
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private RenderTarget2D rt;
        GameManager GameManager;
        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            this.IsFixedTimeStep = false;
        }

        protected override void Initialize()
        {

            base.Initialize();
            Globals.InitContent(Content);
            Globals.InitWindow(Window);
            _graphics.PreferredBackBufferHeight = (int)Globals.WindowSize.Y;
            _graphics.PreferredBackBufferWidth = (int)Globals.WindowSize.X;
            _graphics.ApplyChanges();

            GameManager = new();
            rt = new RenderTarget2D(_graphics.GraphicsDevice, 400, 255);
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            Globals.SpriteBatch = _spriteBatch;
            Globals.GraphicsDevice = GraphicsDevice;

        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            {
                Exit();
            }
            Globals.Update(gameTime);
            GameManager.Update();
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            
            Globals.GraphicsDevice.SetRenderTarget(rt);
            GameManager.Draw();
            Globals.GraphicsDevice.SetRenderTarget(null);
            Globals.SpriteBatch.Begin(SpriteSortMode.Immediate, null, SamplerState.PointClamp, null, null);
            Globals.SpriteBatch.Draw(rt, new Rectangle(0, 0, (int)Globals.WindowSize.X, (int)Globals.WindowSize.Y),Color.White);
            Globals.SpriteBatch.End();
            base.Draw(gameTime);
        }
    }
}