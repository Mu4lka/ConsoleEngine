using ConsoleEngine;
using ConsoleEngine.Enums;
using ConsoleEngine.Extensions;
using ConsoleEngine.Geometry;
using ConsoleEngine.Input;
using ConsoleEngine.Objects;
using ConsoleEngine.Objects.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test;

public class Tank : Reactangle
{
    private int _countBullet = 100;

    public Tank() : base(new Vector(0, 0), (byte)'+', 3, 2)
    {
    }

    public override void Start()
    {
        ConsoleInput.OnPressed += Move;
        ConsoleInput.OnPressed += Fire;
    }

    public override void Update()
    {
    }

    private void Move(ConsoleKey key)
    {
        Direction? diration = key switch
        {
            ConsoleKey.UpArrow => Direction.Up,
            ConsoleKey.DownArrow => Direction.Down,
            ConsoleKey.RightArrow => Direction.Right,
            ConsoleKey.LeftArrow => Direction.Left,
            _ => null
        };

        if (diration is null)
        {
            return;
        }

        var vector = diration.Value.ToVector();
        Transform = new Transform(Transform.Position + vector, diration.Value);
    }

    private void Fire(ConsoleKey key)
    {
        if (key != ConsoleKey.Spacebar)
            return;
    }
}
