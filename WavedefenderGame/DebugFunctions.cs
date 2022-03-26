using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace FørsteSemesterEksamen
{
    static class DebugFunctions
    {
        public static Texture2D MakeSquare(GraphicsDevice graphicDevice, int size, Color color)
        {
            Texture2D square = new Texture2D(graphicDevice, size, size);
            SetColor(color, square);

            return square;
        }

        public static void SetColor(Color color, Texture2D sprite)
        {

            int spriteSize = sprite.Width * sprite.Height;
            Color[] colorData = new Color[spriteSize];

            for (int i = 0; i < spriteSize; i++)
            {
                colorData[i] = color;
            }


            sprite.SetData<Color>(colorData);
        }

        public static void DrawWireSquare(SpriteBatch spriteBatch, Rectangle rectangle, int lineWidth)
        {
            int x = rectangle.X;
            int y = rectangle.Y;
            int width = rectangle.Width;
            int height = rectangle.Height;

            Texture2D pixel = MakeSquare(Gameworld._graphics.GraphicsDevice, 1, Color.Blue);

            Rectangle topLine = new Rectangle(x, y, width, lineWidth);
            Rectangle botLine = new Rectangle(x, y + height, width + lineWidth, lineWidth);
            Rectangle rightLine = new Rectangle(x + width, y, lineWidth, height);
            Rectangle leftLine = new Rectangle(x, y, lineWidth, height);

            spriteBatch.Draw(pixel, topLine, Color.White);
            spriteBatch.Draw(pixel, botLine, Color.White);
            spriteBatch.Draw(pixel, rightLine, Color.White);
            spriteBatch.Draw(pixel, leftLine, Color.White);

        }
    }
}
