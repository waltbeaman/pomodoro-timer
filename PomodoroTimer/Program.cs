namespace PomodoroTimer;
class Program
{
    static void Main()
    {
        Console.SetWindowSize(58, 25);
        Console.Title = "Pomodoro Timer";

        // Create timer variables
        int taskTime = 1500000;
        int breakTime = 300000;

        // Test timer variables
        //int taskTime = 3000;
        //int breakTime = 3000;

        do
        {
            while (!Console.KeyAvailable)
            {
                Console.BackgroundColor = ConsoleColor.Black;
                GenerateBanner(1);
                Console.ReadKey();
                Thread.Sleep(taskTime);
                StartAlarm();

                Console.BackgroundColor = ConsoleColor.Black;
                GenerateBanner(2);
                Console.ReadKey();
                Thread.Sleep(breakTime);
                StartAlarm();
            }

        } while (Console.ReadKey(true).Key != ConsoleKey.Escape);

        Environment.Exit(0); 
    }

    public static void GenerateBanner(int menu)
    {
        Console.Clear();
        Console.Write(@"

 ╔══════════════════════════════════════════════════════╗
 ║   _____                          _                   ║
 ║  |  __ \                        | |                  ║
 ║  | |__) |__  _ __ ___   ___   __| | ___  _ __ ___    ║
 ║  |  ___/ _ \| '_ ` _ \ / _ \ / _` |/ _ \| '__/ _ \   ║
 ║  | |  | (_) | | | | | | (_) | (_| | (_) | | | (_) |  ║
 ║  |_| __\___/|_| |_| |_|\___/ \__,_|\___/|_|  \___/   ║
 ║     |__   __(_)                                      ║
 ║        | |   _ _ __ ___   ___ _ __                   ║
 ║        | |  | | '_ ` _ \ / _ \ '__|                  ║
 ║        | |  | | | | | | |  __/ |                     ║
 ║        |_|  |_|_| |_| |_|\___|_|                     ║
 ╟──────────────────────────────────────────────────────╢");

        string startTask = @"
 ║        PRESS THE SPACEBAR TO START THE TASK          ║
 ╚══════════════════════════════════════════════════════╝
";
        string startBreak = @"
 ║        PRESS THE SPACEBAR TO START THE BREAK         ║
 ╚══════════════════════════════════════════════════════╝
";
        string silenceAlarm = @"
 ║        PRESS THE SPACEBAR TO STOP THE ALARM          ║
 ╚══════════════════════════════════════════════════════╝
";
        switch (menu)
        {
            case 1:
                Console.Write(startTask);
                break;
            case 2:
                Console.Write(startBreak);
                break;
            default:
                Console.Write(silenceAlarm);
                break;
        }
        
    }

    public static void StartTask(int taskTime)
    {
        GenerateBanner(1);
        Console.ReadKey();
        Thread.Sleep(taskTime);
    }

    public static void StartBreak(int breakTime)
    {
        GenerateBanner(2);
        Console.ReadKey();
        Thread.Sleep(breakTime);
    }

    public static void StartAlarm()
    {
        GenerateBanner(3);
        Console.BackgroundColor = ConsoleColor.Yellow;
        do
        {
            while (!Console.KeyAvailable)
            {
                Console.Beep();
                Thread.Sleep(500);
                Console.Write("█");
            }

        } while (Console.ReadKey(true).Key != ConsoleKey.Spacebar && Console.ReadKey(true).Key != ConsoleKey.Escape);
    }

}
