using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MapEditor.Forms
{
    public partial class LoadMapForm : Form
    {
        //Declare the load file name
        string loadFileName;

        public LoadMapForm()
        {
            InitializeComponent();
        }

        private void browseButton_Click(object sender, EventArgs e)
        {
            //Set the initial directory
            openFileDialog1.InitialDirectory = @"C:\";

            //Set the title for the dialog box
            openFileDialog1.Title = "Select a Map File";
            openFileDialog1.FileName = "";

            //Set the filter for text files only
            openFileDialog1.Filter = "Text Files (*.txt)| *.txt";
            openFileDialog1.FilterIndex = 1;

            //Get the load file name
            if (openFileDialog1.ShowDialog() != DialogResult.Cancel)
            {
                loadFileName = openFileDialog1.FileName;
                fileName.Text = loadFileName;
            }
            else
            {
                loadFileName = "";
            }
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            //Return the cancel dialog result
            this.DialogResult = DialogResult.Cancel;
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            //Check that a tile sheet has been loaded before the map file is
            if (Game1.tileSheetFileName != null)
            {
                Game1.map.LoadMap(loadFileName);
            }
            else
            {
                MessageBox.Show("Please load a tile set before loading a map");
            }

            //update the map size and tile dimensions
            Game1.mapHeight = Game1.map.mapHeight;
            Game1.mapWidth = Game1.map.mapWidth;
            Game1.tileHeight = Game1.map.tileHeight;
            Game1.tileWidth = Game1.map.tileWidth;

            //update the map size and tile dimensions
            Game1.map = new Map_Classes.Map(Game1.mapWidth, Game1.mapHeight, Game1.tileWidth, Game1.tileHeight);

            //Load the map
            Game1.map.LoadMap(loadFileName);

            //Re-load the tileset
            Game1.map.LoadTileSet(Game1.tileSheet);

            //Return the ok dialog result
            this.DialogResult = DialogResult.OK;
        }
    }
}
