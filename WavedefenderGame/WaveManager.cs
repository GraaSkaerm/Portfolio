using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace FørsteSemesterEksamen
{
    public static class WaveManager
    {
        private static int basePoints = 100;

        private static int currentWave = 0;
        private static int zombiesToKill = 0;
        private static int zombiesKilled = 0;
        private static int spawnedZombies;
        private static int zombiesToSpawn;

        public static bool IsZombieKilled;

        public static int CurrentWave
        {
            get => currentWave;
            set
            {
                if (value < 0)
                {
                    currentWave = 0;
                }
                else
                {
                    currentWave = value;
                }
            }
        }

        public static int ZombiesToKill { get => zombiesToKill; set => zombiesToKill = value; }

        public static int ZombiesKilled
        { 
            get => zombiesKilled; 
            set 
            { 
                zombiesKilled = value;
                if (zombiesKilled >= zombiesToKill)
                    NextWave();
            } 
        }

        public static void NextWave()
        {
            zombiesToSpawn = (int)(5 * Math.Pow(1.03, currentWave) + currentWave);
            int startZombiesToSpawn = zombiesToSpawn;

            if (startZombiesToSpawn > 35)
            {
                startZombiesToSpawn = 35;
            }

            // Get points for completing a wave
            if (currentWave != 0)
            {
                UIManager.highscoreUI.Stat += basePoints * currentWave;
            }

            spawnedZombies = startZombiesToSpawn;
            zombiesToKill += zombiesToSpawn;


            ZombieSpawner.SpawnWave(startZombiesToSpawn);
            CurrentWave++;

            UIManager.waveCountUI.Stat = currentWave;
            UIManager.DebugNumberOfEnemiesSpawned.Stat = 0;
            UIManager.DebugNumberOfEnemiesAlive.Stat = 0;
        }

        public static void Reset()
        {
            currentWave = 0;
            zombiesToKill = 0;
            zombiesKilled = 0;
        }


        public static void SpawnWastedZombie(GameTime gameTime)
        {
            if (IsZombieKilled)
            {
                if (spawnedZombies < zombiesToSpawn)
                {
                    ZombieSpawner.SpawnZombie();
                    spawnedZombies++;
                    UIManager.DebugNumberOfEnemiesSpawned.Stat++;
                }
                IsZombieKilled = false;
            }
        }
    }
}
