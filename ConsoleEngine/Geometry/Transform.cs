using ConsoleEngine.Enums;

namespace ConsoleEngine.Geometry;

public struct Transform : IEquatable<Transform>
{
    public Transform() { }

    public Transform(Vector position, Direction direction)
    {
        Position = position;
        Direction = direction;
    }

    public Vector Position { get; set; }
    public Direction Direction { get; set; }

    public bool Equals(Transform other)
    {
        return other.Direction.Equals(Direction)
            && other.Position.Equals(Position);
    }

    public override bool Equals(object obj)
    {
        return obj is Transform && Equals((Transform)obj);
    }

    public static bool operator ==(Transform left, Transform right)
    {
        return left.Equals(right);
    }

    public static bool operator !=(Transform left, Transform right)
    {
        return !(left == right);
    }

    public override int GetHashCode()
    {
        return base.GetHashCode();
    }
}