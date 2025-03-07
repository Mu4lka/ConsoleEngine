using ConsoleEngine.Core;
using ConsoleEngine.Objects.Base;
using System.Xml.Linq;

namespace ConsoleEngine;

public class GameObject
{
    public string Name { get; set; }

    public virtual void Start() { }

    public virtual void Update() { }

    public static GameObject Create(ConsoleModel model)
    {
        ConsoleEngineCore.Core.Models.Add(model);
        return model;
    }

    public static GameObject? FindByName(string name)
    {
        return ConsoleEngineCore.Core.Models.FirstOrDefault(m => m.Name == name);
    }

    public static void Destroy(ConsoleModel model)
    {
        ConsoleEngineCore.Core.Models.Remove(model);
    }
}
