using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace WindowsGame1.GUI
{
    public class newMapButton : Buttan
    {
         public bool clicked = false;

         public newMapButton(Texture2D texure, Vector2 posititon)
            :base(texure, posititon)
        {

        }

        public override void Update()
        {
            clicked = base.clicked;           
            base.Update();

        }


        public override void Effect()
        {
            Game1.state = state.FREEZE;


            Forms.NewMapForm newMap = new Forms.NewMapForm();
            newMap.ShowDialog();

            if (newMap.DialogResult == System.Windows.Forms.DialogResult.OK)
            {
                Game1.mapHeight = newMap.mapHeight;
                Game1.mapWidth = newMap.mapWidth;
                Game1.tileHeight = newMap.tileHeight;
                Game1.tileWidth = newMap.tileWidth;
                Game1.mapName = newMap.mapName;


                Game1.selectedTileNo = 0;
                Game1.drowOffset = Microsoft.Xna.Framework.Vector2.Zero;

                Game1.map = new Map_Classes.Map(Game1.mapWidth, Game1.mapHeight, Game1.tileWidth, Game1.tileHeight);

                if (Game1.tileSheet != null)
                    Game1.map.lodeTileSat(Game1.tileSheet);

                base.prevClicked = false;

            }

            else
            {

                base.prevClicked = false;

            }


            Game1.state = state.PLAY;

            base.Effect();
        }
    }
}
