using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace pong
{
    class GameObject
    {

        public Texture2D gfx;
        public Vector2 start;
        public Rectangle box;


        
        public void Draw(SpriteBatch spritebatch)
        {
            spritebatch.Draw(gfx, start, Color.White);
        }


    }

}
