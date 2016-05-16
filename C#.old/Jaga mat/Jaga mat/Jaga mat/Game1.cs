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

namespace Jaga_mat
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        Player player1, player2;
        //Food mat;
        List<Food> mat = new List<Food>();
        List<Food> mat2 = new List<Food>();
        public static Rectangle gameScreen;
        Texture2D gfx;
        Texture2D gfx2;
        SpriteFont font;
        KeyboardState ks, lastKs;
        
        int antalmat = 20;
        int antalmat2 = 5;
      
        

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            gameScreen = new Rectangle(0, 0, 800, 600);

            graphics.PreferredBackBufferWidth = gameScreen.Width;

            graphics.PreferredBackBufferHeight = gameScreen.Height;
        
        }

       
        protected override void LoadContent()
        {
            
            spriteBatch = new SpriteBatch(GraphicsDevice);
            gfx = Content.Load<Texture2D>("food");
            gfx2 = Content.Load<Texture2D>("head");
            player1 = new Player(gfx2, new Vector2(100, 300), Color.Blue,Keys.W, Keys.S, Keys.A, Keys.D);
            player2 = new Player(gfx2, new Vector2(680, 300), Color.Red, Keys.Up, Keys.Down, Keys.Left, Keys.Right);
            for (int i = 0; i < antalmat; i++)
            {
                mat.Add(new Food(gfx, Color.White));
            }
            for (int i = 0; i < antalmat2; i++)
            {
                mat2.Add(new Food(gfx, Color.Crimson));
            }
            font = Content.Load<SpriteFont>("SpriteFont");
           
        }

        
        protected override void Update(GameTime gameTime)
        {
            lastKs = ks;
            ks = Keyboard.GetState();
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();
            if (player1.paus == false && player2.paus == false)
            {
                player1.Update();
                player2.Update();
            }
            
            for (int i = 0; i < antalmat; i++)
            {
                bool tref = player1.Collision(mat[i]);
                bool tref2 = player2.Collision(mat[i]);

                if (tref == true || tref2 == true)
                {
                    mat[i] = new Food(gfx, Color.White);

                    if (tref == true)
                    {
                        player1.poang++;
                        if (player1.poang <= player2.poang -20)
                        {
                            player1.poang += 9;
                        }
                    }
                    if (tref2 == true)
                    {
                        player2.poang++;
                        if (player2.poang <= player1.poang -20)
                        {
                            player2.poang += 9;
                        }
                    }
                }
            }
            for (int i = 0; i < antalmat2; i++)
            {
                bool dtref = player1.Collision(mat2[i]);
                bool dtref2 = player2.Collision(mat2[i]);
                if (dtref == true || dtref2 == true)
                {

                    mat2[i] = new Food(gfx, Color.Crimson);
                    if (dtref == true)
                    {
                        player1.poang -= 10;
                    }
                    if (dtref2 == true)
                    {
                        player2.poang -= 10;
                    }
                }
            }
            if (player1.poang <= 0 )
            {
                player1.poang = 0;
            }
            if (player2.poang <= 0)
            {
                player2.poang = 0;
            }
            if (lastKs.IsKeyDown(Keys.Space) && ks.IsKeyUp(Keys.Space) && player1.paus == false && player2.paus == false)
            {
                player1.paus = true;
                player2.paus = true;
            }
            else if (lastKs.IsKeyDown(Keys.Space) && ks.IsKeyUp(Keys.Space) && player1.paus == true && player2.paus == true)
            {
                player1.paus = false;
                player2.paus = false;
            }

            if (player1.playerRect.Intersects(player2.playerRect) )
            {

                player1.speed *= -10;
                player2.speed *= -10;
                
            }

            base.Update(gameTime);
        }

        
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            spriteBatch.Begin();

            player1.Draw(spriteBatch);
            player2.Draw(spriteBatch);
            for (int i = 0; i < antalmat; i++)
            {
                mat[i].Draw(spriteBatch);
            }
            for (int i = 0; i < antalmat2; i++)
            {
                mat2[i].Draw(spriteBatch);
            }
            
            spriteBatch.DrawString(font, "player1 poang: " + player1.poang, new Vector2(10, 10), Color.White);
            spriteBatch.DrawString(font, "player2 poang: " + player2.poang, new Vector2(gameScreen.Width -200,10), Color.White);
            if (player1.paus == true && player2.paus == true)
            {
                spriteBatch.DrawString(font, "PAUS", new Vector2(gameScreen.Width / 2, gameScreen.Height / 2), Color.White);
            }
            
            
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
