using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Not_Space_Invaders
{
    class EnemyShips : Sprite
    {
        private const int SPACE_BETWEEN_SHIPS = 10;
        private Aliens[,] shipsArray;
        private Sprite otherSprite;
        private bool moveLeft, MoveRight;
        

        public EnemyShips(Rectangle inPosition, Texture2D inTexture, Color inColour, Aliens[,] inShipsArray, Sprite inOtherSprite) : base(inTexture, inPosition, inColour)
        {
            shipsArray = inShipsArray;
            otherSprite = inOtherSprite;
            
        }


        public void InitialiseEnemyShips()
        {
            
            for (int i = 0; i <= shipsArray.GetUpperBound(0); i++)
            {
                for (int j = 0; j <= shipsArray.GetUpperBound(1); j++)
                {
                    shipsArray[i, j] = new Aliens(new Rectangle((i * entityTexture.Width) + (i * SPACE_BETWEEN_SHIPS),
                        (j * entityTexture.Height) + (j * SPACE_BETWEEN_SHIPS), entityTexture.Width, entityTexture.Height), 
                        entityTexture, Color.White, true, otherSprite);
                }
            }
        }
        public void ShipsMovement(GraphicsDeviceManager inGraphics)
        {
            for (int i = 0; i <= shipsArray.GetUpperBound(0); i++)
            {
                for(int j = 0; j <= shipsArray.GetUpperBound(1); j++)
                {
                    if(shipsArray[shipsArray.GetUpperBound(0), j].Position.X + shipsArray[shipsArray.GetUpperBound(0), j].Texture.Width >= inGraphics.PreferredBackBufferWidth)
                    {
                        moveLeft = true;
                        MoveRight = false;
                    }
                    if (shipsArray[0,j].Position.X <= 0)
                    {
                        moveLeft = false;
                        MoveRight = true;
                    }
                }    
            }
            foreach (Aliens e in shipsArray)
            {
                if(MoveRight == true)
                {
                    e.Position = new Rectangle(e.Position.X + 1, e.Position.Y, Texture.Width, Texture.Height);
                }
                if(moveLeft == true)
                {
                    e.Position = new Rectangle(e.Position.X - 1, e.Position.Y, e.Texture.Width, Texture.Height);
                }
            }
        }
    }
}
