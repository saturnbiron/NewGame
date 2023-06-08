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
    class Ship : GameObject
    {

        private const float Speed = 0.7f;
        private const int FireDelay = 200;
        private int _fireTimer;
        
        private readonly Sprite _sprite = new Sprite();
        public Ship()
        {
            _sprite.Texture = Game.GetTexture("Resources/harlow.png");
            _sprite.Position = new Vector2f(100, 100);
            AssignTag("harlow");
            SetCollisionCheckEnabled(true);
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

            int msElapsed = Elapsed.AsMilliseconds();

            if (Keyboard.IsKeyPressed(Keyboard.Key.W)) { y -= Speed * msElapsed; }
            if (Keyboard.IsKeyPressed(Keyboard.Key.S)) { y += Speed * msElapsed; }
            if (Keyboard.IsKeyPressed(Keyboard.Key.A)) { x -= Speed * msElapsed; }
            if (Keyboard.IsKeyPressed(Keyboard.Key.D)) { x += Speed * msElapsed; }
            _sprite.Position = new Vector2f (x, y);    
            
            if(_fireTimer > 0) { _fireTimer -= msElapsed; }

            if(Keyboard.IsKeyPressed(Keyboard.Key.Space) && _fireTimer <= 0)
            {
                _fireTimer = FireDelay;
                FloatRect bounds = _sprite.GetGlobalBounds();
                float laserX = x + bounds.Width;
                float laserY = y + bounds.Height / 6.0f;
                Laser laser = new Laser(new Vector2f(laserX, laserY));
                Game.CurrentScene.AddGameObject(laser);
            }


        }

        public override FloatRect GetCollisionRect()
        {
            return _sprite.GetGlobalBounds();
        }

        public override void HandleCollision(GameObject otherGameObject)
        {
            if (otherGameObject.HasTag("meteor"))
            {
                otherGameObject.MakeDead();
                GameScene scene = (GameScene)Game.CurrentScene;
                scene.DecreaseLives();                
            }
        }

    }
}
