using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;

namespace snake
{
    public class KeyInput
    {
        // The text that will be printed
        public string text;

        // The characters we want to process
        List <string> characters;
        List<string> shiftCharacters;

        // KeyboardState for current input and for previous input
        KeyboardState keyboardState;
        KeyboardState previousState;

        public KeyInput()
        {
            // Initialization
            text = "";
            characters = new List<string>();
            shiftCharacters = new List<string>();

            // Add the characters we wish to use to the array
            for (int i = 65; i < 65 + 26; i++)
            {
                characters.Add(Convert.ToChar(i).ToString());
            }
            for (int i = 0; i < 10; i++)
            {
                characters.Add("D" + i);
                characters.Add("NumPad" + i);
            }
            characters.AddRange(new string[] { "OemComma", "OemPeriod", "OemMinus", "OemPlus", "OemQuestion", Keys.Oem8.ToString()});
            shiftCharacters.AddRange(new string[] { "!", "\"", "#", "$", "%", "&", "/", "(", ")", "=" });
        }

        public void Update()
        {
            // Update the current keyboard state
            keyboardState = Keyboard.GetState();

            // Get all the currently pressed keys
            Keys[] arr = keyboardState.GetPressedKeys();

            // Check if any keys are pressed
            if (arr.Length > 0)
            {

                // Loop Through the pressed keys
                foreach (Keys key in arr)
                {
                    // Check for space
                    if (key == Keys.Space && previousState.IsKeyUp(Keys.Space))
                        text += " ";

                    // Make sure the key is not just still pressed from a previous call
                    if (characters.Contains(key.ToString()) && previousState.IsKeyUp(key))
                    {

                        // Extract the string equivalent of the pressed key
                        string output = key.ToString();

                        // Strip numbers pressed of text
                        if (output.Contains("NumPad"))
                            output = output.Substring(6, 1);
                        else if (output.Contains("D") && key != Keys.D)
                        {
                            output = output.Substring(1, 1);

                            // I shift is pressed, output shift click-representative
                            if (arr.Contains(Keys.LeftShift) || arr.Contains(Keys.RightShift))
                                output = shiftCharacters[int.Parse(output) == 0 ? 9 : int.Parse(output) - 1];
                        }
                        else if (key == Keys.OemPlus)
                        {
                            if (arr.Contains(Keys.LeftShift) || arr.Contains(Keys.RightShift))
                                output = "?";
                            else
                                output = "+";
                        }
                        else if (key == Keys.OemMinus)
                        {
                            if (arr.Contains(Keys.LeftShift) || arr.Contains(Keys.RightShift))
                                output = "_";
                            else
                                output = "-";
                        }
                        else if (key == Keys.OemPeriod)
                        {
                            if (arr.Contains(Keys.LeftShift) || arr.Contains(Keys.RightShift))
                                output = ":";
                            else
                                output = ".";
                        }
                        else if (key == Keys.OemComma)
                        {
                            if (arr.Contains(Keys.LeftShift) || arr.Contains(Keys.RightShift))
                                output = ";";
                            else
                                output = ",";
                        }
                        else if (key == Keys.OemQuestion)
                        {
                            if (arr.Contains(Keys.LeftShift) || arr.Contains(Keys.RightShift))
                                output = "*";
                            else
                                output = "'";
                        }
                        // If shift is not pressed, output lower case letter
                        else if (!arr.Contains(Keys.LeftShift) && !arr.Contains(Keys.RightShift))
                            output = output.ToLower();


                        // Add the keys value to the text
                        text += output;
                    }
                }
            }

            // Check for backspace click to remove letters
            if (keyboardState.IsKeyDown(Keys.Back) && previousState.IsKeyUp(Keys.Back)
                && text.Length > 0)

                // Remove the last character from the text
                text = text.Substring(0, text.Length - 1);

            // Update the previous keyboard state
            previousState = keyboardState;
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 position, SpriteFont font)
        {
            // Draw the text on the screen
            spriteBatch.DrawString(font, text, position, Color.White);
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 position, SpriteFont font, Color color)
        {
            // Get the center of the text
            Vector2 origin = font.MeasureString(text) / 2;

            // Draw the text on the screen
            spriteBatch.DrawString(font, text, position, color, 0, origin, 1.0f, SpriteEffects.None, 0);
        }
    }
}
