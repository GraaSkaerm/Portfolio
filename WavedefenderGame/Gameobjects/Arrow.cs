using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace FørsteSemesterEksamen
{
    class Arrow : Gameobject, ICollideable, IMoveable
    {
        private float speedFactor = 300;
        private Vector2 velocity;
        private int damage = 50;

        public int Damage { get => damage; }

        public Arrow(Vector2 startPosition, Vector2 velocity) : base(Gameworld.content.Load<Texture2D>("Sprites/Arrow"))
        {
            Position = startPosition;
            this.velocity = velocity;
            this.rotation = ConvertDirection.ConvertToRotation(velocity);
        }

        /// <summary>
        /// Move Arrow through space
        /// </summary>
        /// <param name="gameTime"></param>
        public void Move(GameTime gameTime)
        {
            float deltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;

            this.Position += (velocity * speedFactor) * deltaTime;
        }

        /// <summary>
        /// destroy on collision and give damage if colliding with zombie
        /// </summary>
        /// <param name="other"></param>
        public void OnCollision(Gameobject other)
        {
            if (!(other is PlayerCharacter) && !(other is Arrow) && !(other is AmmoPickup) && !(other is HealthPickup))
            {
                if (other is ZombieCharacter)
                    (other as ZombieCharacter).TakeDamage(Damage);

                Gameworld.GarbageCan.Add(this);
            }
        }
    }
}
