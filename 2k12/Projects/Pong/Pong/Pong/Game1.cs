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

namespace Pong
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Texture2D texture;
        Ball boule;
        AI ai;
        SoundEffect blip;
        SoundEffect point;
        bool p1last = false;
        bool p2last = false;
        SoundEffectInstance test;
        SpriteFont ecriture;
        int largeur = 30;
        Joueur p1;
        Joueur p2;
        Rectangle[] sides;
        private SoundEffect blipSide;

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
            texture = Content.Load<Texture2D>("empty");
            sides = new Rectangle[]
            {
                new Rectangle(graphics.PreferredBackBufferWidth, 0, largeur, graphics.PreferredBackBufferHeight),
                new Rectangle(0, -largeur, graphics.PreferredBackBufferWidth, largeur),
                new Rectangle(-largeur, 0, largeur, graphics.PreferredBackBufferHeight),
                new Rectangle(0, graphics.PreferredBackBufferHeight, graphics.PreferredBackBufferWidth, largeur)
            };
            point = Content.Load<SoundEffect>("Point");
            blip = Content.Load<SoundEffect>("Blip");
            blipSide = Content.Load<SoundEffect>("BlipSide");
            test = blipSide.CreateInstance();
            test.Pitch = -1;
            ecriture = Content.Load<SpriteFont>("SpriteFont1");
            p1 = new Joueur(PlayerIndex.One, ecriture);
            p2 = new Joueur(PlayerIndex.Two, ecriture);
            ai = new AI(ref p2);
            boule = new Ball();
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
                this.Exit();

            if (kB.IsKeyDown(Keys.Space))
                boule = new Ball();

            if (kB.IsKeyDown(Keys.Up))
                p2.direction = Joueur.Direction.Up;
            else if (kB.IsKeyDown(Keys.Down))
                p2.direction = Joueur.Direction.Down;
            else
                p2.direction = Joueur.Direction.None;

            if (kB.IsKeyDown(Keys.S))
                p1.direction = Joueur.Direction.Down;
            else if (kB.IsKeyDown(Keys.W))
                p1.direction = Joueur.Direction.Up;
            else
                p1.direction = Joueur.Direction.None;

            Rectangle collisionChecker = Rectangle.Intersect(p1.spacePos, boule.spacePos);
            if (collisionChecker != Rectangle.Empty)
            {
                if (!p1last)
                {
                    ai.canMove = true;
                    if (collisionChecker.Width > collisionChecker.Height)
                    {
                        boule.direction = 360 - boule.direction;
                    }
                    else
                    {
                        Vector2 c = new Vector2(p1.spacePos.X - p1.centralPointDistance, p1.spacePos.Center.Y);
                        boule.direction = (int)MathHelper.ToDegrees((float)Math.Atan2(collisionChecker.Center.Y - c.Y, collisionChecker.Center.X - c.X));
                        //int incomingAngle = boule.direction;
                        //pour un dynamisme, 
                        //boule.direction = (int)(_angle + 180 - incomingAngle);
                        //PS: _angle c'est la mathématique que j'utilise pour la direction en ce moment
                    }
                    blip.Play();
                    if (test.Pitch + 0.01f < 1)
                    {
                        test.Pitch += 0.01f;
                    }
                    p2.speed += 5;
                    p1.speed += 5;
                    ai.Reset();
                    boule.speed += new Vector2(5);
                }
                p1last = true;
            }
            else
                p1last = false;

            collisionChecker = Rectangle.Intersect(p2.spacePos, boule.spacePos);

            if (collisionChecker != Rectangle.Empty)
            {
                if (!p2last)
                {
                    ai.canMove = false;
                    if (collisionChecker.Width > collisionChecker.Height)
                    {
                        boule.direction = 360 - boule.direction;
                    }
                    else
                    {
                        Vector2 c = new Vector2(p2.spacePos.X + p2.centralPointDistance, p2.spacePos.Center.Y);
                        boule.direction = (int)MathHelper.ToDegrees((float)Math.Atan2(collisionChecker.Center.Y - c.Y, collisionChecker.Center.X - c.X));
                    }
                    blip.Play();
                    test.Pitch += 0.02f;
                    p2.speed += 3;
                    p1.speed += 3;
                    boule.speed += new Vector2(5);
                }
                p2last = true;
            }
            else
                p2last = false;

            if (boule.spacePos.Intersects(sides[1]) || boule.spacePos.Intersects(sides[3]))
            {
                boule.direction = 360 - boule.direction;
                test.Play();
            }

            if (boule.spacePos.Intersects(sides[0]) && !p2last)
            {
                p1.score++;
                point.Play();
                test.Pitch = -1;
                p1.Reset(PlayerIndex.One);
                p2.Reset(PlayerIndex.Two);
                boule = new Ball();
            }
            else if (boule.spacePos.Intersects(sides[2]) && !p1last)
            {
                p2.score++;
                point.Play();
                test.Pitch = -1;
                p1.Reset(PlayerIndex.One);
                p2.Reset(PlayerIndex.Two);
                boule = new Ball();
            }

            // TODO: Add your update logic here
            p1.Update(gameTime);
            //ai.Update(boule);
            ai.MathUpdate(boule);
            p2.Update(gameTime);
            boule.Update(gameTime);
            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);
            spriteBatch.Begin();
            spriteBatch.Draw(texture, p1.spacePos, Color.White);
            spriteBatch.Draw(texture, p2.spacePos, Color.White);
            spriteBatch.Draw(texture, boule.spacePos, Color.White);
            spriteBatch.DrawString(ecriture, p1.score.ToString(), p1.scorePos, Color.White);
            spriteBatch.DrawString(ecriture, p2.score.ToString(), p2.scorePos, Color.White);
            spriteBatch.End();
            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}
