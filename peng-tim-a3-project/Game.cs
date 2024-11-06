using System;
using System.Numerics;

namespace Game10003
{
    /// <summary>
    /// The main game class that handles game logic and rendering.
    /// </summary>
    public class Game
    {
        // configuration variables for easy adjustments
        private const int WindowWidth = 800;
        private const int WindowHeight = 600;

        // player settings
        private Vector2 playerStartPosition = new Vector2(100, 500); // player starting position
        private float playerSize = 50f; // player size
        private float playerJumpHeight = 30f; // jump height
        private float playerGravity = 2f; // gravity applied to player

        // rectangle obstacle settings
        private Vector2 rectangleObstaclePosition = new Vector2(800, 500); // rectangle positioned at player level
        private Vector2 rectangleObstacleSize = new Vector2(100, 50); // rectangle size
        private float rectangleObstacleSpeed = -9f; // speed of rectangle obstacle

        // circle obstacle settings
        private Vector2 circleObstaclePosition = new Vector2(1200, 500); // circle obstacle positioned at player level
        private float circleObstacleRadius = 25f; // circle radius
        private float circleObstacleSpeed = -6f; // speed of circle obstacle

        private Player player; // player instance
        private Obstacle rectangleObstacle; // rectangle obstacle instance
        private Obstacle circleObstacle; // circle obstacle instance
        private Ground ground; // ground instance
        private bool isGameOver; // game over

        /// <summary>
        /// Setup runs once before the game loop begins.
        /// </summary>
        public void Setup()
        {
            Window.SetSize(WindowWidth, WindowHeight); // set the window size
            player = new Player(playerStartPosition, playerSize, playerJumpHeight, playerGravity); // initializes player
            rectangleObstacle = new Obstacle(rectangleObstaclePosition, rectangleObstacleSize, rectangleObstacleSpeed); // rectangle obstacle
            circleObstacle = new Obstacle(circleObstaclePosition, circleObstacleRadius, circleObstacleSpeed); // circle obstacle
            ground = new Ground(new Vector2(0, 550), new Vector2(WindowWidth, 50)); // initialize ground at the bottom
            isGameOver = false; // initiallizes game over
        }

        /// <summary>
        /// Update runs every frame.
        /// </summary>
        public void Update()
        {
            if (isGameOver)
            {
                // closes (crashes) the game upon player death (code mostly found in module 3 - Arrays: Errors)
                int[] numbers = null;
                Console.WriteLine(numbers.Length);
                return;
            }

            Window.ClearBackground(Color.White); // clears the window with white before drawing

            player.Update(); // update player position
            rectangleObstacle.Update(); // update rectangle obstacle
            circleObstacle.Update(); // update circle obstacle

            // rectangle Collision Check
            Vector2 rectanglePosition = rectangleObstacle.Position;
            Vector2 rectangleSize = rectangleObstacle.Size;

            // determine the edges of the rectangle
            float leftEdge = rectanglePosition.X;
            float rightEdge = rectanglePosition.X + rectangleSize.X;
            float topEdge = rectanglePosition.Y;
            float bottomEdge = rectanglePosition.Y + rectangleSize.Y;

            // check for collision using player size and position
            bool isWithinX = (player.Position.X + player.Size > leftEdge) && (player.Position.X < rightEdge);
            bool isWithinY = (player.Position.Y + player.Size > topEdge) && (player.Position.Y < bottomEdge);

            // if both conditions are met, set game over
            if (isWithinX && isWithinY)
            {
                isGameOver = true; // set game over flag if collision detected
            }

            // circle Collision Check
            Vector2 circlePosition = circleObstacle.Position;
            float circleRadius = circleObstacle.Radius;
            float playerRadius = player.Size / 2;

            float combinedRadius = circleRadius + playerRadius;
            float distance = Vector2.Distance(circlePosition, player.Position + new Vector2(playerRadius, playerRadius));

            if (distance <= combinedRadius)
            {
                isGameOver = true; // sets game over if collision detected
            }

            // draw all objects
            ground.DrawGround(); // draw ground
            Draw.FillColor = Color.Black; // set player color   
            player.DrawPlayer(); // draw player
            Draw.FillColor = Color.Black; // set rectangle obstacle color   
            rectangleObstacle.DrawObstacle(); // draw rectangle obstacle
            Draw.FillColor = Color.Black; // set circle obstacle color  
            circleObstacle.DrawObstacle(); // draw circle obstacle
        }
    }
}
