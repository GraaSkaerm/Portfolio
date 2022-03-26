using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace FørsteSemesterEksamen
{
    class Animation
    {
        public Texture2D[] Frames { get; set; }

        public float TimeBetweenFrames { get; set; }

        public int CurrentFrameIndex { get; set; }

        public int FrameCount { get; private set; }

        /// <summary>
        /// Makes an animation.
        /// </summary>
        /// <param name="frames"></param>
        public Animation(Texture2D[] frames)
        {
            this.Frames = frames;
            this.FrameCount = frames.Length;
            this.TimeBetweenFrames = .1f;
        }
    }
}
