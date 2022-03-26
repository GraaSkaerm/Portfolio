using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace FørsteSemesterEksamen
{
    class Wall : Gameobject, ICollideable
    {
        public Wall(Vector2 position, Texture2D sprite, float layerDepth = 1f) : base(sprite, layerDepth)
        {
            Position = position;
        }


        public void Instantiate()
        {
            Gameworld.AddGameobjects.Add(this);
        }

        /// <summary>
        /// Called when wall has collided with another gameobject
        /// </summary>
        /// <param name="other">Gameobject collided with</param>
        public void OnCollision(Gameobject other)
        {
            //does nothing player handles collision
        }
    }
}
