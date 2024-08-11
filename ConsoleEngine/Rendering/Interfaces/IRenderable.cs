namespace ConsoleEngine.Rendering;

public interface IRenderable<TVisualization>
{
    bool Swown { get; set; }

    TVisualization GetVisualization();
}
