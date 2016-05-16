using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace pong
{
    class Padel : GameObject
    {

        Keys höger;
        Keys vänster;
        public int tal = 0;

        public Padel(Texture2D gfx, Vector2 start, Rectangle box, Keys höger, Keys vänster)
        {
            this.gfx = gfx;
            this.start = start;
            this.box = box;
            this.höger = höger;
            this.vänster = vänster;
            
        }

        public void update()
        {
            KeyboardState ks = Keyboard.GetState();
            box = new Rectangle((int)start.X, (int)start.Y, 90, 12);
            if(ks.IsKeyDown(vänster))
            {
                start.X -= 5;

            }
            if(ks.IsKeyDown(höger))
            {
                start.X += 5;
            }
            if (start.X <= 0)
            {
                start.X = 0;
            }
            if (start.X >= 710)
            {
                start.X = 710;
            }
 
        }

    } 
}
