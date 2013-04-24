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
    /// <summary>
    /// This is a game component that implements IUpdateable.
    /// </summary>
    public class GameOverScreen : Microsoft.Xna.Framework.DrawableGameComponent
    {
        Rectangle window;
        MousePointer crosshair;
        SpriteBatch spriteBatch;
        ContentManager Content;
        Texture2D sad_soldier;
        Texture2D zombie_win;
        SpriteFont game_over;

        public GameOverScreen(Game game)
            : base(game)
        {
            window = Game.Window.ClientBounds;
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

        /// <summary>
        /// Allows the game component to update itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        /// 

        protected override void LoadContent()
        {
            Content = Game.Content;
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(Game.GraphicsDevice);

            // TODO: use this.Content to load your game content here
            sad_soldier = Content.Load<Texture2D>("images/sad_soldier");
            zombie_win = Content.Load<Texture2D>("images/zombie_win");
            game_over = Content.Load<SpriteFont>("Fonts/SpriteFont3");
            crosshair = new MousePointer(Content.Load<Texture2D>("images/crosshair"), new Point(40, 40),
                                0, new Vector2(0, 0));
        }

        public override void Update(GameTime gameTime)
        {
            crosshair.Update(gameTime, window);
        }

        public override void Draw(GameTime gameTime)
        {

            // TODO: Add your drawing code here
            spriteBatch.Begin();

            spriteBatch.Draw(zombie_win,
               new Vector2(50, 175),
               null,
               Color.White,
               0,
               new Vector2(0, 0),
               2.3f,
               SpriteEffects.None,
               0);

            spriteBatch.Draw(sad_soldier,
               new Vector2(475, 275),
               null,
               Color.White,
               0,
               new Vector2(0, 0),
               1.5f,
               SpriteEffects.None,
               0);

            spriteBatch.DrawString(game_over, "GAME OVER", new Vector2(65, 10), Color.White);
            crosshair.Draw(gameTime, spriteBatch);

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}