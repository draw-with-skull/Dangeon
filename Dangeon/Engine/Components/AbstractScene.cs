using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DangeonMaster.Engine.Components
{
    internal abstract class AbstractScene
    {
        protected ushort CameraWidth = 800;
        protected ushort CameraHeight = 450;
        public abstract void Init();
        public abstract void Update();
        public abstract void Draw();
    }
}
