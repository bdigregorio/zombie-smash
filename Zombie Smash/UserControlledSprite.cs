using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace ZombieSmash
{
    class UserControlledSprite : Sprite {

        public UserControlledSprite(Texture2D textureImage, Point frameSize, int collisionOffset)
            : base(textureImage, frameSize, collisionOffset) {

        }

        public override void Update(GameTime gameTime, Rectangle clientBounds) {
            KeyboardState ks = Keyboard.GetState();
            if (ks.IsKeyDown(Keys.Left) || ks.IsKeyDown(Keys.A)) {
                position.X -= 3;
            }
            else if (ks.IsKeyDown(Keys.Right) || ks.IsKeyDown(Keys.D)) {
                position.X += 3;
            }

            if (ks.IsKeyDown(Keys.Up) || ks.IsKeyDown(Keys.W)) {
                position.Y -= 3;
            }
            else if (ks.IsKeyDown(Keys.Down) || ks.IsKeyDown(Keys.S)) {
                position.Y += 3;
            }

            if (position.X < 0) {
                //snap to smallest X value
                position.X = 0;
            }
            //if too far right,
            if (position.X + frameSize.X > clientBounds.Width) {
                //snap to largest X value
                position.X = clientBounds.Width - frameSize.X;
            }
            //similar comments to above...
            if (position.Y < 0) {
                position.Y = 0;
            }
            if (position.Y + frameSize.Y > clientBounds.Height) {
                position.Y = clientBounds.Height - frameSize.Y;
            }
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch) {
            spriteBatch.Draw(textureImage, position, framePosition, Color.White, 0,
                                Vector2.Zero, 1f, SpriteEffects.None, 0);
        }
    }
}
