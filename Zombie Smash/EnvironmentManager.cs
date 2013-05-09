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

        private static int invincibilityTimer = 0;
        private static int spawnTimer = 0;
        private static int randomZombieLimit = 0;
        private static int spawnInterval = 1000;
        private static Random rng;
        private static Rectangle clientBounds;
        private static SpriteBatch spriteBatch; 
        private static List<AutomatedSprite> zombies;
        private static List<Projectile> activeBullets;
        public static int player_lives = 5;

        public EnvironmentManager(Game game)
            : base(game) {
        }

        public static void initializeSelf(Rectangle window, SpriteBatch batch) {
            clientBounds = window;
            spriteBatch = batch;
        }

        public static void initGameLevel(ContentManager content, UserControlledSprite soldier, List<Vector2> spawnLocations, int spawnLimit, int interval) {
            activeBullets = new List<Projectile>();
            zombies = new List<AutomatedSprite>();
            randomZombieLimit = spawnLimit;
            spawnInterval = interval; 
            foreach (Vector2 location in spawnLocations) {
                zombies.Add(generateEasyZombie(content, soldier, location));
            }
        }

        private static AutomatedSprite generateEasyZombie(ContentManager content, UserControlledSprite soldier, Vector2 location) {
            return new AutomatedSprite(content.Load<Texture2D>("Images/zombie_sprite"),
                            new Point(50, 50), 0, soldier, new Vector2(0.50f, 0.50f), location, Color.White);
        }

        private static AutomatedSprite generateMediumZombie(ContentManager content, UserControlledSprite soldier, Vector2 location) {
            return new AutomatedSprite(content.Load<Texture2D>("Images/zombie_sprite"),
                            new Point(50, 50), 0, soldier, new Vector2(0.95f, 0.95f), location, Color.Blue);
        }

        private static AutomatedSprite generateHardZombie(ContentManager content, UserControlledSprite soldier, Vector2 location) {
            return new AutomatedSprite(content.Load<Texture2D>("Images/zombie_sprite"),
                            new Point(50, 50), 0, soldier, new Vector2(1.65f, 1.65f), location, Color.Red);
        }

        public static void setRandomGenerator(Random gen) {
            rng = gen;
        }

        public static void spawnBullet(ContentManager content, Vector2 orientation, Vector2 location) {
            activeBullets.Add(new Projectile(content.Load<Texture2D>("Images/bullet"), 
                                new Point(32, 32), 0, 4, orientation, location));
        }

        public static void removeZombie(int index) {
            zombies.RemoveAt(index);
        }

        public static void removeBullet(int index) {
            activeBullets.RemoveAt(index);
        }

        public static bool detectCollisions(Sprite soldier, bool soldierIsInvincible, GameTime gameTime) {
            if (soldierIsInvincible) {
                invincibilityTimer += gameTime.ElapsedGameTime.Milliseconds;
                if (invincibilityTimer > 1000) {
                    invincibilityTimer = 0;
                    soldierIsInvincible = false;
                }
            }
            
            for (int x = 0; x < zombies.Count; x++) {
                Rectangle zArea = zombies[x].getCollisionArea();
                if (!soldierIsInvincible) {
                    if (zArea.Intersects(soldier.getCollisionArea())) {
                        AudioFramework.playHeroDeath();
                        player_lives--;
                        soldierIsInvincible = true;
                    }
                }

                for (int y = 0; y < activeBullets.Count; y++) {
                    if (zArea.Intersects(activeBullets[y].getCollisionArea())) {
                        AudioFramework.playZombieDeath();
                        zombies.RemoveAt(x);
                        x--;
                        activeBullets.RemoveAt(y);
                        y--;
                    }
                }
            }
            return soldierIsInvincible;
        }

        public static void spawnMoreZombies(GameTime gameTime, UserControlledSprite soldier, ContentManager content) {
            spawnTimer += gameTime.ElapsedGameTime.Milliseconds;
            if (spawnTimer > spawnInterval) {
                Vector2 randomLocation = generateRandomLocation();

                AutomatedSprite newRandomZombie;
                int select = rng.Next(29);
                if (select < 15) {
                    newRandomZombie = generateHardZombie(content, soldier, randomLocation);
                }
                else if (14 < select && select <  25) {
                    newRandomZombie = generateMediumZombie(content, soldier, randomLocation);
                }
                else {
                    newRandomZombie = generateEasyZombie(content, soldier, randomLocation);
                }

                Rectangle safeZone = soldier.getCollisionArea();
                safeZone.X -= 50;
                safeZone.Width += 50;
                safeZone.Y -= 50;
                safeZone.Height += 50;
                while (newRandomZombie.getCollisionArea().Intersects(safeZone)) {
                    newRandomZombie.position = generateRandomLocation();
                }
                zombies.Add(newRandomZombie);
                spawnTimer = 0;
                randomZombieLimit--;
            }
        }

        public static Vector2 generateRandomLocation() {
            return new Vector2(rng.Next(725), rng.Next(525));
        }

        public static bool allZombiesAreDead() {
            if (zombies.Count == 0) {
                return true;
            }
            else {
                return false;
            }
        }

        public static bool isGameOver() {
            if (player_lives < 1)
                return true;
            else
                return false;
        }

        public static void Update(GameTime gameTime, UserControlledSprite soldier, ContentManager content) {
            if (randomZombieLimit > 0) {
                spawnMoreZombies(gameTime, soldier, content);
            }
            for (int x = 0; x < zombies.Count; x++) {
                Rectangle zArea = zombies[x].getCollisionArea();
                
                if (zombies[x].position.X < soldier.position.X) {
                    zombies[x].position.X += zombies[x].speed.X;
                    for (int y = x + 1; y < zombies.Count; y++) {
                        Rectangle z2Area = zombies[y].getCollisionArea();
                        if (zArea.Intersects(z2Area)) {
                            zombies[x].position.X -= zombies[x].speed.X;
                        }
                    }
                }
                else if (zombies[x].position.X > soldier.position.X) {
                    zombies[x].position.X -= zombies[x].speed.X;
                    for (int y = x + 1; y < zombies.Count; y++) {
                        Rectangle z2Area = zombies[y].getCollisionArea();
                        if (zArea.Intersects(z2Area)) {
                            zombies[x].position.X += zombies[x].speed.X;
                        }
                    }
                }
                if (zombies[x].position.Y < soldier.position.Y) {
                    zombies[x].position.Y += zombies[x].speed.Y;
                    for (int y = x + 1; y < zombies.Count; y++) {
                        Rectangle z2Area = zombies[y].getCollisionArea();
                        if (zArea.Intersects(z2Area)) {
                            zombies[x].position.Y -= zombies[x].speed.Y;
                        }
                    }
                }
                else if (zombies[x].position.Y > soldier.position.Y) {
                    zombies[x].position.Y -= zombies[x].speed.Y;
                    for (int y = x + 1; y < zombies.Count; y++) {
                        Rectangle z2Area = zombies[y].getCollisionArea();
                        if (zArea.Intersects(z2Area)) {
                            zombies[x].position.Y += zombies[x].speed.Y;
                        }
                    }
                }
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