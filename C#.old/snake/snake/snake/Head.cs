using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace snake
{
    class Head
    {

        public float speed;
        private float rotation;
        private Texture2D texture;
        public Vector2 position ;
        public Vector2 prevPosition;
        public Rectangle hitbox;
        public bool alive = true;
        public int point;
        int h = 5;
        public int exfood = 50;
        public int antalfood = 1;
        public bool pause = false;
       


        public Head(Texture2D texture, float s)
        {
            this.texture = texture;
            this.speed = s;
            position.X = Game1.gameScreen.Width/2;
            position.Y = Game1.gameScreen.Height/2;
    


        }

        public void Update(GameTime gameTime)
        {
            prevPosition = position;	
            hitbox = new Rectangle((int)position.X - texture.Width / 2, (int)position.Y - texture.Height / 2, texture.Width, texture.Height);
            Vector2 direction = new Vector2((float)Math.Cos(rotation), (float)Math.Sin(rotation));

            KeyboardState ks = Keyboard.GetState();

            position += direction * speed;

            if (ks.IsKeyDown(Keys.Left))
            {
                rotation -= MathHelper.ToRadians(h);
            }
            if (ks.IsKeyDown(Keys.Right))
            {
                rotation += MathHelper.ToRadians(h);
            }
            //if (position.X < 0 || position.Y < 0 || position.X > Game1.gameScreen.Width || position.Y > Game1.gameScreen.Height)
            //{
            //    alive = false;
            //}
            if (position.X < 0)
            {
                position.X = Game1.gameScreen.Width;
            }
            if (position.Y < 0)
            {
                position.Y = Game1.gameScreen.Height;
            }
            if (position.X > Game1.gameScreen.Width)
            {
                position.X = 0;
            }
            if (position.Y > Game1.gameScreen.Height)
            {
                position.Y = 0;
            }

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, position, null, Color.White, rotation + MathHelper.ToRadians(90), new Vector2(texture.Width / 2, texture.Height / 2), 1f, SpriteEffects.None, 0f);
        }


    }
}
