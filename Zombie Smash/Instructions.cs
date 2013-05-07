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
    public class Instructions : Microsoft.Xna.Framework.DrawableGameComponent {
        private Rectangle window;
        private ContentManager Content;
        private SpriteBatch spriteBatch;
        private UserControlledSprite soldier;
        private MousePointer crosshair;
        private MouseState prevMS;
        private Sprite menuText;
        private bool backToMenu = false;

        Texture2D instructions;
        Texture2D soldier_derp;
        SpriteFont instructionTitle;
        SpriteFont info;

        public Instructions(Game game)
            : base(game) {
            window = Game.Window.ClientBounds;
            Content = Game.Content;
        }


        public override void Initialize() {
            EnvironmentManager.initializeSelf(window, spriteBatch);
            EnvironmentManager.initGameLevel(Game.Content, soldier, new List<Vector2>());
            base.Initialize();
        }


        protected override void LoadContent() {
            spriteBatch = new SpriteBatch(Game.GraphicsDevice);
            instructions = Content.Load<Texture2D>("images/Keyboard");
            soldier_derp = Content.Load<Texture2D>("images/soldier_derp");
            instructionTitle = Content.Load<SpriteFont>("Fonts/SpriteFont1");
            info = Content.Load<SpriteFont>("Fonts/SpriteFont2");
            menuText = new Sprite(Content.Load<Texture2D>("images/main_menu_button"), new Point(200, 40), 0, new Vector2(580, 350));
            soldier = new UserControlledSprite(Content.Load<Texture2D>("images/soldier"),
                                            new Point(29, 81), 0, new Vector2(2.5f, 2.5f),
                                            new Vector2(425, 450));
            crosshair = new MousePointer(Content.Load<Texture2D>("images/crosshair"), new Point(40, 40),
                                            0, new Vector2(0, 0));
            prevMS = Mouse.GetState();
        }


        public override void Update(GameTime gameTime) {
            MouseState ms = Mouse.GetState();
            if (ms.LeftButton == ButtonState.Pressed && prevMS.LeftButton != ButtonState.Pressed) {
                Vector2 orientation = new Vector2(crosshair.position.X - soldier.position.X,
                                                    crosshair.position.Y - soldier.position.Y);
                Vector2 position = new Vector2(soldier.position.X + 10, soldier.position.Y + 15);
                EnvironmentManager.spawnBullet(Content, orientation, position);
            }
            prevMS = ms;

            if (crosshair.getCollisionArea().Intersects(menuText.getCollisionArea())) {
                if (ms.LeftButton == ButtonState.Pressed) {
                    backToMenu = true;
                }
            }

            soldier.Update(gameTime, window);
            crosshair.Update(gameTime, window);

            base.Update(gameTime);
        }

        public bool showMainMenu() {
            return backToMenu;
        }

        public void resetInstructionScreen() {
            backToMenu = false;
        }

        public override void Draw(GameTime gameTime) {
            Game.GraphicsDevice.Clear(Color.Aquamarine);

            spriteBatch.Begin();

            spriteBatch.DrawString(instructionTitle, "Instructions", new Vector2(140, 0), Color.Purple);

            spriteBatch.DrawString(info, "Practice movement above!", new Vector2(30, 530), Color.Purple);

            spriteBatch.Draw(soldier_derp,
               new Vector2(500, 335),
               null,
               Color.White,
               0,
               new Vector2(0, 0),
               0.45f,
               SpriteEffects.None,
               0);

            spriteBatch.Draw(instructions,
               new Vector2(20, 100),
               null,
               Color.White,
               0,
               new Vector2(0, 0),
               0.28f,
               SpriteEffects.None,
               0);

            if (crosshair.getCollisionArea().Intersects(menuText.getCollisionArea())) {
                menuText.Draw(gameTime, spriteBatch, Color.Green);
            }
            else {
                menuText.Draw(gameTime, spriteBatch);
            }

            soldier.Draw(gameTime, spriteBatch);
            crosshair.Draw(gameTime, spriteBatch);

            spriteBatch.End();
        }
    }
}