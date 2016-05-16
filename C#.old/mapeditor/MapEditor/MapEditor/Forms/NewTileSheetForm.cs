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
    public partial class NewTileSheetForm : Form
    {
        //FileName for the tile sheet
        public String sheetFileName;

        //Tile dimensions
        public int tileHeight = 32;
        public int tileWidth = 32;

        public NewTileSheetForm()
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
            openFileDialog1.Filter = "Image Files (*.png)| *.png";
            openFileDialog1.FilterIndex = 1;

            //Browse for the tile sheet file
            if (openFileDialog1.ShowDialog() != DialogResult.Cancel)
            {
                sheetFileName = openFileDialog1.FileName;
            }
            else
            {
                sheetFileName = "";
            }

            //Set the textbox to the specified file name
            fileNameTextbox.Text = sheetFileName;
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            //Return ok dialog result
            this.DialogResult = DialogResult.OK;
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            //Cancel input
            this.DialogResult = DialogResult.Cancel;
        }
    }
}
