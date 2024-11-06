// Include code libraries you need below (use the namespace).
using System.Numerics;

// The namespace your code is in.
namespace Game10003;

/// <summary>
/// Your game code goes inside this class!
/// </summary>
public class Ground
{
    public Vector2 Position { get; private set; } // position of the ground
    public Vector2 Size { get; private set; }     // size of the ground

    /// <summary>
    /// Setup runs once before the game loop begins.
    /// </summary>
    public Ground(Vector2 position, Vector2 size)
    {
        Position = position;
        Size = size;
    }

    /// <summary>
    /// Update runs every frame.
    /// </summary>
    public void DrawGround()
    {
        Draw.FillColor = Color.Red; // sets color to red
        Draw.Rectangle(Position.X, Position.Y, Size.X, Size.Y); // draw the rectangle
    }
}
