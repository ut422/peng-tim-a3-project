// Include code libraries you need below (use the namespace).
using System;
using System.Numerics;

// The namespace your code is in.
namespace Game10003
{
    /// <summary>
    ///     Your game code goes inside this class!
    /// </summary>
    public class Player
    {
        // Place your variables here:
        public Vector2 Position { get; private set; }
        public float Size { get; private set; }
        private float jumpHeight;
        private float gravity;
        private bool isJumping;
        private float verticalVelocity;
        private const float GroundLevel = 500; // ground level constant

        public Player(Vector2 startPosition, float playerSize, float playerJumpHeight, float playerGravity)
        {
            Position = startPosition;
            Size = playerSize;
            jumpHeight = playerJumpHeight;
            gravity = playerGravity;
            isJumping = false;
            verticalVelocity = 0f;
        }

        /// <summary>
        ///     Update runs every frame.
        /// </summary>
        public void Update()
        {
            // checks if space is pressed and player is not currently jumping
            if (Input.IsKeyboardKeyDown(KeyboardInput.Space) && !isJumping)
            {
                StartJump();
            }

            // apply gravity and update position if jumping
            if (isJumping)
            {
                verticalVelocity -= gravity; // apply gravity
                // update player position (create a new Vector2 for position)
                Position = new Vector2(Position.X, Position.Y - verticalVelocity); // moves player upward (Y decreases)

                // checks if the player has landed
                if (Position.Y >= GroundLevel)
                {
                    Position = new Vector2(Position.X, GroundLevel); // reset to ground level
                    isJumping = false; // reset jumping state
                    verticalVelocity = 0f; // reset vertical velocity
                }
            }
        }

        private void StartJump()
        {
            Console.WriteLine("Jump triggered!");
            isJumping = true; // set jumping state to true
            verticalVelocity = jumpHeight; // set vertical velocity to jump height
        }

        public void DrawPlayer()
        {
            DrawSquare(); // call method to draw the square
        }

        private void DrawSquare()
        {
            Draw.Square(Position.X, Position.Y, Size); // draw the square
        }
    }
}
