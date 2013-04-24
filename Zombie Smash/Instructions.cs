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
    public class Instructions : Microsoft.Xna.Framework.DrawableGameComponent
    {
        private Rectangle window;
        private ContentManager Content;
        private SpriteBatch spriteBatch;

        Texture2D instructions;
        Texture2D soldier_derp;
        SpriteFont instructionTitle;
        SpriteFont info;

        public Instructions(Game game)
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
            instructions = Content.Load<Texture2D>("images/Keyboard");
            soldier_derp = Content.Load<Texture2D>("images/soldier_derp");
            instructionTitle = Content.Load<SpriteFont>("Fonts/SpriteFont1");
            info = Content.Load<SpriteFont>("Fonts/SpriteFont2");
        }


        public override void Update(GameTime gameTime)
        {

            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            Game.GraphicsDevice.Clear(Color.Aquamarine);

            spriteBatch.Begin();

            spriteBatch.DrawString(instructionTitle, "Instructions", new Vector2(140, 25), Color.Purple);

            spriteBatch.DrawString(info, "Helpful Tip: DON'T DIE!", new Vector2(50, 450), Color.Purple);

            spriteBatch.Draw(soldier_derp,
               new Vector2(410, 335),
               null,
               Color.White,
               0,
               new Vector2(0, 0),
               0.45f,
               SpriteEffects.None,
               0);

            spriteBatch.Draw(instructions,
               new Vector2(20, 175),
               null,
               Color.White,
               0,
               new Vector2(0, 0),
               0.28f,
               SpriteEffects.None,
               0);
            
            spriteBatch.End();
        }
    }
}