using GameEngine;

namespace MyGame
{
    static class MyGame
    {
        private const int WindowWidth = 1000;
        private const int WindowHeight = 600;

        private const string WindowTitle = "gushers glitter and mo";

        private static void Main(string[] args)
        {
            // Initialize the game.
            Game.Initialize(WindowWidth, WindowHeight, WindowTitle);

            // Create our scene.
            GameScene scene = new GameScene();
            Game.SetScene(scene);

            // Run the game loop.
            Game.Run();
        }
    }
}