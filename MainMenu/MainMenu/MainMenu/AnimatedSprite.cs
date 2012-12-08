/*
 * 
 * 
 * Animation des sprites/persos
 * 
 * 
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace MainMenu
{
    public class AnimatedSprite
    {
        //Definition des methodes et variables globales
        public Texture2D Texture { get; set; }
        public int Rows { get; set; }
        public int Columns { get; set; }
        public int currentFrame;
        public int totalFrames;

        //Definit notre texture avec sa taille
        public AnimatedSprite(Texture2D texture, int rows, int columns)
        {
            Texture = texture;
            Rows = rows;
            Columns = columns;
            currentFrame = 0;
            totalFrames = Rows * Columns;
        }

        //Permet de faire bouger la texture 
        public void Update()
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Right)) currentFrame++;
            else if (Keyboard.GetState().IsKeyDown(Keys.Left)) currentFrame++;
            

            if (currentFrame == totalFrames) currentFrame = 0;
        }
        //Dessine la texture
        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            int width = Texture.Width / Columns; // la largeur = largeur de la texture / nbr de colones (4)
            int heigth = Texture.Height / Rows; // la hauteur = hauteur de la texture / nbr de lignes (4)
            int row = (int)((float)currentFrame / (float)Rows); //ligne actuelle = frame actuelle / nbr de colones (4)
            int column = currentFrame % Columns; // colone actuelle = frame actuelle / nbr de colones (4)

            Rectangle sourceRectangle = new Rectangle(width * column, heigth * row, width, heigth);
            Rectangle destinationRectangle = new Rectangle((int)location.X, (int)location.Y, width, heigth);
            spriteBatch.Draw(Texture, destinationRectangle, sourceRectangle, Color.White);
        }
    }
}
