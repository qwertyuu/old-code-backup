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
using System.IO;
using System.Xml.Serialization;

//////////////////////////
//LEARN TO CODE GOD DAMMIT
//ou pas
//////////////////////////


namespace TD
{
    enum GameState { MainMenu, Options, InGame, PlayMenu, LoadingMenu, InGameMenu, SaveMenu, EndGameMenu, None}
    enum ClickState { Clicked, Held, Releasing, Released }

    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        public static SpriteFont font;
        MouseHandler mouse;
        KeyboardHandler keyboard;
        InGameUI gameUi;
        IMenu currentMenu;
        Camera cam;
        Tower clippedToMouse;
        Texture2D[] towersText;
        Texture2D[] uiTextures;
        public Texture2D[] mainMenuButtons;
        public static Texture2D cellT;
        IMenu ingamemenu;
        public static bool _Exit;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            base.Initialize();
            mouse = new MouseHandler();
            keyboard = new KeyboardHandler();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            mainMenuButtons = new Texture2D[3];
            Map.map = Map.Parse("1.txt");
            cam = new Camera();
            mainMenuButtons[0] = Content.Load<Texture2D>("PlayButton");
            mainMenuButtons[1] = Content.Load<Texture2D>("OptsButton");

            cellT = Content.Load<Texture2D>("Cell");

            font = Content.Load<SpriteFont>("SpriteFont1");

            towersText = new Texture2D[10];
            towersText[0] = Content.Load<Texture2D>("Tower");

            uiTextures = new Texture2D[10];
            uiTextures[0] = Content.Load<Texture2D>("planUI");

            clippedToMouse = new Tower(Point.Zero, Tower.Types.type1, towersText[0]);

            currentMenu = new Menus.MainMenu();
            gameUi = new InGameUI(uiTextures);
            ingamemenu = new Menus.InGameMenu(ref cam, "1.txt");
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (IsActive)
            {
                keyboard.Update();
                mouse.Update(cam, currentMenu);
                if(currentMenu == null)
                {
                        if (mouse.LeftClickState == ClickState.Clicked)
                            ClipTowersToCell(true);
                        if (mouse.RightClickState == ClickState.Clicked)
                            DeleteTower();
                        else
                            ClipTowersToCell(false);


                        if (keyboard.pressedKeysList.Contains(Keys.Escape))
                            currentMenu = ingamemenu;

                        cam.Update(mouse, gameTime);
                }

                else
                    currentMenu = IMenu.UpdateMenu(mouse, currentMenu, keyboard);
            }

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            if(_Exit)
            {
                Exit();
            }
            else if (currentMenu == null)
            {
                spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, null, null, null, null, cam.viewMatrix);
                foreach (var item in Map.map)
                {
                    if (item.contains != null)
                    {
                        item.contains.Draw(spriteBatch, 1.0f);
                    }
                    else
                    {
                        Color a = Color.White;
                        switch (item.type)
                        {
                            case Cell.CellTypes.Rock:
                                a = Color.Brown;
                                break;
                            case Cell.CellTypes.Turret:
                                a = Color.Green;
                                break;
                            default:
                                break;
                        }
                        spriteBatch.Draw(cellT, item.spacePos, a);
                    }
                }

                if (clippedToMouse != null)
                    clippedToMouse.Draw(spriteBatch, 0.5f);


                spriteBatch.End();
                spriteBatch.Begin();
                gameUi.Draw(spriteBatch);
                spriteBatch.End();
            }
            else
            {
                spriteBatch.Begin();
                IMenu.Draw(spriteBatch, currentMenu);
                spriteBatch.End();
            }
            base.Draw(gameTime);
        }
        private void ClipTowersToCell(bool click)
        {
            foreach (var item in Map.map)
            {
                if (item.spacePos.Contains(mouse.fakePos))
                {
                    if (item.type == Cell.CellTypes.Turret)
                    {
                        if (click && item.contains == null)
                        {
                            Tower buf = new Tower(item.spacePos.Location, Tower.Types.type1, towersText[0]);
                            item.contains = buf;
                        }
                        clippedToMouse = new Tower(item.spacePos.Location, Tower.Types.type1, towersText[0]);
                        break;
                    }
                    else
                    {
                        clippedToMouse = null;
                    }
                }
            }
        }

        private void DeleteTower()
        {
            foreach (var item in Map.map)
            {
                if (item.spacePos.Contains(mouse.fakePos) && item.contains != null)
                {
                    item.contains = null;
                }
            }
        }
    }
}
