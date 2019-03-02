using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;

namespace JorgenFinal
{
    class WalkerScroll
    {
        //Varibler
        int scroll;
        Vector2 size;
        Texture2D texture;
        Vector2 position;
        float speed;
        Rectangle rect;
        bool agro = false;
        bool agro2 = false;
        PlayerManager player;
        int zone;
        bool alive;

        //Walker specific
        // bool goingLeft = true;
        //17.0f == infinity?
        //   float directionTimer = 17.0f;
        //Get/Set

        #region Get/Set

        public int Scroll
        {
            get { return scroll; }
            set { scroll = value; }
        }

        public Vector2 Position
        {
            get { return position; }
            set { position = value; }
        }

        public Vector2 Size
        {
            get { return size; }
            set { size = value; }
        }

        public Rectangle Rect
        {
            get { return rect; }
            set { rect = value; }
        }

        public Texture2D Texture
        {
            get { return texture; }
            set { texture = value; }
        }

        public bool Alive
        {
            get { return alive; }
            set { alive = value; }
        }

        #endregion

        //Constructor
        public WalkerScroll(Texture2D texture, Vector2 position, Vector2 size, int scroll, float speed,
            PlayerManager player, int coveredArea, bool alive)
        {
            this.texture = texture;
            this.position = position;
            this.size = size;
            this.scroll = scroll;
            this.speed = speed;
            this.player = player;
            this.zone = coveredArea;
            this.alive = alive;
        }


        public void Update(GameTime gameTime)
        {
            ////walker position 
            ////Set x and y position in load content then use ([Insert class name].Position.X, [Insert class name].Position.Y) in update to define position
            rect = new Rectangle(((int) position.X + (int) (scroll * speed)), (int) position.Y, (int) size.X,
                (int) size.Y);


            if (player.Position.X - ((int) position.X + (int) (scroll * speed)) < zone &&
                player.Position.X - ((int) position.X + (int) (scroll * speed)) > -zone)
            {
                agro = true;
            }


            if (agro == true)
            {
                if ((position.X + (scroll * speed)) > player.Position.X)
                {
                    position.X -= 5;
                }

                if ((position.X + (scroll * speed)) < player.Position.X)
                {
                    position.X += 5;
                }

                if (player.Position.Y > position.Y
                )
                {
                    position.Y += 2;
                }

                if (player.Position.Y < position.Y
                )
                {
                    position.Y -= 2;
                }
            }
        }

        public void Update2(GameTime gameTime)
        {
            ////walker position 
            ////Set x and y position in load content then use ([Insert class name].Position.X, [Insert class name].Position.Y) in update to define position
            rect = new Rectangle(((int) position.X + (int) (scroll * speed)), (int) position.Y, (int) size.X,
                (int) size.Y);


            if (player.Position.X - ((int) position.X + (int) (scroll * speed)) < zone &&
                player.Position.X - ((int) position.X + (int) (scroll * speed)) > -zone)
            {
                agro2 = true;
            }


            if (agro2 == true)
            {
                if ((position.X + (scroll * speed)) > player.Position.X)
                {
                    position.X -= 12;
                }

                if ((position.X + (scroll * speed)) < player.Position.X)
                {
                    position.X += 12;
                }

                if (player.Position.Y > position.Y
                )
                {
                    position.Y += 5;
                }

                if (player.Position.Y < position.Y
                )
                {
                    position.Y -= 5;
                }
            }
        }
    }
}
