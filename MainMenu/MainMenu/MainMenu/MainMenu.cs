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

namespace MainMenu
{
    class MainMenu
    {
        //Boutons
        Button playButton, exitButton;

        //Background
        Texture2D background;

        //Taille ecran
        int widthScreen, heigthScreen;

        //Differents munus
        public enum GameState
        {
            mainMenu,
            gameMenu,
            pauseMenu,
            exit
        }

        //Etat du menu
        public GameState currentGameState = GameState.mainMenu;

        public MainMenu(Texture2D playTexture, Texture2D exitTexture,Texture2D newBackground, int heigth, int width, GraphicsDevice graphics)
        {
            //Chargement de la taille
            widthScreen = width;
            heigthScreen = heigth;

            //Chargement des boutons
            playButton = new Button(playTexture, graphics);
            playButton.setPosition(new Vector2(widthScreen / 3, heigthScreen / 2));
            exitButton = new Button(exitTexture, graphics);
            exitButton.setPosition(new Vector2(widthScreen / 3, heigthScreen / 2 + playButton._size.Y));
            background = newBackground;
        }

        public void Update(MouseState mouse)
        {
            mouse = Mouse.GetState();
            if (playButton.isClicked) currentGameState = GameState.gameMenu;
            if (exitButton.isClicked) currentGameState = GameState.exit;
            playButton.Update(mouse);
            exitButton.Update(mouse);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(background, new Rectangle(0, 0, widthScreen, heigthScreen), Color.White);
            playButton.Draw(spriteBatch);
            exitButton.Draw(spriteBatch);
        }

    }
}
