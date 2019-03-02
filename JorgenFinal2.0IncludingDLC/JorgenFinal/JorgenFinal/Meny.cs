using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace JorgenFinal
{
    class Meny
    {
        public bool TitleScreen = true;
        public bool Instructions = false;
        public bool Credits = false;
        public bool Level = false;
        public bool Victory = false;
        public bool GameOver = false;
        public bool level2 = false;

         Game1 game1;

        public Vector2 boxPosition = new Vector2(500, 450);

        public Vector2 box2Position = new Vector2(500, 550);

        public Vector2 box3Position = new Vector2(500, 350);

        public Vector2 box4Position = new Vector2(500, 10);

        public Vector2 exitPosition = new Vector2(0, 0);

        public Vector2 exit2Position = new Vector2(0, 0);

        MouseState mouse = Mouse.GetState();

        KeyboardState keyboard = Keyboard.GetState();

        public Rectangle mouseRect;

        public Rectangle boxRect;

        public Rectangle box2Rect;

        public Rectangle box3Rect;

        public Rectangle exitRect;

        public Rectangle exit2Rect;

        public Song mainTheme;

        public Song campaignTheme;

        public SoundEffect menuClick;

        public void LoadContent(ContentManager Content)
        {
            menuClick = Content.Load<SoundEffect>(@"Effects/MenuClick");
            mainTheme = Content.Load<Song>(@"Ost/mainTheme");
            campaignTheme = Content.Load<Song>(@"Ost/campaign");
        }

        public void Update(MouseState mouse)
        {
            if (TitleScreen == false)
            {
                MediaPlayer.Play(mainTheme);
            }

            if (TitleScreen == true)
            {
                


                boxRect = new Rectangle((int)boxPosition.X, (int)boxPosition.Y, 250, 50);

                mouseRect = new Rectangle(mouse.X, mouse.Y, 1, 1);

                if ((mouse.LeftButton == ButtonState.Pressed) && (mouseRect.Intersects(boxRect)))
                {
                    TitleScreen = false;
                    Instructions = true;
                    Credits = false;
                    Level = false;
                    menuClick.Play();
                }




                box2Rect = new Rectangle((int)box2Position.X, (int)box2Position.Y, 250, 50);


                if ((mouse.LeftButton == ButtonState.Pressed) && (mouseRect.Intersects(box2Rect)))
                {
                    TitleScreen = false;
                    Instructions = false;
                    Credits = true;
                    Level = false;
                    menuClick.Play();
                }


                box3Rect = new Rectangle((int)box3Position.X, (int)box3Position.Y, 250, 50);



                if ((mouse.LeftButton == ButtonState.Pressed) && (mouseRect.Intersects(box3Rect)))
                {
                    TitleScreen = false;
                    Instructions = false;
                    Credits = false;
                    Level = true;
                    menuClick.Play();
                }




            }
            if (Instructions == true)
            {
                exitRect = new Rectangle((int)exitPosition.X, (int)exitPosition.Y, 250, 50);

                mouseRect = new Rectangle(mouse.X, mouse.Y, 1, 1);

                if ((mouse.LeftButton == ButtonState.Pressed) && (mouseRect.Intersects(exitRect)))
                {
                    TitleScreen = true;
                    Instructions = false;
                    Credits = false;
                    Level = false;
                    menuClick.Play();
                }
            }


            if (Credits == true)
            {
                exit2Rect = new Rectangle((int)exitPosition.X, (int)exit2Position.Y, 250, 50);

                mouseRect = new Rectangle(mouse.X, mouse.Y, 1, 1);

                if ((mouse.LeftButton == ButtonState.Pressed) && (mouseRect.Intersects(exit2Rect)))
                {
                    TitleScreen = true;
                    Instructions = false;
                    Credits = false;
                    Level = false;
                    menuClick.Play();
                }
            }

            if (Victory == true)
            {
                //exit2Rect = new Rectangle((int)exitPosition.X, (int)exit2Position.Y, 250, 50);

                //mouseRect = new Rectangle(mouse.X, mouse.Y, 1, 1);

                //if ((mouse.LeftButton == ButtonState.Pressed) && (mouseRect.Intersects(exit2Rect)))
                //{
                //    TitleScreen = true;
                //    Instructions = false;
                //    Credits = false;
                //    Level = false;
                //}

                //box3Rect = new Rectangle((int)box3Position.X, (int)box3Position.Y, 250, 50);

                //if ((mouse.LeftButton == ButtonState.Pressed) && (mouseRect.Intersects(box3Rect)))
                //{
                //    TitleScreen = false;
                //    Instructions = false;
                //    Credits = true;
                //    Level = false;

                //}
            }

            if (GameOver == true)
            {
                //Rectangle exit5Rect = new Rectangle(360, 506, 160, 110);

                //mouseRect = new Rectangle(mouse.X, mouse.Y, 1, 1);

                //if ((mouse.LeftButton == ButtonState.Pressed) && (mouseRect.Intersects(exit5Rect)))
                //{
                //    TitleScreen = false;
                //    Instructions = false;
                //    Credits = false;
                //    Level = true;
                //}

                //Rectangle box6Rect = new Rectangle(861, 516, 160, 110);

                //if ((mouse.LeftButton == ButtonState.Pressed) && (mouseRect.Intersects(box3Rect)))
                //{
                //    TitleScreen = false;
                //    Instructions = false;
                //    Credits = true;
                //    Level = false;

                //}
            }



        }


        public void Draw(SpriteBatch spritebatch)
        {

        }

    }
}
