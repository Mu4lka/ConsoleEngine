using ConsoleEngine.Rendering;

namespace ConsoleEngine.Core;

public class CoreEngine<T, V>(IEnumerable<T> _gameObjects, IRenderer<T> _render) : ICoreEngine where T : IRenderable<V>
{
    private bool _isRunning = false;

    public void Start()
    {
        _isRunning = true;
        Run();
    }

    public void Stop()
    {
        _isRunning = false;
    }

    private void Run()
    {
        while (_isRunning)
        {
            foreach (var gameObject in _gameObjects)
            {
                _render.Render(gameObject);
            }

        }
    }
}
