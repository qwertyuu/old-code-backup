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

namespace _1DCA
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        object lockObject = new object();
        SpriteBatch spriteBatch;
        bool[] oldLine;
        bool[] currentLine;
        int lessOne;
        const double ratio = 0.5;
        Texture2D toDraw;
        List<bool[]> toConvert;
        Camera cam;
        System.Threading.Thread toTexture;
        System.Threading.Thread calculator;

        public Game1()
        {
            //initialisation de la carte graphique pour le framework XNA
            graphics = new GraphicsDeviceManager(this);
            graphics.PreferMultiSampling = true;
            Content.RootDirectory = "Content";
            //je set la grosseur de la fenêtre
            graphics.PreferredBackBufferWidth = 1000;
            graphics.PreferredBackBufferHeight = (int)(graphics.PreferredBackBufferWidth * ratio);
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            //initialisation de plusieurs variables
            IsMouseVisible = true;
            cam = new Camera();
            toConvert = new List<bool[]>();
            //les deux threads qui permettent de calculer(Algo) et de créer une texture à partir des calculs (toTexture)
            toTexture = new System.Threading.Thread(new System.Threading.ParameterizedThreadStart(Texturer));
            calculator = new System.Threading.Thread(new System.Threading.ParameterizedThreadStart(Algo));
            toTexture.IsBackground = true;
            calculator.IsBackground = true;
            oldLine = new bool[GraphicsDevice.Viewport.Width];
            //j'initialise toute les bool en false pour commencer et puis j'active (true) seulement celle qui est au centre
            for (int i = 0; i < oldLine.Length; i++)
            {
                oldLine[i] = false;
            }
            oldLine[oldLine.Length / 2] = true;
            //j'ajoute la première ligne à la liste de convertion
            toConvert.Add(oldLine);
            //je met la valeur - 1 à une fausse constante pour ne pas avoir à faire le calcul à chaque répétition (ralentissement)
            lessOne = oldLine.Length - 1;
            //je commence l'execution des threads
            calculator.Start();
            toTexture.Start();
            base.Initialize();
        }
        protected override void OnExiting(object sender, EventArgs args)
        {
            toTexture.Abort();
            calculator.Abort();
            base.OnExiting(sender, args);
        }
        private void Algo(object obj)
        {
            //for loop de la hauteur de la fenètre, en pixels
            for (int j = 0; j < GraphicsDevice.Viewport.Height; j++)
            {
                //j'initialise un bool[] pour la prochaine ligne à être calculée de la même longueur que l'ancienne ligne (oldLine)
                currentLine = new bool[oldLine.Length];
                //j'itère chaque élément de l'ancienne ligne
                for (int i = 0; i < oldLine.Length; i++)
                {
                    //P = i-1, Q = i, R = i+1

                    //111110111111
                    //    vvv
                    //    PQR
                    //le 0 est l'index présent
                    bool P, Q, R;
                    Q = oldLine[i];
                    if (i == 0)
                    {
                        //si on est à gauche de l'écran (a l'index 0 de l'array), 
                        //on ordonne à P d'égaler l'élément à l'autre extrémité de l'écran
                        //pour empêcher un IndexOutOfRange
                        P = oldLine[lessOne];
                        R = oldLine[i + 1];
                    }
                    else if (i == lessOne)
                    {
                        //même principe, si on est à l'extrémité droite de l'écran
                        //on repousse R vers l'index 0
                        P = oldLine[i - 1];
                        R = oldLine[0];
                    }
                    else
                    {
                        //sinon et bien tout est OK
                        P = oldLine[i - 1];
                        R = oldLine[i + 1];
                    }
                    //quelques règles que j'ai touvé qui faisaient de beau schémas
                    //???: P ^ Q || R ^ Q
                    //rule 73: !((P && R) || (P ^ Q ^ R))
                    //rule 126: P ^ Q || R ^ Q
                    //rule 210: P ^ (Q || R) ^ Q
                    //rule 150: P ^ Q ^ R
                    //rule 105: P == Q ^ R
                    //rule 135: P == (Q && R)
                    //voici l'algorithme qui sert à calculer l'image. Assez simple
                    currentLine[i] = P ^ Q ^ R;
                }
                //on ajoute la ligne fraîchement calculée à la liste pour conversion
                toConvert.Add(currentLine);
                //on dit à oldLine d'être la nouvelle ligne (ainsi va la vie)
                oldLine = currentLine;
            }
        }

        private void Texturer(object obj)
        {
            //en utilisant la liste de bool[], je les convertis en textures pixel par pixel.
            //une Texture2D est une classe propre à XNA qui permet d'aller chercher une image en mémoire
            //depuis un Stream ou d'en créer une à partir d'un Array

            int count1 = toConvert.Count;
            //tant que le nombre de conversions a faire est pas égale à la hauteur de l'écran
            while (count1 - 1 != GraphicsDevice.Viewport.Height)
            {
                //je met à jour le nombre de lignes
                count1 = toConvert.Count;
                //j'enregistre la largeur de l'array qui contiens les infos de ce qui faut afficher à l'écran
                int count2 = oldLine.Length;
                //j'initialise le Color[] qui va servir de conteneur pour l'image à afficher avamt de les appliquer dans la texture
                //qui sera affichée à l'écran
                Color[] colorsForTexture = new Color[count1 * count2];
                //j'initialise la texture qui sera affichée à l'écran avec les dimensions correctes
                Texture2D toAdd = new Texture2D(graphics.GraphicsDevice, oldLine.Length, count1);
                //j'itère en hauteur puis en largeur chaque éléments pour les transormer en pixels
                for (int i = 0; i < count1; i++)
                {
                    for (int j = 0; j < count2; j++)
                    {
                        //si l'élément à cet endroit est TRUE, le pixel sera opaque (White dans ce cas-ci), sinon le pixel est transparent
                        colorsForTexture[i * toConvert[i].Length + j] = toConvert[i][j] ? Color.White : Color.Transparent;
                    }
                }
                //j'applique les changements à toAdd puis les transfère à toDraw pour qu'XNA puisse afficher la chose
                //(toDraw est la variable globale de texture qui communique entre les threads différents)
                toAdd.SetData(colorsForTexture);
                toDraw = toAdd;
            }
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            //un spritebatch est une chose qui sert à dessiner à l'écran, qui communique avec la carte graphique directement
            //pour faire des changements de vue avec des systèmes de caméras et tout plein de choses (que je ne sais même pas moi-même)
            spriteBatch = new SpriteBatch(GraphicsDevice);
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
            //cette partie est appelée une fois à toute les 1/60 seconde.
            //Je l'utilise donc pour mettre à jour la caméra qui sert à Zoomer l'image
            cam.Update(oldLine.Length, graphics);
            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            //cette partie est aussi appelée une fois toute les 1/60 seconde
            //elle sert à afficher les choses à l'écran seulement. Aucun calcul ici, car ça ferait descendre le nombre d'images
            //par secondes (60 dans le cas présent)

            //Clear sert à vider l'écran de ses éléments avec une couleur de fond
            GraphicsDevice.Clear(Color.White);
            //on donne l'ordre à la carte graphique de se préparer à imprimer des choses à l'écran
            spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, SamplerState.PointClamp, null, null, null, cam.viewMatrix);
            if (toDraw != null)
            {
                //j'affiche la texture toDraw à la position (0,0) en couleur noire (je teint le Blanc en Noir, car en XNA, le blanc est la couleur
                //pleine qui peut se faire teindre de toutes les façons)
                spriteBatch.Draw(toDraw, Vector2.Zero, Color.Black);
            }
            //on donne l'ordre à la carte graphique de finalement imprimer tout ce qui à a imprimer à l'écran
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
