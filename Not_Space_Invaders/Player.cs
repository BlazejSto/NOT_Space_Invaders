using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Not_Space_Invaders
{
    class Player : Sprite
    {

        private int playerLives = 3;

     


        public Player(Rectangle inPos, Texture2D inTexture, Color inColour) : base(inTexture, inPos, inColour)
        {
            
        }
        public bool Collided(int inLives)
        {
            playerLives -= 1;
            return true;

        }
        public void Movement(GraphicsDeviceManager inGraphics)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Right) && entityPos.X + entityTexture.Width < inGraphics.PreferredBackBufferWidth)
            {
                entityPos.X += 1;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Left) && entityPos.X > 0)
            {
                entityPos.X -= 1;
            }
        }
    }
}
