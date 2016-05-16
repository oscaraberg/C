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
    public class HUD
    {
        Texture2D panel;
        Texture2D newMap;
        Texture2D saveMap;
        Texture2D lodeMap;
        Texture2D lodeTiles;
        Texture2D backLayer;
        Texture2D frontLayer;
        Texture2D collisionLayer;

        Vector2 position;

        List<Buttan> buttons = new List<Buttan>();

        public HUD (ContentManager content)
	    {

            panel = content.Load<Texture2D>(@"Sprites/panel");
            newMap = content.Load<Texture2D>(@"Sprites/newMapButton");
            saveMap = content.Load<Texture2D>(@"Sprites/saveMapButton");
            lodeMap = content.Load<Texture2D>(@"Sprites/loadMapButton");
            lodeTiles = content.Load<Texture2D>(@"Sprites/loadTileButton");
            backLayer = content.Load<Texture2D>(@"Sprites/backLayer");
            frontLayer = content.Load<Texture2D>(@"Sprites/frontLayer");
            collisionLayer = content.Load<Texture2D>(@"Sprites/collisionLayerButton");

            position = new Vector2(0, (int)Game1.clientbounds.Y - panel.Height);

            buttons.Add(new newMapButton(newMap, new Vector2(position.X + 25, position.Y + 25)));
            buttons.Add(new saveMapButton(saveMap, new Vector2(position.X + 150, position.Y + 25)));
            buttons.Add(new loadMapButton(lodeMap, new Vector2(position.X + 275, position.Y + 25)));
            buttons.Add(new loadTileButton(lodeTiles, new Vector2(position.X + 400, position.Y + 25)));
            buttons.Add(new BackLayerButton(backLayer, new Vector2(position.X + 525, position.Y + 25)));
            buttons.Add(new frontLayerButton(frontLayer, new Vector2(position.X + 600, position.Y + 25)));
            buttons.Add(new collisionLayerButton(collisionLayer, new Vector2(position.X + 675, position.Y + 25)));
            


	    }

        public void Update()
        {
            for (int i = 0; i < buttons.Count; i++)
            {
                buttons[i].Update();

                if (buttons[i].clicked)
                    buttons[i].Effect();

            }
        }

        public void Draw()
        {

            Game1.spriteBatch.Draw(panel, position, Color.White);

            for (int i = 0; i < buttons.Count; i++)
                buttons[i].Drow();
           

        }                                            

    }
}
