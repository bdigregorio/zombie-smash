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
    public class Level2Manager : Microsoft.Xna.Framework.DrawableGameComponent {
        private bool goToNextScreen = false;
        private bool gameOver = false;
        private Rectangle window;
        private ContentManager Content;
        
        private SpriteBatch spriteBatch;
        private UserControlledSprite soldier;
        private Sprite frog;
        private Sprite[] sprite_list;
        private Random gen;

        private Texture2D door;
        private Texture2D jungle_grass;
        private Texture2D tree;

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
            Content = Game.Content;
            soldier = new UserControlledSprite(Game.Content.Load<Texture2D>("images/soldier"), 
                                            new Point(29, 81), 0, new Vector2(2.5f, 2.5f), 
                                            new Vector2(window.Width / 2, window.Height / 2));

            door = Content.Load<Texture2D>("Images/Door");
            jungle_grass = Content.Load<Texture2D>("Images/Jungle_Grass");
            tree = Content.Load<Texture2D>("Images/Tree");

            gen = new Random();
            frog = new Sprite(Content.Load<Texture2D>(@"Images/Frog_obstacle"), new Point(75, 75), 0, Vector2.Zero);

            sprite_list = new Sprite[1];
            for (int x = 0; x < sprite_list.Length; x++) {
                sprite_list[x] = new Sprite (Content.Load<Texture2D>(@"Images/Frog_obstacle"), new Point(75, 75), 0, new Vector2(gen.Next(0, 730)));
            }
        }


        public override void Update(GameTime gameTime) {
            
            gameOver = EnvironmentManager.detectCollisions(soldier);
            if (EnvironmentManager.allZombiesAreDead()) {
                goToNextScreen = true;
            }

            frog.Update(gameTime, Game.Window.ClientBounds);
            for (int x = 0; x < sprite_list.Length; x++) {
                sprite_list[x].Update(gameTime, Game.Window.ClientBounds);
            }

            soldier.Draw(gameTime, spriteBatch);
            base.Update(gameTime); 
        }

        public bool levelIsComplete() {
            return goToNextScreen;
        }

        public bool playerIsDead() {
            return gameOver;
        }

        public override void Draw(GameTime gameTime) {
            spriteBatch.Begin();

            spriteBatch.Draw(jungle_grass,
                new Vector2(0, 0),
                null,
                Color.White,
                0,
                new Vector2(0, 0),
                1f,
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



            spriteBatch.Draw(tree,
                new Vector2(125, 100),
                null,
                Color.White,
                0,
                new Vector2(0, 0),
                0.5f,
                SpriteEffects.None,
                0);

            spriteBatch.Draw(tree,
                new Vector2(500, 100),
                null,
                Color.White,
                0,
                new Vector2(0, 0),
                0.5f,
                SpriteEffects.None,
                0);

            frog.Draw(gameTime, spriteBatch);
            for (int x = 0; x < sprite_list.Length; x++) {
                sprite_list[x].Draw(gameTime, spriteBatch);
            }

            soldier.Draw(gameTime, spriteBatch);
            spriteBatch.End();
        }
    }
}