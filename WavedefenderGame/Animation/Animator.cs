using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace FørsteSemesterEksamen
{
    class Animator
    {
        private Dictionary<AnimationType, Animation> animations;

        private Animation animation;

        private float timer;

        
        public Texture2D CurrentFrame { get; set; }

        /// <summary>
        /// Describes an animator. Which holds animations.
        /// </summary>
        /// <param name="animations"></param>
        public Animator(Dictionary<AnimationType, Animation> animations)
        {
            this.animations = animations;
        }

        /// <summary>
        /// Plays a wanted animation.
        /// </summary>
        /// <param name="name"></param>
        public void PlayAnimation(AnimationType animationType)
        {
            Animation animation = animations[animationType];

            if (this.animation == animation) { return; }

            this.animation = animation;

            this.animation.CurrentFrameIndex = 0;

            timer = 0;
        }

        /// <summary>
        /// Updates what frame that is the current frame.
        /// </summary>
        /// <param name="gameTime"></param>
        public void UpdateFrame(GameTime gameTime)
        {
            timer += (float)gameTime.ElapsedGameTime.TotalSeconds;

            if (timer > animation.TimeBetweenFrames)
            {
                timer = 0f;

                animation.CurrentFrameIndex++;

                if (animation.CurrentFrameIndex >= animation.FrameCount)
                {
                    animation.CurrentFrameIndex = 0;
                }
            }
        }

        /// <summary>
        /// Returns the animaitons current frame.
        /// </summary>
        /// <param name="spriteBatch"></param>
        /// <param name="position"></param>
        public Texture2D GetCurrentFrame()
        {
            return animation.Frames[animation.CurrentFrameIndex];
        }
    }

    public enum AnimationType
    {
        Run,
    }
}
