using System;
using System.Runtime.InteropServices;


namespace PokemonCMD
{
    class Program
    {
        #region MaximizeWindow
        [DllImport("kernel32.dll", ExactSpelling = true)]
        private static extern IntPtr GetConsoleWindow();
        private static IntPtr ThisConsole = GetConsoleWindow();
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);
        private const int HIDE = 0;
        private const int MAXIMIZE = 3;
        private const int MINIMIZE = 6;
        private const int RESTORE = 9;
        #endregion MaximizeWindow
        static void Main(string[] args)
        {
            SetConsoleVisualSettings();
            GameManager.StartGame();
        }

        private static void SetConsoleVisualSettings()
        {
            #region Maximize
            Console.SetWindowSize(Console.LargestWindowWidth, Console.LargestWindowHeight);
            ShowWindow(ThisConsole, MAXIMIZE);
            #endregion Maximize 
            Console.Title = "Pokemon: Return of the Database";
            ConsoleHelper.SetCurrentFont("MS Gothic", 36);
            Console.Clear();
        }
    }
}
