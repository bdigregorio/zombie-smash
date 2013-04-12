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


namespace ZombieSmash {
    /// <summary>
    /// This is a game component that implements IUpdateable.
    /// </summary>
    public class Level1Manager : Microsoft.Xna.Framework.DrawableGameComponent {
        private bool goToNextScreen = false;
        SpriteBatch spriteBatch;

        Texture2D door;
        Texture2D road;
        Texture2D fence;
        Texture2D grass;
        Texture2D windows;
        UserControlledSprite soldier;
        AutomatedSprite zombie;

        public Level1Manager(Game game)
            : base(game) {
        }


        public override void Initialize() {
            // TODO: Add your initialization code here

            base.Initialize();
        }


        protected override void LoadContent() {
            spriteBatch = new SpriteBatch(Game.GraphicsDevice);
            door = Game.Content.Load<Texture2D>("Images/Door");
            road = Game.Content.Load<Texture2D>("Images/Road");
            fence = Game.Content.Load<Texture2D>("Images/Fence");
            grass = Game.Content.Load<Texture2D>("Images/Grass");
            windows = Game.Content.Load<Texture2D>("Images/Windows");
            soldier = new UserControlledSprite(Game.Content.Load<Texture2D>("images/soldier"), new Point(29, 81), 0);
            zombie = new AutomatedSprite(Game.Content.Load<Texture2D>("Images/zombie_sprite"), new Point(50, 50), 0, soldier, new Vector2(2, 2));
        }


        public override void Update(GameTime gameTime) {
            // TODO: Add your update code here

            if (false /* all zombies are dead condition here */) {
                goToNextScreen = true;
            }
            soldier.Update(gameTime, Game.Window.ClientBounds);
            zombie.Update(gameTime, Game.Window.ClientBounds);

            base.Update(gameTime);
        }


        public bool isFinished() {
            return goToNextScreen;
        }


        public override void Draw(GameTime gameTime) {
            spriteBatch.Begin();
            spriteBatch.Draw(windows,
                new Vector2(-60, -100),
                null,
                Color.White,
                0,
                new Vector2(0, 0),
                0.8f,
                SpriteEffects.None,
                0);

            spriteBatch.Draw(windows,
                new Vector2(110, -100),
                null,
                Color.White,
                0,
                new Vector2(0, 0),
                0.8f,
                SpriteEffects.None,
                0);

            spriteBatch.Draw(windows,
                new Vector2(440, -100),
                null,
                Color.White,
                0,
                new Vector2(0, 0),
                0.8f,
                SpriteEffects.None,
                0);

            spriteBatch.Draw(windows,
                new Vector2(610, -100),
                null,
                Color.White,
                0,
                new Vector2(0, 0),
                0.8f,
                SpriteEffects.None,
                0);

            spriteBatch.Draw(door,
                new Vector2(350, 0),
                null,
                Color.White,
                0,
                new Vector2(0, 0),
                0.1f,
                SpriteEffects.None,
                0);



            spriteBatch.Draw(road,
                new Vector2(0, 100),
                null,
                Color.White,
                0,
                new Vector2(0, 0),
                0.5f,
                SpriteEffects.None,
                0);

            spriteBatch.Draw(road,
                new Vector2(207, 100),
                null,
                Color.White,
                0,
                new Vector2(0, 0),
                0.5f,
                SpriteEffects.None,
                0);

            spriteBatch.Draw(road,
                new Vector2(414, 100),
                null,
                Color.White,
                0,
                new Vector2(0, 0),
                0.5f,
                SpriteEffects.None,
                0);

            spriteBatch.Draw(road,
                new Vector2(621, 100),
                null,
                Color.White,
                0,
                new Vector2(0, 0),
                0.5f,
                SpriteEffects.None,
                0);

            spriteBatch.Draw(grass,
               new Vector2(275, 310),
               null,
               Color.White,
               0,
               new Vector2(0, 0),
               0.2f,
               SpriteEffects.None,
               0);

            spriteBatch.Draw(grass,
               new Vector2(0, 425),
               null,
               Color.White,
               0,
               new Vector2(0, 0),
               0.2f,
               SpriteEffects.None,
               0);

            spriteBatch.Draw(grass,
               new Vector2(220, 425),
               null,
               Color.White,
               0,
               new Vector2(0, 0),
               0.2f,
               SpriteEffects.None,
               0);

            spriteBatch.Draw(grass,
               new Vector2(440, 425),
               null,
               Color.White,
               0,
               new Vector2(0, 0),
               0.2f,
               SpriteEffects.None,
               0);

            spriteBatch.Draw(grass,
               new Vector2(660, 425),
               null,
               Color.White,
               0,
               new Vector2(0, 0),
               0.2f,
               SpriteEffects.None,
               0);

            spriteBatch.Draw(fence,
               new Vector2(0, 300),
               null,
               Color.White,
               0,
               new Vector2(0, 0),
               0.2f,
               SpriteEffects.None,
               0);

            spriteBatch.Draw(fence,
               new Vector2(100, 300),
               null,
               Color.White,
               0,
               new Vector2(0, 0),
               0.2f,
               SpriteEffects.None,
               0);

            spriteBatch.Draw(fence,
               new Vector2(450, 300),
               null,
               Color.White,
               0,
               new Vector2(0, 0),
               0.2f,
               SpriteEffects.None,
               0);

            spriteBatch.Draw(fence,
               new Vector2(600, 300),
               null,
               Color.White,
               0,
               new Vector2(0, 0),
               0.2f,
               SpriteEffects.None,
               0);

            soldier.Draw(gameTime, spriteBatch);
            zombie.Draw(gameTime, spriteBatch);
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}