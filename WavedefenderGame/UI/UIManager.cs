using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace FørsteSemesterEksamen
{

    public static class UIManager
    {

        public static AmmoUI ammoUI = new AmmoUI(new Vector2(10, 15));
        public static HealthUI healthUI = new HealthUI(new Vector2(10, 30));
        public static HighscoreUI highscoreUI = new HighscoreUI (new Vector2(10, 45));
        public static WaveCountUI waveCountUI = new WaveCountUI(new Vector2(10, 60));
        public static TutorialUI moveTextUI = new TutorialUI(new Vector2(250, 120), "Press W,A,S,D or use the arrow keys to Move");
        public static TutorialUI shootTextUI = new TutorialUI(new Vector2(250, 150), "Press spacebar to shoot");

        public static PauseUI pauseUI = new PauseUI(new Vector2(Gameworld.Screensize.X / 2 - 50, Gameworld.Screensize.Y / 2 - 50));
        public static GameoverUI gameoverUI = new GameoverUI(new Vector2(Gameworld.Screensize.X / 2 - 50, Gameworld.Screensize.Y / 2 - 50));

        // Debug
        public static DebugNumberOfEnemiesSpawnedUI DebugNumberOfEnemiesSpawned = new DebugNumberOfEnemiesSpawnedUI(new Vector2(10, 75));
        public static DebugNumberOfEnemiesAliveUI DebugNumberOfEnemiesAlive = new DebugNumberOfEnemiesAliveUI(new Vector2(10, 90));

        public static List<UITextElement> textElements_UI = new List<UITextElement> { ammoUI, healthUI, highscoreUI, waveCountUI, DebugNumberOfEnemiesSpawned, DebugNumberOfEnemiesAlive, moveTextUI, shootTextUI, gameoverUI, pauseUI };

        public static void UpdateUITextElements()
        {
            foreach (UITextElement textElement in textElements_UI)
            {
                textElement.ChangeText();
            }
        }

        /// <summary>
        /// Sætter UI til default værdier
        /// </summary>
        public static void ResetUI()
        {
            foreach (UITextElement textElement in textElements_UI)
            {
                textElement.Reset();
            }
        }
     
        public static void DrawUI()
        {
            foreach (UITextElement textElement in textElements_UI)
            {
                textElement.DrawText();
            }
        }
    }
}
