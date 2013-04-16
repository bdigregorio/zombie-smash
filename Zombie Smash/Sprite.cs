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
    public class Sprite {
        protected Texture2D textureImage;
        public Vector2 position;
        protected Point frameSize;
        protected Rectangle framePosition;
        protected int elapsedTime, collisionOffset;

        public Sprite(Texture2D textureImage, Point frameSize, int collisionOffset, Vector2 initialPosition) {
            this.textureImage = textureImage;
            this.frameSize = frameSize;
            this.collisionOffset = collisionOffset;
            position = initialPosition;
            framePosition = new Rectangle(0, 0, frameSize.X, frameSize.Y);
            elapsedTime = 0;
        }

        public Rectangle getCollisionArea() {
            Rectangle collisionArea = new Rectangle();
            collisionArea.X = (int)position.X + collisionOffset;
            collisionArea.Y = (int)position.Y + collisionOffset;
            collisionArea.Width = frameSize.X - (collisionOffset * 2);
            collisionArea.Height = frameSize.Y - (collisionOffset * 2);
            return collisionArea;
        }

        public virtual void Update(GameTime gameTime, Rectangle clientBounds) { }

        public virtual void Draw(GameTime gameTime, SpriteBatch spriteBatch) { }
    }
}
