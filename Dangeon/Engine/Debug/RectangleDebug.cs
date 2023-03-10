using DangeonMaster.Engine;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dangeon.Engine.Debug
{
    internal  class RectangleDebug
    {
        private static Texture2D t = new Texture2D(Globals.GraphicsDevice, 1, 1);
        public static void Draw(Rectangle rec, Color color)
        {
            t.SetData(new[] { color});
            Globals.SpriteBatch.Draw(t, rec, color);
        }
        public static void Draw(Point position, Point size,Color color)
        {
            t.SetData(new[] { color });
            Globals.SpriteBatch.Draw(t, new Rectangle(position.X,position.Y,size.X,size.Y), color);
        }
        public static void Draw(Point position, Vector2 size,Color color)
        {
            t.SetData(new[] { color });
            Globals.SpriteBatch.Draw(t, new Rectangle(position.X, position.Y, (int)size.X, (int)size.Y), color);
        }

        public static void Draw(Vector2 position, Vector2 size, Color color)
        {
            t.SetData(new[] { color });
            Globals.SpriteBatch.Draw(t, new Rectangle((int)position.X, (int)position.Y, (int)size.X, (int)size.Y), color);
        }
        public static void Draw(int x,int y ,int width,int height,Color color)
        {
            t.SetData(new[] { color });
            Globals.SpriteBatch.Draw(t, new Rectangle(x, y, width, height), color);
        }

        public static void Draw(List<Rectangle> recs,Color color)
        {
            t.SetData(new[] { color });
            recs.ForEach((rec) => { Globals.SpriteBatch.Draw(t, rec, color); });
        }


    }
}
