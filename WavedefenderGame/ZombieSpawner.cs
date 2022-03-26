using Microsoft.Xna.Framework;
using System.Collections.Generic;
using System;
using System.Diagnostics;

namespace FørsteSemesterEksamen
{
    public static class ZombieSpawner
    {
        
        private static List<Vector2> spawnPoints = new List<Vector2>() 
        { 
            new Vector2(714, 35),
            new Vector2(510, 35),
            new Vector2(306, 35),
            new Vector2(102, 35),
            new Vector2(0, Gameworld.Screensize.Y / 2 + 20),
            new Vector2(Gameworld.Screensize.X, 216),
            new Vector2(Gameworld.Screensize.X, 108),
            new Vector2(Gameworld.Screensize.X, 380)
        };

        private static int queuedZombies = 0;
        private static double cooldown = 0;

        public static void SpawnZombies(GameTime gameTime)
        {
            if (queuedZombies > 0 && gameTime.TotalGameTime.TotalMilliseconds > cooldown)
            {
                SpawnZombie();
                queuedZombies--;
                UIManager.DebugNumberOfEnemiesSpawned.Stat++;
                cooldown = gameTime.TotalGameTime.TotalMilliseconds + 400;
            }
        }

        public static void SpawnZombie()
        {
            Vector2 randomPosition = GetRandomPosition();
            Gameworld.AddGameobjects.Add(new ZombieCharacter(randomPosition));
        }

        public static void SpawnWave(int count)
        {
            queuedZombies = count;
        }

        private static Vector2 GetRandomPosition()
        {
            int randomInt = new Random().Next(0, spawnPoints.Count);
            return spawnPoints[randomInt];
        }
    }
}