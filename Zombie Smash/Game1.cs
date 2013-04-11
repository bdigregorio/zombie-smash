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
    public class Game1 : Microsoft.Xna.Framework.Game {

        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Texture2D door;
        Texture2D road;
        Texture2D fence;
        Texture2D grass;
        Texture2D windows;
        //Vector2 position = new Vector2(0, 0);


        public Game1() {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }


        protected override void Initialize() {
            // TODO: Add your initialization logic here

            base.Initialize();
        }


        protected override void LoadContent() {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            //game content here
            // TODO: use this.Content to load your game content here
            door = Content.Load<Texture2D>("Images/Door");
            road = Content.Load<Texture2D>("Images/Road");
            fence = Content.Load<Texture2D>("Images/Fence");
            grass = Content.Load<Texture2D>("Images/Grass");
            windows = Content.Load<Texture2D>("Images/Windows");
            AudioFramework.initAudioFramework(Content);
            AudioFramework.playMainTheme();

        }


        protected override void UnloadContent() {
            // TODO: Unload any non ContentManager content here
        }


        protected override void Update(GameTime gameTime) {
            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();

            base.Update(gameTime);
        }


        protected override void Draw(GameTime gameTime) {
            GraphicsDevice.Clear(Color.White);
            Vector2 pos = new Vector2(50, 50);
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



            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
