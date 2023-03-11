using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dangeon.Engine.Components
{
    internal abstract class Entity
    {
        public abstract void Draw();
        public abstract void Update();
    }
}
