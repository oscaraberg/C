using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Asteroids
{
    class Ship
    {
        Texture2D textur;
        Texture2D acc_texture;
        public Vector2 positon;
        float speedMax = 3;
        float speedAcc = 0.1f;
        bool acc;
        public float angle = 0;
        Vector2 ship_speed = new Vector2();
        public Rectangle playerBox;
        public int liv = 3;
        



        public Ship(Texture2D textur, Vector2 positon, Texture2D acc_texture)
        {
            this.textur = textur;
            this.positon = positon;
            this.acc_texture = acc_texture;
        }
        public void uppdatera()
        {
            KeyboardState ks = Keyboard.GetState();
            playerBox = new Rectangle((int)positon.X-24, (int)positon.Y-30, 48, 60);

            if (ks.IsKeyDown(Keys.Left))
            {
                angle -= 0.03f;
            }
            if (ks.IsKeyDown(Keys.Right))
            {
                angle += 0.03f;
            }
            //fart
            if (ks.IsKeyDown(Keys.Up))
            {
                acc = true;
                ship_speed.Y += speedAcc * (float)Math.Sin(angle - MathHelper.PiOver2);
                ship_speed.X += speedAcc * (float)Math.Cos(angle - MathHelper.PiOver2);
                if (ship_speed.Length() > speedMax)
                {
                    ship_speed.Normalize();
                    ship_speed *= speedMax;
                }
            }
            else
            {
                acc = false;
            }
            if (ks.IsKeyDown(Keys.Down))
            {
                acc = false;
                ship_speed.Y -= speedAcc * (float)Math.Sin(angle - MathHelper.PiOver2);
                ship_speed.X -= speedAcc * (float)Math.Cos(angle - MathHelper.PiOver2);
                if (ship_speed.Length() > (speedMax/2))
                {
                    ship_speed.Normalize();
                    ship_speed *= (speedMax / 2);
                }
            }
            
            positon += ship_speed;
            if (positon.X < 0)
            {
                positon.X = Game1.gameScreen.Width;
            }
            if (positon.X > Game1.gameScreen.Width)
            {
                positon.X = 0;
            }
            if (positon.Y < 0)
            {
                positon.Y = Game1.gameScreen.Height;
            }
            if (positon.Y > Game1.gameScreen.Height)
            {
                positon.Y = 0;
            }
            
            
        }
        public void rita(SpriteBatch spriteBatch)
        {
            
            if (acc)
            {
                spriteBatch.Draw(acc_texture, positon, null, Color.White, angle, new Vector2(textur.Width / 2, textur.Height / 2), 1.0f, SpriteEffects.None, 0);
            }

            spriteBatch.Draw(textur, positon, null, Color.White, angle, new Vector2(textur.Width / 2, textur.Height / 2), 1.0f, SpriteEffects.None, 0);
        }

    }
}
