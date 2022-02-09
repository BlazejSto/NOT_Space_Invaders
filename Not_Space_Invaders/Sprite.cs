using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Not_Space_Invaders
{
    class Sprite
    {
        protected Rectangle entityPos;
        protected Texture2D entityTexture;
        protected Color entityColour;
     
 

        public Sprite(Texture2D inTexture, Rectangle inPos, Color inColour)
        {
            entityTexture = inTexture;
            entityPos = inPos;
            entityColour = inColour;
          
        }
        public void DrawSprite(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(entityTexture, entityPos, entityColour); 
        }
        public void SetPosition(Rectangle inPos)
        {
            entityPos = inPos;
        }
        public Rectangle GetPosition()
        {
            return entityPos;
        }

        public Rectangle Position
        {
          get { return entityPos; }
          set { entityPos = value; } 
            
        }
        public Texture2D Texture
        {
            get { return entityTexture; }
            set { entityTexture = value; }
        }


        
    }
}
