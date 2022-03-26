using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace FørsteSemesterEksamen
{
    public class ZombieCharacter : Character2D, ICollideable, IMoveable, IAnimateable
    {
        private int health = 100;
        private int damage = 5;

        private PlayerCharacter player;

        private RepelSystem repelSystem = new RepelSystem();
        private ZombieAnimator zombieAnimator;

        private float attackTimer = 0;
        private float attackCooldown = 1f;
        private float collideCooldown = 1f;
        private float collideTimer = 0;

        public int Health
        {
            get
            {
                return health;
            }
            set
            {
                if (value <= 0)
                {
                    Die();
                }
                else
                {
                    health = value;
                }
            }
        }

        private bool CanAttack
        {
            get
            {
                if (attackTimer >= attackCooldown)
                {
                    attackTimer = 0;
                    return true;
                }

                return false;
            }
        }

        public bool CanCollide
        {
            get
            {
                if (collideTimer >= collideCooldown)
                {
                    return true;
                }

                return false;
            }
        }

        public ZombieCharacter(Vector2 positon) : base(Gameworld.content.Load<Texture2D>("Sprites/ZombieRunAnimation1"), 0.9f)
        {
            this.Position = positon;

            UIManager.DebugNumberOfEnemiesAlive.Stat++;
            this.health = 100;
            this.speedFactor = new Random().Next(70, 110);

            zombieAnimator = new ZombieAnimator(this);
        }

        public override void SetDirection()
        {
            if (player == null)
                AquireTarget();

            FollowTarget(player);
        }

        public override void OnCollision(Gameobject other)
        {
            if (other is Wall || other is ZombieCharacter && other != this)
            {
                if (CanCollide)
                {
                    repelSystem.InputDirection(this, other);
                }
            }
            else if (other is PlayerCharacter)
            {
                repelSystem.InputDirection(this, other);
                Attack(other as PlayerCharacter);
            }
        }

        public override void Move(GameTime gameTime)
        {
            FlipSprite();

            float deltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;

            attackTimer += deltaTime;
            collideTimer += deltaTime;

            Vector2 velocity = direction * speedFactor;
            Position += velocity * deltaTime;
        }

        private void AquireTarget()
        {
            foreach (Gameobject go in Gameworld.gameobjects)
            {
                if (go is PlayerCharacter)
                {
                    player = go as PlayerCharacter;
                }
            }
        }

        public void Animate(GameTime gameTime)
        {
            zombieAnimator.Update(gameTime);
        }

        private void Attack(PlayerCharacter player)
        {
            if (CanAttack)
            {
                player.Health -= damage;
            }
        }

        public override void TakeDamage(int damage)
        {
            Health -= damage;
        }

        protected override void Die()
        {
            AudioManager.PlaySound(AudioManager.Sound.Oof);
            Gameworld.GarbageCan.Add(this);
            WaveManager.ZombiesKilled++;
            UIManager.DebugNumberOfEnemiesAlive.Stat--;

            // Spawner en ammopickup hver gang spilleren har dræbt 20 zombier, der giver spilleren 60 ammo, hvis spilleren samler den op.
            if (WaveManager.ZombiesKilled % 20 == 0)
            {
                Gameworld.AddGameobjects.Add(new AmmoPickup(this.Position));
            }

            // Spawner en healthpickup hver gang man har nakket 50 zombier, der giver spilleren 50 liv, hvis spilleren samler den op.
            if (WaveManager.ZombiesKilled % 50 == 0)
            {
                Gameworld.AddGameobjects.Add(new HealthPickup(this.Position));
            }

            UIManager.highscoreUI.Stat += 100;

            WaveManager.IsZombieKilled = true;

        }

        /// <summary>
        /// Zombien følger efter spilleren.
        /// </summary>
        /// <param name="target">Target to follow</param>
        private void FollowTarget(PlayerCharacter target)
        {
            if (target != null)
                direction = target.Position - this.position;

            if (direction != Vector2.Zero)
            {
                direction.Normalize();
            }
        }

        private void FlipSprite()
        {
            if (direction.X > 0)
            {
                spriteEffect = SpriteEffects.None;
            }
            else
            {
                spriteEffect = SpriteEffects.FlipHorizontally;
            }
        }

    }
}
