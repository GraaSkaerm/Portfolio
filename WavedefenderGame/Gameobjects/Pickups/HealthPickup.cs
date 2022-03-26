using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace FørsteSemesterEksamen
{
    class HealthPickup : Pickup
    {
        private int healthAmount = 100;

        public HealthPickup(Vector2 position) : base(position, Gameworld.content.Load<Texture2D>("Sprites/HearthPowerUp"))
        {
            this.position = position;
        }

        /// <summary>
        /// Give health to player
        /// </summary>
        /// <param name="player">Player to give health to</param>
        public override void GivePowerup(PlayerCharacter player)
        {
            player.Health += healthAmount;
        }
    }
}
