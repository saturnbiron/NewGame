using GameEngine;
using SFML.Graphics;
using SFML.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace MyGame
{
    class Glitter : GameObject
    {
        private readonly Text _text = new Text();

        public Glitter(Vector2f pos)
        {
            _text.Font = Game.GetFont("Resources/Courneuf-Regular.ttf");
            _text.Position = pos;
            _text.CharacterSize = 38;
            _text.FillColor = Color.Green;
            AssignTag("Glitter");
        }

        public override void Draw()
        {
            Game.RenderWindow.Draw(_text);
        }

        public override void Update(Time elapsed)
        {
            GameScene scene = (GameScene)Game.CurrentScene;
            _text.DisplayedString = "Glitter: " + scene.GetGlitter();
        }
    }
}
