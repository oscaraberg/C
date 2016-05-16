using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;

namespace WindowsGame1.GUI
{
    public class Buttan
    {
        public bool clicked = false;
        public bool prevClicked = false;
        bool hover = false;
        Texture2D texture;
        public Vector2 position;
        Rectangle collisionRect;

        public Buttan(Texture2D tex, Vector2 position)
        {
            this.texture = tex;
            this.position = position;
        }

        public virtual void Update()
        {
            collisionRect = new Rectangle((int)position.X, (int)position.Y, texture.Width, texture.Height);

            MouseState mouse = Mouse.GetState();
            Rectangle mousePos = new Rectangle(mouse.X, mouse.Y, 1, 1);

            if (mousePos.Intersects(collisionRect))
                hover = true;
            else
                hover = false;

            if (mousePos.Intersects(collisionRect) && mouse.LeftButton == ButtonState.Pressed && !prevClicked)
                clicked = true;
            else
                clicked = false;

            prevClicked = prevClicked || clicked;

        }

        public virtual void Effect()
        {

        }

        public void Drow()
        {
            if (hover)
            {
                Game1.spriteBatch.Draw(texture, position, Color.White);
                Game1.spriteBatch.Draw(texture, position, new Color(255, 0, 0, 180));
            }
            else
                Game1.spriteBatch.Draw(texture, position, Color.White);

        }
    }
}
