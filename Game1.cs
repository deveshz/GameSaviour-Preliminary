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
using Microsoft.Xna.Framework.Net;
using Microsoft.Xna.Framework.Storage;

namespace Zephyr
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
       public GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        public Random rnd { get; private set; }
        AudioEngine audioEngine;
        WaveBank waveBank;
        SoundBank soundBank;
        Cue trackCue;
        Cue trackCue1;
        public int chances{ get; set;}
        public int saviourno { get; set; }
 
        
      
       
        enum GameState
        {
            Start,
            Menu,
            MenuEnter,
            Credits,
            Help,
            InGame1,
            InGame11,
            InGame2,
            InGame22,
            GameOver
        };
        GameState currentGameState = GameState.Start;

        SpriteManager spriteManager;
        SpriteManager1 spriteManager1;
        TitleMenu titleMenu;
        SelectMenu selectMenu;
        CreditsMenu creditsMenu;
        TrackManager trackManager;
        TrackManager1 trackManager1;
        LooseMenu looseMenu;
        Select enter;
        HelpMenu helpMenu;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            graphics.PreferredBackBufferWidth = 1200;
            graphics.PreferredBackBufferHeight = 700;
            TargetElapsedTime = new TimeSpan(0, 0, 0, 0, 150);
            rnd = new Random();
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
           
            spriteManager = new SpriteManager(this);
            Components.Add(spriteManager);
            spriteManager1 = new SpriteManager1(this);
            Components.Add(spriteManager1);
            titleMenu = new TitleMenu(this);
            Components.Add(titleMenu);
            selectMenu = new SelectMenu(this);
            Components.Add(selectMenu);
           creditsMenu = new CreditsMenu(this);
           Components.Add(creditsMenu);
           trackManager = new TrackManager(this);
           Components.Add(trackManager);
           trackManager1 = new TrackManager1(this);
           Components.Add(trackManager1);
           looseMenu = new LooseMenu(this);
           Components.Add(looseMenu);
           enter = new Select(this);
           Components.Add(enter);
           helpMenu = new HelpMenu(this);
           Components.Add(helpMenu);
 
 

           selectMenu.Enabled = false;
            selectMenu.Visible = false;
            titleMenu.Enabled = false;
            titleMenu.Visible = false;
            spriteManager.Enabled = false;
            spriteManager.Visible = false;
            spriteManager1.Enabled = false;
            spriteManager1.Visible = false;
            creditsMenu.Enabled = false;
            creditsMenu.Visible = false;
            trackManager.Enabled = false;
            trackManager.Visible = false;
            trackManager1.Enabled = false;
            trackManager1.Visible = false;
            looseMenu.Visible = false;
            looseMenu.Enabled = false;
            helpMenu.Visible = false;
            helpMenu.Enabled = false;
            enter.Visible = false;
            enter.Enabled = false;
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
            audioEngine = new AudioEngine(@"Content\Audio\GameAudio.xgs");
            waveBank = new WaveBank(audioEngine, @"Content\Audio\Wave Bank.xwb");
            soundBank = new SoundBank(audioEngine, @"Content\Audio\Sound Bank.xsb");
            trackCue1 = soundBank.GetCue("track");
            trackCue = soundBank.GetCue("start");
            trackCue.Play();
            trackCue1.Play();
            
           


            
            
          
          
            //saviour = Content.Load<Texture2D>(@"Images\saviour");

            // TODO: use this.Content to load your game content here
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
            switch (currentGameState)
            {
                case GameState.Start:
                    break;
                case GameState.Menu:
                    break;
                case GameState.MenuEnter:
                    break;
                case GameState.Credits:
                    break;
                case GameState.Help:
                    break;
                case GameState.InGame1:
                    break;
                case GameState.InGame11:
                    break;
                case GameState.InGame2:
                    break;
                case GameState.InGame22:
                    break;
                case GameState.GameOver:
                    break;
            }
            chances = trackManager.mdg8_rep + trackManager1.mdg8_rep;
            saviourno = enter.selectsaviour;
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();

            

            //If the Fade delays has dropped below zero, then it is time to 
            //fade in/fade out the image a little bit more.
           
           
         
           

          
           
            // TODO: Add your update logic here
            audioEngine.Update();
            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            switch (currentGameState)
            {
                case GameState.Start:

                    titleMenu.Enabled = true;
                    titleMenu.Visible = true;
                    if (titleMenu.g1state == true)
                    {
                        currentGameState = GameState.Menu;
                        selectMenu.Enabled = true;
                        selectMenu.Visible = true;
                        titleMenu.Enabled = false;
                        titleMenu.Visible = false;
                        trackManager.Visible = false;
                        trackManager.Enabled = false;
                        trackManager1.Visible = false;
                        trackManager1.Enabled = false;
                        looseMenu.Visible = false;
                        looseMenu.Enabled = false;
                        spriteManager.Visible = false;
                        spriteManager.Enabled = false;
                        spriteManager1.Visible = false;
                        spriteManager1.Enabled = false;
                        
                        enter.Visible = false;
                        enter.Enabled = false;
                        
                        trackCue1.Pause();
                       
                       
                    }
                    break;

                case GameState.Menu:
                    
                    if (selectMenu.g2state == true)
                    {
                     currentGameState = GameState.MenuEnter;
                    
                     selectMenu.Enabled = false;
                     selectMenu.Visible = false;
                     creditsMenu.Enabled = false;
                     creditsMenu.Visible = false;
                     selectMenu.g2state = false;
                     spriteManager.Enabled = false;
                     spriteManager.Visible = false;
                     spriteManager1.Enabled = false;
                     spriteManager1.Visible = false;
                     trackManager.Visible = false;
                     trackManager.Enabled = false;
                     trackManager1.Visible = false;
                     trackManager1.Enabled = false;
                     looseMenu.Visible = false;
                     looseMenu.Enabled = false;
                     enter.Visible = true;
                     enter.Enabled = true;
                        helpMenu.Visible = false;
                        helpMenu.Enabled = false;
                     trackCue.Pause();
                     trackCue1.Resume();
                   
                     
                       
            
                    }
                    else if (selectMenu.g4state == true)
                    {
                        currentGameState = GameState.Credits;
                        selectMenu.Enabled = false;
                        selectMenu.Visible = false;
                        trackManager.Visible = false;
                        trackManager.Enabled = false;
                        trackManager1.Visible = false;
                        trackManager1.Enabled = false;
                        spriteManager1.Enabled = false;
                        spriteManager1.Visible = false;
           
                        spriteManager.Enabled = false;
                        spriteManager.Visible = false;
                        selectMenu.g4state = false;
                        creditsMenu.Enabled = true;
                        creditsMenu.Visible = true;
                        looseMenu.Visible = false;
                        looseMenu.Enabled = false;
                        helpMenu.Visible = false;
                        helpMenu.Enabled = false;
                        
                    }
                    else if (selectMenu.helpstate == true)
                    {
                        currentGameState = GameState.Help;
                        selectMenu.Enabled = false;
                        selectMenu.Visible = false;
                        trackManager.Visible = false;
                        trackManager.Enabled = false;
                        trackManager1.Visible = false;
                        trackManager1.Enabled = false;
                        spriteManager1.Enabled = false;
                        spriteManager1.Visible = false;

                        spriteManager.Enabled = false;
                        spriteManager.Visible = false;
                        selectMenu.g4state = false;
                        creditsMenu.Enabled = false;
                        creditsMenu.Visible = false;
                        looseMenu.Visible = false;
                        looseMenu.Enabled = false;
                        helpMenu.Visible = true;
                        helpMenu.Enabled = true;
                    }


                    else if (selectMenu.g3state == true)

                        Exit();
                    break;
                case GameState.MenuEnter:
                    if (enter.enter)
                    {
                        currentGameState = GameState.InGame1;
                        selectMenu.Enabled = false;
                        selectMenu.Visible = false;
                        creditsMenu.Enabled = false;
                        creditsMenu.Visible = false;
                        selectMenu.g2state = false;
                        spriteManager.Enabled = false;
                        spriteManager.Visible = false;
                        spriteManager1.Enabled = false;
                        spriteManager1.Visible = false;
                        trackManager.Visible = true;
                        trackManager.Enabled = true;
                        trackManager1.Visible = false;
                        trackManager1.Enabled = false;
                        looseMenu.Visible = false;
                        looseMenu.Enabled = false;
                        enter.Visible = false;
                        enter.Enabled = false;
                        helpMenu.Visible = false;
                        helpMenu.Enabled = false;
                    }
                    break;
                case GameState.InGame1:
                    if (trackManager.isOver)
                    {
                        currentGameState = GameState.InGame11;

                        selectMenu.Enabled = false;
                        selectMenu.Visible = false;
                        creditsMenu.Enabled = false;
                        creditsMenu.Visible = false;
                        selectMenu.g2state = false;
                        looseMenu.Visible = false;
                        looseMenu.Enabled = false;
                        trackManager.Visible = false;
                        trackManager.Enabled = false;
                        spriteManager.Enabled = false;
                        spriteManager.Visible = false;
                        spriteManager1.Enabled = false;
                        spriteManager1.Visible = false;
                        trackManager1.Visible = true;
                        trackManager1.Enabled = true;
                        helpMenu.Visible = false;
                        helpMenu.Enabled = false;
                        trackCue.Pause();
                        trackCue1.Resume();
                       
                    }
                    else if (trackManager.loose)
                    {
                        currentGameState = GameState.GameOver;
                        selectMenu.Enabled = false;
                        selectMenu.Visible = false;
                        creditsMenu.Enabled = false;
                        creditsMenu.Visible = false;
                        selectMenu.g2state = false;

                        trackManager.Visible = false;
                        trackManager.Enabled = false;
                        trackManager1.Visible = false;
                        trackManager1.Enabled = false;
                        spriteManager.Enabled = false;
                        spriteManager.Visible = false;
                        spriteManager1.Enabled = false;
                        spriteManager1.Visible = false;
                        helpMenu.Visible = false;
                        helpMenu.Enabled = false;
                        looseMenu.Visible = true;
                        looseMenu.Enabled = true;

                    }
                    break;
                case GameState.InGame11:
                    if (trackManager1.isOver)
                    {
                        currentGameState = GameState.InGame2;
                        spriteManager.Enabled = true;
                        spriteManager.Visible = true;
                        selectMenu.Enabled = false;
                        selectMenu.Visible = false;
                        creditsMenu.Enabled = false;
                        creditsMenu.Visible = false;
                        helpMenu.Enabled = false;
                        helpMenu.Visible = false;
                        selectMenu.g2state = false;
                        looseMenu.Visible = false;
                        looseMenu.Enabled = false;
                        trackManager.Visible = false;
                        trackManager.Enabled = false;
                      
                        trackManager1.Visible = false;
                        trackManager1.Enabled = false;
                        spriteManager1.Enabled = false;
                        spriteManager1.Visible = false;
                        trackCue.Resume();
                        trackCue1.Pause();

                    }
                    else if (trackManager1.loose)
                    {
                        currentGameState = GameState.GameOver;
                        selectMenu.Enabled = false;
                        selectMenu.Visible = false;
                        creditsMenu.Enabled = false;
                        creditsMenu.Visible = false;
                        selectMenu.g2state = false;
                        helpMenu.Enabled = false;
                        helpMenu.Visible = false;

                        trackManager.Visible = false;
                        trackManager.Enabled = false;
                        trackManager1.Visible = false;
                        trackManager1.Enabled = false;
                        spriteManager.Enabled = false;
                        spriteManager.Visible = false;
                        spriteManager1.Enabled = false;
                        spriteManager1.Visible = false;

                        looseMenu.Visible = true;
                        looseMenu.Enabled = true;

                    }
                    break;
                case GameState.InGame2:

                    if (spriteManager.gstate == true)
                    {
                        currentGameState = GameState.Menu;

                        spriteManager.Enabled = false;
                        spriteManager.Visible = false;
                        helpMenu.Enabled = false;
                        helpMenu.Visible = false;
                        trackManager.Enabled = false;
                       trackManager.Visible = false;
                       trackManager1.Enabled = false;
                       trackManager1.Visible = false;
                        spriteManager1.Enabled = false;
                        spriteManager1.Visible = false;
                        creditsMenu.Enabled = false;
                        creditsMenu.Visible = false;
                        looseMenu.Visible = false;
                        looseMenu.Enabled = false;
                        spriteManager.gstate = false;
                        selectMenu.Enabled = true;
                        selectMenu.Visible = true;

                      




                    }
                    if (spriteManager.go == true)
                    {
                        currentGameState = GameState.InGame22;

                        spriteManager.Enabled = false;
                        spriteManager.Visible = false;
                        spriteManager1.Enabled = true;
                        spriteManager1.Visible = true;
                        creditsMenu.Enabled = false;
                        creditsMenu.Visible = false;
                        helpMenu.Enabled = false;
                        helpMenu.Visible = false;
                        looseMenu.Visible = false;
                        looseMenu.Enabled = false;
                        spriteManager.gstate = false;
                        selectMenu.Enabled = false;
                        selectMenu.Visible = false;
                        trackManager.Enabled = false;
                        trackManager.Visible = false;
                        trackManager1.Enabled = false;
                        trackManager1.Visible = false;

                    }
                    else if (spriteManager.loose)
                    {
                        currentGameState = GameState.GameOver;
                        spriteManager.Enabled = false;
                        spriteManager.Visible = false;
                        spriteManager1.Enabled = false;
                        spriteManager1.Visible = false;
                        creditsMenu.Enabled = false;
                        creditsMenu.Visible = false;
                        helpMenu.Enabled = false;
                        helpMenu.Visible = false;
                        looseMenu.Visible = true;
                        looseMenu.Enabled = true;
                        spriteManager.gstate = false;
                        selectMenu.Enabled = false;
                        selectMenu.Visible = false;
                        trackManager.Enabled = false;
                        trackManager.Visible = false;
                        trackManager1.Enabled = false;
                        trackManager1.Visible = false;
                    }
                    break;
                case GameState.InGame22:

                    if (spriteManager1.gstate == true)
                    {
                        currentGameState = GameState.Menu;

                        spriteManager.Enabled = false;
                        spriteManager.Visible = false;
                        creditsMenu.Enabled = false;
                        creditsMenu.Visible = false;
                        helpMenu.Enabled = false;
                        helpMenu.Visible = false;
                        looseMenu.Visible = false;
                        looseMenu.Enabled = false;
                        spriteManager1.gstate = false;
                        spriteManager1.Enabled = false;
                        spriteManager1.Visible = false;
                        trackManager.Enabled = false;
                        trackManager.Visible = false;
                        trackManager1.Enabled = false;
                        trackManager1.Visible = false;
                        selectMenu.Enabled = true;
                        selectMenu.Visible = true;
                        trackCue1.Pause();





                    }
                    else if (spriteManager1.loose)
                    {
                        currentGameState = GameState.GameOver;
                        spriteManager.Enabled = false;
                        spriteManager.Visible = false;
                        spriteManager1.Enabled = false;
                        spriteManager1.Visible = false;
                        creditsMenu.Enabled = false;
                        creditsMenu.Visible = false;
                        helpMenu.Enabled = false;
                        helpMenu.Visible = false;
                        looseMenu.Visible = true;
                        looseMenu.Enabled = true;
                        spriteManager.gstate = false;
                        selectMenu.Enabled = false;
                        selectMenu.Visible = false;
                        trackManager.Enabled = false;
                        trackManager.Visible = false;
                        trackManager1.Enabled = false;
                        trackManager1.Visible = false;
                    }
                    break;

                case GameState.Credits:
                    
                    if (creditsMenu.cstate == true)
                    {
                        currentGameState = GameState.Menu;
                    
                        creditsMenu.Enabled = false;
                        creditsMenu.Visible = false;
                        spriteManager.Enabled = false;
                        spriteManager.Visible = false;
                        spriteManager1.Enabled = false;
                        spriteManager1.Visible = false;
                        trackManager.Enabled = false;
                        trackManager.Visible = false;
                        trackManager1.Enabled = false;
                        trackManager1.Visible = false;
                        creditsMenu.cstate = false;
                        looseMenu.Visible = false;
                        looseMenu.Enabled = false;
                        selectMenu.Enabled = true;
                        selectMenu.Visible = true;
                        helpMenu.Visible = false;
                        helpMenu.Enabled = false;
                       
                        
                    }
                    break;
                case GameState.Help:

                    if (helpMenu.back == true)
                    {
                        currentGameState = GameState.Menu;

                        creditsMenu.Enabled = false;
                        creditsMenu.Visible = false;
                        spriteManager.Enabled = false;
                        spriteManager.Visible = false;
                        spriteManager1.Enabled = false;
                        spriteManager1.Visible = false;
                        trackManager.Enabled = false;
                        trackManager.Visible = false;
                        trackManager1.Enabled = false;
                        trackManager1.Visible = false;
                        helpMenu.back = false;
                        selectMenu.helpstate = false;
                        looseMenu.Visible = false;
                        looseMenu.Enabled = false;
                        selectMenu.Enabled = true;
                        selectMenu.Visible = true;
                        helpMenu.Visible = false;
                        helpMenu.Enabled = false;
                     
                     

                    }
                    break;
                
                // TODO: Add your drawing code here
                case GameState.GameOver:
                    if (looseMenu.again)
                    {
                        currentGameState = GameState.MenuEnter;
                        selectMenu.Enabled = false;
                        selectMenu.Visible = false;
                        creditsMenu.Enabled = false;
                        creditsMenu.Visible = false;
                        selectMenu.g2state = false;
                        spriteManager.Enabled = false;
                        spriteManager.Visible = false;
                        spriteManager1.Enabled = false;
                        spriteManager1.Visible = false;
                        trackManager.Visible = false;
                        trackManager.Enabled = false;
                        trackManager1.Visible = false;
                        trackManager1.Enabled = false;
                        looseMenu.Visible = false;
                        looseMenu.Enabled = false;
                        enter.Visible = true;
                        enter.Enabled = true;
                        trackManager1.isOver = false;
                        trackManager.isOver = false;
                        spriteManager.go = false;
                        trackManager.loose = false;
                        trackManager1.loose = false;
                        spriteManager.loose = false;

                  
                    }
                    break;
            }
            base.Draw(gameTime);
        }

    }
}
