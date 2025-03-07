using ConsoleEngine.Geometry;
using System.Text;

namespace ConsoleEngine.Objects.Base;

internal class RenderState(byte[,] ascii, Transform transform)
{
    internal byte[,] Ascii { get; set; } = ascii;
    internal Transform Transform { get; set; } = transform;
}