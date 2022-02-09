using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Not_Space_Invaders
{
    class Animation : Sprite
    {
        private int frames;
        private float timeElapsed, timeToUpdate;
        private bool isLooping = false;
        private Vector2 origin;
        private float rotation = 0.0f;
        private float scale = 0.0f;
        private SpriteEffects spriteEffects;
        private Rectangle[] rectangles;
        private int frameIndex = 0;

        public Animation(Rectangle inPos, Texture2D inTexture, Color inColour, int inFrames): base(inTexture, inPos, inColour)
        {
            entityTexture = inTexture;
            int width = inTexture.Width / inFrames;
            rectangles = new Rectangle[inFrames];

            for (int i = 0; i < inFrames; i++)
            {
                rectangles[i] = new Rectangle(i * width, 0, width, entityTexture.Height / 2);
            }
        }
        public int FPS
        {
            set { timeToUpdate = (1f / value); }
        }
        public void  Update(GameTime inGameTime)
        {
            timeElapsed += (float)inGameTime.ElapsedGameTime.TotalSeconds;

            if(timeElapsed > timeToUpdate)
            {
                timeElapsed -= timeToUpdate;

                if(frameIndex < rectangles.Length - 1)
                {
                    frameIndex++;
                }
                else if (isLooping)
                {
                    frameIndex = 0;
                }
            }
        }
        
    }
}
