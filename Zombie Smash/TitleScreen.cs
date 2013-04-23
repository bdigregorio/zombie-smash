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

namespace ZombieSmash{
    public class TitleScreen : Microsoft.Xna.Framework.DrawableGameComponent {
        private ContentManager Content;
        private Rectangle window;

        private SpriteFont my_font;
        private SpriteFont instructions;
        private bool show_instructions = false;
        private int timer = 0;
        
        private SpriteBatch spriteBatch;
        private MousePointer crosshair;
        private Texture2D soldier;
        private Texture2D zombie;
        private Texture2D road;
        private Texture2D buildings;
        private Texture2D clouds;
        private Texture2D debris;

        public TitleScreen(Game game) 
            : base (game) {
            Content = Game.Content;
            window = Game.Window.ClientBounds;
        }

        public override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        protected override void LoadContent()
        {
            // TODO: use this.Content to load your game content here
            spriteBatch = new SpriteBatch(Game.GraphicsDevice);
            soldier = Content.Load<Texture2D>("images/cartoonSoldier");
            zombie = Content.Load<Texture2D>("images/zombie");
            road = Content.Load<Texture2D>("images/side_road");
            buildings = Content.Load<Texture2D>("images/ruined_buildings");
            clouds = Content.Load<Texture2D>("images/clouds");
            debris = Content.Load<Texture2D>("images/debris");
            my_font = Content.Load<SpriteFont>("Fonts/SpriteFont1");
            instructions = Content.Load<SpriteFont>("Fonts/SpriteFont2");
            crosshair = new MousePointer(Content.Load<Texture2D>("images/crosshair"), new Point(40, 40),
                                            0, new Vector2(0, 0));
        }

        
        public override void Update(GameTime gameTime)
        {
            timer += gameTime.ElapsedGameTime.Milliseconds;
            if (timer > 400)
            {
                show_instructions = !show_instructions;
                timer = 0;
            }

            crosshair.Update(gameTime, window);
            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            Game.GraphicsDevice.Clear(Color.Black);

            // TODO: Add your drawing code here
            spriteBatch.Begin();

            spriteBatch.Draw(clouds,
               new Vector2(-10, 0),
               null,
               Color.White,
               0,
               new Vector2(0, 0),
               0.5f,
               SpriteEffects.None,
               0);

            spriteBatch.Draw(buildings,
               new Vector2(0, -225),
               null,
               Color.White,
               0,
               new Vector2(0, 0),
               1.4f,
               SpriteEffects.None,
               0);

            spriteBatch.Draw(road,
               new Vector2(0, -250),
               null,
               Color.White,
               0,
               new Vector2(0, 0),
               0.5f,
               SpriteEffects.None,
               0);

            spriteBatch.Draw(debris,
               new Vector2(0, 290),
               null,
               Color.White,
               0,
               new Vector2(0, 0),
               2f,
               SpriteEffects.None,
               0);

            spriteBatch.Draw(soldier, 
               new Vector2(0, 375), 
               null,
               Color.White, 
               0, 
               new Vector2(0, 0),
               1.0f,
               SpriteEffects.None,
               0);

            spriteBatch.Draw(zombie,
               new Vector2(700, 150),
               null,
               Color.White,
               0,
               new Vector2(0, 0),
               0.15f,
               SpriteEffects.None,
               0);

            spriteBatch.Draw(zombie,
               new Vector2(500, 150),
               null,
               Color.White,
               0,
               new Vector2(0, 0),
               0.15f,
               SpriteEffects.None,
               0);

            spriteBatch.Draw(zombie,
               new Vector2(300, 150),
               null,
               Color.White,
               0,
               new Vector2(0, 0),
               0.15f,
               SpriteEffects.None,
               0);

            spriteBatch.Draw(zombie,
               new Vector2(100, 150),
               null,
               Color.White,
               0,
               new Vector2(0, 0),
               0.15f,
               SpriteEffects.None,
               0);

            spriteBatch.Draw(zombie,
               new Vector2(-100, 150),
               null,
               Color.White,
               0,
               new Vector2(0, 0),
               0.15f,
               SpriteEffects.None,
               0);

            spriteBatch.DrawString(my_font, "Zombie Smash", new Vector2(100, 10), Color.Yellow);

            if (show_instructions)
            {
                spriteBatch.DrawString(instructions, "Left click to begin", new Vector2(300, 470), Color.Aqua);
            }

            crosshair.Draw(gameTime, spriteBatch);

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
