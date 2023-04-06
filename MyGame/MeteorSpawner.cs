using GameEngine;
using SFML.Graphics;
using SFML.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MyGame
{
    class MeteorSpawner : GameObject
    {
        private const int SpawnDelay = 1000;

        private int _timer;

        public override void Update(Time elapsed)
        {
            int msElapsed = elapsed.AsMilliseconds();
            _timer -= msElapsed;

            if(_timer <=0)
            {
                _timer = SpawnDelay;
                Vector2u size = Game.RenderWindow.Size;
                float meteorX = size.X + 100;
                float meteorY = Game.Random.Next() % size.Y;
                meteor meteor = new meteor(new Vector2f(meteorX, meteorY));
                Game.CurrentScene.AddGameObject(meteor);
            }
        }
    }
}
