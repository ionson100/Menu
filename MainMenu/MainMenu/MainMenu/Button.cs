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
    class Button
    {
        private Texture2D _texture;

        private Vector2 _position;
        public Vector2 _size;
        private Rectangle _rectangle;

        private Color color = new Color(255, 255, 255, 255);

        //booleen pour gerer la couleur du button et l'etat du bouton
        private bool down;
        public bool isClicked = false;

        //Constructeur de Button attribuant texture, taille et son
        public Button(Texture2D newTexture, GraphicsDevice graphics)
        {
            _texture = newTexture;
            _size = new Vector2(_texture.Width, _texture.Height);
        }


        //Fonction Update avec comme parametre l'etat de la souris
        public void Update(MouseState mouse)
        {
            _rectangle = new Rectangle((int)_position.X, (int)_position.Y, (int)_size.X, (int)_size.Y); //Rectangle du bouton donc ca position + sa taille

            Rectangle mouseRectangle = new Rectangle(mouse.X, mouse.Y, 1, 1); //Rectangle de la souris avec comme dimensions 1,1

            //Boucle permettant de savoir si la souris est sur le bouton + modifie la couche Alpha du bouton
            //Petit probleme a ce niveau la du surement a la fonction update principale, le bouton est clique plusieurs fois au lieu d'une
            if(mouseRectangle.Intersects(_rectangle))
            {
                if(color.A == 255) down = false;
                if (color.A == 0) down = true;
                if (down) color.A += 3; else color.A -= 3;
                if (mouse.LeftButton == ButtonState.Pressed)
                {
                    isClicked = true;
                }

                else if (mouse.LeftButton == ButtonState.Released) isClicked = false;

                else
                    isClicked = false;

            }

            //Si la couche alpha est plus petite que 255 et que la souris n'est pas en intersection alors on reattribue doucement la couche alpha
            else if (color.A < 255)
            {
                color.A += 3;
                isClicked = false;
            }
            
        }

        //Definit la position du bouton
        public void setPosition(Vector2 newPosition)
        {
            _position = newPosition;
        }

        //Dessine le bouton
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_texture, _rectangle, color);
        }
    }
}
