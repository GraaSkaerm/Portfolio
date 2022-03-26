using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace FørsteSemesterEksamen
{
    class Pointer : Gameobject, IMoveable
    {
        private PlayerCharacter player;

        public Pointer() : base (Gameworld.content.Load<Texture2D>("Sprites/pointerV2"), 1f)
        {
        }

        public void Move(GameTime gameTime)
        {
            if (player == null)
            {
                player = GetPlayer();
            }

            base.position = player.Position + GetOffset();
            base.rotation = GetRotation();
        }

        private float GetRotation()
        {
             return ConvertDirection.ConvertToRotation(player.ShootDirection);
        } 

        private Vector2 GetOffset()
        {
            float offsetValue = 35;

            if (player.ShootDirection.X > 0 && player.ShootDirection.Y > 0) { return new Vector2(offsetValue - 5, offsetValue - 5); }
            if (player.ShootDirection.X < 0 && player.ShootDirection.Y > 0) { return new Vector2(-offsetValue + 5, offsetValue - 5); }
            if (player.ShootDirection.X > 0 && player.ShootDirection.Y < 0) { return new Vector2(offsetValue - 5, -offsetValue + 10); }
            if (player.ShootDirection.X < 0 && player.ShootDirection.Y < 0) { return new Vector2(-offsetValue + 5, -offsetValue + 10); }

            if (player.ShootDirection.X > 0) { return new Vector2(offsetValue, 5); }
            if (player.ShootDirection.X < 0) { return new Vector2(-offsetValue, 5); }
            if (player.ShootDirection.Y < 0) { return new Vector2(0, -offsetValue); }
            if (player.ShootDirection.Y > 0) { return new Vector2(0, offsetValue); }
            

            return Vector2.Zero;
        }

        private PlayerCharacter GetPlayer()
        {
            foreach (Gameobject gameobject in Gameworld.gameobjects)
            {
                if (gameobject is PlayerCharacter)
                {
                    return gameobject as PlayerCharacter;
                }
            }

            return null;
        }
    }
}
