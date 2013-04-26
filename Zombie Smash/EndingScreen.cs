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



namespace ZombieSmash
{
    public class EndingScreen : Microsoft.Xna.Framework.DrawableGameComponent
    {
        private Rectangle window;
        private ContentManager Content;
        private SpriteBatch spriteBatch;

        Texture2D soldier_talk;
        SpriteFont win_info;
        SpriteFont win_info2;

        MousePointer crosshair;
        int timer = 0;
        int timer2 = 0;
        bool show_click = false;
        bool load = false;
        bool goToNextLevel = false;

        public EndingScreen(Game game)
            : base(game)
        {
            window = Game.Window.ClientBounds;
            Content = Game.Content;
        }


        public override void Initialize()
        {
            // TODO: Add your initialization code here
            base.Initialize();
        }


        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(Game.GraphicsDevice);
            soldier_talk = Content.Load<Texture2D>("images/soldier_talk");
            win_info = Content.Load<SpriteFont>("Fonts/SpriteFont1");
            win_info2 = Content.Load<SpriteFont>("Fonts/SpriteFont2");
            crosshair = new MousePointer(Content.Load<Texture2D>("images/crosshair"), new Point(40, 40),
                                            0, new Vector2(0, 0));
        }


        public override void Update(GameTime gameTime)
        {
            timer += gameTime.ElapsedGameTime.Milliseconds;
            timer2 += gameTime.ElapsedGameTime.Milliseconds;

            if (timer > 400)
            {
                show_click = !show_click;
                timer = 0;
            }

            if (timer2 > 3000)
            {
                load = true;
                MouseState ms = Mouse.GetState();
                if (ms.LeftButton == ButtonState.Pressed)
                {
                    goToNextLevel = true;
                }
            }

            crosshair.Update(gameTime, window);

            base.Update(gameTime);
        }

        public bool advanceLevel()
        {
            return goToNextLevel;
        }

        public override void Draw(GameTime gameTime)
        {
            Game.GraphicsDevice.Clear(Color.Black);

            spriteBatch.Begin();

            spriteBatch.Draw(soldier_talk,
               new Vector2(160, 300),
               null,
               Color.White,
               0,
               new Vector2(0, 0),
               1.5f,
               SpriteEffects.None,
               0);

            spriteBatch.DrawString(win_info, "Well Done!", new Vector2(150, 25), Color.Purple);
            spriteBatch.DrawString(win_info, "U R Amazing!", new Vector2(100, 100), Color.Purple);

            if (load)
            {
                if (show_click)
                {
                    spriteBatch.DrawString(win_info2, "Click to go back to the main menu", new Vector2(75, 240), Color.White);
                }
            }
            crosshair.Draw(gameTime, spriteBatch);

            spriteBatch.End();
        }
    }
}