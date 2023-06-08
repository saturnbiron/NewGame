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
    class BlueGlitterSpawner : GameObject
    {
        private const int SpawnDelay = 1000;

        private int _timer;

        public override void Update(Time elapsed)
        {
            int msElapsed = elapsed.AsMilliseconds();
            _timer -= msElapsed;

            if(_timer <= 0)
            {
                _timer = SpawnDelay;
                Vector2u size = Game.RenderWindow.Size;

                float blueglitterX = size.X + 100;
                float blueglitterY = Game.Random.Next() % size.Y;

                blueglitter blueglitter = new blueglitter(new Vector2f(blueglitterX, blueglitterY));        //creates new glitter
                Game.CurrentScene.AddGameObject(blueglitter);

            }
        }
    }
}
