using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;


namespace WindowsGame1.Map_Classes
{
    public class Map
    {
            public int mapWidth { get; set; }
            public int mapHeidht { get; set; }
            public int tileWidth { get; set; }
            public int tileHeidht { get; set; }

            public Layer TileLayer1;
            public Layer TileLayer2;
            public Layer SolidLayer;

            public List<Rectangle> tileSet = new List<Rectangle>();

            Rectangle bounds;

                public Map (int mapWidth, int mapHeigth, int tileWidth, int tileHeagth)
	        {
                this.mapHeidht = mapHeigth;
                this.mapWidth = mapWidth;
                this.tileHeidht = tileHeagth;
                this.tileWidth = tileWidth;

                //Initialise the layers
                TileLayer1 = new Layer(mapWidth, mapHeidht, tileWidth, tileHeidht);
                TileLayer2 = new Layer(mapWidth, mapHeidht, tileWidth, tileHeidht);
                SolidLayer = new Layer(mapWidth, mapHeidht, tileWidth, tileHeidht);
	        }

            public void UpDateUserInput()
            {
                KeyboardState newState = Keyboard.GetState();   
                if(Game1.drowOffset.X >0)
                {
                    if(newState.IsKeyDown(Keys.D))
                    {
                        Game1.drowOffset.X -= 1;
                    }
                }
                if(Game1.drowOffset.X < mapWidth -1)
                {
                    if(newState.IsKeyDown(Keys.A))
                    {
                        Game1.drowOffset.X +=1;
                    }
                }
                if (Game1.drowOffset.Y > 0)
                {
                    if (newState.IsKeyDown(Keys.S))
                    {
                        Game1.drowOffset.Y += 1;
                    }
                }
                if (Game1.drowOffset.Y < mapHeidht - 1)
                {
                    if (newState.IsKeyDown(Keys.W))
                    {
                        Game1.drowOffset.Y -= 1;
                    }
                }
            }

            public void SaveMap(string fileName)
            {
                try
                {
                    System.IO.StreamWriter objWriter;
                    objWriter = new System.IO.StreamWriter(@fileName + ".txt");

                    objWriter.WriteLine(mapHeidht);
                    objWriter.WriteLine(mapWidth);
                    objWriter.WriteLine(tileHeidht);
                    objWriter.WriteLine(tileWidth);

                    TileLayer1.saveLayer(objWriter);
                    TileLayer2.saveLayer(objWriter);
                    SolidLayer.saveLayer(objWriter);

                    objWriter.Close();
                    objWriter.Dispose();


                }
                catch(Exception ex)
                {
                    System.Windows.Forms.MessageBox.Show("There was an error saving the map./nError:" + ex);
                }

            }

            public void LoadMap(string loadFileName)
            {
                try
                {
                    System.IO.StreamReader objReader;
                    objReader = new System.IO.StreamReader(@loadFileName);

                    mapHeidht = Convert.ToInt32(objReader.ReadLine());
                    mapWidth = Convert.ToInt32(objReader.ReadLine());
                    tileHeidht = Convert.ToInt32(objReader.ReadLine());
                    tileWidth = Convert.ToInt32(objReader.ReadLine());

                    TileLayer1 = new Layer(mapWidth, mapHeidht, tileWidth, tileHeidht);
                    TileLayer2 = new Layer(mapWidth, mapHeidht, tileWidth, tileHeidht);
                    SolidLayer = new Layer(mapWidth, mapHeidht, tileWidth, tileHeidht);

                    TileLayer1.LoadLayer(objReader);
                    TileLayer2.LoadLayer(objReader);
                    SolidLayer.LoadLayer(objReader);

                }
                catch (Exception ex)
                {
                    System.Windows.Forms.MessageBox.Show("There was an error loading the map./nError:" + ex);
                }
            }

            public void DrowMap()
            {
                try
                {
                    for (int x = 0; x <mapHeidht; x++)
                    {

                        for (int y = 0; y <mapWidth ; y++)
                        {
                            if (TileLayer1.layer[y, x] != 0)
                            {
                                bounds = tileSet[TileLayer1.layer[y, x] - 1];

                                Game1.spriteBatch.Draw(Game1.tileSheet, new Vector2(((y - Game1.drowOffset.X) * tileWidth), ((x - Game1.drowOffset.Y) * tileHeidht)), bounds, Color.White); 
                            }

                            if (TileLayer2.layer[y, x] != 0)
                            {
                                bounds = tileSet[TileLayer2.layer[y, x] - 1];

                                Game1.spriteBatch.Draw(Game1.tileSheet, new Vector2(((y - Game1.drowOffset.X) * tileWidth), ((x - Game1.drowOffset.Y) * tileHeidht)), bounds, Color.White);
                            }

                            if (SolidLayer.layer[y, x] != 0)
                            {
                                Game1.spriteBatch.Draw(Game1.solid,new Vector2(((y - Game1.drowOffset.X) * tileWidth), ((x - Game1.drowOffset.Y) * tileHeidht)),new Rectangle(0,0,tileHeidht,tileWidth),new Color(255,255,255,100));
                            }
                        }

                    }

                }
                catch
                {

                }

            }

            public void lodeTileSat(Texture2D tileSheet)
            {

                int onofTilesX = (int)tileSheet.Width / tileWidth;
                int onofTilesY = (int)tileSheet.Height / tileHeidht;

                tileSet = new List<Rectangle>(onofTilesX * onofTilesY);

                for (int j = 0; j < onofTilesY; j++)
                {
                    for (int i = 0; i < onofTilesX; i++)
                    {
                        bounds = new Rectangle(i * tileWidth, j * tileHeidht, tileWidth, tileHeidht);
                        tileSet.Add(bounds);
                    }
                }

            }
    }
}
