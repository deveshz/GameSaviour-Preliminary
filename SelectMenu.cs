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
    /// This is a game component that implements IUpdateable.
    /// </summary>
    public class SelectMenu : Microsoft.Xna.Framework.DrawableGameComponent
    {
        SpriteBatch spriteBatch;
        SpriteFont text;
        Texture2D newgame;
        Texture2D help;
        Texture2D credits;
        Texture2D quit;

        Rectangle newgameRect;
        Rectangle helpRect;
        Rectangle creditsRect;
        Rectangle quitRect;

        Texture2D arrow;
        Rectangle arrowRect;

        Vector2 arr_position;
        MouseState prevMouseState;

         public bool g2state = false;
         public bool g3state = false;
         public bool g4state = false;

       public  bool helpstate = false;
        public SelectMenu(Game game)
            : base(game)
        {
            // TODO: Construct any child components here
        }

        /// <summary>
        /// Allows the game component to perform any initialization it needs to before starting
        /// to run.  This is where it can query for any required services and load content.
        /// </summary>
        public override void Initialize()
        {
            // TODO: Add your initialization code here

            base.Initialize();
        }
        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(Game.GraphicsDevice);
            newgame = Game.Content.Load<Texture2D>(@"Images\newgame");
            help = Game.Content.Load<Texture2D>(@"Images\help");
            credits = Game.Content.Load<Texture2D>(@"Images\credits");
            quit = Game.Content.Load<Texture2D>(@"Images\quit");
            arrow = Game.Content.Load<Texture2D>(@"Images\arrow");
            text = Game.Content.Load<SpriteFont>(@"Fonts\Snap");
            base.LoadContent();
        }
        /// <summary>
        /// Allows the game component to update itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        public override void Update(GameTime gameTime)
        {
            // TODO: Add your update code here
            newgameRect = new Rectangle(40, 200, 250, 300);
            helpRect = new Rectangle(330, 200, 250, 300);
            arrowRect = new Rectangle((int)arr_position.X, (int)arr_position.Y, 32, 32);
            creditsRect = new Rectangle(620, 200, 250, 300);
            quitRect = new Rectangle(910, 200, 250, 300);
            MouseState mouseState = Mouse.GetState();
            if (mouseState.X != prevMouseState.X ||
            mouseState.Y != prevMouseState.Y)
            {
                arr_position = new Vector2(mouseState.X, mouseState.Y);
                prevMouseState = mouseState;
            }
            arrowRect = new Rectangle((int)arr_position.X, (int)arr_position.Y, 32, 32);
 
            if (arrowRect.Intersects(newgameRect) && mouseState.LeftButton == ButtonState.Pressed)
            {
                newgameRect.Inflate(10, 10);
                g2state = true;

            }
             else if (arrowRect.Intersects(newgameRect))
            {
                newgameRect.Inflate(10, 10);
            }
            if (arrowRect.Intersects(helpRect) && mouseState.LeftButton == ButtonState.Pressed)
            {
                helpRect.Inflate(10, 10);
                helpstate = true;

            }
            else  if (arrowRect.Intersects(helpRect))
            {
                helpRect.Inflate(10, 10);
            }
            if (arrowRect.Intersects(creditsRect) && mouseState.LeftButton == ButtonState.Pressed)
            {
                creditsRect.Inflate(10, 10);
                g4state = true;
            }

             else if (arrowRect.Intersects(creditsRect))
            {
               creditsRect.Inflate(10, 10);
            }

            if (arrowRect.Intersects(quitRect) && mouseState.LeftButton == ButtonState.Pressed)
            {

                g3state = true;

            } 
            else if (arrowRect.Intersects(quitRect))
            {
                quitRect.Inflate(10, 10);
            }

            base.Update(gameTime);
        }
        public override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.MidnightBlue);
            spriteBatch.Begin();
            spriteBatch.Draw(newgame, newgameRect, Color.White);
            spriteBatch.Draw(help, helpRect, Color.White);
            spriteBatch.Draw(credits, creditsRect, Color.White);
            spriteBatch.Draw(quit, quitRect, Color.White);
            spriteBatch.Draw(arrow, arrowRect, Color.White);
            if (arrowRect.Intersects(newgameRect))
            {
                newgameRect.Inflate(10, 10);
                spriteBatch.DrawString(text, "Start your journey Saviour",
new Vector2(550, 600), Color.Green, 0, new Vector2(0, 0),
1, SpriteEffects.None, 1);
            }

            else if (arrowRect.Intersects(creditsRect))
            {
                spriteBatch.DrawString(text, "Know the Developers!",
new Vector2(550, 600), Color.Orange, 0, new Vector2(0, 0),
1, SpriteEffects.None, 1);
            }

            else if (arrowRect.Intersects(helpRect))
            {
                
                spriteBatch.DrawString(text, "Get help about the game",
new Vector2(550, 600), Color.Yellow, 0, new Vector2(0, 0),
1, SpriteEffects.None, 1);
            }

            else if (arrowRect.Intersects(quitRect))
            {
                spriteBatch.DrawString(text, "Do not want to play ! Quit",
new Vector2(550, 600), Color.White, 0, new Vector2(0, 0),
1, SpriteEffects.None, 1);
                quitRect.Inflate(10, 10);
            }
            else
            {
                spriteBatch.DrawString(text, " WELCOME ! SAVIOUR - PLAY AND SAVE THE WORLD",
new Vector2(350, 100), Color.White, 0, new Vector2(0, 0),
1, SpriteEffects.None, 1);
            }
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}