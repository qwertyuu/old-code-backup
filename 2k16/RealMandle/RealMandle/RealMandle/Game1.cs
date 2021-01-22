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

namespace RealMandle
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
            Content.RootDirectory = "Content";
            max_iter = 100;
            scale = 1;
            pos = Vector2.Zero;
            ReRender = true;
            offset = 0;
            calar = new Color[max_iter + 1];
            this.graphics.PreferredBackBufferHeight = 720;
            this.graphics.PreferredBackBufferWidth = 1280;
            this.IsMouseVisible = true;
        }
        int offset;
        Vector2 pos;
        private void rndClr()
        {
            Color bleu = new Color(0, 0, 255);
            Color noir = new Color(0, 0, 0);
            Color orange = new Color(255, 127.5f, 0);
            Color blanc = new Color(255, 255, 255);
            for (int i = 0; i < calar.Length; i++)
            {
                int step = (i + offset) % 20;
                if (step < 5)
                {
                    calar[i] = Color.Lerp(noir, bleu, i % 5 / 5f);
                }
                else if (step < 10)
                {
                    calar[i] = Color.Lerp(bleu, blanc, i % 5 / 5f);
                }
                else if (step < 15)
                {
                    calar[i] = Color.Lerp(blanc, orange, i % 5 / 5f);
                }
                else
                {
                    calar[i] = Color.Lerp(orange, noir, i % 5 / 5f);
                }
            }
        }
        private float map(float _value, float _min1, float _max1, float _min2, float _max2)
        {
            return _value * (_max2 - _min2) / (_max1 - _min1) + _min2;
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
        }
        Color[] calar;
        int max_iter;
        int width;
        bool ReRender;
        float scale;
        int height;
        Texture2D fractal;
        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.

            spriteBatch = new SpriteBatch(GraphicsDevice);
        }

        // TODO: use this.Content to load your game content here

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
            // TODO: Add your update logic here
            if (Keyboard.GetState().IsKeyDown(Keys.Left) && !ReRender)
            {
                pos.X -= 0.1f * scale;
                ReRender = true;
            }
            else if (Keyboard.GetState().IsKeyDown(Keys.Right) && !ReRender)
            {
                pos.X += 0.1f * scale;
                ReRender = true;
            }
            else if (Keyboard.GetState().IsKeyDown(Keys.Up) && !ReRender)
            {
                pos.Y -= 0.1f * scale;
                ReRender = true;
            }
            else if (Keyboard.GetState().IsKeyDown(Keys.Down) && !ReRender)
            {
                pos.Y += 0.1f * scale;
                ReRender = true;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.OemPlus) && !ReRender)
            {
                scale/=2;
                ReRender = true;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.OemMinus) && !ReRender)
            {
                scale*=2;
                ReRender = true;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.J) && !ReRender)
            {
                offset += 5;
                ReRender = true;
            }
            if (fractal == null || ReRender)
            {
                rndClr();
                width = GraphicsDevice.Viewport.Width;
                height = GraphicsDevice.Viewport.Height;
                fractal = new Texture2D(GraphicsDevice, width, height);
                Color[] pixels = new Color[width * height];
                for (int Pixl = 0; Pixl < pixels.Length; Pixl++)
                {
                    float x0 = map(Pixl % width, 0, width, pos.X-Math.Abs(2.5f * scale), pos.X + Math.Abs(1 * scale));
                    float y0 = map(Pixl / width, 0, height, pos.Y-Math.Abs(1 * scale), pos.Y + Math.Abs(1 * scale));
                    float x = 0.0f;
                    float y = 0.0f;
                    float i;
                    for (i = 0; x * x + y * y < 256 && i < max_iter; i++)
                    {
                        float xtemp = x * x - y * y + x0;
                        float ytemp = 2 * x * y + y0;
                        if (x == xtemp && y == ytemp)
                        {
                            i = max_iter;
                            break;
                        }
                        x = xtemp;
                        y = ytemp;
                    }
                    if (i < max_iter)
                    {
                        i += (float)(2 - (Math.Log(Math.Log(x * x + y * y))) / (Math.Log(2)));
                    }
                    Color color1 = calar[(int)(i - 1)];
                    Color color2 = calar[(int)(i - 1) + 1];
                    pixels[Pixl] = Color.Lerp(color1, color2, i % 1);
                }
                fractal.SetData<Color>(pixels);
                ReRender = false;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Escape))
                this.Exit();
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
            if (fractal != null)
            {
                spriteBatch.Draw(fractal, new Rectangle(0, 0, width, height), Color.White);
            }
            spriteBatch.End();
            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}
