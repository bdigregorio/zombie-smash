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
        private SpriteBatch spriteBatch;
        ContentManager Content;

        Texture2D soldier;
        Texture2D zombie;
        Texture2D road;
        Texture2D buildings;
        Texture2D clouds;
        Texture2D debris;

        SpriteFont my_font;
        SpriteFont instructions;

        bool show_instructions = false;
        int timer = 0;

        public TitleScreen(Game game) 
            : base (game) {
            Content = Game.Content;
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
            soldier = Content.Load<Texture2D>("Sprites/Soldier");
            zombie = Content.Load<Texture2D>("Sprites/zombie");
            road = Content.Load<Texture2D>("Sprites/side_road");
            buildings = Content.Load<Texture2D>("Sprites/ruined_buildings");
            clouds = Content.Load<Texture2D>("Sprites/clouds");
            debris = Content.Load<Texture2D>("Sprites/debris");
            my_font = Content.Load<SpriteFont>("Fonts/SpriteFont1");
            instructions = Content.Load<SpriteFont>("Fonts/SpriteFont2");
        }

        
        public override void Update(GameTime gameTime)
        {
            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                ;

            // TODO: Add your update logic here
            timer += gameTime.ElapsedGameTime.Milliseconds;

            if (timer > 400)
            {
                show_instructions = !show_instructions;
                timer = 0;
            }

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
                spriteBatch.DrawString(instructions, "Press any key to begin", new Vector2(300, 470), Color.Aqua);
            }

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
