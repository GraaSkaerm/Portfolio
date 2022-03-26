using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace FørsteSemesterEksamen
{
    class AmmoPickup : Pickup
    {
        private int ammoAmount = 60;

        public AmmoPickup(Vector2 position) : base(position, Gameworld.content.Load<Texture2D>("Sprites/AmmoPickup_small"))
        {
        }

        /// <summary>
        /// Give ammo to player
        /// </summary>
        /// <param name="player">Player to give ammo to</param>
        public override void GivePowerup(PlayerCharacter player)
        {
            player.Ammo += ammoAmount;
        }
    }
}
