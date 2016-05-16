using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace pong
{
    class boll : GameObject
    {

    
        public int fartx = 3;
        public int farty = 3;
       

        public boll(Texture2D gfx, Vector2 start, Rectangle box)
        {
            this.gfx = gfx;
            this.start = start;
            this.box = box;
        }

        public void update()
        {
            box = new Rectangle((int)start.X, (int)start.Y, 12, 12);
            start.X += fartx;
            start.Y += farty;
            if (start.X <= 0)
            {
                fartx *= -1;
            }
            if (start.X >= 788)
            {
                fartx *= -1;
            }
            if (start.Y <= 0)
            {
                farty *= -1;
            }
           

        }

       
    }
}
