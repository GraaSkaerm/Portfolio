using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace FørsteSemesterEksamen
{
    class ZombieAnimator
    {
        private Animator animator;
        private ZombieCharacter zombieCharacter;

        public Animator Animator { get => animator; }

        /// <summary>
        /// Describes a zombies animator.
        /// </summary>
        /// <param name="zombieCharacter"></param>
        public ZombieAnimator(ZombieCharacter zombieCharacter)
        {
            this.zombieCharacter = zombieCharacter;
            LoadAnimations();
        }

        /// <summary>
        /// Loads the zombies animations.
        /// </summary>
        private void LoadAnimations()
        {
            Dictionary<AnimationType, Animation> animations = new Dictionary<AnimationType, Animation>();

            Texture2D[] sprites = new Texture2D[4];
            sprites[0] = Gameworld.content.Load<Texture2D>("Sprites/ZombieRunAnimation1");
            sprites[1] = Gameworld.content.Load<Texture2D>("Sprites/ZombieRunAnimation2");
            sprites[2] = Gameworld.content.Load<Texture2D>("Sprites/ZombieRunAnimation3");
            sprites[3] = Gameworld.content.Load<Texture2D>("Sprites/ZombieRunAnimation4");

            animations.Add(AnimationType.Run, new Animation(sprites));

            animator = new Animator(animations);
            animator.PlayAnimation(AnimationType.Run);
        }

        /// <summary>
        /// Updates the animators animation.
        /// </summary>
        public void Update(GameTime gameTime)
        {
            if (zombieCharacter.Health > 0)
            {
                animator.PlayAnimation(AnimationType.Run);
            }

            animator.UpdateFrame(gameTime);
            zombieCharacter.Sprite = Animator.GetCurrentFrame();
        }
    }
}
