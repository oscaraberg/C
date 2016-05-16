using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsGame1.Forms
{
    public partial class Load_MapForm : Form
    {

        string lodeFileName;

        public Load_MapForm()
        {
            InitializeComponent();
        }

        private void browseButton_Click(object sender, EventArgs e)
        {
            openFileDialog1.InitialDirectory = @"C:\";

            openFileDialog1.Title = "select a map file";
            openFileDialog1.FileName = "";

            openFileDialog1.Filter = "Text Files (*.txt)| *.txt";
            openFileDialog1.FilterIndex = 1;


            if (openFileDialog1.ShowDialog() != DialogResult.Cancel)
            {
                lodeFileName = openFileDialog1.FileName;
                fileName.Text = lodeFileName;
            }
            else
            {
                lodeFileName = "";
            }

           
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            if (Game1.tileSheetFileName != null)
            {
                Game1.map.LoadMap(lodeFileName);
            }
            else
            {
                MessageBox.Show("Please lode a tile set before loading a map");
            }

            Game1.mapHeight = Game1.map.mapHeidht;
            Game1.mapWidth = Game1.map.mapWidth;
            Game1.tileHeight = Game1.map.tileHeidht;
            Game1.tileWidth = Game1.map.tileWidth;


            Game1.map = new Map_Classes.Map(Game1.mapWidth, Game1.mapHeight, Game1.tileWidth, Game1.tileHeight);

            Game1.map.LoadMap(lodeFileName);

            Game1.map.lodeTileSat(Game1.tileSheet);
            
            this.DialogResult = DialogResult.OK;
        }
    }
}
