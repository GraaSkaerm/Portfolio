using Network;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using UserInterface;

namespace GameClient
{
    enum MenuState
    {
        Lobby,
        Main,
        Login,
        Game,
    }

    static class App
    {
        public static MenuState MenuState { get; set; }

        public static bool IsGameRunning { get; set; }
        public static bool IsCursorBeingUsed { get; set; }

        private static object _lock = new object();

        public static TextBox ChatTextBox { get; set; }
        public static TextBox LobbyTextBox { get; set; }
        public static TextBox LogTextBox { get; set; }
        public static TextBox LeaderBoardTextBox { get; set; }
        public static TextBox QuestionTextBox { get; set; }

        public static User User { get; set; }

        public static Client Client { get; set; }
        public static Listener Listener { get; set; }

        public static IMenu Menu { get; set; }
        private static IMenu _prevMenu;

       public static void WaitUntilCursorCanBeUsed()
        {
            lock (_lock)
            {
                while (IsCursorBeingUsed)
                {

                }
            }
          
       }


        [DllImport("User32.Dll", EntryPoint = "PostMessageA")]
        private static extern bool _postMessage(IntPtr hWnd, uint msg, int wParam, int lParam);

        private const int _VK_RETURN = 0x0D;
        private const int _WM_KEYDOWN = 0x100;


        public static void Run()
        {
            Menu = new LoginMenu();

            while (true)
            {
                Menu.OnLoad();
                _prevMenu = Menu;

                while (Menu == _prevMenu)
                {
                    Menu.OnUpdate();
                }
            }
        }

   

        public static void AbortReadline(int waitTime)
        {
            Thread.Sleep(waitTime);
            var hWnd = System.Diagnostics.Process.GetCurrentProcess().MainWindowHandle;

            _postMessage(hWnd, _WM_KEYDOWN, _VK_RETURN, 0);
        }


    }
}
