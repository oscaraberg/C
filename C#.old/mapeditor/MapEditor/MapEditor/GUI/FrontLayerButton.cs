﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MapEditor.GUI
{
    public class FrontLayerButton : Button
    {
         //Declare an instance variable
        public bool clicked = false;

        //Constructor
        public FrontLayerButton(Texture2D texture, Vector2 position)
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
            //Set the drawable layer
            Game1.drawableLayer = 1;
            base.prevClicked = false;

            base.Effect();
        }
    }
}
