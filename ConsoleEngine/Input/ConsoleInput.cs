namespace ConsoleEngine.Input;

public class ConsoleInput
{
    static public ConsoleKey Key { get; private set; }

    public delegate void OnPressedKey(ConsoleKey Key);
    static public event OnPressedKey OnPressed;

    public static void Run()
    {
        Task.Run(() =>
        {
            while (true)
            {
                Key = Console.ReadKey(true).Key;
                OnPressed?.Invoke(Key);
            }
        });
    }
}
