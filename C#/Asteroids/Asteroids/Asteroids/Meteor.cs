using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Asteroids
{
    class Meteor
    {
        Texture2D textur;
        public Vector2 position;
        Vector2 speed;
        public Rectangle meteorBox;
        public int liv = 2;

        public Meteor(Texture2D textur)
        {
            this.textur = textur;
            position = new Vector2(Game1.myRnd.Next(800), Game1.myRnd.Next(600));
            double tmp_angle = (Game1.myRnd.Next(1000) * Math.PI * 2) / 1000.0;
            double tmp_speed = 0.5 + 3.0 * (Game1.myRnd.Next(1000) / 1000.0);
            speed = new Vector2((float)(tmp_speed * Math.Cos(tmp_angle)), (float)(tmp_speed * Math.Sin(tmp_angle)));
        }
        public void uppdatera()
        {
            meteorBox = new Rectangle((int)position.X - textur.Width / 2, (int)position.Y - textur.Height / 2, 60, 60);
            position += speed;
            
        }
        public void draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(textur, position, null, Color.White, 0, new Vector2(textur.Width / 2, textur.Height / 2), 1.0f, SpriteEffects.None, 0);
        }
    }
    
}
