using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;
using System.Text;

namespace JorgenFinal
{
    class Axe_animation
    {
        //variabler
        Texture2D axesprite;
        float timer = 0f;
        float interval = 150f;
        int currentFrame = 0;
        int spriteWidth = 16;
        int spriteHeight = 15;
        Rectangle sourceRect;
        Vector2 position;  

        //Get Set
        public Vector2 Position
        {
            get
            { return position; }
            set
            { position = value; }
        }
       
        public Texture2D Texture
        {
            get
            { return axesprite; }
            set
            { axesprite = value; }
        }
        public Rectangle SourceRect
        {
            get
            { return sourceRect; }
            set
            { sourceRect = value; }
        }
        //Constructor
        public Axe_animation(Texture2D texture, int currentFrame, int spriteWidth, int spriteHeight)
        {
            this.axesprite = texture;
            this.currentFrame = currentFrame;
            this.spriteWidth = spriteWidth;
            this.spriteHeight = spriteHeight;
        }

       
        public void HandleSpriteMovement(GameTime gameTime)

        {
           
            //animation
            sourceRect = new Rectangle(currentFrame * spriteWidth, 0, spriteWidth, spriteHeight);


            Animate(gameTime);
             
        }

        public void Animate(GameTime gameTime)
        {
          
            timer += (float)gameTime.ElapsedGameTime.TotalMilliseconds;
            if (timer > interval)
            {
                currentFrame++;
                if (currentFrame > 2)
                {
                    currentFrame = 0;
                }
                timer = 0f;
            }
        }
    }
    }
