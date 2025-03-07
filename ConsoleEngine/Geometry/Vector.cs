namespace ConsoleEngine;

public struct Vector : IEquatable<Vector>
{
    private int _x;
    private int _y;

    public Vector() { }

    public Vector(int x, int y)
    {
        X = x;
        Y = y;
    }

    public int X { get; set; }
    public int Y { get; set; }

    public bool Equals(Vector other)
    {
        return other.X == X && other.Y == Y;
    }

    public override bool Equals(object obj)
    {
        return obj is Vector && Equals((Vector)obj);
    }

    public static bool operator ==(Vector left, Vector right)
    {
        return left.Equals(right);
    }

    public static bool operator !=(Vector left, Vector right)
    {
        return !(left == right);
    }

    public override int GetHashCode()
        => base.GetHashCode();

    public static Vector operator +(Vector left, Vector right)
    {
        return new Vector(left.X + right.X, left.Y + right.Y);
    }

    public static Vector operator -(Vector left, Vector right)
    {
        return new Vector(left.X - right.X, left.Y - right.Y);
    }
}
