using DangeonMaster.Engine.Managers;
using DangeonMaster.GameComponents.Scenes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DangeonMaster.Engine
{
    internal class GameManager
    {
        public GameManager()
        {
            SceneManager.Add(new Room1());
        }
        public void Update()
        {
            SceneManager.GetScene().Update();
        }

        public void Draw()
        {
            SceneManager.GetScene().Draw();
        }
    }
}
