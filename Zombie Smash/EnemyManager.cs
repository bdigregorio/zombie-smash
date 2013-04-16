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
    public class EnemyManager : Microsoft.Xna.Framework.GameComponent {

        private static Rectangle clientBounds;
        private static SpriteBatch spriteBatch; 
        private static List<AutomatedSprite> zombies;

        public EnemyManager(Game game)
            : base(game) {
        }

        public static void initEnemyManager(Rectangle window, SpriteBatch batch) {
            clientBounds = window;
            spriteBatch = batch;
        }

        public static void initGameLevel(ContentManager content, UserControlledSprite soldier, List<Vector2> spawnLocations) {
            zombies = new List<AutomatedSprite>();
            foreach (Vector2 location in spawnLocations) {
                zombies.Add(new AutomatedSprite(content.Load<Texture2D>("Images/zombie_sprite"), new Point(50, 50), 0, soldier, new Vector2(0.75f, 0.75f), location));
            }
        }

        public static void Update(GameTime gameTime) {
            foreach (Sprite zombie in zombies) {
                zombie.Update(gameTime, clientBounds);
            }
        }

        public static void Draw(GameTime gameTime) {
            foreach (Sprite zombie in zombies) {
                zombie.Draw(gameTime, spriteBatch);
            }
        }
    }
}