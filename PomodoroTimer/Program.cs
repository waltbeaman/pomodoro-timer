namespace PomodoroTimer;
class Program
{

    public enum Menu
    {
        TaskTime,
        StartTask,
        BreakTime,
        StartBreak,
        Alarm
    }

    static void Main()
    {
        Console.SetWindowSize(58, 20);
        Console.SetBufferSize(58, 20);
        Console.Title = "Pomodoro Timer";

        // Create timer variables
        // 25 minutes work time and 5 minutes task time
        int taskTime = 1500000;
        int breakTime = 300000;

        // Test timer variables
        //int taskTime = 3000;
        //int breakTime = 3000;

        do
        {
            while (!Console.KeyAvailable)
            {
                Console.ResetColor();

                // Ask user to start task and load task timer
                GenerateBanner(Menu.StartTask);
                Console.ReadKey();

                // Start the task timer
                StartTask(taskTime);

                // Start the alarm
                StartAlarm();

                // Ask user to start break and load break timer
                Console.ResetColor();
                GenerateBanner(Menu.StartBreak);
                Console.ReadKey();
                StartBreak(breakTime);

                // Start the alarm
                StartAlarm();
            }

        } while (Console.ReadKey(true).Key != ConsoleKey.Escape);

        Environment.Exit(0); 
    }

    public static void StartTask(int taskTime)
    {
        GenerateBanner(Menu.TaskTime);
        Console.SetCursorPosition(2, 17);
        int clock = taskTime;
        int interval = taskTime / 53;
        while (clock > 0)
        {
            Console.Write("█");
            new ManualResetEvent(false).WaitOne(interval);
            clock -= interval;
        }
    }

    public static void StartBreak(int breakTime)
    {
        GenerateBanner(Menu.BreakTime);
        Console.SetCursorPosition(2, 17);
        int clock = breakTime;
        int interval = breakTime / 53;
        while (clock > 0)
        {
            Console.Write("█");
            new ManualResetEvent(false).WaitOne(interval);
            clock -= interval;
        }
    }

    public static void StartAlarm()
    {
        do
        {
            while (!Console.KeyAvailable)
            {
                Console.ResetColor();
                Console.BackgroundColor = ConsoleColor.Red;
                Console.ForegroundColor = ConsoleColor.Black;
                GenerateBanner(Menu.Alarm);
                Console.Beep();
                new ManualResetEvent(false).WaitOne(250);
                Console.ResetColor();
                GenerateBanner(Menu.Alarm);
                new ManualResetEvent(false).WaitOne(250);
            }
        } while (Console.ReadKey(true).Key != ConsoleKey.Spacebar && Console.ReadKey(true).Key != ConsoleKey.Escape);
    }

    public static void GenerateBanner(Enum menu)
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
        string taskTime = @"
 ║                     TASK TIME                        ║
 ╟──────────────────────────────────────────────────────╢
 ║                                                      ║
 ╚══════════════════════════════════════════════════════╝
";
        string startBreak = @"
 ║        PRESS THE SPACEBAR TO START THE BREAK         ║
 ╚══════════════════════════════════════════════════════╝
";
        string breakTime = @"
 ║                     BREAK TIME                       ║
 ╟──────────────────────────────────────────────────────╢
 ║                                                      ║
 ╚══════════════════════════════════════════════════════╝
";
        string silenceAlarm = @"
 ║        PRESS THE SPACEBAR TO STOP THE ALARM          ║
 ╚══════════════════════════════════════════════════════╝
";
        switch (menu)
        {
            case Menu.StartTask:
                Console.Write(startTask);
                break;
            case Menu.TaskTime:
                Console.Write(taskTime);
                break;
            case Menu.StartBreak:
                Console.Write(startBreak);
                break;
            case Menu.BreakTime:
                Console.Write(breakTime);
                break;
            case Menu.Alarm:
                Console.Write(silenceAlarm);
                break;
        }

    }

}
