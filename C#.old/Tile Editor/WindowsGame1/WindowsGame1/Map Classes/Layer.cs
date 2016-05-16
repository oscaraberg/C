using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;

namespace WindowsGame1.Map_Classes
{
    public class Layer
    {
        public int[,] layer;

        int mapWidth, mapHeidht, tileWidht, tileHeidht;

        public Layer(int mapWidth, int mapHeidht, int tileWidht, int tileHeidht)
        {
            this.mapHeidht = mapHeidht;
            this.mapWidth = mapWidth;
            this.tileHeidht = tileHeidht;
            this.tileWidht = tileWidht;
            layer = new int[mapWidth, mapHeidht];
        }

        public void SetTiles(int selectedTile)
        {

            Vector2 mouse;
            double mouseMapX;
            double mouseMapY;

            MouseState currMouseStste = Mouse.GetState();

            try
            {
                if (currMouseStste.LeftButton == ButtonState.Pressed)
                {
                    mouse = new Vector2(currMouseStste.X, currMouseStste.Y);
                    mouseMapX = ((int)mouse.X / tileWidht) + Game1.drowOffset.X;
                    mouseMapY = ((int)mouse.Y / tileHeidht) + Game1.drowOffset.Y;
                    if (mouseMapX < mapWidth && mouseMapY < mapHeidht && mouseMapX >= 0 && mouseMapY >= 0)
                    {
                        layer[(int)mouseMapX, (int)mouseMapY] = selectedTile;
                    }
                }

                 if (currMouseStste.RightButton == ButtonState.Pressed)
                {
                    mouse = new Vector2(currMouseStste.X, currMouseStste.Y);
                    mouseMapX = ((int)mouse.X / tileWidht) + Game1.drowOffset.X;
                    mouseMapY = ((int)mouse.Y / tileHeidht) + Game1.drowOffset.Y;
                    if (mouseMapX < mapWidth && mouseMapY < mapHeidht && mouseMapX >= 0 && mouseMapY >= 0)
                    {
                        layer[(int)mouseMapX, (int)mouseMapY] = 0;
                    }
                }

            }
            catch
            {

            }

        }

        public void saveLayer(System.IO.StreamWriter objWriter)
        {

            try
            {
                for (int i = 0; i < mapWidth; i++)
                {
                    for (int j = 0; i < mapHeidht; j++)
                    {
                        objWriter.WriteLine(layer[i, j]);
                    }
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("There was an error saving the map./nError:" + ex);
            }


        }

        public void LoadLayer(System.IO.StreamReader objReader)
        {
            try
            {
                for (int i = 0; i < mapWidth; i++)
                {
                    for (int j = 0; i < mapHeidht; j++)
                    {
                        layer[i, j] = Convert.ToInt32(objReader.ReadLine());
                    }
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("There was an error loading the map./nError:" + ex);
            }
        }

    }
}
