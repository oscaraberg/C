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
    class Food
    {

        Texture2D gfx;
        Vector2 position;
        static Random random = new Random();
        int platsX;
        int platsY;
        Color color;

        public Food(Texture2D gfx, Color color)
        {
            this.gfx = gfx;
            this.color = color;
            platsX = random.Next(0, 780);
            platsY = random.Next(0, 580);
            position = new Vector2(platsX, platsY);
           
            
        }
        public Rectangle GetRect()
        {
            Rectangle box = new Rectangle(platsX + gfx.Width/2  , platsY + gfx.Height/2, gfx.Width, gfx.Height);
            return box;
        }
        public void Draw(SpriteBatch sb)
        {
            sb.Draw(gfx, position,color);
        }
        
    }
}
