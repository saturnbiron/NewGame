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
    class Background : GameObject
    {
        private const float Speed = 0.7f;
        private readonly Sprite _sprite = new Sprite();
       

        public Background()
        {            
                _sprite.Texture = Game.GetTexture("Resources/background.png");
                _sprite.Position = new Vector2f(0, 0);
                AssignTag("background");             
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

           // if (Keyboard.IsKeyPressed(Keyboard.Key.D)) { x -= Speed * msElapsed; }
            _sprite.Position = new Vector2f(x, y);
        }
    }
}
