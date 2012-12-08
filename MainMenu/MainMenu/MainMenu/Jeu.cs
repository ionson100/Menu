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

namespace Jeu
{
    public class Jeu : Microsoft.Xna.Framework.Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        private AnimatedSprite animatedSprite;

        private Texture2D texture;
        private Texture2D arrow;

        private Vector2 positionTexture;
        private Vector2 location;
        private Rectangle sourceRectangle;
        private Vector2 origin;

        private float angle = 0f;

        public Jeu()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        protected override void Initialize()
        {
            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            IsMouseVisible = true;
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            texture = Content.Load<Texture2D>("SmileyWalk");
            arrow = Content.Load<Texture2D>("arrow");

            positionTexture = new Vector2(100, 100);

            //rotaion
            location = new Vector2(400, 240);
            origin = new Vector2(arrow.Width / 2, arrow.Height);
            sourceRectangle = new Rectangle(0, 0, arrow.Width, arrow.Height);
            animatedSprite = new AnimatedSprite(texture, 4, 4);

        }
        protected override void UnloadContent()
        {

        }

        protected override void Update(GameTime gameTime)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Right) && positionTexture.X + texture.Width / 4 < 800) positionTexture.X += 6;
            if (Keyboard.GetState().IsKeyDown(Keys.Left) && positionTexture.X > 0) positionTexture.X -= 6;
            if (Keyboard.GetState().IsKeyDown(Keys.Up)) angle += 0.05f;
            if (Keyboard.GetState().IsKeyDown(Keys.Down)) angle -= 0.05f;
            animatedSprite.Update();


            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            _spriteBatch.Begin();

            animatedSprite.Draw(_spriteBatch, positionTexture);
            _spriteBatch.Draw(arrow, location, sourceRectangle, Color.White, angle, origin, 2.0f, SpriteEffects.None, 1);          
            
            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
