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
    public class Level2Manager : Microsoft.Xna.Framework.DrawableGameComponent {
        private bool goToNextScreen = false;
        private bool gameOver = false;
        private Rectangle window;
        
        private SpriteBatch spriteBatch;
        private UserControlledSprite soldier;

        public Level2Manager(Game game)
            : base(game) {
            window = Game.Window.ClientBounds;
        }


        public override void Initialize() {
            // TODO: Add your initialization code here
            base.Initialize();
        }


        protected override void LoadContent() {
            spriteBatch = new SpriteBatch(Game.GraphicsDevice);
            soldier = new UserControlledSprite(Game.Content.Load<Texture2D>("images/soldier"), 
                                            new Point(29, 81), 0, new Vector2(2.5f, 2.5f), 
                                            new Vector2(window.Width / 2, window.Height / 2));
        }


        public override void Update(GameTime gameTime) {
            
            gameOver = EnvironmentManager.detectCollisions(soldier);
            if (EnvironmentManager.allZombiesAreDead()) {
                goToNextScreen = true;
            }

            base.Update(gameTime); 
        }

        public bool levelIsComplete() {
            return goToNextScreen;
        }

        public bool playerIsDead() {
            return gameOver;
        }
    }
}