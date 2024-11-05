using System;
using System.Numerics;

namespace Game10003
{
    /// <summary>
    /// The main game class that handles game logic and rendering.
    /// </summary>
    public class Game
    {
        
        private const int WindowWidth = 800;
        private const int WindowHeight = 600;

        /// <summary>
        /// Setup runs once before the game loop begins.
        /// </summary>
        public void Setup()
        {
            Window.SetSize(800, 600); // set the window size
            ground = new Ground(new Vector2(0, 550), new Vector2(800, 50)); // ground at Y=550 with width 800 and height 50
           
        }
        }
    }
}
