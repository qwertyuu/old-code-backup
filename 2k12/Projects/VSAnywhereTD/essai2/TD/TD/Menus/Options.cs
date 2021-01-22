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

namespace TD.Menus
{
    class Options : IMenu
    {
        GraphicsDeviceManager graphics;
        Buttons back;
        public Options(GraphicsDeviceManager graphics)
        {
            this.graphics = graphics;
            gameState = GameState.Options;
            Buttons AntiAlias = new Buttons();
            AntiAlias.text = "Antialias: " + graphics.PreferMultiSampling;
            AntiAlias.couleur = Color.Blue;
            AntiAlias.Clic += AntiAlias_Clic;
            AddButton(AntiAlias);

            Slider speed = new Slider();
            AddButton(speed);

            back = new Buttons();
            back.text = "Back";
            back.couleur = Color.Orange;
            back.returnState = GameState.MainMenu;
            back.Clic += back_Clic;
            AddButton(back);
            this.Escape = back.returnState;
        }

        private void back_Clic(object sender, IMenu SendingMenu)
        {
            back.returnState = senderMenuState;
            graphics.ApplyChanges();
        }

        private void AntiAlias_Clic(object sender, IMenu swag)
        {
            graphics.PreferMultiSampling = !graphics.PreferMultiSampling;
            ((Buttons)sender).text = "Antialias: " + graphics.PreferMultiSampling;
        }


        public override void EscapePressed()
        {
            buttonsList[1].Clicked(this);
            base.EscapePressed();
        }
    }
}
