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
        SpriteBatch spriteBatch;

        public Level2Manager(Game game)
            : base(game) {


        }


        public override void Initialize() {
            // TODO: Add your initialization code here

            base.Initialize();
        }


        protected override void LoadContent() {
            spriteBatch = new SpriteBatch(Game.GraphicsDevice);
        }


        public override void Update(GameTime gameTime) {
            // TODO: Add your update code here

            if (false /* all zombies are dead condition here */) {
                goToNextScreen = true;
            }

            base.Update(gameTime);
        }

        public bool isFinished() {
            return goToNextScreen;
        }
    }
}