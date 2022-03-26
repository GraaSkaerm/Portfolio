using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace FørsteSemesterEksamen
{
    public static class GameManager
    {

        public static void InitializeGame()
        {
            SpawnGameScene();
            Gameworld.tutorial = new Tutorial();
        }


        public static void ResetGame()
        {
            DeleteGameScene();

            // Reset UI
            UIManager.ResetUI();

            // Reset Wavemanager
            WaveManager.Reset();

            // Stop Audio via AudioManager
            AudioManager.StopAllAudio();

            SpawnGameScene();
        }

        /// <summary>
        /// Hvis spillerens ammo ryger under 0, så spawnes der en nyt ammo pickup powerup i midten af banen.
        /// </summary>
        public static void CheckPlayerAmmo()
        {
            foreach (Gameobject go in Gameworld.gameobjects)
            {
                if (go is PlayerCharacter)
                {
                    if ((go as PlayerCharacter).Ammo == 0)
                    {
                        Gameworld.AddGameobjects.Add(new AmmoPickup(new Vector2(Gameworld.Screensize.X / 2, Gameworld.Screensize.Y / 2)));
                    }
                }
            }
        }


        private static void DeleteGameScene()
        {
            foreach (Gameobject gameobject in Gameworld.gameobjects)
            {
                Gameworld.GarbageCan.Add(gameobject);
            }
        }

        /// <summary>
        /// Spawner alle vægge på banen.
        /// </summary>
        private static void SpawnGameScene()
        {
            AudioManager.PlaySong(AudioManager.Track.SeaShanty);

            // Load sprites into variables
            Texture2D FloorSprite = Gameworld.content.Load<Texture2D>("Sprites/Floor");
            Texture2D TopWallSprite = Gameworld.content.Load<Texture2D>("Sprites/TopWall");
            Texture2D LeftWallSprite = Gameworld.content.Load<Texture2D>("Sprites/LeftWall");
            Texture2D RightWallSprite = Gameworld.content.Load<Texture2D>("Sprites/RightWall");
            Texture2D BottomWallSprite = Gameworld.content.Load<Texture2D>("Sprites/BottomWall");


            Gameworld.AddGameobjects.Add(new PlayerCharacter());

            // Top walls
            Gameworld.AddGameobjects.Add(new Wall(new Vector2(TopWallSprite.Width / 2 + TopWallSprite.Width * 0, -TopWallSprite.Height / 2 + 5), TopWallSprite, 0.2f));
            Gameworld.AddGameobjects.Add(new Wall(new Vector2(TopWallSprite.Width / 2 + TopWallSprite.Width * 1, -TopWallSprite.Height / 2 + 5), TopWallSprite, 0.2f));
            Gameworld.AddGameobjects.Add(new Wall(new Vector2(TopWallSprite.Width / 2 + TopWallSprite.Width * 2, -TopWallSprite.Height / 2 + 5), TopWallSprite, 0.2f));
            Gameworld.AddGameobjects.Add(new Wall(new Vector2(TopWallSprite.Width / 2 + TopWallSprite.Width * 3, -TopWallSprite.Height / 2 + 5), TopWallSprite, 0.2f));

            // Images of top walls
            Gameworld.AddGameobjects.Add(new Image(new Vector2(TopWallSprite.Width / 2 + TopWallSprite.Width * 0, TopWallSprite.Height / 2), TopWallSprite));
            Gameworld.AddGameobjects.Add(new Image(new Vector2(TopWallSprite.Width / 2 + TopWallSprite.Width * 1, TopWallSprite.Height / 2), TopWallSprite));
            Gameworld.AddGameobjects.Add(new Image(new Vector2(TopWallSprite.Width / 2 + TopWallSprite.Width * 2, TopWallSprite.Height / 2), TopWallSprite));
            Gameworld.AddGameobjects.Add(new Image(new Vector2(TopWallSprite.Width / 2 + TopWallSprite.Width * 3, TopWallSprite.Height / 2), TopWallSprite));

            // Floor
            Gameworld.AddGameobjects.Add(new Image(new Vector2(FloorSprite.Width / 2, FloorSprite.Height / 2 + TopWallSprite.Height), FloorSprite));

            // Left walls
            Gameworld.AddGameobjects.Add(new Wall(new Vector2(LeftWallSprite.Width / 2, LeftWallSprite.Height / 2 + LeftWallSprite.Height * 0), LeftWallSprite, 0.8f));
            Gameworld.AddGameobjects.Add(new Wall(new Vector2(LeftWallSprite.Width / 2, LeftWallSprite.Height / 2 + LeftWallSprite.Height * 1), LeftWallSprite, 0.8f));

            // Right walls
            Gameworld.AddGameobjects.Add(new Wall(new Vector2(Gameworld.Screensize.X - RightWallSprite.Width / 2, RightWallSprite.Height / 2 + RightWallSprite.Height * 0), RightWallSprite, 0.8f));
            Gameworld.AddGameobjects.Add(new Wall(new Vector2(Gameworld.Screensize.X - RightWallSprite.Width / 2, RightWallSprite.Height / 2 + RightWallSprite.Height * 1), RightWallSprite, 0.8f));

            // Bottom walls
            Gameworld.AddGameobjects.Add(new Wall(new Vector2(BottomWallSprite.Width / 2 + BottomWallSprite.Width * 0, Gameworld.Screensize.Y - BottomWallSprite.Height / 2), BottomWallSprite, 0.9f));
            Gameworld.AddGameobjects.Add(new Wall(new Vector2(BottomWallSprite.Width / 2 + BottomWallSprite.Width * 1, Gameworld.Screensize.Y - BottomWallSprite.Height / 2), BottomWallSprite, 0.9f));
            Gameworld.AddGameobjects.Add(new Wall(new Vector2(BottomWallSprite.Width / 2 + BottomWallSprite.Width * 2, Gameworld.Screensize.Y - BottomWallSprite.Height / 2), BottomWallSprite, 0.9f));
            Gameworld.AddGameobjects.Add(new Wall(new Vector2(BottomWallSprite.Width / 2 + BottomWallSprite.Width * 3, Gameworld.Screensize.Y - BottomWallSprite.Height / 2), BottomWallSprite, 0.9f));

            Gameworld.AddGameobjects.Add(new Pointer());
        }
    }
}
