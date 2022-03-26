using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace FørsteSemesterEksamen
{
    public class PauseUI : UITextElement
    {
        public PauseUI(Vector2 position) : base(position)
        {
        }

        public override void Reset()
        {
            Stat = 0;
            ChangeText();
        }

        protected internal override void ChangeText()
        {
            text = "Paused";
        }

        public override void DrawText()
        {
            if (Gameworld.IsPaused && !Gameworld.IsGameOver)
                base.DrawText();
        }
    }
}
