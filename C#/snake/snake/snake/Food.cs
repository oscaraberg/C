using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace snake
{
    class Food
    {

        private Random rnd;
        private Texture2D texture;
        public Rectangle hitbox;


        public Food(Texture2D t)
        {
            this.texture = t;
            rnd = new Random();
            RandomPosition();
        }

        public void RandomPosition()
        {
            hitbox = new Rectangle(rnd.Next(0, Game1.gameScreen.Width - texture.Width), rnd.Next(0, Game1.gameScreen.Height - texture.Height), texture.Width, texture.Height);
        }

        public void draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, hitbox, Color.White);
        }
    }
}
