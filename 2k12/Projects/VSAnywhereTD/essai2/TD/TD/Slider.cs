#region Using Statements
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
#endregion

namespace TD
{
    class Slider : Buttons
    {
        Buttons[] sliderPartsPos;
        public override Rectangle spacePos
        {
            get
            {
                return base.spacePos;
            }
            set
            {
                sliderPartsPos[0] = new Buttons()
                {
                    spacePos = new Rectangle(value.X, value.Y, 0, 0),
                    text = "-",
                    font = Game1.font,
                    returnState = GameState.None,
                    couleur = Color.Green

                };
                sliderPartsPos[0].textSpot = new Vector2(sliderPartsPos[0].textOffset.X + sliderPartsPos[0].spacePos.X, sliderPartsPos[0].textOffset.Y + sliderPartsPos[0].spacePos.Y);
                sliderPartsPos[0].Clic += lessClick;
                sliderPartsPos[1] = new Buttons()
                {
                    spacePos = new Rectangle(value.X + sliderPartsPos[0].spacePos.Width, value.Y, 0, 0),
                    text = "Speed: " + Camera.speed / 200,
                    font = Game1.font,
                    returnState = GameState.None,
                    couleur = Color.Green
                };
                sliderPartsPos[1].textSpot = new Vector2(sliderPartsPos[1].textOffset.X + sliderPartsPos[1].spacePos.X, sliderPartsPos[1].textOffset.Y + sliderPartsPos[1].spacePos.Y);

                sliderPartsPos[2] = new Buttons()
                {
                    spacePos = new Rectangle(value.X + sliderPartsPos[0].spacePos.Width + sliderPartsPos[1].spacePos.Width, value.Y, 0, 0),
                    text = "+",
                    font = Game1.font,
                    returnState = GameState.None,
                    couleur = Color.Green
                };
                sliderPartsPos[2].textSpot = new Vector2(sliderPartsPos[2].textOffset.X + sliderPartsPos[2].spacePos.X, sliderPartsPos[2].textOffset.Y + sliderPartsPos[2].spacePos.Y);
                sliderPartsPos[2].Clic += UpClick;
                base.spacePos = new Rectangle(value.X, value.Y, sliderPartsPos[0].spacePos.Width + sliderPartsPos[1].spacePos.Width + sliderPartsPos[2].spacePos.Width, sliderPartsPos[0].spacePos.Height);
            }
        }

        private void UpClick(object sender, IMenu swag)
        {
            if ((Camera.speed + 200) <= 1800)
            {
                Camera.speed += 200;
                updateText();
            }
        }

        private void lessClick(object sender, IMenu swag)
        {
            if ((Camera.speed - 200) > 0)
            {
                Camera.speed -= 200;
                updateText();
            }
        }

        public Slider()
        {
            sliderPartsPos = new Buttons[3];
        }


        public override bool Update(MouseHandler mouse, IMenu sender)
        {

            for (int i = 0; i < sliderPartsPos.Length; i++)
            {
                if (sliderPartsPos[i].spacePos.Contains(mouse.position))
                {
                    sliderPartsPos[i].Transparency = 0.5f;
                    if (mouse.LeftClickState == ClickState.Clicked)
                    {
                        sliderPartsPos[i].Clicked(sender);
                        if (returnState != GameState.None)
                            return true;
                    }
                }
                else
                {
                    sliderPartsPos[i].Transparency = 1.0f;
                }
            }

            return false;
        }

        public override void Draw(SpriteBatch sprite)
        {
            for (int i = 0; i < sliderPartsPos.Length; i++)
            {
                sliderPartsPos[sliderPartsPos.Length - 1 - i].Draw(sprite);
            }
        }

        private void updateText()
        {
            sliderPartsPos[1].text = "Speed: " + Camera.speed / 200;
        }
    }
}
