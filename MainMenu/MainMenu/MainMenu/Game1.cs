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

        public class Game1 : Microsoft.Xna.Framework.Game
        {
            GraphicsDeviceManager graphics;
            SpriteBatch spriteBatch;

            //Textures / Backgrounds
            Texture2D backgroundMain;
            Texture2D backgroundsGame;
            Texture2D backgroundPause;

            //Position / Rectangles

            //Songs
            Song mainTheme;

            //Screen
            int heigthScreen;
            int widthScreen;

            //Autres
            Menus menu;

            public Game1()
            {
                graphics = new GraphicsDeviceManager(this);
                Content.RootDirectory = "Content";
            }


            protected override void Initialize()
            {
                spriteBatch = new SpriteBatch(GraphicsDevice);
                IsMouseVisible = true;
                heigthScreen = GraphicsDevice.DisplayMode.Height;
                widthScreen = GraphicsDevice.DisplayMode.Width;
                graphics.PreferredBackBufferHeight = heigthScreen;
                graphics.PreferredBackBufferWidth = widthScreen;
                graphics.IsFullScreen = true;
                graphics.ApplyChanges();

                base.Initialize();
            }


            protected override void LoadContent()
            {
                //Chargement des contenus
                backgroundMain = Content.Load<Texture2D>("background3");
                backgroundPause = Content.Load<Texture2D>("background2");
                backgroundsGame = Content.Load<Texture2D>("background");
                mainTheme = Content.Load<Song>("Main Theme");

                //Gestion du son
                MediaPlayer.IsRepeating = true;
                MediaPlayer.Play(mainTheme);

                //Menus
                menu = new Menus(widthScreen, heigthScreen, Content.Load<Texture2D>("SmileyWalk"), Content.Load<Texture2D>("Arrow"), backgroundMain, backgroundPause, backgroundsGame, Content.Load<Texture2D>("play"), Content.Load<Texture2D>("exit"), GraphicsDevice);
            }

            protected override void UnloadContent()
            {

            }

            protected override void Update(GameTime gameTime)
            {
                if (Keyboard.GetState().IsKeyDown(Keys.Escape) || menu.currentGameState == Menus.GameState.exit)
                    this.Exit();
                MouseState mouse = Mouse.GetState();
                
                menu.Update(mouse);

                base.Update(gameTime);
            }

            protected override void Draw(GameTime gameTime)
            {
                GraphicsDevice.Clear(Color.Black);

                menu.Draw(spriteBatch);

                base.Draw(gameTime);
            }
        }
    }
