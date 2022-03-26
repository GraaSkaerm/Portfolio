using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace FørsteSemesterEksamen
{
    public class GameoverUI : UITextElement
    {

        public GameoverUI(Vector2 position) : base(position)
        {
        }

        public override void Reset()
        {
            Stat = UIManager.highscoreUI.Stat;
            ChangeText();
        }

        protected internal override void ChangeText()
        {
            text = $"Score: {UIManager.highscoreUI.Stat}";
        }

        public override void DrawText()
        {
            if (Gameworld.IsGameOver)
            {
                ChangeText();
                Gameworld.spriteBatch.Begin();

                Gameworld.spriteBatch.DrawString(font, "Game Over", position, Color.White);
                Gameworld.spriteBatch.DrawString(font, text, position + new Vector2(0, 30), Color.White);
                Gameworld.spriteBatch.DrawString(font, $"Wave reached: {UIManager.waveCountUI.Stat}", position + new Vector2(0, 60), Color.White);
                Gameworld.spriteBatch.DrawString(font, "Press 'R' to restart", position + new Vector2(0, 90), Color.White);

                Gameworld.spriteBatch.End();
            }
        }
    }
}
