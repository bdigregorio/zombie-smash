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

namespace ZombieSmash
{
    class AutomatedSprite : Sprite {
        protected Color color;
        protected Vector2 speed, spriteCenterPosition;
        protected float rotationIncrement, rotationAngle;
        protected Random rng;

        public AutomatedSprite(Texture2D textureImage, Point frameSize, int collisionOffset, Random rng)
            : base(textureImage, frameSize, collisionOffset) {
            this.rng = rng;
            NewRandomPosition();
            NewRandomSpeed();
            NewRandomColor();
            rotationIncrement = (float)rng.NextDouble() * 0.05f;
            spriteCenterPosition = new Vector2(25, 25);
        }

        public override void Update(GameTime gameTime, Rectangle clientBounds) {
            position.X += speed.X;
            position.Y += speed.Y;
            if (position.Y > clientBounds.Height) {
                NewRandomPosition();
                NewRandomSpeed();
            }
            rotationAngle += rotationIncrement;
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch) {
            spriteBatch.Draw(textureImage, position, framePosition, color,
                            rotationAngle, spriteCenterPosition, 1f, SpriteEffects.None, 0);
        }

        protected void NewRandomPosition() {
            this.position = new Vector2(rng.Next(750), -50);
        }

        protected void NewRandomSpeed() {
            this.speed = new Vector2(rng.Next(-2, 3), rng.Next(1, 5));
        }

        protected void NewRandomColor() {
            this.color = new Color((float)rng.NextDouble(), (float)rng.NextDouble(), (float)rng.NextDouble());
        }
    }
}
