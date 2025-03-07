using ConsoleEngine.Geometry;
using ConsoleEngine.Objects.Base;

namespace ConsoleEngine;

public class TextModel : ConsoleModel
{
    public TextModel(Vector position, string text)
        : base(new Transform() { Position = position }, ToAscii(text))
    {

    }

    protected static byte[,] ToAscii(string data)
    {
        var ascii = new byte[1, data.Length];

        for (var x = 0; x < ascii.GetLength(1); x++)
        {
            ascii[0, x] = (byte)data[x];
        }
        return ascii;
    }
}
