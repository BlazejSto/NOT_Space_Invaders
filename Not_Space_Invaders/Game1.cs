using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Diagnostics;

namespace Not_Space_Invaders
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        private Rectangle entityPos;
        private Texture2D entityTexture;
        private Color entityColour;
        private Rectangle tempPos;
        private Sprite otherSprite;
        private bool isDrawn;
        private Player player1;
        private Bullet bullet;
        private Aliens alienShips;
        private EnemyShips allShips;
        private Aliens[,] shipsArray = new Aliens[13,5];
        private bool Bcollided;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            _graphics.PreferredBackBufferWidth = 1500;
            _graphics.PreferredBackBufferHeight = 750;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        protected override void LoadContent()
        {
            //player1 = Content.Load<Texture2D>("Brick");
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            entityTexture = Content.Load<Texture2D>("Brick");
            
            player1 = new Player(new Rectangle(0, 0, entityTexture.Width, entityTexture.Height), entityTexture, Color.White);
            player1.SetPosition(new Rectangle(_graphics.PreferredBackBufferWidth / 2 - entityTexture.Width / 2,
                _graphics.PreferredBackBufferHeight - entityTexture.Height,
                entityTexture.Width, entityTexture.Height));
            alienShips = new Aliens(new Rectangle(0, 0, entityTexture.Width, entityTexture.Height), entityTexture, Color.White, isDrawn, otherSprite);
            allShips = new EnemyShips(entityPos, entityTexture, entityColour, shipsArray, otherSprite);

            entityTexture = Content.Load<Texture2D>("Bullet"); 
            bullet = new Bullet(new Rectangle(0, 0, entityTexture.Width, entityTexture.Height), entityTexture, Color.Red);

            
            //alienShips = new EnemyShips(new Rectangle(0, 0, entityTexture.Width, entityTexture.Height), entityTexture, Color.White, shipsArrray, otherSprite);
            //bullet.SetPosition(new Rectangle(_graphics.PreferredBackBufferWidth / 2 - entityTexture.Width / 2,
            //    _graphics.PreferredBackBufferHeight - entityTexture.Height - 30,
            //    entityTexture.Width, entityTexture.Height));
            bullet.InitialPos(player1);
            allShips.InitialiseEnemyShips();
            

            // TODO: use this.Content to load your game content here
        }
        protected override void Update(GameTime gameTime)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Escape))
            {
                Exit();
            }
            player1.Movement(_graphics);
            bullet.FireBullet(player1);
            allShips.ShipsMovement(_graphics);
            
            
            
            
            



            //if (Keyboard.GetState().IsKeyDown(Keys.Right) && player1.GetPosition().X <= Window.ClientBounds.Width - entityTexture.Width)
            //{
            //    tempPos = new Rectangle(player1.GetPosition().X + 1, player1.GetPosition().Y, entityTexture.Width, entityTexture.Height);
            //    player1.SetPosition(tempPos);
            //}
            //if (Keyboard.GetState().IsKeyDown(Keys.Left) && player1.GetPosition().X >= 0)
            //{
            //    tempPos = new Rectangle(player1.GetPosition().X - 1, player1.GetPosition().Y, entityTexture.Width, entityTexture.Height);
            //    player1.SetPosition(tempPos);
            //}
            //if (Keyboard.GetState().IsKeyDown(Keys.Up))
            //{
            //
            //}
            // TODO: Add your update logic here


            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            // TODO: Add your drawing code here
            _spriteBatch.Begin();
            player1.DrawSprite(_spriteBatch);
            bullet.DrawSprite(_spriteBatch);
            foreach (Aliens e in shipsArray)
            {
                Bcollided = e.CheckCollided(bullet);
                if (Bcollided == true)
                {
                    e.IsDrawn = false;
                    e.Position = new Rectangle(e.Position.X, 1000, 10, 10);
                    bullet.InitialPos(player1);
                }
            }    

            foreach (Aliens e in shipsArray)
            {
                e.DrawSprite(_spriteBatch);
            }


            _spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
