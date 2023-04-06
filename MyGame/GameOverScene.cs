using GameEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGame
{
    class GameOverScene : Scene
    {
        public GameOverScene(int score)
        {
            GameOverMessage gameovermessage = new GameOverMessage(score);
            AddGameObject(gameovermessage);
        }
    }
}
