using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace FørsteSemesterEksamen
{
    public abstract class Character2D : Gameobject, ICollideable, IMoveable
    {
        
        protected int speedFactor;
        protected Vector2 direction;

        public float Mass { get; set; } = 1;

        public Vector2 Direction { get => direction; set => direction = value; }

        public Character2D(Texture2D sprite, float layerDepth = 1f) : base(sprite, layerDepth)
        {
        }

        /// <summary>
        /// Take damage
        /// </summary>
        abstract public void TakeDamage(int damage);

        /// <summary>
        /// Move character
        /// </summary>
        /// <param name="gameTime">GameTime reference</param>
        abstract public void Move(GameTime gameTime);

        /// <summary>
        /// Called when character has collided with another gameobject
        /// </summary>
        /// <param name="other">Gameobject collided with</param>
        abstract public void OnCollision(Gameobject other);

        /// <summary>
        /// Character dies
        /// </summary>
        abstract protected void Die();

        abstract public void SetDirection();
    }
}
