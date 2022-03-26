using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace FørsteSemesterEksamen
{
    public class Gameworld : Game
    {
        private SpriteBatch _spriteBatch;
        public static GraphicsDeviceManager _graphics;
        public static ContentManager content;
        public static SpriteBatch spriteBatch;
        public static Tutorial tutorial;

        public static List<Gameobject> gameobjects = new List<Gameobject>();
        public static List<Gameobject> AddGameobjects = new List<Gameobject>();
        public static List<Gameobject> GarbageCan = new List<Gameobject>();

        public static Vector2 Screensize;

        public static bool IsPaused = false;

        private float pauseTimer = 0;
        private float pauseCooldown = 0.2f;

        private static bool isGameOver = false;

        private bool CanPause
        {
            get
            {
                if (pauseTimer >= pauseCooldown)
                {
                    pauseTimer = 0;
                    return true;
                }

                return false;
            }
        }


        public static bool IsGameOver
        {
            get
            {
                return isGameOver;
            }
            set
            {
                isGameOver = value;
            }
        }

        public Gameworld()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;

            Screensize = new Vector2(_graphics.PreferredBackBufferWidth, _graphics.PreferredBackBufferHeight);
        }

        protected override void Initialize()
        {
            Window.Title = "Gruppe 6";
            content = Content;
            UIManager.ResetUI();
            AudioManager.LoadAudio();
            GameManager.InitializeGame();
            base.Initialize();
            
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            spriteBatch = _spriteBatch;
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();


            if (Keyboard.GetState().IsKeyDown(Keys.P) && CanPause)
            {
                IsPaused = !IsPaused;
            }

            pauseTimer += (float)gameTime.ElapsedGameTime.TotalSeconds;
            
            if (!IsGameOver)
            {
                if (!IsPaused)
                {
                    tutorial?.CheckIfCompleted();
                    SetDirections();
                    DoCollisions();
                    MoveObjects(gameTime);
                    AnimateObjects(gameTime);

                    if (tutorial == null)
                        SpawnNextWave();

                    ZombieSpawner.SpawnZombies(gameTime);
                    WaveManager.SpawnWastedZombie(gameTime);
                    GameManager.CheckPlayerAmmo();
                    AddNewGameobjects();
                    DestroyGameobjects();

                    base.Update(gameTime);
                }
            }

            if (Keyboard.GetState().IsKeyDown(Keys.R) && IsGameOver)
            {
                IsGameOver = false;
                GameManager.ResetGame();
            }

        }

        private void SpawnNextWave()
        {
            if (WaveManager.ZombiesKilled == WaveManager.ZombiesToKill)
            {
                WaveManager.NextWave();
            }
        }

        /// <summary>
        /// Draw all gameobjects
        /// </summary>
        private void DrawObjects()
        {
            _spriteBatch.Begin(SpriteSortMode.FrontToBack);

            foreach (Gameobject go in gameobjects)
            {
                go.Draw();
            }

            _spriteBatch.End();
        }

        private void SetDirections()
        {
            foreach (Gameobject go in gameobjects)
            {
                if (go is Character2D charcter2D)
                {
                    charcter2D.SetDirection();
                }
            }
        }

        private void DoCollisions()
        {
            // Loop through all gameobjects as go
            foreach (Gameobject go in gameobjects)
            {
                // Loop though all gameobjects again as other
                foreach (Gameobject other in gameobjects)
                {
                    if (go != other)
                    {
                        // If both gameobjects is ICollideable
                        if (go is ICollideable goCollideable && other is ICollideable otherCollideable)
                        {
                            // If the gameobjects intersects
                            if (go.HitBox.Intersects(other.HitBox))
                            {
                                goCollideable.OnCollision(other);
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Move all moveable gameobjects
        /// </summary>
        /// <param name="gameTime">GameTime reference</param>
        private void MoveObjects(GameTime gameTime)
        {
            foreach (Gameobject go in gameobjects)
            {
                // Check if gameobject is moveable
                if (go is IMoveable moveable)
                {
                    moveable.Move(gameTime);
                }
            }
        }

        /// <summary>
        /// Animates all animatable gameobjects.
        /// </summary>
        private void AnimateObjects(GameTime gameTime)
        {
            foreach (Gameobject go in gameobjects)
            {
                // Check if gameobject is animatable
                if (go is IAnimateable animateable)
                {
                    animateable.Animate(gameTime);
                }
            }
        }

        /// <summary>
        /// Destroy all gameobjects in list GarbageCan and delete them from list gameobjects
        /// </summary>
        private void DestroyGameobjects()
        {
            foreach (Gameobject go in GarbageCan)
            {
                gameobjects.Remove(go);
            }

            GarbageCan.Clear();
        }

        /// <summary>
        /// Add gameobjects that is in list AddGameobjects to list gameobjects
        /// </summary>
        private void AddNewGameobjects()
        {
            foreach (Gameobject go in AddGameobjects)
            {
                gameobjects.Add(go);
            }

            AddGameobjects.Clear();
        }


        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            // TODO: Add your drawing code here
            DrawObjects();
            UIManager.DrawUI();

            base.Draw(gameTime);
        }
    }
}
