using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace FørsteSemesterEksamen
{
    class PlayerAnimator
    {
        private Animator animator;

        private PlayerCharacter playerCharacter;

        private bool isRunning;

        public Animator Animator { get => animator; }

        /// <summary>
        /// Describes a players animator.
        /// </summary>
        /// <param name="playerCharacter"></param>
        public PlayerAnimator(PlayerCharacter playerCharacter)
        {
            this.playerCharacter = playerCharacter;
            LoadAnimations();
        }

        /// <summary>
        /// Loads the players animations.
        /// </summary>
        private void LoadAnimations()
        {
            Dictionary<AnimationType, Animation> animations = new Dictionary<AnimationType, Animation>();

            Texture2D[] sprites = new Texture2D[4];
            sprites[0] = Gameworld.content.Load<Texture2D>("Sprites/PlayerRunAnimation1");
            sprites[1] = Gameworld.content.Load<Texture2D>("Sprites/PlayerRunAnimation2");
            sprites[2] = Gameworld.content.Load<Texture2D>("Sprites/PlayerRunAnimation3");
            sprites[3] = Gameworld.content.Load<Texture2D>("Sprites/PlayerRunAnimation4");


            animations.Add(AnimationType.Run, new Animation(sprites));

            animator = new Animator(animations);
            animator.PlayAnimation(AnimationType.Run);
        }

        /// <summary>
        /// Updates the animators animation.
        /// </summary>
        public void Update(GameTime gameTime)
        {
            if (isRunning == true)
            {
                animator.PlayAnimation(AnimationType.Run);
            }

            animator.UpdateFrame(gameTime);
            playerCharacter.Sprite = Animator.GetCurrentFrame();
        }
    }
}
