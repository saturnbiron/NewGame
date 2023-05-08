using GameEngine;
using SFML.Graphics;
using SFML.System;
using System;
using System.Reflection.Metadata.Ecma335;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGame
{
    class Car : GameObject
    {
        private const float speed = 1.0f;
        private readonly Sprite _sprite = new Sprite();
        
        public Car(Vector2f pos)
        {
            _sprite.Texture = Game.GetTexture("Resources/car.png");
            _sprite.Position = pos;
            AssignTag("Car");
        }

        public override void Draw()
        {
            Game.RenderWindow.Draw(_sprite);
        }

        public override void Update(Time elapsed)
        {
            int msElapsed = elapsed.AsMilliseconds();
            Vector2f pos = _sprite.Position;

            if (pos.X < _sprite.GetGlobalBounds().Width * -1)
            {
                MakeDead();
            }
            else
            {
                _sprite.Position = new Vector2f(pos.X - speed * msElapsed, pos.Y);
            }
        }

        public override FloatRect GetCollisionRect()
        {
            return _sprite.GetGlobalBounds();
        }

        public override void HandleCollision(GameObject otherGameObject)
        {
            if (otherGameObject.HasTag("laser")) ;
            {
                otherGameObject.MakeDead();
            }
            MakeDead();
        }
    }
}
