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
    class CarSpawner : GameObject
    {
        private const int SpawnDelay = 2000; // number of ms between each car spawn

        private int _timer;

        public override void Update(Time Elapsed)       //determine how much time has passed and adjust our timer
        {
            int msElapsed = Elapsed.AsMilliseconds();
            _timer -= msElapsed;


            if (_timer <= 0)            // if our timer has elapsed reset it and spawn a new car
            {
                _timer = SpawnDelay;
                Vector2u size = Game.RenderWindow.Size;

                float carX = size.X + 100;      // spawn meteor to right side  // for these two lines use vector2f and put in specific coordinates (250, 210)
                float carY = Game.Random.Next() % size.Y;       //spawn randomly on y axis

                Car car = new Car(new Vector2f(carX, carY));        //creates new car
                Game.CurrentScene.AddGameObject(car);
            }
        }
    }
}
