using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace FørsteSemesterEksamen
{
   public abstract class UITextElement
    {
        protected string text;
        protected int stat;

        protected SpriteFont font;
        protected Vector2 position;

        public int Stat
        {
            get { return stat; }
            set
            {
                if (value < 0)
                {
                    stat = 0;
                }
                else
                {
                    stat = value;
                }

                ChangeText();
            }
        }


        public UITextElement(Vector2 position)
        {
            this.position = position;
            this.font = Gameworld.content.Load<SpriteFont>("standardFont");
        }

        public virtual void DrawText()
        {
            Gameworld.spriteBatch.Begin();

            Gameworld.spriteBatch.DrawString(font, text, position, Color.White);
            
            Gameworld.spriteBatch.End();
        }

        /// <summary>
        /// Ændrer teksten på UI's til at passe til de nuværende stats.
        /// </summary>
        protected internal abstract void ChangeText();

        public abstract void Reset();
        
            
    }
}
