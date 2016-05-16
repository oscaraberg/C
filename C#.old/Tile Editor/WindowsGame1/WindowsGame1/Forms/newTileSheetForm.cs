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
    public partial class newTileSheetForm : Form
    {

        public String SheetFileName;

        public int tileWidth = 32;
        public int tileHeight = 32;




        public newTileSheetForm()
        {
            InitializeComponent();
        }

       
        private void BrowseButton_Click(object sender, EventArgs e)
        {

            openFileDialog1.InitialDirectory = @"C:\";

            openFileDialog1.Title = "select a map file";
            openFileDialog1.FileName = "";

            openFileDialog1.Filter = "Image Files (*.png)| *.png";
            openFileDialog1.FilterIndex = 1;


            if (openFileDialog1.ShowDialog() != DialogResult.Cancel)
            {
                SheetFileName = openFileDialog1.FileName;
            }
            else
            {
                SheetFileName = "";
            }

            FileNameTextBox.Text = SheetFileName; 
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void tileHeightBox_ValueChanged(object sender, EventArgs e)
        {

        }

    }
}
