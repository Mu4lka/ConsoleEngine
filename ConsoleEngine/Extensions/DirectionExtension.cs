using ConsoleEngine.Enums;

namespace ConsoleEngine.Extensions;

public static class DirectionExtension
{
    /// <summary>
    /// Этот метод преобразует <see cref="Direction"/> в <see cref="Vector"/>
    /// </summary>
    /// <param name="direction">Направление</param>
    /// <returns><see cref="Vector"/> у которого одна из координат имеет единичое значение</returns>
    /// <exception cref="ArgumentNullException"></exception>
    public static Vector ToVector(this Direction direction, int value = 1)
        => direction switch
        {
            Direction.Left => new() { X = -value, Y = 0 },
            Direction.Right => new() { X = value, Y = 0 },
            Direction.Up => new() { X = 0, Y = -value },
            Direction.Down => new() { X = 0, Y = value },
            _ => throw new ArgumentNullException()
        };

    /// <summary>
    /// Этот метод преобразует <see cref="Direction"/> в <see cref="Vector"/>
    /// </summary>
    /// <param name="direction">Направление</param>
    /// <param name="vector"><see cref="Vector"/> для дальнейшего преобразования, у которого будет одна из координат имеет единичое значение.
    /// В противном случае будет дефолтные значения</param>
    /// <returns> В случае успешного преобразования вернет <see cref="true"/>, в противном случае <see cref="false"/> </returns>
    public static bool TryToVector(this Direction direction, out Vector vector, int value = 1)
    {
        Vector? vectorOrNull = direction switch
        {
            Direction.Left => new() { X = -value, Y = 0 },
            Direction.Right => new() { X = value, Y = 0 },
            Direction.Up => new() { X = 0, Y = -value },
            Direction.Down => new() { X = 0, Y = value },
            _ => null
        };

        if (vectorOrNull == null)
        {
            vector = new();
            return false;
        }
        vector = (Vector)vectorOrNull;
        return true;
    }
}
