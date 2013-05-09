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
    public class AutomatedSprite : Sprite {
        public Vector2 speed;
        protected Sprite soldier;
        protected Color color;

        public AutomatedSprite(Texture2D textureImage, Point frameSize, int collisionOffset, Sprite soldier, Vector2 speed, Vector2 initialPosition, Color color)
            : base(textureImage, frameSize, collisionOffset, initialPosition) {
            this.soldier = soldier;
            this.speed = speed;
            this.color = color;
        }

        public override void Update(GameTime gameTime, Rectangle clientBounds) {
            base.Update(gameTime, clientBounds);
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch) {
            spriteBatch.Draw(textureImage, position, framePosition, color, 0,
                            Vector2.Zero, 1f, SpriteEffects.None, 0);
        }
    }
}
