﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;

namespace Break_Out
{
    class Paddle
    {
        Vector2 position;
        Vector2 motion;
        float paddleSpeed = 8f;

        KeyboardState KeyboardState;
        GamePadState GamePadState;

        Texture2D texture;
        Rectangle screenBounds;

        public Paddle(Texture2D texture, Rectangle screenBounds)
        {
            this.texture = texture;
            this.screenBounds = screenBounds;
            SetInStartPosition();
        
        }

        public void Update()
        {
            motion = Vector2.Zero;

            KeyboardState = Keyboard.GetState();
            GamePadState = GamePad.GetState(PlayerIndex.One);

            if (KeyboardState.IsKeyDown(Keys.Left) || GamePadState.IsButtonDown(Buttons.LeftThumbstickLeft) || GamePadState.IsButtonDown(Buttons.DPadLeft))
                motion.X = -1;
            if (KeyboardState.IsKeyDown(Keys.Right) || GamePadState.IsButtonDown(Buttons.LeftThumbstickRight) ||GamePadState.IsButtonDown(Buttons.DPadRight))
                motion.X = 1;

            motion.X *= paddleSpeed;
            position += motion;
            LockPaddle();
        }

        private void LockPaddle()
        {
            if (position.X < 0)
                position.X = 0;
            if (position.X + texture.Width > screenBounds.Width)
                position.X = screenBounds.Width - texture.Width;
        }

        public void SetInStartPosition()
        {
            position.X = (screenBounds.Width - texture.Width) / 2;
            position.Y = screenBounds.Height - texture.Height - 5;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, position, Color.White);
        }

        public Rectangle GetBounds()
        {
            return new Rectangle(
            (int)position.X,
            (int)position.Y,
            texture.Width,
            texture.Height);
        }
    }
}
