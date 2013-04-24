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
    public class NameOfLevelOrScreen : Microsoft.Xna.Framework.DrawableGameComponent
    {
        private Rectangle window;
        private ContentManager Content;
        private SpriteBatch spriteBatch;

        public NameOfLevelOrScreen(Game game)
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
        }


        public override void Update(GameTime gameTime)
        {

            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin();


            spriteBatch.End();
        }
    }
}