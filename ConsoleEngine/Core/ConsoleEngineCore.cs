using ConsoleEngine.Input;
using ConsoleEngine.Objects.Base;
using ConsoleEngine.Rendering;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace ConsoleEngine.Core;

public class ConsoleEngineCore: IEngineCore
{
    internal static ConsoleEngineCore Core;

    private ConsoleEngineCore(params ConsoleModel[] models)
    {
        Models = [.. models];
    }

    internal List<ConsoleModel> Models { get; set; }

    private readonly ConsoleRenderer _renderer = new();
    private bool _isRunning = false;


    public void Start()
    {
        _isRunning = true;
        Console.CursorVisible = false;
        ConsoleInput.Run();
        RunModelsHandling();
    }

    public void Stop()
    {
        _isRunning = false;
    }

    private void RunModelsHandling()
    {
        foreach (var model in Models)
        {
            model.Start();
            _renderer.Render(model);
        }

        while (_isRunning)
        {
            HandleModels();
        }
    }

    private void HandleModels()
    {
        try
        {
            foreach (var model in Models)
            {
                model.Update();
                _renderer.Render(model);
            }
        }
        catch
        {

        }
    }

    public static ConsoleEngineCore Create(params ConsoleModel[] models)
    {
        if (Core is not null)
        {
            throw new InvalidOperationException("Можно создать только одно ядро движка");
        }
        Core = new ConsoleEngineCore(models);
        return Core;
    }
}
