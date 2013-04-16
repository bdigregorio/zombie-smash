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
        protected Vector2 speed;
        protected Sprite soldier;

        public AutomatedSprite(Texture2D textureImage, Point frameSize, int collisionOffset, Sprite soldier, Vector2 speed, Vector2 initialPosition)
            : base(textureImage, frameSize, collisionOffset, initialPosition) {
            this.soldier = soldier;
            this.speed = speed;
        }

        public override void Update(GameTime gameTime, Rectangle clientBounds) {

            base.Update(gameTime, clientBounds);
            //if bad guy is to the left of good guy...
            if (position.X < soldier.position.X) {
                position.X += speed.X;
            }
            //if bad guy is to the right of good guy...
            else if (position.X > soldier.position.X) {
                position.X -= speed.X;
            }
            //if bad guy is above good guy (remember: inverted Y)
            if (position.Y < soldier.position.Y) {
                position.Y += speed.Y;
            }
            //if bad guy is below good guy (remember: inverted Y)
            else if (position.Y > soldier.position.Y) {
                position.Y -= speed.Y;
            }
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch) {
            spriteBatch.Draw(textureImage, position, framePosition, Color.White, 0,
                            Vector2.Zero, 1f, SpriteEffects.None, 0);
        }
    }
}
