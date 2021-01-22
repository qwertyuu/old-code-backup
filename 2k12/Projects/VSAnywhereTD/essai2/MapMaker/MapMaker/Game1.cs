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

namespace MapMaker
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    enum ClickState { Clicked, Held, Releasing, Released }
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        public static GraphicsDeviceManager graphics;
        List<Cell> changed;
        SpriteBatch spriteBatch;
        MouseHandler mouse;
        Camera cam;
        Grille grid;
        public static Texture2D texture;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
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
            IsMouseVisible = true;
            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            texture = Content.Load<Texture2D>("Cell");
            spriteBatch = new SpriteBatch(GraphicsDevice);
            grid = Grille.Parse(Content.Load<Texture2D>("map1"));
            cam = new Camera(grid);
            mouse = new MouseHandler();
            changed = new List<Cell>();
            // TODO: use this.Content to load your game content here
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
            // Allows the game to exit
            if (Keyboard.GetState().IsKeyDown(Keys.Escape))
                this.Exit();
            if (mouse.LeftClickState == ClickState.Clicked || mouse.LeftClickState == ClickState.Held)
            {
                foreach (var item in grid.cellules)
                {
                    if (item.position.Contains(mouse.fakePos))
                    {
                        item.SwitchKind();
                        changed.Add(item);
                    }
                }
            }
            else if (mouse.LeftClickState == ClickState.Releasing)
            {
                foreach (var item in changed)
                {
                    item.changed = false;
                }
            }

            cam.Update(mouse, gameTime);
            mouse.Update(cam);
            // TODO: Add your update logic here

            base.Update(gameTime);
        }
        protected override void OnExiting(object sender, EventArgs args)
        {
            if (!Directory.Exists("maps"))
            {
                Directory.CreateDirectory("maps");
            }
            var a = Directory.GetFiles("maps", "*.txt", SearchOption.TopDirectoryOnly);
            int highest = 0;
            foreach (var item in a)
            {
                int buf = 0;
                if (int.TryParse(Path.GetFileNameWithoutExtension(item), out buf))
                {
                    if (buf > highest)
                    {
                        highest = buf;
                    }
                }
            }
            using (TextWriter tW = new StreamWriter("maps/" + (highest + 1) + ".txt"))
            {
                for (int i = 0; i < grid.cellules.GetLength(1); i++)
                {
                    for (int j = 0; j < grid.cellules.GetLength(0); j++)
                    {
                        tW.Write(grid.cellules[j, i].chiffre);
                    }
                    if (i != grid.cellules.GetLength(1) - 1)
                    {
                        tW.Write(Environment.NewLine);
                    }
                }
            }
            base.OnExiting(sender, args);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, null, null, null, null, cam.viewMatrix);
            grid.Draw(spriteBatch);
            spriteBatch.End();
            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}
