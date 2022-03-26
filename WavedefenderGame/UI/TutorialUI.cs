using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace FørsteSemesterEksamen
{
    public class TutorialUI : UITextElement
    {
        string initialText;

        public TutorialUI(Vector2 position, String text) : base(position)
        {
            this.text = text;
            initialText = text;
        }

        public override void Reset()
        {
            text = initialText;
        }

        protected internal override void ChangeText()
        {
            
        }

        public void Clear()
        {
            text = String.Empty;
        }

        public override void DrawText()
        {
            if (Gameworld.tutorial != null)
                base.DrawText();
        }
    }
}
