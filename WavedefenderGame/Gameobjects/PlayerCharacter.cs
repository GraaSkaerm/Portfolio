using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace FørsteSemesterEksamen
{
    public class PlayerCharacter : Character2D, ICollideable, IMoveable, IAnimateable
    {
        private int health;
        private int ammo;

        private RepelSystem repelSystem = new RepelSystem();
        private PlayerAnimator playerAnimator;

        private Vector2 shootDirection;

        private float shootTimer = 0;
        private float shootCooldown = 0.2f;

        public Vector2 ShootDirection { get => shootDirection; }

        /// <summary>
        /// Current health of player
        /// </summary>
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
                    health = 0;
                    UIManager.healthUI.Stat = health;
                    Die();
                }
                else if (value > 100)
                {
                    health = 100;
                }
                else
                {
                    health = value;
                }

                UIManager.healthUI.Stat = health;
            }
        }

        /// <summary>
        /// Propertien Ammo sørger for at max ammo = 200. 
        /// </summary>
        public int Ammo
        {
            get
            {
                return ammo;
            }
            set
            {
                if (value < 0)
                {
                    ammo = 0;
                }
                else if (value > 200)
                {
                    ammo = 200;
                }
                else
                {
                    ammo = value;
                }

                UIManager.ammoUI.Stat = ammo;
            }
        }

        /// <summary>
        /// Is player able to shoot
        /// </summary>
        /// <returns>True if the player can shoot else false</returns>
        private bool CanShoot
        {
            get
            {
                if (Ammo > 0)
                {
                    if (shootTimer >= shootCooldown)
                    {
                        shootTimer = 0;
                        return true;
                    }
                }

                return false;
            }
        }

        public PlayerCharacter(float layerDepth = 1f) : base(Gameworld.content.Load<Texture2D>("Sprites/PlayerRunAnimation1"), layerDepth)
        {
            // Start position
            this.Position = new Vector2(Gameworld.Screensize.X / 2, Gameworld.Screensize.Y / 2);

            this.speedFactor = 125;
            this.Health = 100;
            this.Ammo = 100;
            this.shootDirection = new Vector2(0, -1);

            playerAnimator = new PlayerAnimator(this);
        }

        public override void SetDirection()
        {
            HandleInput();
        }

        public override void OnCollision(Gameobject other)
        {
            if (other is Wall || other is ZombieCharacter)
            {
                repelSystem.InputDirection(this, other);
            }
        }

        public override void Move(GameTime gameTime)
        {
            float deltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;

            shootTimer += deltaTime;

            Vector2 velocity = direction * speedFactor;
            Position += velocity * deltaTime;
        }

        public void Animate(GameTime gameTime)
        {
            playerAnimator.Update(gameTime);
        }

        /// <summary>
        /// Change direction based on key input
        /// </summary>
        private void HandleInput()
        {
            // Reset direction
            direction = Vector2.Zero;

            // Get keyboard state
            KeyboardState keyState = Keyboard.GetState();

            // Up
            if (keyState.IsKeyDown(Keys.W))
            {
                direction += new Vector2(0, -1);
            }

            // Down
            if (keyState.IsKeyDown(Keys.S))
            {
                direction += new Vector2(0, 1);
            }

            // Left
            if (keyState.IsKeyDown(Keys.A))
            {
                direction += new Vector2(-1, 0);
                spriteEffect = SpriteEffects.FlipHorizontally;
            }

            // Right
            if (keyState.IsKeyDown(Keys.D))
            {
                direction += new Vector2(1, 0);
                spriteEffect = SpriteEffects.None;
            }

            // Space
            if (keyState.IsKeyDown(Keys.Space))
            {
                Shoot();
            }

            // Normalize vector if moving
            if (direction != Vector2.Zero)
            {
                direction.Normalize();
                shootDirection = direction;
            }
        }

        /// <summary>
        /// Add health to players health
        /// </summary>
        /// <param name="health">Health to add to players health</param>
        public void TakeHealth(int health)
        {
            this.Health += health;
        }

        public override void TakeDamage(int damage)
        {
            Health -= damage;
        }

        /// <summary>
        /// Add ammo to players ammo
        /// </summary>
        /// <param name="ammo">Ammo to add to players ammo</param>
        public void TakeAmmo(int ammo)
        {
            this.ammo += ammo;
        }

        protected override void Die()
        {
            UIManager.healthUI.Stat = health;
            Gameworld.IsGameOver = true;
            Gameworld.GarbageCan.Add(this);
        }

        /// <summary>
        /// Player shoots
        /// </summary>
        private void Shoot()
        {
            if (CanShoot)
            {
                Ammo--;
                Gameworld.AddGameobjects.Add(new Arrow(Position, ShootDirection));
                AudioManager.PlaySound(AudioManager.Sound.Gunshot);
            }
        }
    }
}
