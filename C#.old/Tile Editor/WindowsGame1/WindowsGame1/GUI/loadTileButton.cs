using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.IO;

namespace WindowsGame1.GUI
{
    public class loadTileButton : Buttan
    {
        public bool clicked = false;

        public loadTileButton(Texture2D texure, Vector2 posititon)
            : base(texure, posititon)
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

            Forms.newTileSheetForm frmTileSheet = new Forms.newTileSheetForm();
            frmTileSheet.ShowDialog();

            if (frmTileSheet.DialogResult == System.Windows.Forms.DialogResult.OK)
            {
                Game1.tileHeight = frmTileSheet.tileHeight;
                Game1.tileWidth = frmTileSheet.tileWidth;
                Game1.tileSheetFileName = frmTileSheet.SheetFileName;
                base.prevClicked = false;

                try
                {

                    Game1.tileSheet = Texture2DFromFile(Game1.tileSheetFileName );
                    Game1.map.lodeTileSat(Game1.tileSheet);

                }
                catch
                {
                    System.Windows.Forms.MessageBox.Show("There was an error loading the texture.");
                }
            }

            else
            {
                base.prevClicked = false;
            }

            Game1.state = state.PLAY;

            base.Effect();
        }
        
        public Texture2D Texture2DFromFile(string fileName)
        {
            Texture2D texture;

            FileStream stream = new FileStream(fileName, FileMode.Open);
            texture = Texture2D.FromStream(Game1.graphics.GraphicsDevice, stream);

            stream.Close();
            return texture;
        }
    }
}
