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
    public class Select : Microsoft.Xna.Framework.DrawableGameComponent
    {
        SpriteBatch spriteBatch;
        SpriteFont text;
        public bool enter = false;
        public int selectsaviour;
        Texture2D saviour1;
        Texture2D saviour2;
        Texture2D saviour3;
        Texture2D saviour4;
        Rectangle arrowRect;

        Vector2 arr_position;
        MouseState prevMouseState;

        Texture2D goal1;
        Texture2D goal2;
        Texture2D goal3;
        Texture2D goal4;
        Texture2D goal5;
        Texture2D goal6;
        Texture2D goal7;
        Texture2D arrow;
        Texture2D highlight;
        Texture2D highlight1;

      Rectangle saviour1rect = new Rectangle(200,200,150,50);
      Rectangle highlightrect = new Rectangle(194, 196, 150, 50);
      Rectangle saviour2rect = new Rectangle(450, 200, 150, 50);
      Rectangle saviour3rect = new Rectangle(700, 200, 150, 50);
      Rectangle saviour4rect = new Rectangle(950, 200, 150, 50);

      Rectangle goal1rect = new Rectangle(105, 450, 50, 50);
      Rectangle goal2rect = new Rectangle(262, 450, 50, 50);
      Rectangle goal3rect = new Rectangle(414, 450, 50, 50);
      Rectangle goal4rect = new Rectangle(569, 450, 50, 50);
      Rectangle goal5rect = new Rectangle(725, 450, 50, 50);
      Rectangle goal6rect = new Rectangle(882, 450, 50, 50);
      Rectangle goal7rect = new Rectangle(1036, 450, 50, 50);


      bool yes = false;
      bool intersect = false;


      bool yes1 = false;
      bool intersect1 = false;

      bool a = false;
      bool b = false;

     
        public Select(Game game)
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
            saviour1 = Game.Content.Load<Texture2D>(@"Images\saviour1");
            saviour2 = Game.Content.Load<Texture2D>(@"Images\saviour2");
            saviour3 = Game.Content.Load<Texture2D>(@"Images\saviour3");
            saviour4 = Game.Content.Load<Texture2D>(@"Images\saviour4");

            goal1 = Game.Content.Load<Texture2D>(@"Images\mdg1");
            goal2 = Game.Content.Load<Texture2D>(@"Images\mdg2");
            goal3 = Game.Content.Load<Texture2D>(@"Images\mdg3");
            goal4 = Game.Content.Load<Texture2D>(@"Images\mdg4");
            goal5 = Game.Content.Load<Texture2D>(@"Images\mdg5");
            goal6 = Game.Content.Load<Texture2D>(@"Images\mdg6");
            goal7 = Game.Content.Load<Texture2D>(@"Images\mdg7");
            arrow = Game.Content.Load<Texture2D>(@"Images\arrow");
            text = Game.Content.Load<SpriteFont>(@"Fonts\Snap");
            highlight = Game.Content.Load<Texture2D>(@"Images\highlight");
            highlight1 = Game.Content.Load<Texture2D>(@"Images\poverty");
            base.LoadContent();
        }
        
        /// <summary>
        /// Allows the game component to update itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        public override void Update(GameTime gameTime)
        {
            // TODO: Add your update code here
            MouseState mouseState = Mouse.GetState();
            if (mouseState.X != prevMouseState.X ||
            mouseState.Y != prevMouseState.Y)
            {
                arr_position = new Vector2(mouseState.X, mouseState.Y);
                prevMouseState = mouseState;
            }
            arrowRect = new Rectangle((int)arr_position.X, (int)arr_position.Y, 32, 32);
            if (arrowRect.Intersects(saviour1rect)&& mouseState.LeftButton == ButtonState.Pressed)
            {
                yes = true;
            }
            if (arrowRect.Intersects(goal1rect) && mouseState.LeftButton == ButtonState.Pressed)
            {
                yes1 = true;
            }
            KeyboardState aKeyboard = Keyboard.GetState();
            if (aKeyboard.IsKeyDown(Keys.Enter) && a && b)
                enter = true;

            base.Update(gameTime);
        }
        public override void Draw(GameTime gameTime)
        {
            // TODO: Add your update code here
            GraphicsDevice.Clear(Color.MidnightBlue);
            spriteBatch.Begin();
            spriteBatch.Draw(saviour1, saviour1rect, Color.White);
            spriteBatch.Draw(saviour2, new Vector2(450, 200), Color.White);
            spriteBatch.Draw(saviour3, new Vector2(700, 200), Color.White);
            spriteBatch.Draw(saviour4, new Vector2(950, 200), Color.White);

            spriteBatch.Draw(goal1, new Vector2(105, 450), Color.White);
            spriteBatch.Draw(goal2, new Vector2(262, 450), Color.White);
            spriteBatch.Draw(goal3, new Vector2(414, 450), Color.White);
            spriteBatch.Draw(goal4, new Vector2(569, 450), Color.White);

            spriteBatch.Draw(goal5, new Vector2(725, 450), Color.White);
            spriteBatch.Draw(goal6, new Vector2(882, 450), Color.White);
            spriteBatch.Draw(goal7, new Vector2(1036, 450), Color.White);
            spriteBatch.DrawString(text, " SELECT YOUR AVATAR , MILLENIUM DEVELOPMENT GOAL TO ACHIEVE & PRESS ENTER",
new Vector2(5, 50), Color.Orange, 0, new Vector2(0, 0),
1, SpriteEffects.None, 1);
            spriteBatch.DrawString(text, " -------------------------------------------------------------------------------------------------------------------------------------------- ",
new Vector2(5, 60), Color.Orange, 0, new Vector2(0, 0),
1, SpriteEffects.None, 1);

            if (arrowRect.Intersects(goal2rect) || arrowRect.Intersects(goal3rect) || arrowRect.Intersects(goal4rect) || arrowRect.Intersects(goal5rect) || arrowRect.Intersects(goal6rect) || arrowRect.Intersects(goal7rect))
            {
                spriteBatch.DrawString(text, " -----------------LOCKED IN DEMO ---------------------",
new Vector2(400, 550), Color.Orange, 0, new Vector2(0, 0),
1, SpriteEffects.None, 1);

            }
            if (arrowRect.Intersects(saviour2rect))
                selectsaviour = 2;
           else if (arrowRect.Intersects(saviour3rect))
                selectsaviour = 3;
            else if (arrowRect.Intersects(saviour4rect))
                selectsaviour = 4;
          





            if (arr_position.X>200 && arr_position.X<350 && arr_position.Y>200 && arr_position.Y< 250 && yes)
            {
                intersect = true;
            }
            if (arr_position.X > 105 && arr_position.X < 155 && arr_position.Y > 450 && arr_position.Y < 500 && yes1)
            {
                intersect1 = true;
            }
            if (intersect && yes)
            {
                spriteBatch.Draw(highlight, highlightrect, Color.White);
                a = true;
            }

            if (intersect1 && yes1)
            {
                spriteBatch.Draw(highlight1, new Vector2(10, 500), Color.White);
                b = true;
            }
            spriteBatch.Draw(arrow, arrowRect, Color.White);

            spriteBatch.End();


            base.Draw(gameTime);
        }

    }
}