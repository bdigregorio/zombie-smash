using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace ZombieSmash
{
    public class Sprite2
    {
        protected Texture2D textureImage;
        protected Vector2 position;
        protected Point frameSize;
        protected int collisionOffset;
        protected Point currentFrame;
        protected Point sheetSize;
        protected int timeSinceLastFrame = 0;
        protected int millisecondsPerFrame;
        protected Vector2 speed;
        protected Color tint = Color.White;
        const int defaultMillisecondsPerFrame = 16;
        protected Vector2 original_position;

        public Sprite2(Texture2D textureImage, Vector2 position, Point frameSize,
                        int collisionOffset, Point currentFrame, Point sheetSize, Vector2 speed)
        {
            this.textureImage = textureImage;
            this.position = position;
            original_position = position;
            this.frameSize = frameSize;
            this.collisionOffset = collisionOffset;
            this.sheetSize = sheetSize;
            this.speed = speed;
        }

        public virtual void Update(GameTime gameTime, Rectangle clientBounds)
        {
            position.X += speed.X;
            if (position.X > clientBounds.Width) {
                position.X = -1500;
            }
        }

        public virtual void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            //Draw the sprite
            spriteBatch.Draw(textureImage,
                position,
                new Rectangle(currentFrame.X * frameSize.X,
                    currentFrame.Y * frameSize.Y,
                    frameSize.X, frameSize.Y),
                tint, 0, Vector2.Zero,
                1f, SpriteEffects.None, 0);
        }
    }
}
