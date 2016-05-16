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

namespace snake
{
    
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        KeyboardState ks, lastKs;
        public static Rectangle gameScreen;
        Head player;
        List<Body> body = new List<Body>();
        Texture2D bodyTexture;
       
        List<Food> food = new List<Food>();
        Texture2D foodTexture;
        public SpriteFont font;
        
        highscore high = new highscore();
        KeyInput kIn = new KeyInput();
        
        bool lista = true;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            graphics.PreferredBackBufferHeight = 800;
            graphics.PreferredBackBufferWidth = 1000;
            gameScreen.Width = graphics.PreferredBackBufferWidth;
            gameScreen.Height = graphics.PreferredBackBufferHeight;
        }

        
        protected override void Initialize()
        {
           
            base.Initialize();
        }

        
        protected override void LoadContent()
        {
            
            spriteBatch = new SpriteBatch(GraphicsDevice);
            Texture2D t = Content.Load<Texture2D>("head");
            bodyTexture = Content.Load<Texture2D>("body");
            player = new Head(t, 3);
            for (int i = 0; i < 40; i++)
            {
              body.Add(new Body(bodyTexture));
            }

            foodTexture = Content.Load<Texture2D>("food");
            food.Add(new Food(foodTexture));
          

            font = Content.Load<SpriteFont>("font");
        }


        protected override void UnloadContent()
        {
           
        }

      
        protected override void Update(GameTime gameTime)
        {
           
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();
            
            //player.Update(gameTime);
            lastKs = ks;
            ks = Keyboard.GetState();
            if (player.alive == true && player.pause == false)
            {
                if (lastKs.IsKeyDown(Keys.L) && ks.IsKeyUp(Keys.L) && lista == false) { lista = true;}
                else if (lastKs.IsKeyDown(Keys.L) && ks.IsKeyUp(Keys.L) && lista == true) { lista = false;}
                player.Update(gameTime);
                body[0].Update(gameTime);
                body[0].position = player.prevPosition;
                for (int i = 1; i < body.Count; i++)
                {
                    body[i].Update(gameTime);
                    body[i].position = body[i - 1].prevPosition;
                    if (i > 15)
                    {
                        if (body[i].hitbox.Intersects(player.hitbox))
                        {
                            player.alive = false;
                            lista = false;
                        }
                    }
                }
            }
            else if(player.alive == false)
            {
                kIn.Update();
         
                if (ks.IsKeyDown(Keys.Enter))
                {
                    high.UppDateraLista(player.point, kIn.text);
                    body.Clear();
                    food.Clear();
                    player.position.X = Game1.gameScreen.Width / 2;
                    player.position.Y = Game1.gameScreen.Height / 2;
                    for (int i = 0; i < 40; i++)
                    {
                        body.Add(new Body(bodyTexture));
                    }
                    player.exfood = 50;
                    player.antalfood = 1;
                    player.point = 0;
                    food.Add(new Food(foodTexture));
                    player.alive = true;
                    kIn.text = "";
                }
            }
            if (lastKs.IsKeyDown(Keys.Space) && ks.IsKeyUp(Keys.Space) && player.pause == false && player.alive == true)
            {
                player.pause = true;
            }
            else if (lastKs.IsKeyDown(Keys.Space) && ks.IsKeyUp(Keys.Space) && player.pause == true && player.alive == true)
            {
                player.pause = false;
            }

          
     

            for(int i = 0; i <food.Count; i++)
            if (food[i].hitbox.Intersects(player.hitbox))
            {
                food[i].RandomPosition();
                
                player.point++;
                for (int j = 0; j < 10; j++)
                {
                    body.Add(new Body(bodyTexture));
                }
            }

            if (player.point == player.exfood && food.Count == player.antalfood)
            {
                food.Add(new Food(foodTexture));
                player.exfood += 50;
                player.antalfood++;
            }

            base.Update(gameTime);

        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            spriteBatch.Begin();

            for (int i = 0; i < body.Count; i++)
            {
                body[i].Draw(spriteBatch);
            }

            player.Draw(spriteBatch);

            for (int j = 0; j < food.Count; j++)
            {
                food[j].draw(spriteBatch);
            }

            if (lista == true)
            {
                spriteBatch.DrawString(font, high.visalista(), new Vector2(10, Game1.gameScreen.Height / 4), Color.White);
            }
            spriteBatch.DrawString(font, "score:" + player.point, new Vector2(10, 10), Color.White);
            if (player.alive == false)
            {
                spriteBatch.DrawString(font, "Game Over", new Vector2( Game1.gameScreen.Width / 2, Game1.gameScreen.Height / 2), Color.White);

                if (high.test < player.point)
                {
                    spriteBatch.DrawString(font, "Enter Name", new Vector2(Game1.gameScreen.Width / 2 - 10, Game1.gameScreen.Height / 4), Color.White);
                }
                kIn.Draw(spriteBatch, new Vector2(Game1.gameScreen.Width / 2, Game1.gameScreen.Height / 4 + 50), font, Color.White);
                
            }
  
            spriteBatch.End();            

            base.Draw(gameTime);
        }
    }
}
