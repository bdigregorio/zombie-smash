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

        TitleScreen titleScreen;
        Level1Manager level1;
        Level2Manager level2;

        MouseState prevMS;

        public Game1() {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }


        protected override void Initialize() {
            // TODO: Add your initialization logic here
            titleScreen = new TitleScreen(this);
            level1 = new Level1Manager(this);
            level2 = new Level2Manager(this);

            titleScreen.Enabled = true;
            titleScreen.Visible = true;
            level1.Enabled = false;
            level1.Visible = false;
            level2.Enabled = false;
            level2.Visible = false;

            Components.Add(titleScreen);
            Components.Add(level1);
            Components.Add(level2);

            prevMS = Mouse.GetState();

            base.Initialize();
        }


        protected override void LoadContent() {
            //game content here
            // TODO: use this.Content to load your game content here
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

            if (titleScreen.Enabled) {
                MouseState ms = Mouse.GetState();
                if (ms.LeftButton == ButtonState.Pressed && prevMS.LeftButton != ButtonState.Pressed) {
                    level1.Enabled = true;
                    level1.Visible = true;
                    titleScreen.Enabled = false;
                    titleScreen.Visible = false;
                }
                prevMS = ms;
            }

            if (level1.Enabled && level1.levelIsComplete()) {
                level2.Enabled = true;
                level2.Visible = true;
                level1.Enabled = false;
                level1.Visible = false;
            }


            base.Update(gameTime);
        }


        protected override void Draw(GameTime gameTime) {
            GraphicsDevice.Clear(Color.White);

            base.Draw(gameTime);
        }
    }
}
