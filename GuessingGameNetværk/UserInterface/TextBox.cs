using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserInterface
{
    public class TextBox
    {
        private int _lineWidth;

        private string _header;
        private string[] _lines;

        private Rectangle _headerRectangle;
        private Rectangle _linesRectangle;

        private InsertDirection _insertDirection;

        public string Header
        {
            get
            {
                return _header;
            }

            set
            {
                _header = value;
                PrintTitle();
            }
        }


        public TextBox(Rectangle rectangle)
        {
            _lineWidth = rectangle.Width - 2;
            _lines = new string[rectangle.Height];
            _headerRectangle = new Rectangle(rectangle.X, rectangle.Y, rectangle.Width, 1);
            _linesRectangle = new Rectangle(rectangle.X, rectangle.Y + 2, rectangle.Width, rectangle.Height);
        }
        public TextBox(Rectangle rectangle, InsertDirection insertDirection)
        {
            _lineWidth = rectangle.Width - 2;
            _insertDirection = insertDirection;
            _lines = new string[rectangle.Height];
            _headerRectangle = new Rectangle(rectangle.X, rectangle.Y, rectangle.Width, 1);
            _linesRectangle = new Rectangle(rectangle.X, rectangle.Y + 2, rectangle.Width, rectangle.Height);
        }
        public TextBox(string header, Rectangle rectangle)
        {
            _header = header;
            _lineWidth = rectangle.Width - 2;
            _lines = new string[rectangle.Height];
            _headerRectangle = new Rectangle(rectangle.X, rectangle.Y, rectangle.Width, 1);
            _linesRectangle = new Rectangle(rectangle.X, rectangle.Y + 2, rectangle.Width, rectangle.Height);
        }
        public TextBox(string header, Rectangle rectangle, InsertDirection insertDirection)
        {
            _header = header;
            _lineWidth = rectangle.Width - 2;
            _insertDirection = insertDirection;
            _lines = new string[rectangle.Height];
            _headerRectangle = new Rectangle(rectangle.X, rectangle.Y, rectangle.Width, 1);
            _linesRectangle = new Rectangle(rectangle.X, rectangle.Y + 2, rectangle.Width, rectangle.Height);
        }

        public void ClearAllLines()
        {
            for (int i = 0; i < _lines.Length; i++)
            {
                _lines[i] = "";
            }
            PrintLines();
        }

        public void ReplaceLineAt(int index, string line)
        {
            _lines[index] = line;
            PrintLine(index);
        }

        public void AddLine(string line)
        {
            if (line == "") return;

            if (line.Length > _lineWidth)
            {
                AddLongLine(line);
                return;
            }

            switch (_insertDirection)
            {
                case InsertDirection.TopToBottom: AddLineFromTopToBottom(line); break;
                case InsertDirection.BottomToTop: AddLineFromBottomToTop(line); break;
                default: throw new Exception();
            }
            PrintLines();
        }

        private void AddLines(string a, string b)
        {
            if (a[0] == ' ')
            {
                a = ReplaceCharacterAt(0, a, new char());
            }

            AddLine(a);
            AddLine(b);
        }
        private void AddLongLine(string line)
        {
            string a = line.Substring(0, _lineWidth);
            string b = line.Substring(_lineWidth - 1, line.Length - _lineWidth + 1);

            a = ReplaceCharacterAt(_lineWidth - 1, a, '-');



            switch (_insertDirection)
            {
                case InsertDirection.TopToBottom: AddLines(b, a); break;
                case InsertDirection.BottomToTop: AddLines(a, b); break;
                default: break;
            }


        }
        private void AddLineFromTopToBottom(string line)
        {
            int length = _lines.Length - 1;
            for (int row = 0; row < _lines.Length - 1; row++)
            {
                _lines[length - row] = _lines[length - row - 1];
            }
            _lines[0] = line;
        }
        private void AddLineFromBottomToTop(string line)
        {
            for (int row = 0; row < _lines.Length - 1; row++)
            {
                _lines[row] = _lines[row + 1];
            }
            _lines[_lines.Length - 1] = line;
        }

        public void Print()
        {
            PrintFrames();
            PrintTitle();
            PrintLines();
        }

        public void PrintFrames()
        {
            _headerRectangle.Print();
            _linesRectangle.Print();
        }

        private void PrintTitle()
        {
            Console.SetCursorPosition(_headerRectangle.X + 1, _headerRectangle.Y + 1);
            ConsoleEditor.ClearLine(_lineWidth);
            Console.SetCursorPosition(_headerRectangle.X + 1, _headerRectangle.Y + 1);
            Console.Write(_header);
        }

        public void PrintLines()
        {
            int x = _linesRectangle.X;
            int y = _linesRectangle.Y;

            for (int row = 0; row < _lines.Length; row++)
            {
                Console.SetCursorPosition(x + 1, y + row + 1);

                ConsoleEditor.ClearLine(_lineWidth);

                Console.SetCursorPosition(x + 1, y + row + 1);
                Console.Write(_lines[row]);
            }

        }

        private void PrintLine(int index)
        {
            int x = _linesRectangle.X;
            int y = _linesRectangle.Y;

            Console.SetCursorPosition(x + 1, y + index + 1);

            ConsoleEditor.ClearLine(_lineWidth);

            Console.SetCursorPosition(x + 1, y + index + 1);
            Console.Write(_lines[index]);

        }


        private string ReplaceCharacterAt(int index, string s, char c)
        {
            StringBuilder wantedString = new StringBuilder(s);
            wantedString[index] = c;
            return wantedString.ToString();
        }
    }
}
