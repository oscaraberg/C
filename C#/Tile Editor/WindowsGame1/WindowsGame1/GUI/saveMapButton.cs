using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace WindowsGame1.GUI
{
    public class saveMapButton : Buttan
    {
        public bool clicked = false;

        public saveMapButton(Texture2D texure, Vector2 posititon)
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
            Forms.SaveMapForm saveMap = new Forms.SaveMapForm();
            saveMap.ShowDialog();

            if (saveMap.DialogResult == System.Windows.Forms.DialogResult.OK)
                base.prevClicked = false;
            else
                base.prevClicked = false;

            Game1.state = state.PLAY;


            base.Effect();
        }
    }
}
