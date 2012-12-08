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
    public class Jeu
    {
        int heigthScreen, widthScreen;


        private AnimatedSprite animatedSprite;

        private Texture2D texture;
        private Texture2D arrow;

        private Vector2 positionTexture;
        private Vector2 location;
        private Rectangle sourceRectangle;
        private Vector2 origin;

        private float angle = 0f;
        
        public Jeu(Texture2D newTexture, Texture2D newArrow, int heigth, int width)
        {

            texture = newTexture;
            arrow = newArrow;
            widthScreen = width;
            heigthScreen = heigth;
            positionTexture = new Vector2(100, 100);

            //rotaion
            location = new Vector2(widthScreen / 2, heigthScreen / 2);
            origin = new Vector2(arrow.Width / 2, arrow.Height);
            sourceRectangle = new Rectangle(0, 0, arrow.Width, arrow.Height);
            animatedSprite = new AnimatedSprite(texture, 4, 4);

        }

        public void Update()
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Right) && positionTexture.X + texture.Width / 4 < widthScreen) positionTexture.X += 6;
            if (Keyboard.GetState().IsKeyDown(Keys.Left) && positionTexture.X > 0) positionTexture.X -= 6;
            if (Keyboard.GetState().IsKeyDown(Keys.Up)) angle += 0.05f;
            if (Keyboard.GetState().IsKeyDown(Keys.Down)) angle -= 0.05f;
            animatedSprite.Update();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            animatedSprite.Draw(spriteBatch, positionTexture);
            spriteBatch.Draw(arrow, location, sourceRectangle, Color.White, angle, origin, 2.0f, SpriteEffects.None, 1);          
            
        }
    }
}
