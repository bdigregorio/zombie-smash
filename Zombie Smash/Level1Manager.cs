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
        private bool goToNextLevel = false;
        private bool gameOver = false;
        private SpriteBatch spriteBatch;
        private Rectangle window;
        private List<Vector2> enemySpawnLocations;
        private MousePointer crosshair;
        private MouseState prevMS;

        private Texture2D door;
        private Texture2D road;
        private Texture2D fence;
        private Texture2D grass;
        private Texture2D windows;
        private UserControlledSprite soldier;

        public Level1Manager(Game game)
            : base(game) {
            window = Game.Window.ClientBounds;
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
            soldier = new UserControlledSprite(Game.Content.Load<Texture2D>("images/soldier"), 
                                            new Point(29, 81), 0, new Vector2(2.5f, 2.5f), 
                                            new Vector2(window.Width / 2, window.Height / 2));

            prevMS = Mouse.GetState();
            crosshair = new MousePointer(Game.Content.Load<Texture2D>("images/crosshair"), new Point(40, 40), 
                                            0, new Vector2(prevMS.X, prevMS.Y));
            enemySpawnLocations = new List<Vector2>();
            for (int yPosition = 0; yPosition < window.Height - 50; yPosition += 100) {
                enemySpawnLocations.Add(new Vector2(50, yPosition));
                enemySpawnLocations.Add(new Vector2(window.Width - 100, yPosition));
            }
            EnvironmentManager.initializeSelf(Game.Window.ClientBounds, spriteBatch);
            EnvironmentManager.initGameLevel(Game.Content, soldier, enemySpawnLocations);
        }


        public override void Update(GameTime gameTime) {
            // This code ends the level
            if (EnvironmentManager.allZombiesAreDead()) {
                goToNextLevel = true;
            }

            crosshair.Update(gameTime, Game.Window.ClientBounds);
            soldier.Update(gameTime, Game.Window.ClientBounds);
            EnvironmentManager.Update(gameTime);
            gameOver = EnvironmentManager.detectCollisions(soldier);

            //Spawn a bullet with Mouse position left click
            MouseState ms = Mouse.GetState();
            if (ms.LeftButton == ButtonState.Pressed && prevMS.LeftButton != ButtonState.Pressed) {
                Vector2 orientation = new Vector2(crosshair.position.X - soldier.position.X, 
                                                    crosshair.position.Y - soldier.position.Y);
                Vector2 position = new Vector2(soldier.position.X + 10, soldier.position.Y + 15);
                EnvironmentManager.spawnBullet(Game.Content, orientation, position);
            }
            prevMS = ms;

            base.Update(gameTime);
        }


        public bool levelIsComplete() {
            return goToNextLevel;
        }


        public bool playerIsDead() {
            return gameOver;    
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
            EnvironmentManager.Draw(gameTime);
            crosshair.Draw(gameTime, spriteBatch);
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}