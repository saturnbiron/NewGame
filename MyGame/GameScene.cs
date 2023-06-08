using GameEngine;
using SFML.System;
using System.Runtime.CompilerServices;

namespace MyGame
{
    class GameScene : Scene
    {
        private int _lives = 5;
        private int _score;
        private int _mentalhealth = 0;
        private int _glitter = 0;

        public GameScene()
        {
            Background background = new Background();
            AddGameObject(background);

            Ship ship = new Ship();
            AddGameObject(ship);            

            MeteorSpawner meteorspawner = new MeteorSpawner();
            AddGameObject(meteorspawner);

            Score score = new Score(new Vector2f(10.0f, 10.0f));
            AddGameObject(score);

            MentalHealth mentalhealth = new MentalHealth(new Vector2f(10.0f, 50.0f)); //10,50
            AddGameObject(mentalhealth);

            Glitter glitter = new Glitter(new Vector2f(700.0f, 30.0f));
            AddGameObject(glitter);

            CarSpawner carspawner = new CarSpawner();
            AddGameObject(carspawner);

            BlueGlitterSpawner blueglitterspawner = new BlueGlitterSpawner();
            AddGameObject(blueglitterspawner);



        }
        public int GetGlitter()
        {
            return _glitter;
        }

        public void IncreaseGlitter()
        {
            ++_glitter;
            if (_glitter == 13)
            {
                GameWinScene gamewinscene = new GameWinScene(_score);
                Game.SetScene(gamewinscene);
            }
        }

            public void DecreaseGlitter()
            {
                --_glitter;

            }

            public int GetMentalHealth()
            {
                return _mentalhealth;
            }


            public void DecreaseMentalHealth()
            {
                _mentalhealth = _mentalhealth - 2;
            }



            public int GetScore()
            {
                return _score;
            }

            public void IncreaseScore()
            {
                ++_score;
                if (_score == 5)
                {
                   _lives = _lives + 1;
                }
            }

            public int GetLives()
            {
                return _lives;
            }

            public void IncreaseLives()
            {
                ++_lives;
                if (_score == 5)
                {
                    _lives = _lives + 1;
                }
            }

            public void DecreaseLives()
            {
                --_lives;
                if (_lives == 0)
                {
                    GameOverScene gameOverScene = new GameOverScene(_score);
                    Game.SetScene(gameOverScene);
                }
            }
        
    }
}