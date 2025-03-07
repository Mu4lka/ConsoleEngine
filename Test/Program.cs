using ConsoleEngine;
using ConsoleEngine.Core;
using ConsoleEngine.Objects;
using ConsoleEngine.Rendering;
using Test;


var core = ConsoleEngineCore.Create(
    [
        new Reactangle(new Vector(3, 4), (byte)'*', 10, 5),
        new Tank(),
    ]);
core.Start();