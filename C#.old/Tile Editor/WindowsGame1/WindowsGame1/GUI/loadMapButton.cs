using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace WindowsGame1.GUI
{
    public class loadMapButton : Buttan
    {
        public bool clicked = false;

        public loadMapButton(Texture2D texure, Vector2 posititon)
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

            Forms.Load_MapForm loadMap = new Forms.Load_MapForm();
            loadMap.ShowDialog();

            if (loadMap.DialogResult == System.Windows.Forms.DialogResult.OK)
                base.prevClicked = false;
            else
                base.prevClicked = false;

            Game1.state = state.PLAY;

            base.Effect();
        }
    }
}
