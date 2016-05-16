using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace snake
{
    class Body
    {

        private Texture2D texture;
        private Color color;
        public Vector2 position;
        public Vector2 prevPosition;
        public Rectangle hitbox;
        


        public Body(Texture2D t)
        {
            this.texture = t;
            color = Color.LightGreen;
        }
        public void Update(GameTime gameTime)
        {
            prevPosition = position;
            hitbox = new Rectangle((int)position.X - texture.Width / 2, (int)position.Y - texture.Height / 2, texture.Width, texture.Height);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, position, null, color, 0f, new Vector2(texture.Width / 2, texture.Height / 2), 1f, SpriteEffects.None, 0f);
        }
    }
}
