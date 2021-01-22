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

namespace VisualSort
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            IsMouseVisible = true;
            graphics.PreferMultiSampling = true;
            graphics.PreferredBackBufferHeight = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height;
            graphics.PreferredBackBufferWidth = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width;
            graphics.IsFullScreen = false;
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
            enterPressed = false;
            Random rand = new Random();
            toSort = new int[graphics.PreferredBackBufferWidth];
            max = toSort.Length - 1;
            min = 0;
            //generation des valeurs en ordre
            for (int i = 0; i < toSort.Length; i++)
            {
                toSort[i] = (int)(((double)i / toSort.Length) * graphics.PreferredBackBufferHeight);
            }
            //mélange des valeurs
            for (int i = 0; i < toSort.Length * 20; i++)
            {
                int firstRand = rand.Next(toSort.Length);
                int secondRand = rand.Next(toSort.Length);
                while (secondRand == firstRand)
                {
                    secondRand = rand.Next(toSort.Length);
                }
                int buf = toSort[firstRand];
                toSort[firstRand] = toSort[secondRand];
                toSort[secondRand] = buf;
            }
            base.Initialize();
        }
        int[] toSort;
        bool enterPressed;
        private Texture2D laTexture;
        private SpriteFont font;
        int max;
        int min;
        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            laTexture = Content.Load<Texture2D>("Image1");
            font = Content.Load<SpriteFont>("SpriteFont1");
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            var KB = Keyboard.GetState();
            if (enterPressed)
            {
                //ceci est le cocktail shaker
                //going up
                for (int i = min; i < max; i++)
                {
                    if (toSort[i] > toSort[i + 1])
                    {
                        int buf = toSort[i];
                        toSort[i] = toSort[i + 1];
                        toSort[i + 1] = buf;
                    }
                }
                //drop le max pour pas avoir a checker les valeurs deja en ordre, hurr durr
                //going down
                for (int i = max; i > min; i--)
                {
                    if (toSort[i] < toSort[i - 1])
                    {
                        int buf = toSort[i];
                        toSort[i] = toSort[i - 1];
                        toSort[i - 1] = buf;
                    }
                }
                //pop le min pour pas, encore une fois, avoir a checker les valeurs deja en ordre
                max--;
                min++;
            }
            else if (KB.IsKeyDown(Keys.Enter))
            {
                enterPressed = true;
            }
            if (KB.IsKeyDown(Keys.F11))
            {
                graphics.IsFullScreen = !graphics.IsFullScreen;
                graphics.ApplyChanges();
            }
            if (KB.IsKeyDown(Keys.Escape))
            {
                this.Exit();
            }

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.White);
            spriteBatch.Begin();
            //chaque valeur dans l'array la
            for (int i = 0; i < toSort.Length; i++)
            {
                //valeur de la couleur
                int val = 255 - (int)((double)toSort[i] * 0.5 / graphics.PreferredBackBufferHeight * 255);
                //position, texture, couleur, etc.
                spriteBatch.Draw(laTexture, new Rectangle(i, graphics.PreferredBackBufferHeight - toSort[i], 1, toSort[i]), new Color(val, val, val));
            }
            if (!enterPressed)
            {
                //le texte... ouais
                spriteBatch.DrawString(font, "Appuyer sur Entree pour commencer", new Vector2(graphics.PreferredBackBufferWidth / 2 - font.MeasureString("Appuyer sur Entree pour commencer").X / 2, graphics.PreferredBackBufferHeight / 2), Color.Black);
            }
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
