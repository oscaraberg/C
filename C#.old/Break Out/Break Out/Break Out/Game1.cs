using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace Break_Out
{
    
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Paddle paddle;
        Rectangle screenRectangle;
        Ball ball;

        int bricksWide = 10;
        int bricksHigh = 5;
        Texture2D brickImage;
        Brick[,] bricks;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            screenRectangle = new Rectangle(0, 0, graphics.PreferredBackBufferWidth, graphics.PreferredBackBufferHeight);

          
          
        }

       
        protected override void Initialize()
        {
         

            base.Initialize();
        }

       
        protected override void LoadContent()
        {
          
            spriteBatch = new SpriteBatch(GraphicsDevice);

            Texture2D tempTexture = Content.Load<Texture2D>("paddle");
            paddle = new Paddle(tempTexture, screenRectangle);

            tempTexture = Content.Load<Texture2D>("ball");
            ball = new Ball(tempTexture, screenRectangle);
            brickImage = Content.Load<Texture2D>("brick");
            StartGame();
          
        }

        private void StartGame()
        {
            paddle.SetInStartPosition();

            ball.SetInStartPosition(paddle.GetBounds());
            
            bricks = new Brick[bricksWide, bricksHigh];
            for (int y = 0; y < bricksHigh; y++)
            {
                Color tint = Color.White;
                switch (y)
                {
                    case 0:
                        tint = Color.Blue;
                        break;
                    case 1:
                        tint = Color.Red;
                        break;
                    case 2:
                        tint = Color.Green;
                        break;
                    case 3:
                        tint = Color.Yellow;
                        break;
                    case 4:
                        tint = Color.Purple;
                        break;
                }
                for (int x = 0; x < bricksWide; x++)
                {
                    bricks[x, y] = new Brick( brickImage,new Rectangle(x * brickImage.Width,y * brickImage.Height,brickImage.Width, brickImage.Height), tint);
                }
            }
        }

        protected override void UnloadContent()
        {
            
        }

      
        protected override void Update(GameTime gameTime)
        {
            
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();

            paddle.Update();
            ball.Update();

            foreach (Brick brick in bricks)
            {
                brick.CheckCollision(ball);
            }

            ball.PaddleCollision(paddle.GetBounds());
            
            if (ball.OffBottom())
                StartGame();


            base.Update(gameTime);
        }

        
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin();

            foreach (Brick brick in bricks)
                brick.Draw(spriteBatch);

            paddle.Draw(spriteBatch);
            ball.Draw(spriteBatch);

          

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
