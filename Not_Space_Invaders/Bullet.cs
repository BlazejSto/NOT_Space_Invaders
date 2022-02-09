using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Not_Space_Invaders
{
    class Bullet : Sprite
    {
        private int yPos;
        private int xPos;
        private bool Fired = false;
        public Bullet(Rectangle inPos, Texture2D inTexture, Color inColour) :base(inTexture, inPos, inColour)
        {

        }
        public void InitialPos(Sprite inSprite)
        {
            xPos = inSprite.Position.X + inSprite.Position.Width / 2 - 5;
            entityPos = new Rectangle(xPos, inSprite.Position.Y, entityTexture.Width, entityTexture.Height);
            yPos = entityPos.Y;
        }
        public void FireBullet(Sprite inSprite)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Space))
            {
                Fired = true;
            }
            if (entityPos.Y > inSprite.Position.Y && Fired == true)
            {
                yPos -= 5; 
                entityPos = new Rectangle(xPos, yPos, entityTexture.Width, entityTexture.Height);
            }
            else
            {
                InitialPos(inSprite); //Changed for test
                Fired = false;
            }
 
        }
    }
}
