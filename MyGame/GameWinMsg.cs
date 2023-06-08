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
    class GameWinMsg : GameObject
    {
        private readonly Text _text = new Text();
               

        public GameWinMsg(int score)
        {
            _text.Font = Game.GetFont("Resources/Courneuf-Regular.ttf");
            _text.Position = new Vector2f(90, 280);
            _text.CharacterSize = 64;
            _text.FillColor = Color.Blue;
            _text.DisplayedString = "       you won lets go\n\n         your score: " + score  +  "\n\npress enter to go to the menu";
        }

        public override void Draw()
        {
            Game.RenderWindow.Draw(_text);
           
        }

        public override void Update(Time elapsed)
        {
            if (Keyboard.IsKeyPressed(Keyboard.Key.Enter))
            {
                GameScene scene = new GameScene();
                Game.SetScene(scene);
            }
        }

    }
}
