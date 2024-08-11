namespace ConsoleEngine;

public abstract class GameObject
{
    public Guid Id { get; } = Guid.NewGuid();
    public string Name { get; set; } = "оbject";
    public bool IsActive { get; set; } = true;
    public Transform Transform { get; set; }

    public virtual void Start() { }

    public virtual void Update() { }
}
