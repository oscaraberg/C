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

namespace Asteroids
{
   
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Ship ship;
        public static Rectangle gameScreen;
        public static Random myRnd = new Random();
        
        Texture2D gfx_shot;
        SpriteFont font;
        const int shot_delay = 200;
        int shot_time;
        List<Skot> skotLista = new List<Skot>();
        List<Meteor> meteorLista = new List<Meteor>();
        Texture2D gfx_meteor;
        int antalSkot = 10;
       
       

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            graphics.PreferredBackBufferWidth = 1000;
            graphics.PreferredBackBufferHeight = 600;

            gameScreen = new Rectangle(0, 0, graphics.PreferredBackBufferWidth, graphics.PreferredBackBufferHeight);

            Window.AllowUserResizing = true;
            IsMouseVisible = true;
        }

       
        protected override void Initialize()
        {
           

            base.Initialize();
        }

      
        protected override void LoadContent()
        {
            
            spriteBatch = new SpriteBatch(GraphicsDevice);
            Vector2 position = new Vector2(500, 300);
            font = Content.Load<SpriteFont>("myFont");
           
            Texture2D gfx = Content.Load<Texture2D>("ship");
            Texture2D gfx_acc = Content.Load<Texture2D>("ship_acc");
            gfx_meteor = Content.Load<Texture2D>("meteor");
            gfx_shot = Content.Load<Texture2D>("shot");
            skapaMeteorer(antalSkot);
            

            ship = new Ship(gfx, position, gfx_acc);
           
        }

        protected override void UnloadContent()
        {

            
            
        }
        private void skapaMeteorer(int antal)
        {
            for (int i = 0; i < antal; i++)
            {
                Meteor meteor = new Meteor(gfx_meteor);
                meteorLista.Add(meteor);
            }
        }

      
        protected override void Update(GameTime gameTime)
        {
          
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();
            
            KeyboardState ks = Keyboard.GetState();

            
           
          
            if (shot_time < 0)
            {
                shot_time = 0;
            }

            if (ks.IsKeyDown(Keys.Space) && shot_time == 0)
            {
                shot_time = shot_delay;
                Skot skot= new Skot(gfx_shot,ship.angle,ship.positon);
                skotLista.Add(skot);
               
            }

            for (int i = 0; i < skotLista.Count; i++)
            {
                skotLista[i].uppdatera();
                if (skotLista[i].position.Y < 0 || skotLista[i].position.Y > graphics.PreferredBackBufferHeight || skotLista[i].position.X < 0 || skotLista[i].position.X > graphics.PreferredBackBufferWidth)
                {
                    skotLista.RemoveAt(i);
                }

            }


            

            for (int i = 0; i < meteorLista.Count; i++)
            {
                for (int j = 0; j < skotLista.Count; j++)
                {
                    if (skotLista[j].skottBox.Intersects(meteorLista[i].meteorBox))
                    {
                        skotLista.RemoveAt(j);
                        meteorLista[i].liv--;
                        break;
                    }
                }
            }
            if (ship.liv > 0)
            {
                ship.uppdatera();
                shot_time -= gameTime.ElapsedGameTime.Milliseconds;
                for (int i = 0; i < meteorLista.Count; i++)
                {
                    meteorLista[i].uppdatera();
                    if (meteorLista[i].position.X < -80)
                        meteorLista[i].position.X = graphics.GraphicsDevice.Viewport.Width + 80;
                    if (meteorLista[i].position.X > graphics.GraphicsDevice.Viewport.Width + 80)
                        meteorLista[i].position.X = -80;
                    if (meteorLista[i].position.Y < -60)
                        meteorLista[i].position.Y = graphics.GraphicsDevice.Viewport.Height + 60;
                    if (meteorLista[i].position.Y > graphics.GraphicsDevice.Viewport.Height + 60)
                        meteorLista[i].position.Y = -60;
                    if (ship.playerBox.Intersects(meteorLista[i].meteorBox))
                    {
                        meteorLista[i].liv -= 2;
                        ship.liv--;
                    }
                    if (meteorLista[i].liv <= 0)
                    {
                        meteorLista.RemoveAt(i);
                    }
                }
            }
            if (ship.liv <= 0 && ks.IsKeyDown(Keys.Enter))
            {
                meteorLista.Clear();
                skotLista.Clear();
                ship.positon = new Vector2(500, 300);
                skapaMeteorer(antalSkot);
                ship.liv = 3;
            }

            base.Update(gameTime);
        }

       
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
           
           
            spriteBatch.Begin();
            
            ship.rita(spriteBatch);

            for (int i = 0; i < skotLista.Count; i++)
            {
                skotLista[i].rita(spriteBatch);
            }

            for (int i = 0; i < meteorLista.Count; i++)
            {
                meteorLista[i].draw(spriteBatch);
            }
            spriteBatch.DrawString(font, ship.liv.ToString(), new Vector2(10, 10), Color.Black);
            if (ship.liv <= 0)
            {
                spriteBatch.DrawString(font, "Game over", new Vector2(400, 250), Color.Black, 0,Vector2.Zero,2,SpriteEffects.None,0);
            }
            spriteBatch.End();

            base.Draw(gameTime); 
        }
        
    }
}
