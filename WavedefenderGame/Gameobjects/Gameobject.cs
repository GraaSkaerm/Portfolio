using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace FørsteSemesterEksamen
{
    public abstract class Gameobject
    {
        protected Texture2D sprite;
        protected Vector2 position;

        protected SpriteEffects spriteEffect;
        protected float rotation;
        protected float layerDepth;

        public Texture2D Sprite { get => sprite; set => sprite = value; }

        /// <summary>
        /// Position of gameobject
        /// </summary>
        public Vector2 Position
        {
            get
            {
                return position;
            }
            set
            {
                position = value;
            }
        }

        /// <summary>
        /// Collider of gameobject (Edges of sprite)
        /// </summary>
        public Rectangle HitBox
        {
            get
            {
                return new Rectangle((int)GetRectanglePosition().X, (int)GetRectanglePosition().Y, sprite.Width, sprite.Height);
            }
        }


        public Gameobject(Texture2D sprite, float layerDepth = 0.9f)
        {
            this.sprite = sprite;
            this.spriteEffect = SpriteEffects.None;
            this.rotation = 0f;
            this.layerDepth = layerDepth;
        }


        public Vector2 GetRectanglePosition()
        {
            float x = position.X - sprite.Width / 2;
            float y = position.Y - sprite.Height / 2;

            return new Vector2(x, y);
        }

        /// <summary>
        /// Draw gameobject sprite
        /// </summary>
        public void Draw()
        {
            Gameworld.spriteBatch.Draw(Sprite, Position, null, Color.White, rotation, sprite.Bounds.Center.ToVector2(), 1f, spriteEffect, layerDepth);
        }

    }
}
