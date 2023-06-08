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
        private const float speed = 0.2f;
       
        private readonly Sprite _sprite = new Sprite();
        public blueglitter(Vector2f pos)
        {
            _sprite.Texture = Game.GetTexture("Resources/blueglitter.png");
            _sprite.Position = pos;
            _sprite.Scale = new Vector2f(4.0f, 4.0f);
            SetCollisionCheckEnabled(true);
            AssignTag("blueglitter");
        }

        public override void Draw()
        {
            Game.RenderWindow.Draw(_sprite);
        }

        public override void Update(Time Elapsed)
        {
            int msElapsed = Elapsed.AsMilliseconds();
            Vector2f pos = _sprite.Position;

            if (pos.X < _sprite.GetGlobalBounds().Width * -1)
            {
                GameScene scene = (GameScene)Game.CurrentScene;
                scene.IncreaseGlitter();
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
            if (otherGameObject.HasTag("laser"))
            {
                otherGameObject.MakeDead();
                GameScene scene = (GameScene)Game.CurrentScene;
                scene.IncreaseGlitter();
            }
            Vector2f pos = _sprite.Position;
            pos.X = pos.X + (float)_sprite.GetGlobalBounds().Width / 4.0f;
            pos.Y = pos.Y + (float)_sprite.GetGlobalBounds().Height / 4.0f;
            Explosion explosion = new Explosion(pos);
            Game.CurrentScene.AddGameObject(explosion);
            MakeDead();
           
        }


    }
}