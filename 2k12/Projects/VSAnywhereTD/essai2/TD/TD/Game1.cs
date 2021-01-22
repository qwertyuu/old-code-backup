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
    //enum ClickState { Clicked, Held, Releasing, Released }
    public enum InGameState { Play, Add, Upgrade }
    public enum UIButtonFunction { Add, Upgrade, Sell }

    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        static public InGameState inGameState;

        public static GraphicsDeviceManager graphics;
        private static object _selectedObject;
        public static object SelectedObject
        {
            get
            {
                return _selectedObject;
            }
            set
            {
                if (value == null)
                {
                    if (_selectedObject != null)
                    {
                        if (_selectedObject.GetType() == typeof(Tower))
                            ((Tower)_selectedObject).show = false;
                        else
                            ((Creep)_selectedObject).show = false;
                    }
                    _selectedObject = value;
                }
                else
                {
                    if (value != _selectedObject)
                    {
                        if (value.GetType() == typeof(Tower))
                            ((Tower)value).show = true;
                        else
                            ((Creep)value).show = true;
                        if (_selectedObject != null)
                        {
                            if (_selectedObject.GetType() == typeof(Tower))
                                ((Tower)_selectedObject).show = false;
                            else
                                ((Creep)_selectedObject).show = false;
                        }
                    }
                    _selectedObject = value;
                }
                InGameUI.SetButtons();
            }
        }
        SpriteBatch spriteBatch;
        public static SpriteFont font;
        MouseHandler mouse;
        KeyboardHandler keyboard;
        InGameUI gameUi;
        IMenu options;
        IMenu currentMenu;
        public static Texture2D towerRange;
        Camera cam;
        Tower clippedToMouse;
        Texture2D[] towersText;
        CreepWave wave;
        Texture2D[] uiTextures;
        public static Texture2D creepText;
        public static string currentMap = "11.txt";
        static List<Cell> cellsWithTower;
        SpriteFont debugFont;
        public static Texture2D missileText;
        public Texture2D[] mainMenuButtons;
        public static Texture2D cellT;
        IMenu ingamemenu;
        IMenu gameOverMenu;
        public static bool _Exit;
        public static uint playerLife = 10;

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
            cellsWithTower = new List<Cell>();
            spriteBatch = new SpriteBatch(GraphicsDevice);
            mainMenuButtons = new Texture2D[3];
            Map.map = Map.Parse(currentMap);
            debugFont = Content.Load<SpriteFont>("SpriteFont1");
            towerRange = Content.Load<Texture2D>("range");
            cam = new Camera();
            cam.position = new Vector2(0, Map.initialPathLocation.Y - GraphicsDeviceManager.DefaultBackBufferHeight / 2);
            missileText = Content.Load<Texture2D>("Missile");

            mainMenuButtons[0] = Content.Load<Texture2D>("PlayButton");
            mainMenuButtons[1] = Content.Load<Texture2D>("OptsButton");

            cellT = Content.Load<Texture2D>("Cell");

            font = Content.Load<SpriteFont>("SpriteFont1");

            towersText = new Texture2D[10];
            towersText[0] = Content.Load<Texture2D>("Tower");

            uiTextures = new Texture2D[10];
            uiTextures[0] = Content.Load<Texture2D>("UIParts/UI_Bottom");
            uiTextures[1] = Content.Load<Texture2D>("Icons/deleteIcon");
            uiTextures[2] = Content.Load<Texture2D>("Icons/addIcon");
            uiTextures[3] = Content.Load<Texture2D>("Icons/upgradeIcon");

            clippedToMouse = new Tower(Point.Zero, Tower.Types.type1, towersText[0], 100, false);

            currentMenu = new Menus.MainMenu();
            options = new Menus.Options(graphics);
            gameUi = new InGameUI(uiTextures, ref cellsWithTower);
            ingamemenu = new Menus.InGameMenu(ref cam, ref cellsWithTower, currentMap);
            gameOverMenu = new Menus.GameOverMenu(ref cam, ref cellsWithTower, currentMap);

            creepText = Content.Load<Texture2D>("Creep");
            wave = new CreepWave(30);
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
                if (currentMenu == null)
                {
                    if (!gameUi.textBounds[0].Contains(mouse.position))
                    {
                        if (mouse.LeftClickState == ClickState.Clicked)
                            LeftClick();
                        else if (mouse.LeftClickState == ClickState.Released)
                            Hover();
                        if (mouse.RightClickState == ClickState.Clicked)
                            RightClick();
                    }
                    else
                    {
                        if (clippedToMouse != null)
                        {
                            clippedToMouse = null;
                        }
                    }
                    gameUi.Update(mouse, keyboard);

                    if (keyboard.pressedKeysList.Contains(Keys.Escape))
                        currentMenu = ingamemenu;
                    wave.Update(gameTime, cellsWithTower);
                    for (int i = 0; i < cellsWithTower.Count; i++)
                    {
                        cellsWithTower[i].contains.Update(gameTime);
                    }

                    cam.Update(mouse, gameTime, gameUi);
                    if (playerLife == 0)
                        currentMenu = gameOverMenu;
                }

                else
                {
                    var oldMenuState = currentMenu.gameState;
                    var newMenu = IMenu.UpdateMenu(mouse, currentMenu, keyboard);
                    if (newMenu != currentMenu)
                    {
                        currentMenu = newMenu;
                        if (currentMenu != null)
                        {
                            currentMenu.senderMenuState = oldMenuState;
                        }
                    }
                }
            }

            base.Update(gameTime);
        }

        private void Hover()
        {
            switch (inGameState)
            {
                case InGameState.Play:
                    if (clippedToMouse != null)
                    {
                        clippedToMouse = null;
                    }
                    break;
                case InGameState.Add:
                    ClipTowersToCell(false);
                    break;
                default:
                    break;
            }
        }

        private void LeftClick()
        {
            switch (inGameState)
            {
                case InGameState.Play:
                    var pos = mouse.fakePos;
                    bool hasSelected = false;

                    foreach (var item in cellsWithTower)
                    {
                        if (item.contains.boundingBox.Contains(pos))
                        {
                            Game1.SelectedObject = item.contains;
                            hasSelected = true;
                            break;
                        }
                    }
                    if (!hasSelected)
                    {
                        foreach (var item in CreepWave.inGameCreeps)
                        {
                            if (item.boundingBox.Contains(pos))
                            {
                                Game1.SelectedObject = item;
                                hasSelected = true;
                                break;
                            }
                        }
                    }

                    if (!hasSelected)
                    {
                        Game1.SelectedObject = null;
                    }
                    break;

                case InGameState.Add:
                    if (ClipTowersToCell(true))
                    {
                        inGameState = InGameState.Play;
                    }
                    break;
                default:
                    break;
            }
        }

        private void RightClick()
        {
            switch (inGameState)
            {
                case InGameState.Play:
                    break;
                case InGameState.Add:
                    inGameState = InGameState.Play;
                    break;
                default:
                    break;
            }
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

                foreach (var item in cellsWithTower)
                    item.contains.Draw(spriteBatch, 1.0f);

                foreach (var item in cellsWithTower)
                {
                    if (item.contains.show)
                    {
                        item.contains.DrawRange(spriteBatch);
                        break;
                    }
                }

                wave.Draw(spriteBatch);

                if (clippedToMouse != null)
                {
                    clippedToMouse.Draw(spriteBatch, 0.5f);
                    if (clippedToMouse.show)
                        clippedToMouse.DrawRange(spriteBatch);
                }


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


        private bool ClipTowersToCell(bool click)
        {
            var pos = mouse.fakePos;
            foreach (var item in Map.map)
            {
                if (item.spacePos.Contains(pos))
                {
                    if (item.type == Cell.CellTypes.Turret && item.contains == null)
                    {
                        if (click && item.contains == null)
                        {
                            Tower buf = new Tower(item.spacePos.Location, Tower.Types.type1, towersText[0], 100, false);
                            item.contains = buf;
                            cellsWithTower.Add(item);
                        }
                        if (clippedToMouse == null)
                        {
                            clippedToMouse = new Tower(item.spacePos.Location, Tower.Types.type1, towersText[0], 100, true);
                        }
                        else if (clippedToMouse.boundingBox != item.spacePos)
                        {
                            clippedToMouse.boundingBox = item.spacePos;
                            //clippedToMouse = new Tower(item.spacePos.Location, Tower.Types.type1, towersText[0], 100, true);
                        }
                        return true;
                    }

                    else
                    {
                        clippedToMouse = null;
                    }
                }
            }
            return false;
        }

        private bool DeleteTower()
        {
            var pos = mouse.fakePos;
            foreach (var item in Map.map)
            {
                if (item.spacePos.Contains(pos) && item.contains != null)
                {
                    item.contains = null;
                    cellsWithTower.Remove(item);
                    return true;
                }
            }
            return false;
        }

        public static int gold { get; set; }
    }
}
