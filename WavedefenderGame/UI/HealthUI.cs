using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace FørsteSemesterEksamen
{
    public class HealthUI : UITextElement
    {
        public HealthUI(Vector2 position) : base(position)
        {
        }

        public override void Reset()
        {
            Stat = 100;
            ChangeText();
        }

        protected internal override void ChangeText()
        {
           text = $"Health: {Stat}";
        }
    }
}
