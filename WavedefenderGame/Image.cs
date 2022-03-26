using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace FørsteSemesterEksamen
{
   public class Image : Gameobject
    {
        public Image(Vector2 position, Texture2D sprite, float layerDepth = 0f) : base(sprite, layerDepth)
        {
            this.position = position;
        }
    }
}
