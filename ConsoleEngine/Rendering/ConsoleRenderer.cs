namespace ConsoleEngine.Rendering;

public class ConsoleRenderer : IRenderer<IRenderable<ConsoleVisualization>>
{
    public void Render(IRenderable<ConsoleVisualization> obj)
    {
        if (!obj.Swown)
            return;
        var visual = obj.GetVisualization();

        var ascii = visual.Ascii;
        var transform = visual.Transform;


        foreach (var item in ascii)
        {

        }
    }
}
