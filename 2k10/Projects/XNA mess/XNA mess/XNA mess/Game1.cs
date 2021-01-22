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

namespace XNA_mess
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
        /// 
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            textureDeMarde = Content.Load<Texture2D>("bobcat");
            ecriture = Content.Load<SpriteFont>("Ecriture");
            // TODO: use this.Content to load your game content here
            positionEcriture = new Vector2(50.0f, 50.0f);
            origine.X = textureDeMarde.Width / 2;
            origine.Y = textureDeMarde.Height / 2;
            maxY = graphics.GraphicsDevice.Viewport.Height - textureDeMarde.Height;
            maxX = graphics.GraphicsDevice.Viewport.Width - textureDeMarde.Width;
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
        string text;
        SpriteFont ecriture;
        Vector2 positionEcriture;
        Texture2D textureDeMarde;
        Vector2 position = new Vector2(50f, 50f);
        Vector2 vitesse = new Vector2(300.0f, 300.0f);
        Vector2 origine;
        float rotationValue = 0;

        int maxX;
        int minX = 0;
        int maxY;
        int minY = 0;
        protected override void Update(GameTime gameTime)
        {
            rotationValue += (float)Math.PI / 45;
            position += vitesse * (float)gameTime.ElapsedGameTime.TotalSeconds;

            if (position.X > maxX + 300)
            {
                vitesse.X *= -1f;
            }
            if (position.X < minX)
            {
                vitesse.X *= -1f;
            }
            if (position.Y > maxY + 300)
            {
                vitesse.Y *= (float)-1;
            }
            if (position.Y < minY)
            {
                vitesse.Y *= (float)-1;
            }
            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.BlanchedAlmond);
            // TODO: Add your drawing code here
            spriteBatch.Begin(SpriteSortMode.BackToFront, BlendState.AlphaBlend);
            //spriteBatch.Draw(textureDeMarde, position, null, Color.White, rotationValue, origine, 0.5f, SpriteEffects.None, 0f);
            spriteBatch.Draw(textureDeMarde, position, null, Color.White, rotationValue, origine, 1f, SpriteEffects.None, 0f);

            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
