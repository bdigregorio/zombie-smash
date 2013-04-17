using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
    public class Projectile : Sprite {
        protected Vector2 speed;
        protected SpriteEffects effect;

        public Projectile(Texture2D textureImage, Point frameSize, int collisionOffset, int speed, Vector2 orientation, Vector2 initialPosition)
            : base(textureImage, frameSize, collisionOffset, initialPosition) {
            double angle = Math.Atan((double)orientation.Y / (double)orientation.X);
            if (orientation.X > 0) {
                this.speed.X = (float)((double)speed * Math.Cos(angle));
                this.speed.Y = (float)((double)speed * Math.Sin(angle));
            }
            else {
                this.speed.X = -(float)((double)speed * Math.Cos(angle));
                this.speed.Y = -(float)((double)speed * Math.Sin(angle));
            }
            if (this.speed.X > 0) {
                effect = SpriteEffects.None;
            }
            else {
                effect = SpriteEffects.FlipHorizontally;
            }
        }

        public override Rectangle getCollisionArea() {
            Rectangle collisionArea = new Rectangle();
            collisionArea.X = (int)position.X + collisionOffset;
            collisionArea.Y = (int)position.Y + collisionOffset;
            collisionArea.Width = (frameSize.X - (collisionOffset * 2)) / 2;
            collisionArea.Height = (frameSize.Y - (collisionOffset * 2)) / 2;
            return collisionArea;
        }

        public override void Update(GameTime gameTime, Rectangle clientBounds) {
            position.X += speed.X;
            position.Y += speed.Y; 
            base.Update(gameTime, clientBounds);
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch) {
            spriteBatch.Draw(textureImage, position, framePosition, Color.White, 0,
                            Vector2.Zero, 0.5f, effect, 0);
        }
    }
}
