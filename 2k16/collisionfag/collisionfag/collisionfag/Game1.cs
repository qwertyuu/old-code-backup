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

namespace collisionfag
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Texture2D texture;
        Rectangle PlayerPos;
        Rectangle mouvement;
        Rectangle AssPos;
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
            PlayerPos = new Rectangle(0, 0, 50, 50);
            mouvement = Rectangle.Empty;
            AssPos = new Rectangle(200, 200, 50, 50);
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
            texture = Content.Load<Texture2D>("explosion");
            // TODO: use this.Content to load your game content here
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
            if (kB.IsKeyDown(Keys.Right))
            {
                mouvement.X += 5;
            }
            if (kB.IsKeyDown(Keys.Left))
            {
                mouvement.X -= 5;
            }
            if (kB.IsKeyDown(Keys.Up))
            {
                mouvement.Y -= 5;
            }
            if (kB.IsKeyDown(Keys.Down))
            {
                mouvement.Y += 5;
            }
            PlayerPos.X += mouvement.X;
            PlayerPos.Y += mouvement.Y;

            if (PlayerPos.Intersects(AssPos))
            {
                if (mouvement.X > 0)
                {
                    PlayerPos.X = AssPos.X - PlayerPos.Width;
                }
                if (mouvement.X < 0)
                {
                    PlayerPos.X = AssPos.X + AssPos.Width;
                }
                if (mouvement.Y > 0)
                {
                    PlayerPos.Y = AssPos.Y - PlayerPos.Height;
                }
                if (mouvement.Y < 0)
                {
                    PlayerPos.Y = AssPos.Y + AssPos.Height;
                }
            }
            mouvement = Rectangle.Empty;
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
            spriteBatch.Draw(texture, PlayerPos, Color.Black);
            spriteBatch.Draw(texture, AssPos, Color.Green);
            spriteBatch.End();
            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}
