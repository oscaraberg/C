using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MapEditor.GUI
{
    public class LoadTileButton : Button
    {
        //Declare an instance variable
        public bool clicked = false;

        //Constructor
        public LoadTileButton(Texture2D texture, Vector2 position)
            : base(texture, position)
        {
        }

        //Update clicked
        public override void Update()
        {
            clicked = base.clicked;
            base.Update();
        }

        //Event for the button
        public override void Effect()
        {
            //Freeze the game
            Game1.state = State.FREEZE;

            //Create an instance of the new tilesheet form
            Forms.NewTileSheetForm frmTileSheet = new Forms.NewTileSheetForm();
            frmTileSheet.ShowDialog();

            //Get the tileset if the ok button has been clicked
            if (frmTileSheet.DialogResult == System.Windows.Forms.DialogResult.OK)
            {
                Game1.tileHeight = frmTileSheet.tileHeight;
                Game1.tileWidth = frmTileSheet.tileWidth;
                Game1.tileSheetFileName = frmTileSheet.sheetFileName;
                base.prevClicked = false;

                //Import the tile sheet as a texture
                try
                {
                    //Make magenta the transparent colour
                    TextureCreationParameters tcp = TextureCreationParameters.Default;
                    tcp.ColorKey = Microsoft.Xna.Framework.Graphics.Color.Magenta;
                    tcp.Format = SurfaceFormat.Rgba32;

                    //Load the texture
                    Game1.tileSheet = Texture2D.FromFile(Game1.graphics.GraphicsDevice, Game1.tileSheetFileName, tcp);
                    Game1.map.LoadTileSet(Game1.tileSheet);

                }
                catch
                {
                    //The texture file name may be empty or not exist
                    System.Windows.Forms.MessageBox.Show("There was an error loading the texture.");
                }
            }
            else
            {
                //Reset the button click property
                base.prevClicked = false;
            }

            //Unfreeze the game
            Game1.state = State.PLAY;

            base.Effect();
        }
    }
}
