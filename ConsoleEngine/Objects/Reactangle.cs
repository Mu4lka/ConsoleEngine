using ConsoleEngine.Geometry;
using ConsoleEngine.Objects.Base;

namespace ConsoleEngine.Objects;

public class Reactangle : ConsoleModel
{
    public Reactangle(Vector position, byte symbol, int length, int heigth)
        : base(new Transform() { Position = position }, Fill(new byte[heigth, length], symbol))
    {

    }

    private static byte[,] Fill(byte[,] source, byte symbol)
    {
        for (var y = 0; y < source.GetLength(0); y++)
        {
            for (var x = 0; x < source.GetLength(1); x++)
            {
                source[y, x] = symbol;
            }
        }
        return source;
    }
}
