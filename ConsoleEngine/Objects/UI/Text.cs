using ConsoleEngine.Rendering;

namespace ConsoleEngine;

public class Text(string _text) : GameObject, IRenderable<ConsoleVisualization>
{
    public bool Swown { get; set; } = true;

    public ConsoleVisualization GetVisualization()
        => new() { Transform = Transform, Ascii = [_text] };
}
