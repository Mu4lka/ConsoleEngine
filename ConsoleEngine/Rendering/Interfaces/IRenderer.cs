namespace ConsoleEngine.Rendering;

public interface IRenderer<IRenderable>
{
    void Render(IRenderable obj);
}
