using System;
using System.Collections.Generic;
using System.Text;

namespace PokemonCMD
{
    public enum TextAlignment { Left, Center, Right}
    public static class TextPrinter
    {
        public static void Print(string text, TextAlignment alignment = TextAlignment.Center)
        {
            switch (alignment)
            {
                case TextAlignment.Left:
                    Console.WriteLine(text);
                    break;
                case TextAlignment.Center:
                    Console.SetCursorPosition((Console.LargestWindowWidth - text.Length) / 2, Console.CursorTop);
                    Console.WriteLine(text);
                    Console.SetCursorPosition((Console.LargestWindowWidth - text.Length) / 2, Console.CursorTop);
                    break;
                case TextAlignment.Right:
                    Console.SetCursorPosition((Console.LargestWindowWidth - (text.Length + 2)), Console.CursorTop);
                    Console.WriteLine(text);
                    Console.SetCursorPosition((Console.LargestWindowWidth - text.Length) / 2, Console.CursorTop);
                    break;
                default:
                    break;
            }
        }


    }
}
