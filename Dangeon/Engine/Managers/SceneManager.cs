using DangeonMaster.Engine.Components;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DangeonMaster.Engine.Managers
{
    internal static class SceneManager
    {
        private static Stack<AbstractScene> Scenes= new();
        private static ushort MaxScenes = 20;

        public static void Add(AbstractScene scene)
        {
            if (Scenes.Count >= MaxScenes)
            {
                SwitchScene(scene);
                return;
            }
            Scenes.Push(scene);
        }
        public static void Remove()
        {
            if (Scenes.Count > 0)
            {
                return;
            }
            Scenes.Pop();
        }

        public static AbstractScene GetScene()
        {
            return Scenes.Count < 0? null:Scenes.Peek();
        }
       
        public static void SetMaxScenes(UInt16 count)
        {
            MaxScenes = count;
        }

        public static void SwitchScene(AbstractScene scene)
        {
            Remove();
            Scenes.Push(scene);
        }
    }
}
