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
    public class LoadingScreen : Microsoft.Xna.Framework.DrawableGameComponent
    {
        private Rectangle window;
        private ContentManager Content;
        private SpriteBatch spriteBatch;

        Texture2D win;
        SpriteFont load_info;

        MousePointer crosshair;
        bool goToNextLevel = false;

        int timer = 0;
        bool show_next = false;

        int timer2 = 0;
        bool show_load = false;

        public LoadingScreen(Game game)
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
            win = Content.Load<Texture2D>("images/soldier_victory");
            load_info = Content.Load<SpriteFont>("Fonts/SpriteFont2");
            crosshair = new MousePointer(Content.Load<Texture2D>("images/crosshair"), new Point(40, 40),
                                            0, new Vector2(0, 0));
        }


        public override void Update(GameTime gameTime)
        {
            timer += gameTime.ElapsedGameTime.Milliseconds;
            timer2 += gameTime.ElapsedGameTime.Milliseconds;

            if (timer > 3000)
            {
                show_next = true;
                MouseState ms = Mouse.GetState();
                if (ms.LeftButton == ButtonState.Pressed) {
                    goToNextLevel = true;
                }
            }

            if (timer2 > 500)
            {
                show_load = !show_load;
                timer2 = 0;
            }

            crosshair.Update(gameTime, window);

            base.Update(gameTime);
        }

        public bool advanceLevel() {
            return goToNextLevel;
        }

        public void resetLoadingScreen() {
            timer = 0;
            timer2 = 0;
            show_next = false;
            goToNextLevel = false;
        }

        public override void Draw(GameTime gameTime)
        {
            Game.GraphicsDevice.Clear(Color.PowderBlue);

            spriteBatch.Begin();

            spriteBatch.Draw(win,
               new Vector2(-100, -15),
               null,
               Color.White,
               0,
               new Vector2(0, 0),
               1.5f,
               SpriteEffects.None,
               0);

            spriteBatch.DrawString(load_info, "Well Done!", new Vector2(525, 25), Color.Purple);

            if (show_next)
            {
                spriteBatch.DrawString(load_info, "Click to Begin", new Vector2(500, 300), Color.Purple);
            }
            else
            {
                if (show_load)
                {
                    spriteBatch.DrawString(load_info, "Now Loading...", new Vector2(500, 300), Color.Purple);
                }
            }

            crosshair.Draw(gameTime, spriteBatch);

            spriteBatch.End();
        }
    }
}