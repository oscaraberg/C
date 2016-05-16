using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MapEditor.GUI
{
    public class SaveMapButton : Button
    {
        //Declare an instance variable
        public bool clicked = false;

        //Constructor
        public SaveMapButton(Texture2D texture, Vector2 position)
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

            //Create and show the save map form
            Forms.SaveMapForm saveMap = new Forms.SaveMapForm();
            saveMap.ShowDialog();

            //Get the dialog result
            if (saveMap.DialogResult == System.Windows.Forms.DialogResult.OK)
                base.prevClicked = false;
            else
                base.prevClicked = false;

            //Unfreeze the game
            Game1.state = State.PLAY;

            base.Effect();
        }
    }
}
