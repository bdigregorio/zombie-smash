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
    public class EnvironmentManager : Microsoft.Xna.Framework.GameComponent {

        private static Rectangle clientBounds;
        private static SpriteBatch spriteBatch; 
        private static List<AutomatedSprite> zombies;
        private static List<Projectile> activeBullets;

        public EnvironmentManager(Game game)
            : base(game) {
        }

        public static void initEnemyManager(Rectangle window, SpriteBatch batch) {
            clientBounds = window;
            spriteBatch = batch;
        }

        public static void initGameLevel(ContentManager content, UserControlledSprite soldier, List<Vector2> spawnLocations) {
            activeBullets = new List<Projectile>();
            zombies = new List<AutomatedSprite>();
            foreach (Vector2 location in spawnLocations) {
                zombies.Add(new AutomatedSprite(content.Load<Texture2D>("Images/zombie_sprite"), new Point(50, 50), 0, soldier, new Vector2(0.75f, 0.75f), location));
            }
        }

        public static void spawnBullet(ContentManager content, Vector2 orientation, Vector2 location) {
            activeBullets.Add(new Projectile(content.Load<Texture2D>("Images/bullet"), new Point(32, 32), 0, 4, orientation, location));
        }

        public static void removeZombie(int index) {
            zombies.RemoveAt(index);
        }

        public static void removeBullet(int index) {
            activeBullets.RemoveAt(index);
        }

        public static void Update(GameTime gameTime) {
            foreach (Sprite zombie in zombies) {
                zombie.Update(gameTime, clientBounds);
            }
            foreach (Sprite bullet in activeBullets) {
                bullet.Update(gameTime, clientBounds);
            }
        }

        public static void Draw(GameTime gameTime) {
            foreach (Sprite zombie in zombies) {
                zombie.Draw(gameTime, spriteBatch);
            }
            foreach (Sprite bullet in activeBullets) {
                bullet.Draw(gameTime, spriteBatch);
            }
        }
    }
}