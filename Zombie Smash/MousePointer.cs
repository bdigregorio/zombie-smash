﻿using System;
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
    public class MousePointer : Sprite {

        public MousePointer(Texture2D textureImage, Point frameSize, int collisionOffset, Vector2 initialPosition)
            : base(textureImage, frameSize, collisionOffset, initialPosition) {
        }

        public override void Update(GameTime gameTime, Rectangle clientBounds) {
            MouseState ms = Mouse.GetState();
            position.X = ms.X;
            position.Y = ms.Y;

            base.Update(gameTime, clientBounds);
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch) {
            spriteBatch.Draw(textureImage, position, framePosition, Color.White, 0,
                            Vector2.Zero, 1f, SpriteEffects.None, 0);
        }
    }
}
