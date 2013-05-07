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
    public class Level2Manager : Microsoft.Xna.Framework.DrawableGameComponent {
        private Rectangle window;
        private ContentManager Content;
        private bool goToNextScreen = false;
        private bool gameOver = false;

        private List<Vector2> enemySpawnLocations;
        private MousePointer crosshair;
        private MouseState prevMS;

        private SpriteBatch spriteBatch;
        private UserControlledSprite soldier;
        private Texture2D door;
        private Texture2D jungle_grass;
        private Texture2D tree;

        private SpriteFont lives;
        private Texture2D lives_background;

        public Level2Manager(Game game)
            : base(game) {
            window = Game.Window.ClientBounds;
            Content = Game.Content;
        }


        public override void Initialize() {
            // TODO: Add your initialization code here
            base.Initialize();
        }


        protected override void LoadContent() {
            spriteBatch = new SpriteBatch(Game.GraphicsDevice);
            door = Content.Load<Texture2D>("Images/Door");
            jungle_grass = Content.Load<Texture2D>("Images/Jungle_Grass");
            tree = Content.Load<Texture2D>("Images/Tree");
            crosshair = new MousePointer(Content.Load<Texture2D>("images/crosshair"), new Point(40, 40),
                                            0, new Vector2(prevMS.X, prevMS.Y));
            soldier = new UserControlledSprite(Game.Content.Load<Texture2D>("images/soldier"),
                                            new Point(29, 81), 0, new Vector2(2.5f, 2.5f),
                                            new Vector2(window.Width / 2, window.Height / 2));

            prevMS = Mouse.GetState(); 
            enemySpawnLocations = new List<Vector2>();
            for (int yPosition = 0; yPosition < window.Height - 50; yPosition += 100) {
                enemySpawnLocations.Add(new Vector2(50, yPosition));
                enemySpawnLocations.Add(new Vector2(window.Width - 100, yPosition));
            }
            lives = Content.Load<SpriteFont>("Fonts/SpriteFont2");
            lives_background = Content.Load<Texture2D>("Images/lives_background_square");
        }


        public void initializeEnvironment() {
            EnvironmentManager.initializeSelf(window, spriteBatch);
            EnvironmentManager.initGameLevel(Content, soldier, enemySpawnLocations);
        }


        public override void Update(GameTime gameTime) {
            
            gameOver = EnvironmentManager.detectCollisions(soldier);
            if (EnvironmentManager.allZombiesAreDead()) {
                goToNextScreen = true;
            }

            crosshair.Update(gameTime, window);
            soldier.Update(gameTime, window);
            EnvironmentManager.Update(gameTime);

            //Spawn a bullet at crosshair position upon left click
            MouseState ms = Mouse.GetState();
            if (ms.LeftButton == ButtonState.Pressed && prevMS.LeftButton != ButtonState.Pressed) {
                Vector2 orientation = new Vector2(crosshair.position.X - soldier.position.X,
                                                    crosshair.position.Y - soldier.position.Y);
                Vector2 position = new Vector2(soldier.position.X + 10, soldier.position.Y + 15);
                EnvironmentManager.spawnBullet(Content, orientation, position);
            }
            prevMS = ms;
            base.Update(gameTime); 
        }


        public bool levelIsComplete() {
            return goToNextScreen;
        }


        public void resetLevel() {
            gameOver = false;
            goToNextScreen = false;
        }


        public bool playerIsDead() {
            return gameOver;
        }


        public override void Draw(GameTime gameTime) {
            spriteBatch.Begin();

            spriteBatch.Draw(jungle_grass,
                new Vector2(0, 0),
                null,
                Color.White,
                0,
                new Vector2(0, 0),
                1f,
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

            spriteBatch.Draw(tree,
                new Vector2(125, 100),
                null,
                Color.White,
                0,
                new Vector2(0, 0),
                0.5f,
                SpriteEffects.None,
                0);

            spriteBatch.Draw(tree,
                new Vector2(500, 100),
                null,
                Color.White,
                0,
                new Vector2(0, 0),
                0.5f,
                SpriteEffects.None,
                0);

            soldier.Draw(gameTime, spriteBatch);
            EnvironmentManager.Draw(gameTime);

            spriteBatch.Draw(lives_background,
               new Vector2(630, 15),
               null,
               Color.White,
               0,
               new Vector2(0, 0),
               1f,
               SpriteEffects.None,
               0);
            spriteBatch.DrawString(lives, "lives: " + EnvironmentManager.player_lives, new Vector2(640, 10), Color.Red);

            crosshair.Draw(gameTime, spriteBatch);
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}