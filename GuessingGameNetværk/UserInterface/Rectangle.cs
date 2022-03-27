using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserInterface
{
    public class Rectangle
    {
        private int _x;
        private int _y;

        private int _width;
        private int _height;

        public int Width { get => _width; }
        public int Height { get => _height; }

        public int X { get => _x; set => _x = value; }
        public int Y { get => _y; set => _y = value; }

        public Rectangle(int x, int y, int width, int height)
        {
            _x = x;
            _y = y;
            _width = width;
            _height = height;
        }

        public void Print()
        {
            Console.SetCursorPosition(_x, _y);
            Console.WriteLine(GetHorizontalSide());

            for (int i = 0; i < _height; i++)
            {
                Console.SetCursorPosition(_x, _y + i + 1);
                Console.Write("|");
                Console.SetCursorPosition(_x + _width - 1, _y + i + 1);
                Console.Write("|");
            }

            Console.SetCursorPosition(_x, _y + _height + 1);
            Console.WriteLine(GetHorizontalSide());
        }

        private string GetHorizontalSide()
        {
            string s = null;

            for (int cell = 0; cell < _width; cell++)
            {
                if (cell == 0 || cell == _width - 1)
                {
                    s += "+";
                    continue;
                }

                s += "-";
            }

            return s;
        }


    }
}
