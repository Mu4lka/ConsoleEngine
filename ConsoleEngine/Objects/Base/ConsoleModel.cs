using ConsoleEngine.Geometry;

namespace ConsoleEngine.Objects.Base;

public abstract class ConsoleModel : GameObject
{
    private Transform _transform;
    protected byte[,] _ascii;

    public ConsoleModel(Transform transform, byte[,] ascii)
    {
        _transform = transform;
        _ascii = ascii;
        PreviousRenderStates = [new RenderState(ascii, transform)];
    }

    public byte[,] Ascii
    {
        get => _ascii;
        set
        {
            PreviousRenderStates.Add(new RenderState(_ascii, _transform));
            _ascii = value;
            IsReadyRendering = true;
        }
    }
    public bool Shown { get; set; } = true;
    public ConsoleColor Color { get; set; } = ConsoleColor.White;

    public Transform Transform
    {
        get => _transform;
        set
        {
            if (_transform.Equals(value))
                IsReadyRendering = false;

            PreviousRenderStates.Add(new RenderState(_ascii, _transform));
            _transform = value;
            IsReadyRendering = true;
        }
    }

    internal List<RenderState> PreviousRenderStates { get; private set; }
    internal bool IsReadyRendering { get; set; } = true;
}