using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace WindowsGame1
{

    public enum state
    {
        PLAY,
        FREEZE
    }
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {

        public static state state = state.PLAY;


        public static GraphicsDeviceManager graphics;
        public static SpriteBatch spriteBatch;
        public static Vector2 clientbounds;

        public static bool quit = false;
        public static Vector2 drowOffset = Vector2.Zero;

        public static String mapName;
        public static String fileName;
        public static String loadFileName;
        public static String tileSheetFileName;

        public static int drawableLayer = 0;

        public static Map_Classes.Map map;

        public static int mapHeight = 15;
        public static int mapWidth = 20;
        public static int tileHeight = 32;
        public static int tileWidth = 32;

        public static int selectedTileNo = 0;

        public static Texture2D tileSheet;
        public static Texture2D solid;
        Texture2D pixel;

        MouseState curState;
        KeyboardState prevState;

        SpriteFont basic;


        GUI.HUD hud;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            map = new Map_Classes.Map(mapWidth, mapHeight, tileWidth, tileHeight);


        }



        protected override void Initialize()
        {
            this.IsMouseVisible = true;

            graphics.PreferredBackBufferHeight = 700;
            graphics.PreferredBackBufferWidth = 800;
            graphics.ApplyChanges();

            clientbounds = new Vector2(Window.ClientBounds.Width, Window.ClientBounds.Height);

            base.Initialize();
        }


        protected override void LoadContent()
        {

            spriteBatch = new SpriteBatch(GraphicsDevice);

            pixel = Content.Load<Texture2D>(@"Sprites/pixel");
            solid = Content.Load<Texture2D>(@"Sprites/Solid");

            basic = Content.Load<SpriteFont>(@"Basic");

            hud = new WindowsGame1.GUI.HUD(Content);

        }

        protected override void UnloadContent()
        {

        }


        protected override void Update(GameTime gameTime)
        {

            if (quit)
                this.Exit();

            this.Window.Title = "Map Editor - " + mapName;

            KeyboardState keyState = Keyboard.GetState();
            if (selectedTileNo < map.tileSet.Count - 1)
            {
                if (keyState.IsKeyDown(Keys.Up) && !prevState.IsKeyDown(Keys.Up))
                    selectedTileNo++;
            }
            if (selectedTileNo > 0)
            {
                if (keyState.IsKeyDown(Keys.Down) && !prevState.IsKeyDown(Keys.Down))
                    selectedTileNo--;

            }

            if (state == state.PLAY && tileSheet != null)
            {

                if (drawableLayer == 0)
                    map.TileLayer1.SetTiles(selectedTileNo + 1);
                else if (drawableLayer == 1)
                    map.TileLayer2.SetTiles(selectedTileNo + 1);
                else if (drawableLayer == 2)
                    map.SolidLayer.SetTiles(1);
            }

            curState = Mouse.GetState();

            prevState = keyState;

            map.UpDateUserInput();


            hud.Update();

            base.Update(gameTime);
        }


        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin();


            spriteBatch.Draw(pixel, new Rectangle(-(int)drowOffset.X * map.tileWidth, -(int)drowOffset.Y * map.tileHeidht,
                map.mapWidth * map.tileWidth, map.mapHeidht * map.tileHeidht), Color.White);

            map.DrowMap();



            hud.Draw();


            if (tileSheet != null && drawableLayer != 2)
                spriteBatch.Draw(tileSheet, new Vector2(curState.X - tileWidth / 2, curState.Y - tileHeight / 2), map.tileSet[selectedTileNo], Color.White);

            string layerText = "";

            if (drawableLayer == 0)
                layerText = "Layer 1";
            else if (drawableLayer == 1)
                layerText = "Layer 2";
            else if (drawableLayer == 2)
                layerText = "Collision Layer";

            spriteBatch.DrawString(basic, layerText, new Vector2(5, 5), Color.White);

            

            base.Draw(gameTime);

            spriteBatch.End();
        }
    }
}
