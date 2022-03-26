using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace FørsteSemesterEksamen
{
    public class Tutorial
    {
       public bool isTutorialDone = false;
       private bool isDoneMovingTutorial = false;
       private bool isDoneShootingTutorial = false;

       public void CheckIfCompleted()
        {
            if  ( 
                Keyboard.GetState().IsKeyDown(Keys.A) || 
                Keyboard.GetState().IsKeyDown(Keys.D) || 
                Keyboard.GetState().IsKeyDown(Keys.W) ||
                Keyboard.GetState().IsKeyDown(Keys.S) ||
                Keyboard.GetState().IsKeyDown(Keys.Up) ||
                Keyboard.GetState().IsKeyDown(Keys.Down) ||
                Keyboard.GetState().IsKeyDown(Keys.Right) ||
                Keyboard.GetState().IsKeyDown(Keys.Left)
                )
            {
                isDoneMovingTutorial = true;
                UIManager.moveTextUI.Clear();
            }

            if (Keyboard.GetState().IsKeyDown(Keys.Space))
            {
                isDoneShootingTutorial = true;
                UIManager.shootTextUI.Clear();
            }

            if (isDoneMovingTutorial && isDoneShootingTutorial)
            {
                isTutorialDone = true;
                Gameworld.tutorial = null;
            }

        }
    }
}
