using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace FørsteSemesterEksamen
{
   public class WaveCountUI : UITextElement
    {
        public WaveCountUI(Vector2 position) : base(position)
        {
        }

        public override void Reset()
        {
            Stat = 1;
            ChangeText();
        }

        protected internal override void ChangeText()
        {
            base.text = $"Wave: {Stat}";
        }
    }
}
