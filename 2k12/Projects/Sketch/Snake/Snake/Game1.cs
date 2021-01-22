#region Using Statements
using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Storage;
using Microsoft.Xna.Framework.GamerServices;
#endregion

namespace Snake
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Game
    {
        //j'initialise mes variables
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Texture2D face;
        Texture2D texturePomme;
        //Classe custom que j'ai faite pour les parties du snake et qui adonnait fonctionner pour la pomme aussi
        Part pomme;
        //classe custom que jai faite pour le serpent
        Snake python;
        SpriteFont spriteFont;
        //variable pour la toune qui joue
        //Song song;
        //un random pour la place ou jva spawner la pomme
        Random rand = new Random();
        //le moment ou je start le programme pour pouvoir redémarrer la toune une fois finie
        DateTime start = DateTime.Now;
        //un KeyboardState pour vérifier si la touche viens juste d'être pressée ou si elle est maintenue (c'est le seul moyen que jai trouvé qui fonctionne)
        KeyboardState old;
        DateTime tuneTime;
        Texture2D bG;
        // un StringBuilder pour afficher le score, pas obligatoire... stait plus un test mais ca fonctionne donc je l'ai laissé la
        string stringScore;
        Vector2 middle;
        Vector2 bGMiddle;
        int score = 0;
        int lastScore;
        int highScore = 0;
        bool locked = false;
        bool gameOver = false;

        Texture2D[] tails = new Texture2D[4];
        Texture2D[] body = new Texture2D[6];
        Texture2D[] heads = new Texture2D[4];

        public Game1()
            : base()
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
            spriteFont = Content.Load<SpriteFont>("SpriteFont1");
            face = Content.Load<Texture2D>("avataryay");
            texturePomme = Content.Load<Texture2D>("pomme");
            //song = Content.Load<Song>("song.wav");
            bG = Content.Load<Texture2D>("bg");


            tails[0] = Content.Load<Texture2D>("Tail/tailUp");
            tails[1] = Content.Load<Texture2D>("Tail/tailDown");
            tails[2] = Content.Load<Texture2D>("Tail/tailRight");
            tails[3] = Content.Load<Texture2D>("Tail/tailLeft");
            body[0] = Content.Load<Texture2D>("Body/VtoHL");
            body[1] = Content.Load<Texture2D>("Body/VtoHR");
            body[2] = Content.Load<Texture2D>("Body/HtoVR");
            body[3] = Content.Load<Texture2D>("Body/HtoVL");
            body[4] = Content.Load<Texture2D>("Body/bodyH");
            body[5] = Content.Load<Texture2D>("Body/bodyV");
            heads[0] = Content.Load<Texture2D>("Head/headUp");
            heads[1] = Content.Load<Texture2D>("Head/headDown");
            heads[2] = Content.Load<Texture2D>("Head/headRight");
            heads[3] = Content.Load<Texture2D>("Head/headLeft");

            //je set des variables que j'ai besoin pendant le jeu pi jles ai switché dans le LoadContent pour tout pouvoir
            //resetter d'une shot

            //vars pour l'arriere plan (le centre de l'ecran, de la texture, etc.)
            middle = new Vector2(graphics.GraphicsDevice.Viewport.Width / 2, graphics.GraphicsDevice.Viewport.Height / 2);
            bGMiddle = new Vector2(bG.Bounds.Width / 2, bG.Bounds.Height / 2);
            //le temps a laquelle la toune finie
            tuneTime = DateTime.Now + new TimeSpan(0, 2, 40);
            //start la toune!
            //MediaPlayer.Play(song);
            //MediaPlayer.Volume = 0.8f;
            python = new Snake();
            python.parties = new List<Part>();
            python.length = 3;

            Part toAdd = new Part(0, 0);
            toAdd.headTex = heads[2];
            toAdd.tailTex = tails[3];
            toAdd.texture = body[5];
            python.parties.Add(toAdd);
            python.direction = Snake.Direction.Right;

            pomme = GeneratePomme(python, rand);

            lastScore = score;
            highScore = (score > highScore) ? score : highScore;
            score = 0;
            stringScore = string.Format("Score: {0}, Dernier Score: {1}\nHighScore: {2}", score, lastScore, highScore);

            // TODO: use this.Content to load your game content here
        }
        //une méthode pour générer un endroit aléatoire pour la pomme qui n'est pas directement sur le snake
        private Part GeneratePomme(Snake python, Random rand)
        {
            bool ok = false;
            Vector2 buffer = Vector2.Zero;
            while (!ok)
            {
                buffer = new Vector2(rand.Next(0, 40), rand.Next(0, 24));
                //syntaxe LINQ pour checker si une position pareille a celle générée existe dans les parties du snake
                //lol lol jpense jva gosser pour implanter un binarysearch a place, ça a l'air plus approprié
                var check = from a in python.parties
                            where a.fakePos == buffer
                            select a;
                if (check.ToList().Count == 0)
                {
                    ok = true;
                }
            }

            return new Part(buffer.X * 20, buffer.Y * 20);
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
        /// 
        protected override void Update(GameTime gameTime)
        {
            if (gameOver)
            {
                LoadContent();
                gameOver = false;
            }
            if (DateTime.Now >= tuneTime)
            {
                //pour reset la toune une fois terminée
                tuneTime = DateTime.Now + new TimeSpan(0, 2, 40);
                //MediaPlayer.Play(song);
            }
            //j'enregistre l'état du clavier (les touches pressées) pour l'analyser
            var clés = Keyboard.GetState();
            var buf = clés.GetPressedKeys();
            foreach (var item in buf)
            {
                switch (item)
                {
                    case Keys.Right:
                        //si la direction est pas le contraire exact (genre que dans snake tu peux pas revirer sur toi-même)
                        //et qu'une "frame" a pas passée (la bool locked)
                        //on set la direction et on lock
                        if (python.direction != Snake.Direction.Left && !locked)
                        {
                            python.direction = Snake.Direction.Right;
                            locked = true;
                        }
                        break;
                    case Keys.Left:
                        if (python.direction != Snake.Direction.Right && !locked)
                        {
                            python.direction = Snake.Direction.Left;
                            locked = true;
                        }
                        break;
                    case Keys.Up:
                        if (python.direction != Snake.Direction.Down && !locked)
                        {
                            python.direction = Snake.Direction.Up;
                            locked = true;
                        }
                        break;
                    case Keys.Down:
                        if (python.direction != Snake.Direction.Up && !locked)
                        {
                            python.direction = Snake.Direction.Down;
                            locked = true;
                        }
                        break;
                    case Keys.Escape:
                        //quitter si Échap est cliqué
                        this.Exit();
                        break;
                    case Keys.M:
                        //M pour mute la toune pi j'utilise la technique pour checker si le piton viens d'etre pressé ou est maintenu
                        if (old.IsKeyUp(Keys.M))
                        {
                            //MediaPlayer.IsMuted = !MediaPlayer.IsMuted;
                        }
                        break;
                    default:
                        break;
                }
            }
            //old = le nouveau keyboardstate qui vient d'etre analysé
            old = clés;
            //si 60milisecondes ont passées entre "start" et maintenant
            if (DateTime.Now >= start.AddMilliseconds(60))
            {
                //unlock les keypress
                locked = false;
                //reset le temps
                start = DateTime.Now;
                //textures temporaires a utiliser setter plus tard
                Texture2D daTex = null;
                Texture2D tailTex = null;
                Texture2D headTex = null;
                //un instance de l'enum "direction" dans Snake
                Snake.Direction dir = new Snake.Direction();
                //un buffer de la deniere partie dans le snake pour pouvoir placer notre nouvelle partie par rapport à celle-la
                Part buffer = python.parties[python.parties.Count - 1];
                float x = 0;
                float y = 0;
                switch (python.direction)
                {
                    case Snake.Direction.Up:
                        //si la direction n'est pas égale a la direction de la derniere partie
                        //on change la texture de l'ancienne partie pour un coin au lieu d'un corps droit (il y a eu virage)
                        if (buffer.partDirection != Snake.Direction.Up)
                        {
                            python.parties[python.parties.Count - 1].texture = (buffer.partDirection == Snake.Direction.Left) ? body[2] : body[3];
                            python.parties[python.parties.Count - 1].tailTex = tails[1];
                        }
                        //la texture du corps, de la queue et de la tête pour cette partie est définie
                        daTex = body[4];
                        tailTex = tails[1];
                        headTex = heads[0];
                        //la direction de la partie est définie et sa position par rapport à l'ancienne partie est notée dans y (ou x, tout dépendant de la direction)
                        dir = Snake.Direction.Up;
                        y = -1;
                        break;
                    case Snake.Direction.Down:
                        if (buffer.partDirection != Snake.Direction.Down)
                        {
                            python.parties[python.parties.Count - 1].texture = (buffer.partDirection == Snake.Direction.Left) ? body[1] : body[0];
                            python.parties[python.parties.Count - 1].tailTex = tails[0];
                        }
                        daTex = body[4];
                        tailTex = tails[0];
                        headTex = heads[1];
                        dir = Snake.Direction.Down;
                        y = 1;
                        break;
                    case Snake.Direction.Left:
                        if (buffer.partDirection != Snake.Direction.Left)
                        {
                            python.parties[python.parties.Count - 1].texture = (buffer.partDirection == Snake.Direction.Up) ? body[0] : body[3];
                            python.parties[python.parties.Count - 1].tailTex = tails[2];
                        }
                        daTex = body[5];
                        tailTex = tails[2];
                        headTex = heads[3];
                        dir = Snake.Direction.Left;
                        x = -1;
                        break;
                    case Snake.Direction.Right:
                        if (buffer.partDirection != Snake.Direction.Right)
                        {
                            python.parties[python.parties.Count - 1].texture = (buffer.partDirection == Snake.Direction.Up) ? body[1] : body[2];
                            python.parties[python.parties.Count - 1].tailTex = tails[3];
                        }
                        daTex = body[5];
                        tailTex = tails[3];
                        headTex = heads[2];
                        dir = Snake.Direction.Right;
                        x = 1;
                        break;
                    default:
                        break;
                }
                //on enlève pas de parties sauf si le nombre de partie est plus grande ou égale a la longueur du serpent donnée
                if (python.parties.Count >= python.length)
                {
                    python.parties.RemoveAt(0);
                }
                //cette partie la teste si la nouvelle partie devrait être placée sur un autre bord de l'écran (téléportation bas/haut gauche/droite)
                float newX = buffer.position.X + (x * face.Bounds.Width);
                float newY = buffer.position.Y + (y * face.Bounds.Height);
                if (newX > graphics.GraphicsDevice.Viewport.Width - 20)
                {
                    newX = 0;
                }
                else if (newX < 0)
                {
                    newX = 780;
                }
                if (newY > graphics.GraphicsDevice.Viewport.Height - 20)
                {
                    newY = 0;
                }
                else if (newY < 0)
                {
                    newY = 460;
                }
                //en utilisant les valeurs de pixels utilisés, on génère un vecteur pour savoir si la nouvelle partie touche à une autre avec LINQ
                //encore une fois je devrais utiliser un binarysearch mais la ca marche très bien
                Vector2 check = new Vector2(newX, newY);
                var gameOverChecker = from a in python.parties
                                      where a.position == check
                                      select a;
                if (gameOverChecker.ToList().Count > 0)
                {
                    //s'il y a correspondance, la partie reset au prochain tour
                    gameOver = true;
                }
                //sinon ben on crée finalement la partie à ajouter avec toutes les variables et textures qu'on a besoin
                Part toAdd = new Part(newX, newY);
                toAdd.partDirection = dir;
                toAdd.texture = daTex;
                toAdd.headTex = headTex;
                toAdd.tailTex = tailTex;
                //puis on la met dans la liste
                python.parties.Add(toAdd);
                //si la nouvelle partie (la tête) touche à la pomme
                if (python.parties[python.parties.Count - 1].fakePos == pomme.fakePos)
                {
                    //on génère une nouvelle position de la pomme qui ne touche pas au serpent
                    pomme = GeneratePomme(python, rand);
                    //rallonge le serpent
                    python.length += 2;
                    //monte le score
                    score++;
                    //recrée la string qui nous permet de voir le score en utilisant un bon vieux string.Format()
                    stringScore = string.Format("Score: {0}, Dernier Score: {1}\nHighScore: {2}", score, lastScore, highScore);
                }
            }
            // TODO: Add your update logic here

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
            //on draw le background
            spriteBatch.Draw(bG, middle, null, Color.White, 0.0f, bGMiddle, 1.0f, SpriteEffects.None, 0.0f);
            //on itère chaque partie du serpent
            for (int i = 0; i < python.parties.Count; i++)
            {
                //si i = 0 ca veut dire qu'on a affaire à la queue, donc on utilise la texture de queue de la partie
                if (i == 0)
                {
                    spriteBatch.Draw(python.parties[i].tailTex, python.parties[i].position, Color.White);
                }
                //si i = denier item de la liste, on a affaire a la tête (la tête c'est tjrs le dernier et la queue en premier) et on utilise la texture de tête de la partie
                else if (i == python.parties.Count - 1)
                {
                    spriteBatch.Draw(python.parties[i].headTex, python.parties[i].position, Color.White);
                }
                //sinon ben c'est le corps, donc on draw la texture de corps de la partie
                else
                {
                    spriteBatch.Draw(python.parties[i].texture, python.parties[i].position, Color.White);
                }
            }
            //draw la pomme
            spriteBatch.Draw(texturePomme, pomme.position, Color.White);
            //draw le score
            spriteBatch.DrawString(spriteFont, stringScore, Vector2.Zero, Color.Black);
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
    class Snake
    {
        //un enum avec les 4 points cardinaux
        public enum Direction { Up, Down, Left, Right }

        public Direction direction { get; set; }
        public int length { get; set; }
        public List<Part> parties { get; set; }
    }
    class Part
    {
        //position c'est les pixels ou ils vont être print à l'écran
        public Vector2 position { get; set; }
        //fakepos nous donne la place de l'objet sur une plage de 40x24, c'était plus facile pour moi de visualiser
        //car c'est le nombre de fois que les parties peuvent entrer dans la plage de 800x480 (chacune des texture est de 20x20px)
        public Vector2 fakePos { get; set; }
        public Texture2D texture { get; set; }
        public Texture2D headTex { get; set; }
        public Texture2D tailTex { get; set; }
        //la direction absolue de la partie
        public Snake.Direction partDirection { get; set; }
        //un constructeur qui génère la propriété position et fakePos automatiquement avec les arguments :)
        public Part(float x, float y)
        {
            this.position = new Vector2(x, y);
            this.fakePos = new Vector2(this.position.X / 20, this.position.Y / 20);
        }
    }
}
