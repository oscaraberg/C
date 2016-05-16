using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;

namespace MapEditor.Map_Classes
{
    public class Map
    {
        //Declare map and tile size variables
        public int mapWidth { get; set; }
        public int mapHeight { get; set; }
        public int tileWidth { get; set; }
        public int tileHeight { get; set; }

        //Declare new layers
        public Layer TileLayer1;
        public Layer TileLayer2;
        public Layer SolidLayer;

        //Declare a rectangle list to hold the tile bounds
        public List<Rectangle> tileSet = new List<Rectangle>();

        //Declare a rectangle to temporarily hold the tile bounds
        Rectangle bounds;

        public Map(int mapWidth, int mapHeight, int tileWidth, int tileHeight)
        {
            //Initialising instance variables
            this.mapHeight = mapHeight;
            this.mapWidth = mapWidth;
            this.tileHeight = tileHeight;
            this.tileWidth = tileWidth;

            //Initialise the layers
            TileLayer1 = new Layer(mapWidth, mapHeight, tileWidth, tileHeight);
            TileLayer2 = new Layer(mapWidth, mapHeight, tileWidth, tileHeight);
            SolidLayer = new Layer(mapWidth, mapHeight, tileWidth, tileHeight);
        }

        public void UpdateUserInput()
        {
            //move the viewable map using up down left right
            KeyboardState newState = Keyboard.GetState();
            if (Game1.drawOffset.X > 0)
            {
                if (newState.IsKeyDown(Keys.D))
                    Game1.drawOffset.X -= 1;
            }
            if (Game1.drawOffset.X < mapWidth - 1)
            {
                if (newState.IsKeyDown(Keys.A))
                    Game1.drawOffset.X += 1;
            }
            if (Game1.drawOffset.Y > 0)
            {
                if (newState.IsKeyDown(Keys.S))
                    Game1.drawOffset.Y -= 1;
            }
            if (Game1.drawOffset.Y < mapHeight - 1)
            {
                if (newState.IsKeyDown(Keys.W))
                    Game1.drawOffset.Y += 1;
            }
        }

        public void SaveMap(String fileName)
        {
            try
            {
                //Declare and initialize  the stream writer object
                System.IO.StreamWriter objWriter;
                objWriter = new System.IO.StreamWriter(@fileName + ".txt");

                //Write the map and tile dimensions
                objWriter.WriteLine(mapHeight);
                objWriter.WriteLine(mapWidth);
                objWriter.WriteLine(tileHeight);
                objWriter.WriteLine(tileWidth);

                //Write the layers to the text file
                TileLayer1.SaveLayer(objWriter);
                TileLayer2.SaveLayer(objWriter);
                SolidLayer.SaveLayer(objWriter);

                //close the textfile and dispose of the graphics object
                objWriter.Close();
                objWriter.Dispose();
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("There was an error saving the map.\nError:" + ex);
            }
        }

        public void LoadMap(String loadFileName)
        {
            try
            {
                //Declare and Initialize the stream reader object
                System.IO.StreamReader objReader;
                objReader = new System.IO.StreamReader(@loadFileName);

                //Find the map height and width from file
                mapHeight = Convert.ToInt32(objReader.ReadLine());
                mapWidth = Convert.ToInt32(objReader.ReadLine());
                tileHeight = Convert.ToInt32(objReader.ReadLine());
                tileWidth = Convert.ToInt32(objReader.ReadLine());

                //Reinitialize the map layers
                TileLayer1 = new Layer(mapWidth, mapHeight, tileWidth, tileHeight);
                TileLayer2 = new Layer(mapWidth, mapHeight, tileWidth, tileHeight);
                SolidLayer = new Layer(mapWidth, mapHeight, tileWidth, tileHeight);

                //Load the layers
                TileLayer1.LoadLayer(objReader);
                TileLayer2.LoadLayer(objReader);
                SolidLayer.LoadLayer(objReader);

                //close the text file and dispose of the graphics object
                objReader.Close();
                objReader.Dispose();
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("There was an error loading the map, is the file a valid map file?\nError:" + ex);
            }
        }

        public void DrawMap()
        {
            try
            {
                //Loop through all tile positions
                for (int x = 0; x < mapHeight; ++x)
                {
                    for (int y = 0; y < mapWidth; ++y)
                    {
                        //Tile Layer 1
                        if (TileLayer1.layer[y, x] != 0)
                        {
                            //Get the tile
                            bounds = tileSet[TileLayer1.layer[y, x] - 1];

                            //Draw the tile
                            Game1.spriteBatch.Draw(Game1.tileSheet, new Vector2(((y - Game1.drawOffset.X) * tileWidth),
                                             ((x - Game1.drawOffset.Y) * tileHeight)), bounds, Color.White);
                        }

                        //Tile Layer 2
                        if (TileLayer2.layer[y, x] != 0)
                        {
                            //get the tileSheet bounds so the correct tile is drawn
                            bounds = tileSet[TileLayer2.layer[y, x] - 1];

                            // Draw it in screen space
                            Game1.spriteBatch.Draw(Game1.tileSheet, new Vector2(((y - Game1.drawOffset.X) * tileWidth),
                                ((x - Game1.drawOffset.Y) * tileHeight)), bounds, Color.White);
                        }

                        //Solid Layer
                        if (SolidLayer.layer[y, x] != 0)
                        {
                            // Draw it in screen space
                            Game1.spriteBatch.Draw(Game1.solid, new Vector2(((y - Game1.drawOffset.X) * tileWidth),
                                ((x - Game1.drawOffset.Y) * tileHeight)), new Rectangle(0, 0, tileWidth, tileHeight),
                                new Color(255, 255, 255, 100));
                        }
                    }
                }
            }
            catch
            {
                ;//Empty
            }
        }

        public void LoadTileSet(Texture2D tileSheet)
        {
            //Get the tile dimensions
            int noOfTilesX = (int)tileSheet.Width / tileWidth;
            int noOfTilesY = (int)tileSheet.Height / tileHeight;

            //Initialise the tile set list
            tileSet = new List<Rectangle>(noOfTilesX * noOfTilesY);

            //Get the bounds of all tiles in the sheet
            for (int j = 0; j < noOfTilesY; ++j)
            {
                for (int i = 0; i < noOfTilesX; ++i)
                {
                    bounds = new Rectangle(i * tileWidth, j * tileHeight, tileWidth, tileHeight);
                    tileSet.Add(bounds);
                }
            }
        }
    }
}
