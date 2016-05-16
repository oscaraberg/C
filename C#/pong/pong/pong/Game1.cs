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

namespace pong
{
    
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Padel padel2;
        Padel padel;
        boll Boll;
        SpriteFont font;
       
        

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            graphics.PreferredBackBufferHeight = 600;
            graphics.PreferredBackBufferWidth = 800;
        }

      
        protected override void Initialize()
        {
           

            base.Initialize();
        }

        
        protected override void LoadContent()
        {
         
            spriteBatch = new SpriteBatch(GraphicsDevice);
            Texture2D player = Content.Load<Texture2D>("player");
            Texture2D båll = Content.Load<Texture2D>("ball");
            padel = new Padel(player, new Vector2(350, 550), new Rectangle(), Keys.Right, Keys.Left);
            padel2 = new Padel(player,new Vector2(350,50),new Rectangle(),Keys.D, Keys.A);
            Boll = new boll(båll, new Vector2(400, 300), new Rectangle());
           
            font = Content.Load<SpriteFont>("font");

        }

      
        protected override void UnloadContent()
        {
            
        }

      
        protected override void Update(GameTime gameTime)
        {
           
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
            
            this.Exit();


                if (Boll.start.Y <= 590)
                {
                    padel.update();
                    padel2.update();
                    Boll.update();
                    if (padel.box.Intersects(Boll.box))
                    {
                        Boll.farty *= -1;
                        Boll.start.Y = 530;
                        padel.tal++;
                    }
                    if (padel2.box.Intersects(Boll.box))
                    {
                        Boll.farty *= -1;
                        Boll.start.Y = 70;
                        padel2.tal++;
                    } 
                }

                KeyboardState ks = Keyboard.GetState(); 
                if (ks.IsKeyDown(Keys.Enter))
                {
                    padel.start = new Vector2(350, 550);
                    Boll.start = new Vector2(400, 300);
                    padel.tal = 0;
                    padel2.tal = 0;
                }

           
         
            base.Update(gameTime);
        }

     
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            spriteBatch.Begin();

           
                padel.Draw(spriteBatch);
                Boll.Draw(spriteBatch);
                padel2.Draw(spriteBatch);
               
                spriteBatch.DrawString(font, "skor:" + padel.tal, new Vector2(10, 10), Color.White);
                spriteBatch.DrawString(font, "skor:" + padel2.tal, new Vector2(10, 690), Color.White);


            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
