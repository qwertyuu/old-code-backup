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

namespace Sketch
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Texture2D[] directionTex;
        Texture2D bG;
        SpriteFont ecriture;
        Player joueur;
        Camera camera;
        DateTime now = DateTime.Now;
        KeyboardState old;
        float maxSpeed = 30;
        float accelSpeed = 40;
        Random rand = new Random();

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            graphics.PreferMultiSampling = false;
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
            camera = new Camera();
            joueur = new Player();
            joueur.position = Vector2.Zero;
            directionTex = new Texture2D[2];
            bG = Content.Load<Texture2D>("avataryay");
            ecriture = Content.Load<SpriteFont>("ecriture");
            directionTex[0] = Content.Load<Texture2D>("ouaisR");
            directionTex[1] = Content.Load<Texture2D>("ouaisL");
            joueur.texture = directionTex[0];
            old = Keyboard.GetState();
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
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                this.Exit();
            // TODO: Add your update logic here
            var lol = Keyboard.GetState();
            if (!joueur.inAir)
            {
                if (lol.IsKeyDown(Keys.Right))
                {
                    if (joueur.texture != directionTex[0])
                    {
                        joueur.texture = directionTex[0];
                    }
                    Vector2 buf = joueur.acceleration;
                    if (joueur.speed.X < maxSpeed)
                        buf.X = accelSpeed;
                    else
                        buf.X = 0;
                    joueur.acceleration = buf;
                }
                else if (lol.IsKeyDown(Keys.Left))
                {
                    if (joueur.texture == directionTex[0])
                    {
                        joueur.texture = directionTex[1];
                    }
                    Vector2 buf = joueur.acceleration;
                    buf.X = joueur.speed.X > -maxSpeed ? -accelSpeed : 0;
                    joueur.acceleration = buf;
                }
            }
            if (lol.IsKeyDown(Keys.Space))
            {
                if (!joueur.inAir)
                {
                    joueur.inAir = true;
                    joueur.speed += new Vector2(0, -20);
                    joueur.acceleration += new Vector2(-joueur.acceleration.X, 0);
                }
            }
            if (lol.IsKeyUp(Keys.Left) && lol.IsKeyUp(Keys.Right) && joueur.speed.X != 0)
            {
                joueur.isStopping = true;
            }
            old = lol;
            joueur.Update(gameTime);
            camera.Update(joueur);
            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, null, null, null, null, camera.ViewMatrix);
            //spriteBatch.Begin();
            spriteBatch.Draw(bG, Vector2.One, Color.White);
            spriteBatch.Draw(joueur.texture, joueur.position, Color.White);
            spriteBatch.End();
            string buf = "A";
            spriteBatch.Begin();
            spriteBatch.DrawString(ecriture, buf = string.Format("speed: {0}\nacceleration: {1}\nPos: {2}", joueur.speed, joueur.acceleration, joueur.position), new Vector2(GraphicsDevice.Viewport.Width - 200, 0), Color.Black);
            spriteBatch.End();
            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}
