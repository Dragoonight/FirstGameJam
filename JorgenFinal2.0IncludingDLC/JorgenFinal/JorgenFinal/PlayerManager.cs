using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace JorgenFinal
{
    public class PlayerManager
    {
        // Texture
        Texture2D playerSprite;

        // Timer and interval
        float timer = 0f;
        float interval = 200f;

        private int Num = 5;

        // Frame Managemnt
        int currentFrame = 0;
        int spriteWidth = 32;
        int spriteHeight = 48;

        // Player speed
        int spriteSpeed = 0;

        // SourceRect rectangle
        Rectangle sourceRect;

        // Players position and velocity
        public Vector2 position;
        Vector2 velocity;

        // Keyboardcontroll
        KeyboardState currentKBSState;
        KeyboardState previousKBSState;

        // sinX value
        float sinX;

        // Tell if the player is jumping
        bool jumping = false;

        // How much the collision boxes should scroll
        public int scroll;

        bool collide = false;

        // Get-set code
        public Vector2 Position
        {
            get { return position; }
            set { position = value; }
        }

        public Vector2 Velocity
        {
            get { return velocity; }
            set { velocity = value; }
        }

        public Texture2D Texture
        {
            get { return playerSprite; }
            set { playerSprite = value; }
        }

        public Rectangle SourceRect
        {
            get { return sourceRect; }
            set { sourceRect = value; }
        }

        // The constructor
        public PlayerManager(Texture2D texture, int currentFrame, int spriteWidth, int spriteHeight)
        {
            this.playerSprite = texture;
            this.currentFrame = currentFrame;
            this.spriteWidth = spriteWidth;
            this.spriteHeight = spriteHeight;
        }


        // Animation of the character
        public void HandleSpriteMovement(GameTime gameTime)
        {
            previousKBSState = currentKBSState;
            currentKBSState = Keyboard.GetState();

            sourceRect = new Rectangle(currentFrame * spriteWidth, 0, spriteWidth, spriteHeight);

            if (currentKBSState.GetPressedKeys().Length == 0)
            {
                if (currentFrame > 0 && currentFrame < 4)
                {
                    currentFrame = 0;
                }
                else if (currentFrame == 8 && collide == true)
                {
                    currentFrame = 0;
                }

                if (currentFrame > 4 && currentFrame < 8)
                {
                    currentFrame = 4;
                }
                else if (currentFrame == 9 && collide == true)
                {
                    currentFrame = 4;
                }



            }

            // If player walks rigt, animate the character walking right and player can't go outside the playingfield
            if (currentKBSState.IsKeyDown(Keys.D) == true)
            {
                AnimateRight(gameTime);
                position.X += spriteSpeed;

            }

            // If player walks left, animate the character walking left and player can't go outside the playingfield
            if (currentKBSState.IsKeyDown(Keys.A) == true)
            {
                AnimateLeft(gameTime);
                position.X -= spriteSpeed;

            }



            velocity = new Vector2(sourceRect.Width / 2, sourceRect.Height / 2);
        }

        // Switch frame in the animations
        public void AnimateRight(GameTime gameTime)
        {
            if (jumping == false)
            {
                if (currentKBSState != previousKBSState)
                {
                    currentFrame = 4;
                }

                timer += (float)gameTime.ElapsedGameTime.TotalMilliseconds;

                if (timer > interval)
                {
                    currentFrame++;

                    if (currentFrame > 7)
                    {
                        currentFrame = 5;
                    }

                    timer = 0f;
                }
            }
            else
            {
                currentFrame = 9;
            }
        }

        public void AnimateUp(GameTime gameTime)
        {
            if (currentKBSState != previousKBSState)
            {
                currentFrame = 13;
            }

            timer += (float)gameTime.ElapsedGameTime.TotalMilliseconds;

            if (timer > interval)
            {
                currentFrame++;

                if (currentFrame > 15)
                {
                    currentFrame = 12;
                }

                timer = 0f;
            }
        }

        public void AnimateDown(GameTime gameTime)
        {
            if (currentKBSState != previousKBSState)
            {
                currentFrame = 1;
            }

            timer += (float)gameTime.ElapsedGameTime.TotalMilliseconds;

            if (timer > interval)
            {
                currentFrame++;

                if (currentFrame > 3)
                {
                    currentFrame = 0;
                }

                timer = 0f;
            }
        }

        public void AnimateLeft(GameTime gameTime)
        {
            if (jumping == false)
            {
                if (currentKBSState != previousKBSState)
                {
                    currentFrame = 3;
                }

                timer += (float)gameTime.ElapsedGameTime.TotalMilliseconds;

                if (timer > interval)
                {
                    currentFrame++;

                    if (currentFrame > 3)
                    {
                        currentFrame = 1;
                    }

                    timer = 0f;
                }
            }
            else
            {
                currentFrame = 8;
            }
        }



        // Function to make to player jump
        public void Jumping(GameTime gameTime)
        {

            // Jump if the player is tandinig on a box
            if (currentKBSState.IsKeyDown(Keys.Space) && jumping == false && collide == true)
            {
                // Set jumping bool to true so the player can't double jump
                jumping = true;

                // Set x-value to its' start position
                sinX += 10f;

                collide = false;
            }

            if (jumping == true)
            {
                // Add value to the x-value
                sinX++;

                // Set the postions Y value to cos function
                position.Y -= (float)11 * (float)Math.Sin(sinX / 13);

                // Tell if the player is done with jumping
                if (sinX > 30f || collide == true)
                {
                    jumping = false;

                    // Reset x-value
                    sinX = 0f;
                }
            }
        }


        public void Collision(GameTime gameTime)
        {
            //Kub 1_________________________________________________________________________
            position.Y += Num;

            if (currentKBSState.IsKeyDown(Keys.Up) == true)
            {
                position.Y -= 8;
            }

            if (currentKBSState.IsKeyDown(Keys.D) == true)
            { scroll -= Num; }
            if (currentKBSState.IsKeyDown(Keys.A) == true)
            { scroll += Num; }

            if (position.Y >= 310 && position.X >= (150 + scroll) && position.X <= (1200 + scroll))
            {
                position.Y -= Num;


                jumping = false;
                collide = true;
            }


            if (position.Y >= 310 && position.X >= (150 + scroll) && position.X <= (1200 + scroll))
            {
                position.X -= Num;
                position.Y += Num;

                jumping = false;
                collide = true;
            }


            if (position.Y >= 310 && position.X >= (600 + scroll) && position.X <= (1200 + scroll))
            {
                position.X += Num;
                position.Y += Num;

                jumping = false;
                collide = true;
            }


            //_______________________________________________________________________________

            //Kub 2
            if (position.Y >= 310 && position.X >= (1350 + scroll) && position.X <= (1600 + scroll))
            {

                position.Y -= Num;

                jumping = false;
                collide = true;
            }


            if (position.Y >= 310 && position.X >= (1350 + scroll) && position.X <= (1600 + scroll))
            {

                position.Y += Num;

                jumping = false;
                collide = true;
            }


            if (position.Y >= 310 && position.X >= (1350 + scroll) && position.X <= (1600 + scroll))
            {
                position.X -= Num;

                jumping = false;
                collide = true;
            }


            if (position.Y >= 310 && position.X >= (1350 + scroll) && position.X <= (1600 + scroll))
            {
                position.X += Num;

                jumping = false;
                collide = true;

            }


            //Kub 3
            if (position.Y >= 260 && position.Y <= 270 && position.X >= (1650 + scroll) && position.X <= (1900 + scroll))
            {

                position.Y -= Num;

                jumping = false;
                collide = true;

            }
            if (position.Y >= 260 && position.Y <= 270 && position.X >= (1700 + scroll) && position.X <= (1900 + scroll))
            {

                position.Y += Num;

                jumping = false;
                collide = true;

            }


            if (position.Y >= 260 && position.Y <= 270 && position.X >= (1700 + scroll) && position.X <= (1900 + scroll))
            {
                position.X -= Num;


                jumping = false;
                collide = true;
            }


            if (position.Y >= 260 && position.Y <= 270 && position.X >= (1700 + scroll) && position.X <= (1900 + scroll))
            {
                position.X += Num;

                jumping = false;
                collide = true;

            }

            if (position.Y >= 260 && position.Y <= 270 && position.X >= (500 + scroll) && position.X <= (700 + scroll))
            {
                position.X += Num;



            }

            //Kub 4

            if (position.Y >= 355 && position.Y <= 405 && position.X >= (2000 + scroll) && position.X <= (2200 + scroll))
            {

                position.Y -= Num;

                jumping = false;
                collide = true;

            }
            if (position.Y >= 355 && position.Y <= 405 && position.X >= (2000 + scroll) && position.X <= (2200 + scroll))
            {

                position.Y += Num;

                jumping = false;
                collide = true;

            }


            if (position.Y >= 355 && position.Y <= 405 && position.X >= (2000 + scroll) && position.X <= (2200 + scroll))
            {
                position.X -= Num;


                jumping = false;
                collide = true;
            }


            if (position.Y >= 355 && position.Y <= 405 && position.X >= (2000 + scroll) && position.X <= (2200 + scroll))
            {
                position.X += Num;

                jumping = false;
                collide = true;

            }

            //Kub 5

            if (position.Y >= 300 && position.Y <= 350 && position.X >= (2300 + scroll) && position.X <= (2500 + scroll))
            {

                position.Y -= Num;

                jumping = false;
                collide = true;

            }
            if (position.Y >= 300 && position.Y <= 350 && position.X >= (2300 + scroll) && position.X <= (2500 + scroll))
            {

                position.Y += Num;

                jumping = false;
                collide = true;

            }


            if (position.Y >= 300 && position.Y <= 350 && position.X >= (2300 + scroll) && position.X <= (2500 + scroll))
            {
                position.X -= Num;


                jumping = false;
                collide = true;
            }


            if (position.Y >= 300 && position.Y <= 350 && position.X >= (2300 + scroll) && position.X <= (2500 + scroll))
            {
                position.X += Num;

                jumping = false;
                collide = true;

            }


            //Kub 6

            if (position.Y >= 405 && position.Y <= 455 && position.X >= (2800 + scroll) && position.X <= (3000 + scroll))
            {

                position.Y -= Num;

                jumping = false;
                collide = true;

            }
            if (position.Y >= 405 && position.Y <= 455 && position.X >= (2800 + scroll) && position.X <= (3000 + scroll))
            {

                position.Y += Num;

                jumping = false;
                collide = true;

            }


            if (position.Y >= 405 && position.Y <= 455 && position.X >= (2800 + scroll) && position.X <= (3000 + scroll))
            {
                position.X -= Num;


                jumping = false;
                collide = true;
            }


            if (position.Y >= 405 && position.Y <= 455 && position.X >= (2800 + scroll) && position.X <= (3000 + scroll))
            {
                position.X += Num;

                jumping = false;
                collide = true;

            }



            //Kub 7

            if (position.Y >= 330 && position.Y <= 380 && position.X >= (3100 + scroll) && position.X <= (4100 + scroll))
            {

                position.Y -= Num;

                jumping = false;
                collide = true;

            }
            if (position.Y >= 330 && position.Y <= 380 && position.X >= (3100 + scroll) && position.X <= (4100 + scroll))
            {

                position.Y += Num;

                jumping = false;
                collide = true;

            }


            if (position.Y >= 330 && position.Y <= 380 && position.X >= (3100 + scroll) && position.X <= (4100 + scroll))
            {
                position.X -= Num;


                jumping = false;
                collide = true;
            }


            if (position.Y >= 330 && position.Y <= 380 && position.X >= (3100 + scroll) && position.X <= (4100 + scroll))
            {
                position.X += Num;

                jumping = false;
                collide = true;

            }



            ////Kub 3
            //if (position.Y >= 300 && position.Y <= 150 && position.X >= (500 + scroll) && position.X <= (700 + scroll))
            //{

            //    position.Y -= 4;

            //}
            //if (position.Y >= 300 && position.Y <= 200 && position.X >= (500 + scroll) && position.X <= (700 + scroll))
            //{

            //    position.Y += 4;

            //}
            //if (position.Y >= 300 && position.Y <= 200 && position.X >= (500 + scroll) && position.X <= (700 + scroll))
            //{
            //    position.X -= 5;

            //}

            //if (position.Y >= 300 && position.Y <= 200 && position.X >= (500 + scroll) && position.X <= (700 + scroll))
            //{
            //    position.X += 5;



            //}

        }

        public void Collision2(GameTime gameTime)
        {
            //Kub 1_________________________________________________________________________
            position.Y += Num;



            if (currentKBSState.IsKeyDown(Keys.Right) == true)
            { scroll -= Num; }
            if (currentKBSState.IsKeyDown(Keys.Left) == true)
            { scroll += Num; }

            if (position.Y >= 310 && position.X >= (150 + scroll) && position.X <= (1200 + scroll))
            {
                position.Y -= Num;
                jumping = false;
                collide = true;
            }


            if (position.Y >= 310 && position.X >= (150 + scroll) && position.X <= (1200 + scroll))
            {
                position.X -= Num;
                position.Y += Num;

                jumping = false;
                collide = true;
            }


            if (position.Y >= 310 && position.X >= (600 + scroll) && position.X <= (1200 + scroll))
            {
                position.X += Num;
                position.Y += Num;

                jumping = false;
                collide = true;
            }

        }

        public void reset()
        {
            position = new Vector2(300, 0);
            scroll = 0;
        }



    }
}


