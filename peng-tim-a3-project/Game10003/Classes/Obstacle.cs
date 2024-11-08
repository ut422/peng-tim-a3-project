// Include code libraries you need below (use the namespace).
using System;
using System.Numerics;

// The namespace your code is in.
namespace Game10003;

/// <summary>
/// Your game code goes inside this class!
/// </summary>
public class Obstacle
{
    // Place your variables here:
    public Vector2 Position { get; private set; }
    public Vector2 Size { get; }
    public float Radius { get; }
    public bool IsCircle { get; }
    private float speed;

    // constructor for rectangle obstacles
    public Obstacle(Vector2 position, Vector2 size, float speedValue)
    {
        Position = position;
        Size = size;
        Radius = 0; // not used for rectangles
        IsCircle = false;
        speed = speedValue;
    }

    // constructor for circle obstacles
    public Obstacle(Vector2 position, float radius, float speedValue)
    {
        Position = position;
        Size = Vector2.Zero; // not used for circles
        Radius = radius;
        IsCircle = true;
        speed = speedValue;
    }

    /// <summary>
    /// Update runs every frame.
    /// </summary>
    public void Update()
    {
        // moves the obstacle
        Position = new Vector2(Position.X + speed, Position.Y); // updates the position of the obstacle

        // reset the position if it moves off-screen
        if (IsCircle && Position.X + Radius * 2 < 0)
        {
            Position = new Vector2(800, Position.Y); // reset to the right side
        }
        else if (!IsCircle && Position.X + Size.X < 0)
        {
            Position = new Vector2(800, Position.Y); // reset to the right side
        }
    }

    /// <summary>
    /// Setup runs once before the game loop begins.
    /// </summary>
    public void DrawObstacle()
    {
        if (IsCircle)
        {
            DrawCircle();  // call a separate method for drawing circles
        }
        else
        {
            DrawRectangle();  // call a separate method for drawing rectangles
        }
    }

    private void DrawCircle()  // draws the circle obstacle
    {
        Draw.Circle(Position.X, Position.Y, Radius);
    }

    private void DrawRectangle()  // draws the rectangle obstacle
    {
        Draw.Rectangle(Position.X, Position.Y, Size.X, Size.Y);
    }
}
