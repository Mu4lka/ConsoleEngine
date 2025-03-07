using ConsoleEngine.Objects.Base;
using System.ComponentModel;
using System.Diagnostics;

namespace ConsoleEngine.Rendering;

public class ConsoleRenderer
{
    public void Render(ConsoleModel model)
    {
        if (!model.IsReadyRendering)
        {
            return;
        }

        var can = CanRender(model);
        if (!can)
        {
            Clear(model);
            return;
        }

        if(!model.Shown && can)
        {
            Clear(model);
            return;
        }

        Clear(model);
        Draw(model);
    }

    private static void Clear(ConsoleModel model)
    {
        Console.ResetColor();
        
        foreach (var state in model.PreviousRenderStates)
        {
            var ascii = state.Ascii;
            var positionY = state.Transform.Position.Y;
            var positionX = state.Transform.Position.X;

            // Создаем строку из пробелов, равную ширине ascii
            string spaces = new string(' ', ascii.GetLength(1));

            for (int y = 0; y < ascii.GetLength(0); y++)
            {
                Console.SetCursorPosition(positionX, positionY + y);
                Console.Write(spaces);
            }
        }
        model.PreviousRenderStates.Clear();
    }

    private static void Draw(ConsoleModel model)
    {
        var ascii = model.Ascii;

        var positionY = model.Transform.Position.Y;
        var positionX = model.Transform.Position.X;

        Console.ForegroundColor = model.Color;
        Console.SetCursorPosition(positionX, positionY);
        for (int y = 0; y < ascii.GetLength(0); y++)
        {
            for (int x = 0; x < ascii.GetLength(1); x++)
            {
                Console.Write((char)ascii[y, x]);
            }
            Console.SetCursorPosition(positionX, ++positionY);
        }
        model.IsReadyRendering = false;
    }

    private static bool CanRender(ConsoleModel model)
    {
        var ascii = model.Ascii;
        var positionY = model.Transform.Position.Y;
        var positionX = model.Transform.Position.X;

        if (positionX < 0 || positionY < 0)
            return false;

        if (positionX + ascii.GetLength(1) >= Console.WindowWidth)
        {
            return false;
        }

        if (positionY + ascii.GetLength(0) >= Console.WindowHeight)
        {
            return false;
        }
        return true;
    }
}
