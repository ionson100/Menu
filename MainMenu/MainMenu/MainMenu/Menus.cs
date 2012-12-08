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
    class Menus
    {
        Jeu game;
        MainMenu mainMenu;
        Texture2D pauseBackground, gameBackground;
        int _heigthScreen, _widthScreen;

        public enum GameState
        {
            mainMenu, 
            gameMenu, 
            pauseMenu,
            exit
        }

        public GameState currentGameState = GameState.mainMenu;

        public Menus(int widthScreen, int heigthScreen, Texture2D newPerso, Texture2D newArrow, Texture2D newBackMain, Texture2D newBackPause, Texture2D newBackGame, Texture2D  newPlayButton, Texture2D newExitButton, GraphicsDevice graphics)
        {
            pauseBackground = newBackPause;
            gameBackground = newBackGame;
            _widthScreen = widthScreen;
            _heigthScreen = heigthScreen;
            mainMenu = new MainMenu(newPlayButton, newExitButton, newBackMain, heigthScreen, widthScreen, graphics);
            game = new Jeu(newPerso, newArrow, heigthScreen, widthScreen);
        }



        public void Update(MouseState mouse)
        {
            mouse = Mouse.GetState();
            if(Keyboard.GetState().IsKeyDown(Keys.P)) currentGameState = GameState.pauseMenu;
            switch (currentGameState)
            {
                case GameState.mainMenu:
                    {
                        if (mainMenu.currentGameState == MainMenu.GameState.gameMenu) currentGameState = GameState.gameMenu;
                        if (mainMenu.currentGameState == MainMenu.GameState.exit) currentGameState = GameState.exit;
                        mainMenu.Update(mouse);
                        break;
                    }
                case GameState.pauseMenu:
                    {

                        break;
                    }
                case GameState.gameMenu:
                    {
                        game.Update();
                        break;
                    }
                case GameState.exit:
                    {

                        break;
                    }
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();

            switch (currentGameState)
            {
                case GameState.mainMenu:
                    {
                        mainMenu.Draw(spriteBatch);
                        break;
                    }
                case GameState.pauseMenu:
                    {
                        spriteBatch.Draw(pauseBackground, new Rectangle(0, 0, _widthScreen, _heigthScreen), Color.White);
                        break;
                    }
                case GameState.gameMenu:
                    {
                        game.Draw(spriteBatch);
                        break;
                    }
                case GameState.exit:
                    {

                        break;
                    }
            }

            spriteBatch.End();
        }
    }
}
