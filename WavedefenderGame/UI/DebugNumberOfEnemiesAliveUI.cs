using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace FørsteSemesterEksamen
{
    public class DebugNumberOfEnemiesAliveUI : UITextElement
    {
        public DebugNumberOfEnemiesAliveUI(Vector2 position) : base(position)
        {
        }

        public override void Reset()
        {
            Stat = 0;
            ChangeText();
        }

        protected internal override void ChangeText()
        {
            text = $"Number of enemies alive: {Stat}";
        }
    }
}
