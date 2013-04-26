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
        MouseState prevMS;

        TitleScreen titleScreen;
        Instructions instructionScreen;
        LoadingScreen loadingScreen;
        Level1Manager level1;
        Level2Manager level2;
        GameOverScreen gameOverScreen;
        EndingScreen endingScreen;

        public Game1() {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }


        protected override void Initialize() {
            // TODO: Add your initialization logic here
            titleScreen = new TitleScreen(this);
            instructionScreen = new Instructions(this);
            loadingScreen = new LoadingScreen(this);
            level1 = new Level1Manager(this);
            level2 = new Level2Manager(this);
            gameOverScreen = new GameOverScreen(this);
            endingScreen = new EndingScreen(this);

            titleScreen.Enabled = true;
            titleScreen.Visible = true;
            instructionScreen.Enabled = false;
            instructionScreen.Visible = false;
            loadingScreen.Enabled = false;
            loadingScreen.Visible = false;
            level1.Enabled = false;
            level1.Visible = false;
            level2.Enabled = false;
            level2.Visible = false;
            gameOverScreen.Enabled = false;
            gameOverScreen.Visible = false;
            endingScreen.Enabled = false;
            endingScreen.Visible = false;

            Components.Add(titleScreen);
            Components.Add(instructionScreen);
            Components.Add(loadingScreen);
            Components.Add(level1);
            Components.Add(level2);
            Components.Add(gameOverScreen);
            Components.Add(endingScreen);

            base.Initialize();
        }


        protected override void LoadContent() {
            //game content here
            // TODO: use this.Content to load your game content here
            AudioFramework.initAudioFramework(Content);
            AudioFramework.playMainTheme();
            prevMS = Mouse.GetState();
        }


        protected override void UnloadContent() {
            // TODO: Unload any non ContentManager content here
        }


        protected override void Update(GameTime gameTime) {
            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();

            if (titleScreen.Enabled) {
                if (titleScreen.startGame()) {
                    level1.initializeEnvironment();
                    level1.Enabled = true;
                    level1.Visible = true;
                    titleScreen.Enabled = false;
                    titleScreen.Visible = false;              
                }

                if (titleScreen.showInstructions()) {
                    instructionScreen.Enabled = true;
                    instructionScreen.Visible = true;
                    titleScreen.Enabled = false;
                    titleScreen.Visible = false;
                    titleScreen.resetTitleScreen();
                }
            }

            if (instructionScreen.Enabled) {
                if (instructionScreen.showMainMenu()) {
                    titleScreen.Enabled = true;
                    titleScreen.Visible = true;
                    instructionScreen.Enabled = false;
                    instructionScreen.Visible = false;
                }
            }

            if (level1.Enabled && level1.levelIsComplete()) {
                loadingScreen.resetTimer();
                loadingScreen.Enabled = true;
                loadingScreen.Visible = true;
                level1.Enabled = false;
                level1.Visible = false;
                level1.resetLevel();
            }

            if (loadingScreen.Enabled && loadingScreen.advanceLevel()) {
                level2.initializeEnvironment();
                level2.Enabled = true;
                level2.Visible = true;
                loadingScreen.Enabled = false;
                loadingScreen.Visible = false;
            }

            if (level2.Enabled && level2.levelIsComplete()) {
                endingScreen.Enabled = true;
                endingScreen.Visible = true;
                level2.Enabled = false;
                level2.Visible = false;
                level2.resetLevel();
            }

            if (endingScreen.Enabled) {
                MouseState ms = Mouse.GetState();
                if (ms.LeftButton == ButtonState.Pressed && prevMS.LeftButton != ButtonState.Pressed) {
                    titleScreen.resetTitleScreen();
                    titleScreen.Enabled = true;
                    titleScreen.Visible = true;
                    endingScreen.Enabled = false;
                    endingScreen.Visible = false;
                }
                prevMS = ms;
            }

            base.Update(gameTime);
        }


        protected override void Draw(GameTime gameTime) {
            GraphicsDevice.Clear(Color.Black);

            base.Draw(gameTime);
        }
    }
}
