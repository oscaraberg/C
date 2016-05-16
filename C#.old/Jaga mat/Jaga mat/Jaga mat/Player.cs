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
    class Player
    {

        Texture2D gfx;
        public Vector2 position;
        float rotation = -MathHelper.Pi / 2;
        public float speed;
        Color color;
        float rspeed = 6;
        public Rectangle playerRect;
        Keys keyUp, keyDown, keyLeft, keyRight;
        public int poang;
        public bool paus = false;
        KeyboardState ks;


        public Player(Texture2D gfx, Vector2 startpos, Color color, Keys kU, Keys kD, Keys kL, Keys kR)
        {
            this.gfx = gfx;
            position = startpos;
            //speed = new Vector2(0, 0);
            this.color = color;
            keyUp = kU;
            keyDown = kD;
            keyLeft = kL;
            keyRight = kR;
        }


        public void Update()
        {
            Vector2 direktion = new Vector2((float)Math.Cos(rotation), (float)Math.Sin(rotation));

            ks = Keyboard.GetState();
            
            position += direktion * speed;
            if (ks.IsKeyDown(keyUp))
            {
                speed += 1;
                speed *= 0.75f;
            }

            if (ks.IsKeyDown(keyDown))
            {
                speed -= 1;
                speed *= 0.45f;
            }
            if (ks.IsKeyUp(keyUp) && ks.IsKeyUp(keyDown))
            {
                speed = 0;
            }
            if (ks.IsKeyDown(keyRight))
            {
                rotation += MathHelper.ToRadians(rspeed);

            }
            if (ks.IsKeyDown(keyLeft))
            {
                rotation -= MathHelper.ToRadians(rspeed);
            }


            //if (position.X > Game1.gameScreen.Width)

            //    position.X = 0;

            //if (position.X < 0)

            //    position.X = Game1.gameScreen.Width;

            //if (position.Y > Game1.gameScreen.Height)

            //    position.Y = 0;

            //if (position.Y < 0)

            //    position.Y = Game1.gameScreen.Height;
            if (position.X > Game1.gameScreen.Width || position.Y > Game1.gameScreen.Height || position.Y < 0 || position.X < 0)

                speed *= -10;


        }
        public bool Collision(Food food)
        {
            playerRect = new Rectangle((int)position.X, (int)position.Y, gfx.Width, gfx.Height);

            Rectangle foodRect = food.GetRect();
            if (playerRect.Intersects(foodRect))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void Draw(SpriteBatch sb)
        {
            sb.Draw(gfx, position, null, color, rotation + MathHelper.PiOver2, new Vector2(gfx.Width / 2, gfx.Height / 2), 1.0f, SpriteEffects.None, 0f);

        }
    }
}
