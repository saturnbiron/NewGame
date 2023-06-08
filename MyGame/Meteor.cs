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
    class meteor : GameObject
    {
        private const float speed = 0.5f; 

        private readonly Sprite _sprite = new Sprite();

        public meteor(Vector2f pos)
        {
            _sprite.Texture = Game.GetTexture("Resources/meteor.png");
            _sprite.Position = pos;
            _sprite.Scale = new Vector2f(2.0f, 2.0f);
            AssignTag("meteor");
            SetCollisionCheckEnabled(true);
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
                GameScene scene = (GameScene)Game.CurrentScene;
                scene.DecreaseLives(); 
                // these two lines control the automatic explosions
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
                scene.IncreaseScore();
                scene.DecreaseMentalHealth();
            }
            Vector2f pos = _sprite.Position;
            pos.X = pos.X + (float)_sprite.GetGlobalBounds().Width / 2.0f;
            pos.Y = pos.Y + (float)_sprite.GetGlobalBounds().Height / 2.0f;
            //Explosion explosion = new Explosion(pos);
            //Game.CurrentScene.AddGameObject(explosion);
            MakeDead();         
        }

    }
}
