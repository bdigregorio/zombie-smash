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

        public Projectile(Texture2D textureImage, Point frameSize, int collisionOffset, int speed, Vector2 orientation, Vector2 initialPosition)
            : base(textureImage, frameSize, collisionOffset, initialPosition) {
            double angle = Math.Tan((double)orientation.Y / (double)orientation.X);
            this.speed.X = (float) ((double)speed * Math.Cos(angle));
            this.speed.Y = (float) ((double)speed * Math.Sin(angle));
        }

        public override void Update(GameTime gameTime, Rectangle clientBounds) {
            position.X += speed.X;
            position.Y += speed.Y; 
            base.Update(gameTime, clientBounds);
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch) {
            spriteBatch.Draw(textureImage, position, framePosition, Color.White, 0,
                            Vector2.Zero, 1f, SpriteEffects.None, 0);
        }
    }
}
