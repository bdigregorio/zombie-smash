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

        //float speed_x = 0.1f;

        int ring_timeSinceLastFrame = 0;
        int ring_millisecondsPerFrame = 5000;
     

        protected Vector2 original_position;
        //int timer = 0;

        public Sprite2(Texture2D textureImage, Vector2 position, Point frameSize,
        int collisionOffset, Point currentFrame, Point sheetSize, Vector2 speed,
        int millisecondsPerFrame)
        {
            this.textureImage = textureImage;
            this.position = position;
            original_position = position;
            this.frameSize = frameSize;
            this.collisionOffset = collisionOffset;
            this.currentFrame = currentFrame;
            this.sheetSize = sheetSize;
            this.speed = speed;
            this.millisecondsPerFrame = millisecondsPerFrame;

        }

        public virtual void Update(GameTime gameTime, Rectangle clientBounds)
        {

            speed.X += 0.01f;
            position.X += speed.X;

            //timer += gameTime.ElapsedGameTime.Milliseconds;

            //if (timer > 5)
            //{
            //position = original_position;
            //position.X += speed_x;
            //timer = 0;
            //}

            ring_timeSinceLastFrame += gameTime.ElapsedGameTime.Milliseconds;
            if (ring_timeSinceLastFrame > ring_millisecondsPerFrame)
            {
                ring_timeSinceLastFrame -= ring_millisecondsPerFrame;
                currentFrame.X++;
                if (currentFrame.X >= sheetSize.X)
                {
                    currentFrame.X = 0;
                    currentFrame.Y++;
                    if (currentFrame.Y >= sheetSize.Y)
                    {
                        currentFrame.Y = 0;
                    }
                }
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
