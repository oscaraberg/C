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
    public partial class SaveMapForm : Form
    {

        string saveFileName;

        public SaveMapForm()
        {
            InitializeComponent();
        }

      
        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void browseButton_Click(object sender, EventArgs e)
        {
            saveFileDialog1.Title = "Specify Destination File Name";

            saveFileDialog1.FileName = Game1.mapName;

            saveFileDialog1.OverwritePrompt = true;

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                saveFileName = saveFileDialog1.FileName;
                fileName.Text = saveFileName;
            }
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            if (Game1.tileSheetFileName != null)
            {
                saveFileName = saveFileDialog1.FileName;
                Game1.map.SaveMap(saveFileName);
            }
            else
            {
                MessageBox.Show("You have not loaded a tile sheet");
            }

            this.DialogResult = DialogResult.OK;

        }
    }
}
