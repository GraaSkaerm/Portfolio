using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserInterface
{
    public static class ConsoleEditor
    {
        public static void ClearLine(int width)
        {
            int x = Console.CursorLeft;
            int y = Console.CursorTop;
            Console.Write(new string(' ', width));
            Console.SetCursorPosition(x, y);
        }

    }
}
