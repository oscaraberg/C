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
    public partial class NewMapForm : Form
    {

        public  int mapHeight;
        public  int mapWidth;
        public  int tileHeight;
        public  int tileWidth;

        public String mapName;

        public NewMapForm()
        {
            InitializeComponent();
        }

        private void NewMapForm_Load(object sender, EventArgs e)
        {

        }

        private void okButton_Click(object sender, EventArgs e)
        {

            mapName = mapNameText.Text;
            mapHeight = Convert.ToInt32(mapHeightBox.Value);
            mapWidth = Convert.ToInt32(mapWidthtBox.Value);
            tileHeight = Convert.ToInt32(tileHeightBox.Value);
            tileWidth = Convert.ToInt32(tileWidthtBox.Value);

            this.DialogResult = DialogResult.OK;

        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}
