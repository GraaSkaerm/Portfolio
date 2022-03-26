using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace FørsteSemesterEksamen
{
    public abstract class Pickup : Gameobject, ICollideable
    {
        public Pickup(Vector2 position, Texture2D sprite) : base(sprite, 0.5f)
        {
            this.position = position;
        }

        /// <summary>
        /// Called when colliding another gameobject
        /// </summary>
        /// <param name="other">Gameobject collided with</param>
        public void OnCollision(Gameobject other)
        {
            if (other is PlayerCharacter)
            {
                GivePowerup(other as PlayerCharacter);
                Gameworld.GarbageCan.Add(this);
            }
        }

        /// <summary>
        /// Give player powerup
        /// </summary>
        /// <param name="player">Player to give powerup</param>
        public abstract void GivePowerup(PlayerCharacter player);

    }
}
