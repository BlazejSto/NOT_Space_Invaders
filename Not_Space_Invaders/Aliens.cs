using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Not_Space_Invaders
{
    class Aliens : Sprite
    {

        private Sprite[,] enemyBricks;
        private int Rows = 5;
        private bool isDrawn;
        private bool collided;
        private Sprite otherSprite;

        public Aliens(Rectangle inPos, Texture2D inTexture, Color inColour, bool inIsDrawn, Sprite inOtherSprite) : base(inTexture, inPos, inColour)
        {
            isDrawn = inIsDrawn;
            otherSprite = inOtherSprite;
        }
        public bool CheckCollided(Sprite inOtherSprite)
        {
            collided = false;
            if(entityPos.Intersects(inOtherSprite.Position))
            {
                collided = true;
            }
            return collided;
        }
        public bool IsDrawn
        {
            get { return isDrawn; }
            set { isDrawn = value; }
        }
 


    }
}
