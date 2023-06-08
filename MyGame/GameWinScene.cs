using GameEngine; 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGame
{
    class GameWinScene : Scene
    {
        
        public GameWinScene(int score)
        {
            GameWinMsg gamewinmsg = new GameWinMsg(score);
            AddGameObject(gamewinmsg);
        }
    }
}
