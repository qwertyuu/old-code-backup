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

namespace SelectionTest
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        MouseState last;
        SpriteFont ecriture;
        Rectangle fakeSelect;
        Bonhomme[] armée;
        Selection selectedArmée;
        Rectangle selection;
        Random rand;
        string[] lol;
        private Texture2D texture;

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
            spriteBatch = new SpriteBatch(GraphicsDevice);
            texture = Content.Load<Texture2D>("selection");
            ecriture = Content.Load<SpriteFont>("SpriteFont1");
            armée = new Bonhomme[500];
            selectedArmée = new Selection(ref armée);
            rand = new Random();
            for (int i = 0; i < armée.Length; i++)
            {
                armée[i] = new Bonhomme();
                armée[i].index = i;
                armée[i].couleur = Color.White;
                armée[i].pos = new Vector2(rand.Next(graphics.PreferredBackBufferWidth - 20), rand.Next(graphics.PreferredBackBufferHeight - 20));
            }
            selection = new Rectangle();
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
            var kB = Keyboard.GetState();
            if (kB.IsKeyDown(Keys.Escape))
            {
                this.Exit();
            }
            if (kB.IsKeyDown(Keys.D))
            {
                if (kB.IsKeyDown(Keys.LeftControl))
                {
                    selectedArmée.Clear();
                }
            }
            var mouse = Mouse.GetState();
            if (mouse.LeftButton == ButtonState.Pressed)
            {
                if (last.LeftButton == ButtonState.Released)
                {
                    fakeSelect = new Rectangle(mouse.X, mouse.Y, 0, 0);
                    selection = new Rectangle(fakeSelect.X, fakeSelect.Y, fakeSelect.Width, fakeSelect.Height);
                }
                else
                {
                    fakeSelect = new Rectangle(fakeSelect.X, fakeSelect.Y, mouse.X - fakeSelect.X, mouse.Y - fakeSelect.Y);

                    if (fakeSelect.Height < 0 && fakeSelect.Width > 0)
                    {
                        selection = new Rectangle(fakeSelect.X, fakeSelect.Y + fakeSelect.Height, fakeSelect.Width, -fakeSelect.Height);
                    }
                    else if (fakeSelect.Height > 0 && fakeSelect.Width < 0)
                    {
                        selection = new Rectangle(fakeSelect.X + fakeSelect.Width, fakeSelect.Y, -fakeSelect.Width, fakeSelect.Height);
                    }
                    else if (fakeSelect.Height < 0 && fakeSelect.Width < 0)
                    {
                        selection = new Rectangle(fakeSelect.X + fakeSelect.Width, fakeSelect.Y + fakeSelect.Height, -fakeSelect.Width, -fakeSelect.Height);
                    }
                    else
                    {
                        selection = new Rectangle(fakeSelect.X, fakeSelect.Y, fakeSelect.Width, fakeSelect.Height);
                    }
                }
            }
            else
            {
                if (last.LeftButton == ButtonState.Pressed)
                {
                    List<Bonhomme> tempSelection = (from a in armée
                               where a.spacePos.Intersects(selection)
                               orderby a.index descending
                               select a).ToList();

                    if (tempSelection.Count > 0)
                        if (selection.Width == 0 && selection.Height == 0)
                            if (kB.IsKeyDown(Keys.LeftControl))
                                selectedArmée.CtrlClick(tempSelection[0]);
                            else
                                selectedArmée.NewSelection(tempSelection[0]);
                        else
                            if (kB.IsKeyDown(Keys.LeftControl))
                                selectedArmée.CtrlClick(tempSelection);
                            else
                                selectedArmée.NewSelection(tempSelection);
                    else
                        if (kB.IsKeyUp(Keys.LeftControl))
                            selectedArmée.Clear();

                    fakeSelect = Rectangle.Empty;
                    selection = Rectangle.Empty;
                }
            }
            last = mouse;
            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            spriteBatch.Begin();
            foreach (var item in armée)
            {
                spriteBatch.Draw(texture, item.spacePos, item.couleur);
            }
            spriteBatch.Draw(texture, selection, Color.Red * 0.3f);
            //spriteBatch.DrawString(ecriture, selection.ToString() + selection.Height + selection.Width, Vector2.Zero, Color.White);
            spriteBatch.End();
            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}
