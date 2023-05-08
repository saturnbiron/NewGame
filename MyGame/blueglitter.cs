using GameEngine;
using SFML.Graphics;
using SFML.System;
using SFML.Window;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGame
{
    class blueglitter : GameObject
    {
        private const float Speed = 0.3f;
        private const int FireDelay = 200;
        private int _fireTimer;

        private readonly Sprite _sprite = new Sprite();
        public blueglitter()
        {
            _sprite.Texture = Game.GetTexture("Resources/blueglitter.png");
            _sprite.Position = new Vector2f(400, 600);
            _sprite.Scale = new Vector2f(4.0f, 4.0f);
        }

        public override void Draw()
        {
            Game.RenderWindow.Draw(_sprite);
        }

        public override void Update(Time Elapsed)
        {
            Vector2f pos = _sprite.Position;
            float x = pos.X;
            float y = pos.Y;
        }

        public override FloatRect GetCollisionRect()
        {
            return _sprite.GetGlobalBounds();
        }

        public override void HandleCollision(GameObject otherGameObject)
        {
            if (otherGameObject.HasTag("harlow"))
            {
                otherGameObject.MakeDead();
            }
            MakeDead();
        }


    }
}