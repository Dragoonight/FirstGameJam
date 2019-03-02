using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Media;

namespace JorgenFinal
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        // Classes
        private PlayerManager playerManager;

        //A
        private Axe_animation axe;

        //Reset player position
        private bool resetPosition = false;

        private KeyboardState currentKBSState;
        private KeyboardState previousKBSState;

        // Tell if the player is jumping or not
        private bool jumping = false;

        private GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;

        private Texture2D image;
        private Texture2D bigplatform;

        private WalkerScroll walkerScroll;

        private Texture2D menu;

        private Texture2D play;
        private Texture2D instruction;
        private Texture2D credits;
        private Texture2D back;

        private Texture2D flag;

        private ObjectScroll ground1;
        private ObjectScroll ground2;
        private ObjectScroll ground3;
        private ObjectScroll ground4;
        private ObjectScroll ground5;
        private ObjectScroll ground6;
        private ObjectScroll ground7;

        private ObjectScroll obj3;
        private ObjectScroll obj4;
        private ObjectScroll obj5;
        private ObjectScroll obj6;
        private ObjectScroll obj7;
        private ObjectScroll obj8;
        private ObjectScroll obj9;
        private ObjectScroll obj10;
        private ObjectScroll obj11;
        private ObjectScroll obj12;
        private ObjectScroll obj13;
        private ObjectScroll obj14;
        private ObjectScroll obj15;
        private ObjectScroll obj16;
        private ObjectScroll obj17;
        private ObjectScroll obj18;
        private ObjectScroll obj19;
        private ObjectScroll obj20;
        private ObjectScroll obj21;
        private ObjectScroll obj22;
        private ObjectScroll obj23;
        private ObjectScroll obj24;
        private ObjectScroll obj25;
        private ObjectScroll obj26;

        //Background1
        private ObjectScroll obj27;

        private ObjectScroll obj28;
        private ObjectScroll obj29;
        private ObjectScroll obj30;

        //Background2
        private ObjectScroll obj31;

        private ObjectScroll obj32;
        private ObjectScroll obj33;
        private ObjectScroll obj34;

        //Background3
        private ObjectScroll obj35;

        private ObjectScroll obj36;
        private ObjectScroll obj37;
        private ObjectScroll obj38;

        //Background4
        private ObjectScroll obj39;

        private ObjectScroll obj40;
        private ObjectScroll obj41;
        private ObjectScroll obj42;

        //Background5
        private ObjectScroll obj43;

        private ObjectScroll obj44;
        private ObjectScroll obj45;
        private ObjectScroll obj46;

        //Background6
        private ObjectScroll obj47;

        private ObjectScroll obj48;
        private ObjectScroll obj49;
        private ObjectScroll obj50;

        private int scroll = 100;

        private Texture2D background;

        private Texture2D background1;
        private Texture2D background2;
        private Texture2D background3;
        private Texture2D background4;
        private Texture2D background5;
        private Texture2D background6;

        // Bullets
        private List<Bullets> bullets = new List<Bullets>();

        private Vector2 distance;

        private float rotation;

        private float delay;

        private Meny meny;

        private Texture2D box;
        private Texture2D Exit;
        private Texture2D CreditsList;
        private Texture2D GameOver;
        private Texture2D Victory;
        private Texture2D Victory2;
        private Texture2D Tutorial;
        private Texture2D Loga;

        private Texture2D YesButton;
        private Texture2D NoButton;

        //SoundEffect
        public SoundEffect AxeEffect;

        public SoundEffect PlayerDamage;
        public SoundEffect PlayerDeath;
        private SoundEffect loseEffect;
        private SoundEffect winEffect;
       

        private Rectangle bulletRect;

        private int counter = 50;
        private int limit = 0;

        //every  1s.
        private float countDuration = 1f;

        private float currentTime = 0f;

        //
        private int lifes = 3;

        private Texture2D heart;

        private float delayDamage = 3;

        private Rectangle playerRect;

        private SpriteFont font;

        //Valkyrie enemies
        private WalkerScroll valkyrie1;
        private WalkerScroll valkyrie2;
        private WalkerScroll valkyrie3;
        private WalkerScroll valkyrie4;
        private WalkerScroll valkyrie5;
        private WalkerScroll valkyrie6;

        //Ghost Enemies
        private WalkerScroll ghost1;
        private WalkerScroll ghost2;
        private WalkerScroll ghost3;

        private WalkerScroll chest;

        private Texture2D ghost;
        private Texture2D valkyrie;
        private Texture2D chestTexture;

        private bool ghost1Visable = true;
        private bool ghost2visable = true;
        private bool ghost3Visable = true;

        private bool valkyrie1visable = true;
        private bool valkyrie2visable = true;
        private bool valkyrie3visable = true;
        private bool valkyrie4visable = true;
        private bool valkyrie5visable = true;
        private bool valkyrie6visable = true;

        int time = 1;

        //Countdown for the delay for the gameover screen
        float countdown = 0;

        //Music timer for the main theme
        private int musicTimer = 1;

        //Continue button
        Texture2D continueTexture;

        // Diffrent gamestates
        public enum GameStates
        {
            meny, level, level2, gameover, victory, victory2
        };

        // Set gamestate to meny
        private GameStates gameState = GameStates.meny;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            // Set the resolution
            this.graphics.PreferredBackBufferWidth = 1366;
            this.graphics.PreferredBackBufferHeight = 768;
            this.graphics.ApplyChanges();

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // Load playerSprite
            playerManager = new PlayerManager(Content.Load<Texture2D>(@"spriteSheet/spriteSheet"), 4, 24, 48);

            playerManager.position = new Vector2(200, 0);

            #region Enemy

            valkyrie1 = new WalkerScroll(valkyrie, new Vector2(1000, 200), new Vector2(1366, 768), scroll + 100, 1.0f, playerManager, 400, true);
            valkyrie2 = new WalkerScroll(valkyrie, new Vector2(1700, 100), new Vector2(1366, 768), scroll + 100, 1.0f, playerManager, 500, true);
            valkyrie3 = new WalkerScroll(valkyrie, new Vector2(2200, 400), new Vector2(1366, 768), scroll + 100, 1.0f, playerManager, 400, true);
            valkyrie4 = new WalkerScroll(valkyrie, new Vector2(2500, 200), new Vector2(1366, 768), scroll + 100, 1.0f, playerManager, 500, true);
            valkyrie5 = new WalkerScroll(valkyrie, new Vector2(3000, 300), new Vector2(1366, 768), scroll + 100, 1.0f, playerManager, 400, true);
            valkyrie6 = new WalkerScroll(valkyrie, new Vector2(3700, 200), new Vector2(1366, 768), scroll + 100, 1.0f, playerManager, 500, true);

            ghost1 = new WalkerScroll(ghost, new Vector2(1000, 200), new Vector2(1366, 768), scroll + 100, 2.0f, playerManager, 400, true);
            ghost2 = new WalkerScroll(ghost, new Vector2(1700, 100), new Vector2(1366, 768), scroll + 100, 1.0f, playerManager, 500, true);
            ghost3 = new WalkerScroll(ghost, new Vector2(2200, 400), new Vector2(1366, 768), scroll + 100, 1.0f, playerManager, 400, true);


            //Load the chest
            chest = new WalkerScroll(chestTexture, new Vector2(4010, 298), new Vector2(500, 500), scroll + 100, 1.0f, playerManager, 0, true);

            ghost = Content.Load<Texture2D>(@"SpriteSheet/ghost");

            valkyrie = Content.Load<Texture2D>(@"SpriteSheet/Valkyrie");

            #endregion Enemy

            image = (Content.Load<Texture2D>(@"spriteSheet/Block"));

            bigplatform = (Content.Load<Texture2D>(@"spriteSheet/Block2"));

            background = (Content.Load<Texture2D>(@"spriteSheet/Parallax1.7"));

            Loga = (Content.Load<Texture2D>(@"spriteSheet/Loga"));

            background1 = (Content.Load<Texture2D>(@"spriteSheet/Parallax1.1"));
            background2 = (Content.Load<Texture2D>(@"spriteSheet/Parallax1.2"));
            background3 = (Content.Load<Texture2D>(@"spriteSheet/Parallax1.3"));
            background4 = (Content.Load<Texture2D>(@"spriteSheet/Parallax1.4"));
            background5 = (Content.Load<Texture2D>(@"spriteSheet/Parallax1.5"));
            background6 = (Content.Load<Texture2D>(@"spriteSheet/Parallax1.6"));

            meny = new Meny();

            box = Content.Load<Texture2D>(@"spriteSheet/Placeholder");

            Exit = Content.Load<Texture2D>(@"spriteSheet/Exit");

            CreditsList = Content.Load<Texture2D>(@"spriteSheet/CreditsList");

            GameOver = Content.Load<Texture2D>(@"spriteSheet/GameOver");
            Victory = Content.Load<Texture2D>(@"spriteSheet/Victory");

            YesButton = Content.Load<Texture2D>(@"spriteSheet/YesButton");
            NoButton = Content.Load<Texture2D>(@"spriteSheet/NoButton");
            Tutorial = Content.Load<Texture2D>(@"spriteSheet/Tutorial");
            Victory2 = Content.Load<Texture2D>(@"spriteSheet/Victory2");

            menu = Content.Load<Texture2D>(@"spriteSheet/menu");

            play = (Content.Load<Texture2D>(@"spriteSheet/Play"));
            credits = (Content.Load<Texture2D>(@"spriteSheet/Credits"));
            instruction = (Content.Load<Texture2D>(@"spriteSheet/Instructions"));
            back = (Content.Load<Texture2D>(@"spriteSheet/Back"));

            axe = new Axe_animation(Content.Load<Texture2D>(@"spriteSheet/Axe"), 1, 47, 44);

            AxeEffect = Content.Load<SoundEffect>(@"Effects/Axe");
            PlayerDamage = Content.Load<SoundEffect>(@"Effects/PlayerD");
            PlayerDeath = Content.Load<SoundEffect>(@"Effects/PlayerD_2");

            
            loseEffect = Content.Load<SoundEffect>(@"Effects/Lose");
            winEffect = Content.Load<SoundEffect>(@"Effects/Win");

            font = Content.Load<SpriteFont>(@"Fonts/SpriteFont");

            heart = Content.Load<Texture2D>(@"SpriteSheet/Heart");

            chestTexture = Content.Load<Texture2D>(@"SpriteSheet/Chest");

            continueTexture = Content.Load<Texture2D>(@"SpriteSheet/Continue");

            


            meny.LoadContent(Content);
            // TODO: use this.Content to load your game content here
        }

        public void reset(GameTime gameTime)
        {
            //Reset the player position and scroll
            playerManager.reset();
            lifes = 3;
            counter = 50;
          
            //Reset the enemy visible 
            ghost1Visable = true;
            ghost2visable = true;
            ghost3Visable = true;

            valkyrie1visable = true;
            valkyrie2visable = true;
            valkyrie3visable = true;
            valkyrie4visable = true;
            valkyrie5visable = true;
            valkyrie6visable = true;

            //Reset the enemy position manually // also set starting positions
            ghost1.Position = new Vector2(1150, 285);
            ghost2.Position = new Vector2(2500, 285);
            ghost3.Position = new Vector2(4030, 300);
           
            valkyrie1.Position = new Vector2(900, 100);
            valkyrie2.Position = new Vector2(1700, 100);
            valkyrie3.Position = new Vector2(2100, 450);
            valkyrie4.Position = new Vector2(2500, 200);
            valkyrie5.Position = new Vector2(3000, 400);
            valkyrie6.Position = new Vector2(3700, 100);       
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>

        
       

        protected override void Update(GameTime gameTime)
        {

          
            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed ||
                Keyboard.GetState().IsKeyDown(Keys.Escape))
            {
                this.Exit();
            }

            if (Keyboard.GetState().IsKeyDown(Keys.F))
            {
                graphics.ToggleFullScreen();
                MediaPlayer.Play(meny.mainTheme);
               
            }

            // TODO: Add your update logic here

            currentKBSState = Keyboard.GetState();

            MouseState mouse = Mouse.GetState();
            IsMouseVisible = true;

            distance.X = mouse.X - playerManager.Position.X;
            distance.Y = mouse.Y - playerManager.position.Y;

            rotation = (float)Math.Atan2(distance.Y, distance.X);

            if (currentKBSState.IsKeyDown(Keys.Back))
                this.Exit();

           

            switch (gameState)

            {
                case GameStates.meny:

                   

                    countdown = 0;

                    reset(gameTime);

                    meny.Update(mouse);

                    if (meny.Level == true)
                    {
                        playerManager.position = new Vector2(300, 100);
                        gameState = GameStates.level;
                        MediaPlayer.Stop();
                        MediaPlayer.Play(meny.campaignTheme);
                        MediaPlayer.IsRepeating = true;
                    }

                    #region ObjectScroll

                    ground1 = new ObjectScroll(bigplatform, new Vector2(playerManager.position.X - 230, 350), new Vector2(1030, 50), scroll = 0, 1);
                    ground1.Update();
                    ground2 = new ObjectScroll(image, new Vector2(playerManager.position.X + 965, 350), new Vector2(210, 50), scroll = 0, 1);
                    ground2.Update();
                    ground3 = new ObjectScroll(image, new Vector2(playerManager.position.X + 1270, 300), new Vector2(240, 50), scroll = 0, 1);
                    ground3.Update();
                    ground4 = new ObjectScroll(image, new Vector2(playerManager.Position.X + 1600, 400), new Vector2(215, 50), scroll = 0, 1);
                    ground4.Update();
                    ground5 = new ObjectScroll(image, new Vector2(playerManager.position.X + 1900, 350), new Vector2(210, 50), scroll = 0, 1);
                    ground5.Update();
                    ground6 = new ObjectScroll(image, new Vector2(playerManager.position.X + 2400, 450), new Vector2(210, 50), scroll = 0, 1);
                    ground6.Update();
                    ground7 = new ObjectScroll(bigplatform, new Vector2(playerManager.position.X + 2700, 370), new Vector2(1000, 50), scroll = 0, 1f);
                    ground7.Update();

                    obj3 = new ObjectScroll(background1, new Vector2(0, 0), new Vector2(1366, 768), scroll, 100f);
                    obj3.Update();
                    obj4 = new ObjectScroll(background2, new Vector2(0, 0), new Vector2(1366, 768), scroll, 2f);
                    obj4.Update();
                    obj5 = new ObjectScroll(background3, new Vector2(0, 0), new Vector2(1366, 768), scroll, 1.8f);
                    obj5.Update();
                    obj6 = new ObjectScroll(background4, new Vector2(0, 0), new Vector2(1366, 768), scroll, 1.6f);
                    obj6.Update();
                    obj7 = new ObjectScroll(background5, new Vector2(0, 0), new Vector2(1366, 768), scroll, 1.4f);
                    obj7.Update();
                    obj8 = new ObjectScroll(background6, new Vector2(0, 0), new Vector2(1366, 768), scroll, 1.2f);
                    obj8.Update();

                    obj9 = new ObjectScroll(background1, new Vector2(1366, 0), new Vector2(1366, 768), scroll, 2.2f);
                    obj9.Update();
                    obj10 = new ObjectScroll(background2, new Vector2(1366, 0), new Vector2(1366, 768), scroll, 2f);
                    obj10.Update();
                    obj11 = new ObjectScroll(background3, new Vector2(1366, 0), new Vector2(1366, 768), scroll, 1.8f);
                    obj11.Update();
                    obj12 = new ObjectScroll(background4, new Vector2(1366, 0), new Vector2(1366, 768), scroll, 1.6f);
                    obj12.Update();
                    obj13 = new ObjectScroll(background5, new Vector2(1366, 0), new Vector2(1366, 768), scroll, 1.4f);
                    obj13.Update();
                    obj14 = new ObjectScroll(background6, new Vector2(1366, 0), new Vector2(1366, 768), scroll, 1.2f);
                    obj14.Update();

                    obj15 = new ObjectScroll(background1, new Vector2(-1366, 0), new Vector2(1366, 768), scroll, 2.2f);
                    obj15.Update();
                    obj16 = new ObjectScroll(background2, new Vector2(-1366, 0), new Vector2(1366, 768), scroll, 2f);
                    obj16.Update();
                    obj17 = new ObjectScroll(background3, new Vector2(-1366, 0), new Vector2(1366, 768), scroll, 1.8f);
                    obj17.Update();
                    obj18 = new ObjectScroll(background4, new Vector2(-1366, 0), new Vector2(1366, 768), scroll, 1.6f);
                    obj18.Update();
                    obj19 = new ObjectScroll(background5, new Vector2(-1366, 0), new Vector2(1366, 768), scroll, 1.4f);
                    obj19.Update();
                    obj20 = new ObjectScroll(background6, new Vector2(-1366, 0), new Vector2(1366, 768), scroll, 1.2f);
                    obj20.Update();

                    obj21 = new ObjectScroll(background1, new Vector2(2732, 0), new Vector2(1366, 768), scroll, 2.2f);
                    obj21.Update();
                    obj22 = new ObjectScroll(background2, new Vector2(2732, 0), new Vector2(1366, 768), scroll, 2f);
                    obj22.Update();
                    obj23 = new ObjectScroll(background3, new Vector2(2732, 0), new Vector2(1366, 768), scroll, 1.8f);
                    obj23.Update();
                    obj24 = new ObjectScroll(background4, new Vector2(2732, 0), new Vector2(1366, 768), scroll, 1.6f);
                    obj24.Update();
                    obj25 = new ObjectScroll(background5, new Vector2(2732, 0), new Vector2(1366, 768), scroll, 1.4f);
                    obj25.Update();
                    obj26 = new ObjectScroll(background6, new Vector2(2732, 0), new Vector2(1366, 768), scroll, 1.2f);
                    obj26.Update();

                    //Group1
                    obj27 = new ObjectScroll(background1, new Vector2(4098, 0), new Vector2(1366, 768), scroll, 2.2f);
                    obj27.Update();
                    obj28 = new ObjectScroll(background1, new Vector2(5464, 0), new Vector2(1366, 768), scroll, 2.2f);
                    obj28.Update();
                    obj29 = new ObjectScroll(background1, new Vector2(6830, 0), new Vector2(1366, 768), scroll, 2.2f);
                    obj29.Update();
                    obj30 = new ObjectScroll(background1, new Vector2(8196, 0), new Vector2(1366, 768), scroll, 2.2f);
                    obj30.Update();

                    //Group2
                    obj31 = new ObjectScroll(background2, new Vector2(4098, 0), new Vector2(1366, 768), scroll, 2f);
                    obj31.Update();
                    obj32 = new ObjectScroll(background2, new Vector2(5464, 0), new Vector2(1366, 768), scroll, 2f);
                    obj32.Update();
                    obj33 = new ObjectScroll(background2, new Vector2(6830, 0), new Vector2(1366, 768), scroll, 2f);
                    obj33.Update();
                    obj34 = new ObjectScroll(background2, new Vector2(8196, 0), new Vector2(1366, 768), scroll, 2f);
                    obj34.Update();

                    //Group3
                    obj35 = new ObjectScroll(background3, new Vector2(4098, 0), new Vector2(1366, 768), scroll, 1.8f);
                    obj35.Update();
                    obj36 = new ObjectScroll(background3, new Vector2(5464, 0), new Vector2(1366, 768), scroll, 1.8f);
                    obj36.Update();
                    obj37 = new ObjectScroll(background3, new Vector2(6830, 0), new Vector2(1366, 768), scroll, 1.8f);
                    obj37.Update();
                    obj38 = new ObjectScroll(background3, new Vector2(8196, 0), new Vector2(1366, 768), scroll, 1.8f);
                    obj38.Update();

                    //Group4
                    obj39 = new ObjectScroll(background4, new Vector2(4098, 0), new Vector2(1366, 768), scroll, 1.6f);
                    obj39.Update();
                    obj40 = new ObjectScroll(background4, new Vector2(5464, 0), new Vector2(1366, 768), scroll, 1.6f);
                    obj40.Update();
                    obj41 = new ObjectScroll(background4, new Vector2(6830, 0), new Vector2(1366, 768), scroll, 1.6f);
                    obj41.Update();
                    obj42 = new ObjectScroll(background4, new Vector2(8196, 0), new Vector2(1366, 768), scroll, 1.6f);
                    obj42.Update();

                    //Group5
                    obj43 = new ObjectScroll(background5, new Vector2(4098, 0), new Vector2(1366, 768), scroll, 1.4f);
                    obj43.Update();
                    obj44 = new ObjectScroll(background5, new Vector2(5464, 0), new Vector2(1366, 768), scroll, 1.4f);
                    obj44.Update();
                    obj45 = new ObjectScroll(background5, new Vector2(6830, 0), new Vector2(1366, 768), scroll, 1.4f);
                    obj45.Update();
                    obj46 = new ObjectScroll(background5, new Vector2(8196, 0), new Vector2(1366, 768), scroll, 1.4f);
                    obj46.Update();

                    //Group6
                    obj47 = new ObjectScroll(background6, new Vector2(4098, 0), new Vector2(1366, 768), scroll, 1.2f);
                    obj47.Update();
                    obj48 = new ObjectScroll(background6, new Vector2(5464, 0), new Vector2(1366, 768), scroll, 1.2f);
                    obj48.Update();
                    obj49 = new ObjectScroll(background6, new Vector2(6839, 0), new Vector2(1366, 768), scroll, 1.2f);
                    obj49.Update();
                    obj50 = new ObjectScroll(background6, new Vector2(8196, 0), new Vector2(1366, 768), scroll, 1.2f);
                    obj50.Update();

                    #endregion ObjectScroll

                    //MediaPlayer.Play(meny.mainTheme);

                    break;

                case GameStates.level:

                    #region WalkerUpdate

                    ghost1 = new WalkerScroll(ghost, new Vector2(ghost1.Position.X, ghost1.Position.Y),
                        new Vector2(60, 100), scroll, 1.0f, playerManager, 300, ghost1.Alive);
                    ghost1.Update2(gameTime);
                    ghost2 = new WalkerScroll(ghost, new Vector2(ghost2.Position.X, ghost2.Position.Y),
                        new Vector2(60, 100), scroll, 1.0f, playerManager, 250, ghost2.Alive);
                    ghost2.Update2(gameTime);
                    ghost3 = new WalkerScroll(ghost, new Vector2(ghost3.Position.X, ghost3.Position.Y),
                        new Vector2(60, 100), scroll, 1.0f, playerManager, 300, ghost3.Alive);
                    ghost3.Update2(gameTime);

                    valkyrie1 = new WalkerScroll(valkyrie, new Vector2(valkyrie1.Position.X, valkyrie1.Position.Y),
                        new Vector2(58, 58), scroll, 1.0f, playerManager, 400, valkyrie1.Alive);
                    valkyrie1.Update(gameTime);
                    valkyrie2 = new WalkerScroll(valkyrie, new Vector2(valkyrie2.Position.X, valkyrie2.Position.Y),
                        new Vector2(58, 58), scroll, 1.0f, playerManager, 500, valkyrie2.Alive);
                    valkyrie2.Update(gameTime);
                    valkyrie3 = new WalkerScroll(valkyrie, new Vector2(valkyrie3.Position.X, valkyrie3.Position.Y),
                        new Vector2(58, 58), scroll, 1.0f, playerManager, 400, valkyrie3.Alive);
                    valkyrie3.Update(gameTime);
                    valkyrie4 = new WalkerScroll(valkyrie, new Vector2(valkyrie4.Position.X, valkyrie4.Position.Y),
                        new Vector2(58, 58), scroll, 1.0f, playerManager, 500, valkyrie4.Alive);
                    valkyrie4.Update(gameTime);
                    valkyrie5 = new WalkerScroll(valkyrie, new Vector2(valkyrie5.Position.X, valkyrie5.Position.Y),
                        new Vector2(58, 58), scroll, 1.0f, playerManager, 400, valkyrie5.Alive);
                    valkyrie5.Update(gameTime);
                    valkyrie6 = new WalkerScroll(valkyrie, new Vector2(valkyrie6.Position.X, valkyrie6.Position.Y),
                        new Vector2(58, 58), scroll, 1.0f, playerManager, 500, valkyrie6.Alive);
                    valkyrie6.Update(gameTime);
                    chest = new WalkerScroll(chestTexture, new Vector2(chest.Position.X, chest.Position.Y), new Vector2(350, 250), scroll, 1.0f, playerManager, 0, chest.Alive);
                    chest.Update(gameTime);

                    #endregion WalkerUpdate

                    //      walkerScroll.Update(gameTime);

                    //Resets the win and lose sound effects
                    time = 1;

                    if (playerManager.Position.Y > 700)
                        gameState = GameStates.gameover;

                    currentTime += (float)gameTime.ElapsedGameTime.TotalSeconds;

                    if (currentTime >= countDuration)
                    {
                        counter--;
                        currentTime -= countDuration; // "use up" the time
                        //any actions to perform
                    }
                    if (counter == limit)
                    {
                        gameState = GameStates.gameover;
                    }

                    if ((mouse.LeftButton == ButtonState.Pressed) && delay > 30)
                    {
                        Shoot();
                        delay = 0;
                        AxeEffect.Play();
                    }

                    // Player manager
                    playerManager.HandleSpriteMovement(gameTime);
                    playerManager.Jumping(gameTime);
                    playerManager.Collision(gameTime);

                    axe.Animate(gameTime);

                    #region AnotherObjectScroll

                    ground1 = new ObjectScroll(bigplatform, new Vector2(playerManager.position.X - 140, 350), new Vector2(1050, 50), scroll, 1);
                    ground1.Update();
                    ground2 = new ObjectScroll(image, new Vector2(playerManager.position.X + 1060, 350), new Vector2(230, 50), scroll, 1);
                    ground2.Update();
                    ground3 = new ObjectScroll(image, new Vector2(playerManager.position.X + 1370, 300), new Vector2(235, 50), scroll, 1);
                    ground3.Update();
                    ground4 = new ObjectScroll(image, new Vector2(playerManager.Position.X + 1700, 400), new Vector2(205, 50), scroll, 1);
                    ground4.Update();
                    ground5 = new ObjectScroll(image, new Vector2(playerManager.position.X + 2000, 350), new Vector2(200, 50), scroll, 1);
                    ground5.Update();
                    ground6 = new ObjectScroll(image, new Vector2(playerManager.position.X + 2510, 450), new Vector2(195, 50), scroll, 1);
                    ground6.Update();
                    ground7 = new ObjectScroll(bigplatform, new Vector2(playerManager.position.X + 2810, 370), new Vector2(1000, 50), scroll, 1f);
                    ground7.Update();

                    obj3 = new ObjectScroll(background1, new Vector2(0, 0), new Vector2(1366, 768), scroll, 2.2f);
                    obj3.Update();
                    obj4 = new ObjectScroll(background2, new Vector2(0, 0), new Vector2(1366, 768), scroll, 2f);
                    obj4.Update();
                    obj5 = new ObjectScroll(background3, new Vector2(0, 0), new Vector2(1366, 768), scroll, 1.8f);
                    obj5.Update();
                    obj6 = new ObjectScroll(background4, new Vector2(0, 0), new Vector2(1366, 768), scroll, 1.6f);
                    obj6.Update();
                    obj7 = new ObjectScroll(background5, new Vector2(0, 0), new Vector2(1366, 768), scroll, 1.4f);
                    obj7.Update();
                    obj8 = new ObjectScroll(background6, new Vector2(0, 0), new Vector2(1366, 768), scroll, 1.2f);
                    obj8.Update();

                    obj9 = new ObjectScroll(background1, new Vector2(1366, 0), new Vector2(1366, 768), scroll, 2.2f);
                    obj9.Update();
                    obj10 = new ObjectScroll(background2, new Vector2(1366, 0), new Vector2(1366, 768), scroll, 2f);
                    obj10.Update();
                    obj11 = new ObjectScroll(background3, new Vector2(1366, 0), new Vector2(1366, 768), scroll, 1.8f);
                    obj11.Update();
                    obj12 = new ObjectScroll(background4, new Vector2(1366, 0), new Vector2(1366, 768), scroll, 1.6f);
                    obj12.Update();
                    obj13 = new ObjectScroll(background5, new Vector2(1366, 0), new Vector2(1366, 768), scroll, 1.4f);
                    obj13.Update();
                    obj14 = new ObjectScroll(background6, new Vector2(1366, 0), new Vector2(1366, 768), scroll, 1.2f);
                    obj14.Update();

                    obj15 = new ObjectScroll(background1, new Vector2(-1366, 0), new Vector2(1366, 768), scroll, 2.2f);
                    obj15.Update();
                    obj16 = new ObjectScroll(background2, new Vector2(-1366, 0), new Vector2(1366, 768), scroll, 2f);
                    obj16.Update();
                    obj17 = new ObjectScroll(background3, new Vector2(-1366, 0), new Vector2(1366, 768), scroll, 1.8f);
                    obj17.Update();
                    obj18 = new ObjectScroll(background4, new Vector2(-1366, 0), new Vector2(1366, 768), scroll, 1.6f);
                    obj18.Update();
                    obj19 = new ObjectScroll(background5, new Vector2(-1366, 0), new Vector2(1366, 768), scroll, 1.4f);
                    obj19.Update();
                    obj20 = new ObjectScroll(background6, new Vector2(-1366, 0), new Vector2(1366, 768), scroll, 1.2f);
                    obj20.Update();

                    obj21 = new ObjectScroll(background1, new Vector2(2732, 0), new Vector2(1366, 768), scroll, 2.2f);
                    obj21.Update();
                    obj22 = new ObjectScroll(background2, new Vector2(2732, 0), new Vector2(1366, 768), scroll, 2f);
                    obj22.Update();
                    obj23 = new ObjectScroll(background3, new Vector2(2732, 0), new Vector2(1366, 768), scroll, 1.8f);
                    obj23.Update();
                    obj24 = new ObjectScroll(background4, new Vector2(2732, 0), new Vector2(1366, 768), scroll, 1.6f);
                    obj24.Update();
                    obj25 = new ObjectScroll(background5, new Vector2(2732, 0), new Vector2(1366, 768), scroll, 1.4f);
                    obj25.Update();
                    obj26 = new ObjectScroll(background6, new Vector2(2732, 0), new Vector2(1366, 768), scroll, 1.2f);
                    obj26.Update();

                    //Group1
                    obj27 = new ObjectScroll(background1, new Vector2(4098, 0), new Vector2(1366, 768), scroll, 2.2f);
                    obj27.Update();
                    obj28 = new ObjectScroll(background1, new Vector2(5464, 0), new Vector2(1366, 768), scroll, 2.2f);
                    obj28.Update();
                    obj29 = new ObjectScroll(background1, new Vector2(6830, 0), new Vector2(1366, 768), scroll, 2.2f);
                    obj29.Update();
                    obj30 = new ObjectScroll(background1, new Vector2(8196, 0), new Vector2(1366, 768), scroll, 2.2f);
                    obj30.Update();

                    #endregion AnotherObjectScroll

                    KeyboardState currentKBState;
                    currentKBState = Keyboard.GetState();

                    if (currentKBState.IsKeyDown(Keys.D) == true)
                    { scroll -= 5; }
                    if (currentKBState.IsKeyDown(Keys.A) == true)
                    { scroll += 5; }

                    if (playerManager.Position.X > (4000 + scroll) && playerManager.Position.Y > (400 + scroll))
                        gameState = GameStates.victory2;

                    previousKBSState = Keyboard.GetState();
                    UpdateBullets();

                    delay++;

                    foreach (Bullets bullets in bullets)
                    {
                        bulletRect = new Rectangle((int)bullets.position.X, (int)bullets.position.Y, 40, 40);


                        if (bulletRect.Intersects(ghost1.Rect))
                        {
                            ghost1Visable = false;
                        }

                        if (bulletRect.Intersects(ghost2.Rect))
                        {
                            ghost2visable = false;
                        }

                        if (bulletRect.Intersects(ghost3.Rect))
                        {
                            ghost3Visable = false;
                        }

                        if (bulletRect.Intersects(valkyrie1.Rect))
                        {
                            valkyrie1visable = false;
                        }

                        if (bulletRect.Intersects(valkyrie2.Rect))
                        {
                            valkyrie2visable = false;
                        }

                        if (bulletRect.Intersects(valkyrie3.Rect))
                        {
                            valkyrie3visable = false;
                        }

                        if (bulletRect.Intersects(valkyrie4.Rect))
                        {
                            valkyrie4visable = false;
                        }

                        if (bulletRect.Intersects(valkyrie5.Rect))
                        {
                            valkyrie5visable = false;
                        }

                        if (bulletRect.Intersects(valkyrie6.Rect))
                        {
                            valkyrie6visable = false;
                        }
                    }

                    playerRect = new Rectangle((int)playerManager.Position.X, (int)playerManager.Position.Y, 50, 50);

                    if (playerRect.Intersects(ghost1.Rect) && delayDamage >= 100 && ghost1Visable == true)
                    {
                        lifes -= 1;

                        delayDamage = 0;
                        PlayerDamage.Play();
                    }

                    if (playerRect.Intersects(ghost2.Rect) && delayDamage >= 100 && ghost2visable == true)
                    {
                        lifes -= 1;

                        PlayerDamage.Play();
                        delayDamage = 0;
                    }

                    if (playerRect.Intersects(ghost3.Rect) && delayDamage >= 100 && ghost3Visable == true)
                    {
                        lifes -= 1;

                        PlayerDamage.Play();
                        delayDamage = 0;
                    }

                    if (playerRect.Intersects(valkyrie1.Rect) && delayDamage >= 100 && valkyrie1visable == true)
                    {
                        lifes -= 1;

                        PlayerDamage.Play();

                        delayDamage = 0;
                    }

                    if (playerRect.Intersects(valkyrie2.Rect) && delayDamage >= 100 && valkyrie2visable == true)
                    {
                        lifes -= 1;

                        PlayerDamage.Play();
                        delayDamage = 0;
                    }

                    if (playerRect.Intersects(valkyrie3.Rect) && delayDamage >= 100 && valkyrie3visable == true)
                    {
                        lifes -= 1;
                        PlayerDamage.Play();
                        delayDamage = 0;
                    }

                    if (playerRect.Intersects(valkyrie4.Rect) && delayDamage >= 100 && valkyrie4visable == true)
                    {
                        lifes -= 1;
                        PlayerDamage.Play();
                        delayDamage = 0;
                    }

                    if (playerRect.Intersects(valkyrie5.Rect) && delayDamage >= 100 && valkyrie5visable == true)
                    {
                        lifes -= 1;
                        PlayerDamage.Play();
                        delayDamage = 0;
                    }

                    if (playerRect.Intersects(valkyrie6.Rect) && delayDamage >= 100 && valkyrie6visable == true)
                    {
                        lifes -= 1;
                        PlayerDamage.Play();
                       
                    }

                    delayDamage++;

                    if (lifes <= 0)
                    {
                        gameState = GameStates.gameover;
                        PlayerDeath.Play();
                    }
                        

                   

                    break;

                case GameStates.gameover:

                    MediaPlayer.Stop();

                    //Timer for the sound effects to not repeat and ear rape people
                    if (time < 2)
                    {
                        time =+ 2;
                        loseEffect.Play();
                        PlayerDeath.Play();
                    }
                    meny.Update(mouse);

                    //if (currentKBSState.IsKeyDown(Keys.P))
                    //{
                    //    gameState = GameStates.meny;
                    //    meny.Level = false;
                    //    meny.TitleScreen = true;
                    //    meny.menuClick.Play();
                    //}


                    int delayTimer = 1;
                   

                    Rectangle exit5Rect = new Rectangle(360, 506, 160, 110);

                    Rectangle mouseRect = new Rectangle(mouse.X, mouse.Y, 1, 1);

                    Rectangle box6Rect = new Rectangle(861, 516, 160, 110);

                    countdown += (float)gameTime.ElapsedGameTime.TotalSeconds;

                    if (delayTimer < countdown)
                    {
                        if ((mouse.LeftButton == ButtonState.Pressed) && (mouseRect.Intersects(exit5Rect)))
                        {
                            gameState = GameStates.meny;
                            meny.TitleScreen = false;
                            meny.Instructions = false;
                            meny.Credits = false;
                            meny.Level = true;
                            meny.menuClick.Play();
                        }

                        if ((mouse.LeftButton == ButtonState.Pressed) && (mouseRect.Intersects(box6Rect)))
                        {
                            gameState = GameStates.meny;
                            meny.TitleScreen = false;
                            meny.Instructions = false;
                            meny.Credits = true;
                            meny.Level = false;
                            meny.menuClick.Play();
                        }
                    }
                    
                    


                    reset(gameTime);

                    break;

                case GameStates.victory:

                    

                    Rectangle exit2Rect = new Rectangle(360, 506, 160, 110);

                    mouseRect = new Rectangle(mouse.X, mouse.Y, 1, 1);

                    if ((mouse.LeftButton == ButtonState.Pressed) && (mouseRect.Intersects(exit2Rect)))
                    {
                        gameState = GameStates.meny;
                        meny.TitleScreen = true;
                        meny.Instructions = false;
                        meny.Credits = false;
                        meny.Level = false;
                        meny.level2 = true;
                    }

                    Rectangle box3Rect = new Rectangle(861, 516, 160, 110);

                    if ((mouse.LeftButton == ButtonState.Pressed) && (mouseRect.Intersects(box3Rect)))
                    {
                        gameState = GameStates.meny;
                        meny.TitleScreen = false;
                        meny.Instructions = false;
                        meny.Credits = true;
                        meny.Level = false;
                    }

                    break;

                case GameStates.victory2:

                    MediaPlayer.Stop();

                    if (time < 2)
                    {
                        winEffect.Play();
                        time = +2;
                    }

                    
                    Rectangle exit9Rect = new Rectangle(460, 600, 403, 115);

                    mouseRect = new Rectangle(mouse.X, mouse.Y, 1, 1);

                    if ((mouse.LeftButton == ButtonState.Pressed) && (mouseRect.Intersects(exit9Rect)))
                    {
                        gameState = GameStates.meny;
                        meny.Level = false;
                        meny.TitleScreen = false;
                        meny.Instructions = false;
                        meny.Credits = true;
                        meny.menuClick.Play();
                    }

                    break;

                case GameStates.level2:

                    if (currentKBSState.IsKeyDown(Keys.P))
                    {
                        gameState = GameStates.meny;
                        meny.Level = false;
                        meny.TitleScreen = true;
                    }
                    break;
            }

            base.Update(gameTime);
        }

        public void UpdateBullets()
        {
            foreach (Bullets bullet in bullets)
            {
                bullet.position += bullet.velocity;
                if (Vector2.Distance(bullet.position, playerManager.position) > 2000)
                    bullet.isVisible = false;
            }
            for (int i = 0; i < bullets.Count; i++)
            {
                if (!bullets[i].isVisible)
                {
                    bullets.RemoveAt(i);
                    i--;
                }
            }
        }

        public void Shoot()
        {
            Bullets newBullet = new Bullets(axe.Texture);
            newBullet.velocity = new Vector2((float)Math.Cos(rotation), (float)Math.Sin(rotation)) * 5f;
            newBullet.position = playerManager.position + newBullet.velocity * 5;
            newBullet.isVisible = true;

            bullets.Add(newBullet);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            if (gameState == GameStates.meny)
            {
                spriteBatch.Begin();

                if (meny.TitleScreen == true)
                {
                    spriteBatch.Draw(menu, new Vector2(0, 0), Color.White);
                    spriteBatch.Draw(Loga, meny.box4Position, null, Color.White, 0f,
                        Vector2.Zero, 0.5f, SpriteEffects.None, 0f);
                    spriteBatch.Draw(instruction, meny.boxPosition, Color.White);
                    spriteBatch.Draw(credits, meny.box2Position, Color.White);
                    spriteBatch.Draw(play, meny.box3Position, Color.White);
                }

                if (meny.Instructions == true)
                {
                    spriteBatch.Draw(Tutorial, new Vector2(0, 0), Color.White);
                    spriteBatch.Draw(Exit, meny.exitPosition, meny.exitRect, Color.White);
                }

                if (meny.Credits == true)
                {
                    spriteBatch.Draw(menu, new Vector2(0, 0), Color.White);
                    spriteBatch.Draw(CreditsList, new Vector2(0, 0), null, Color.White);
                    spriteBatch.Draw(Exit, meny.exit2Position, meny.exit2Rect, Color.White);
                }

                spriteBatch.End();
            }

            if (gameState == GameStates.level)
            {
                spriteBatch.Begin();

                spriteBatch.Draw(background, new Vector2(0, 0), Color.White);

                spriteBatch.DrawString(font, counter.ToString(), new Vector2(0, 0), Color.White);

                for (int i = lifes; i > 0; i--)
                {
                    spriteBatch.Draw(heart, new Vector2
                        (500 + i * 60, 15), Color.White);
                }

                spriteBatch.Draw(obj8.Texture, obj8.Rect, Color.White);
                spriteBatch.Draw(obj7.Texture, obj7.Rect, Color.White);
                spriteBatch.Draw(obj6.Texture, obj6.Rect, Color.White);
                spriteBatch.Draw(obj5.Texture, obj5.Rect, Color.White);
                spriteBatch.Draw(obj4.Texture, obj4.Rect, Color.White);

                spriteBatch.Draw(obj14.Texture, obj14.Rect, Color.White);
                spriteBatch.Draw(obj13.Texture, obj13.Rect, Color.White);
                spriteBatch.Draw(obj12.Texture, obj12.Rect, Color.White);
                spriteBatch.Draw(obj11.Texture, obj11.Rect, Color.White);
                spriteBatch.Draw(obj10.Texture, obj10.Rect, Color.White);

                spriteBatch.Draw(obj20.Texture, obj16.Rect, Color.White);
                spriteBatch.Draw(obj19.Texture, obj17.Rect, Color.White);
                spriteBatch.Draw(obj18.Texture, obj18.Rect, Color.White);
                spriteBatch.Draw(obj17.Texture, obj19.Rect, Color.White);
                spriteBatch.Draw(obj16.Texture, obj20.Rect, Color.White);

                spriteBatch.Draw(obj26.Texture, obj22.Rect, Color.White);
                spriteBatch.Draw(obj25.Texture, obj23.Rect, Color.White);
                spriteBatch.Draw(obj24.Texture, obj24.Rect, Color.White);
                spriteBatch.Draw(obj23.Texture, obj25.Rect, Color.White);
                spriteBatch.Draw(obj22.Texture, obj26.Rect, Color.White);

                spriteBatch.Draw(playerManager.Texture, playerManager.Position, playerManager.SourceRect, Color.White);

                spriteBatch.Draw(obj3.Texture, obj3.Rect, Color.White);

                spriteBatch.Draw(obj9.Texture, obj9.Rect, Color.White);

                spriteBatch.Draw(obj15.Texture, obj15.Rect, Color.White);

                spriteBatch.Draw(obj21.Texture, obj21.Rect, Color.White);

                spriteBatch.Draw(obj27.Texture, obj27.Rect, Color.White);
                spriteBatch.Draw(obj28.Texture, obj28.Rect, Color.White);
                spriteBatch.Draw(obj29.Texture, obj29.Rect, Color.White);
                spriteBatch.Draw(obj30.Texture, obj30.Rect, Color.White);

                spriteBatch.Draw(obj31.Texture, obj31.Rect, Color.White);
                spriteBatch.Draw(obj32.Texture, obj32.Rect, Color.White);
                spriteBatch.Draw(obj33.Texture, obj33.Rect, Color.White);
                spriteBatch.Draw(obj34.Texture, obj34.Rect, Color.White);

                spriteBatch.Draw(obj35.Texture, obj35.Rect, Color.White);
                spriteBatch.Draw(obj36.Texture, obj36.Rect, Color.White);
                spriteBatch.Draw(obj37.Texture, obj37.Rect, Color.White);
                spriteBatch.Draw(obj38.Texture, obj38.Rect, Color.White);

                spriteBatch.Draw(obj39.Texture, obj39.Rect, Color.White);
                spriteBatch.Draw(obj40.Texture, obj40.Rect, Color.White);
                spriteBatch.Draw(obj41.Texture, obj41.Rect, Color.White);
                spriteBatch.Draw(obj42.Texture, obj42.Rect, Color.White);

                spriteBatch.Draw(obj43.Texture, obj43.Rect, Color.White);
                spriteBatch.Draw(obj44.Texture, obj44.Rect, Color.White);
                spriteBatch.Draw(obj45.Texture, obj45.Rect, Color.White);
                spriteBatch.Draw(obj46.Texture, obj46.Rect, Color.White);

                spriteBatch.Draw(obj47.Texture, obj47.Rect, Color.White);
                spriteBatch.Draw(obj48.Texture, obj48.Rect, Color.White);
                spriteBatch.Draw(obj49.Texture, obj49.Rect, Color.White);
                spriteBatch.Draw(obj50.Texture, obj50.Rect, Color.White);

                spriteBatch.Draw(ground1.Texture, ground1.Rect, Color.White);
                spriteBatch.Draw(ground2.Texture, ground2.Rect, Color.White);
                spriteBatch.Draw(ground3.Texture, ground3.Rect, Color.White);
                spriteBatch.Draw(ground4.Texture, ground4.Rect, Color.White);
                spriteBatch.Draw(ground5.Texture, ground5.Rect, Color.White);
                spriteBatch.Draw(ground6.Texture, ground6.Rect, Color.White);
                spriteBatch.Draw(ground7.Texture, ground7.Rect, Color.White);

                if (ghost1Visable == true)
                    spriteBatch.Draw(ghost, ghost1.Rect, Color.White);

                if (ghost2visable == true)
                    spriteBatch.Draw(ghost, ghost2.Rect, Color.White);

                if (ghost3Visable == true)
                    spriteBatch.Draw(ghost, ghost3.Rect, Color.White);



                if (valkyrie1visable == true)
                    spriteBatch.Draw(valkyrie, valkyrie1.Rect, Color.White);

                if (valkyrie2visable == true)
                    spriteBatch.Draw(valkyrie, valkyrie2.Rect, Color.White);

                if (valkyrie3visable == true)
                    spriteBatch.Draw(valkyrie, valkyrie3.Rect, Color.White);

                if (valkyrie4visable == true)
                    spriteBatch.Draw(valkyrie, valkyrie4.Rect, Color.White);

                if (valkyrie5visable == true)
                    spriteBatch.Draw(valkyrie, valkyrie5.Rect, Color.White);

                if (valkyrie6visable == true)
                    spriteBatch.Draw(valkyrie, valkyrie6.Rect, Color.White);



                foreach (Bullets bullets in bullets)
                    spriteBatch.Draw(axe.Texture, bullets.position, new Rectangle(0, 0, 40, 40), Color.White);

                //bullets.Draw(spriteBatch);

                //spriteBatch.Draw(axe.Texture, axe.Position, new Rectangle(0,0,30,30), Color.White);

                spriteBatch.Draw(chestTexture, chest.Rect, Color.White);
              

                spriteBatch.End();
            }

            if (gameState == GameStates.gameover)
            {
                spriteBatch.Begin();
                spriteBatch.Draw(GameOver, new Vector2(0, 0), Color.White);
                spriteBatch.Draw(YesButton, new Vector2(360, 506), Color.White);
                spriteBatch.Draw(NoButton, new Vector2(861, 516), Color.White);
                spriteBatch.End();
            }

            if (gameState == GameStates.victory)
            {
                spriteBatch.Begin();
                spriteBatch.Draw(Victory, new Vector2(0, 0), Color.White);
                spriteBatch.DrawString(font, "Finished stage 1 and the time left " + counter.ToString() + " Sec!", new Vector2(60, 370), Color.Yellow);
                spriteBatch.Draw(YesButton, new Vector2(360, 506), Color.White);
                spriteBatch.Draw(NoButton, new Vector2(861, 516), Color.White);
                spriteBatch.End();
            }

            if (gameState == GameStates.victory2)
            {
                spriteBatch.Begin();
                spriteBatch.Draw(Victory2, new Vector2(0, 0), Color.White);
                spriteBatch.Draw(continueTexture, new Vector2(460,600),Color.White);
                spriteBatch.DrawString(font, "Finished the stage and the time left " + counter.ToString() + " Sec!", new Vector2(40, 300), Color.LightGoldenrodYellow);
                spriteBatch.End();
            }

            if (gameState == GameStates.level2)
            {
                spriteBatch.Begin();

                spriteBatch.End();
            }

            base.Draw(gameTime);
        }
    }
}