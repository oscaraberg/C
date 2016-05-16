using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Asteroids
{
    class Skot
    {
        Texture2D textur;
        float riktning;
        public Vector2 position;
        int speed = 5;
        public Rectangle skottBox;

        public Skot(Texture2D textur, float riktning, Vector2 poriton)
        {
            this.textur = textur;
            this.riktning = riktning;
            this.position = poriton;
        }
        public void uppdatera()
        {
            skottBox = new Rectangle((int)position.X, (int)position.Y, 7, 7);
            position += new Vector2(speed * (float)Math.Cos(riktning - MathHelper.PiOver2), speed * (float)Math.Sin(riktning - MathHelper.PiOver2));
        }

        public void rita(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(textur, position, Color.White);
        }

    }
}
