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

namespace Tetris
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Bloc yolo;
        KeyboardState old;

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
            yolo = new Bloc(BlocTypes.Lright, Content.Load<Texture2D>("texture"), new Vector2(200));
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
            var lol = Keyboard.GetState();
            if (lol.IsKeyDown(Keys.Escape))
                Exit();
            if (lol.IsKeyDown(Keys.Up))
            {
                if (old.IsKeyUp(Keys.Up))
                {
                    yolo.rotate = true;
                }
            }
            if (lol.IsKeyDown(Keys.Right))
            {
                if (old.IsKeyUp(Keys.Right))
                {
                    yolo.position += new Vector2(yolo.texture.Width, 0);
                }
            }
            if (lol.IsKeyDown(Keys.Left))
            {
                if (old.IsKeyUp(Keys.Left))
                {
                    yolo.position -= new Vector2(yolo.texture.Width, 0);
                }
            }
            if (lol.IsKeyDown(Keys.Space))
            {
                if (old.IsKeyUp(Keys.Space))
                {
                    if (yolo.type != (BlocTypes)5)
                    {
                        yolo.ChangeType(yolo.type + 1);
                    }
                    else
                    {
                        yolo.ChangeType((BlocTypes)0);
                    }
                }
            }
            old = lol;
            // TODO: Add your update logic here
            yolo.Update();
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
            yolo.Draw(spriteBatch);
            spriteBatch.End();
            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}
