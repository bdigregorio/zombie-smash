using System;
using System.Collections.Generic;
using System.Linq;
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
    /// <summary>
    /// This is a game component that implements IUpdateable.
    /// </summary>
    public class SpriteManager : Microsoft.Xna.Framework.DrawableGameComponent
    {
        SpriteBatch spriteBatch;
        UserControlledSprite player;
        List<Zombie0> zombie0List = new List<Zombie0>();

        public Vector2 GetPlayerPosition()
        {
            return player.GetPosition;
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(Game.GraphicsDevice);

            player = new UserControlledSprite(
                Game.Content.Load<Texture2D>(@"Images/soldier"),
                Vector2.Zero, new Point(29, 81), 10, new Point(0, 0),
                new Point(0, 0), new Vector2(6, 6));
            zombie0List.Add(new Zombie0(
                Game.Content.Load<Texture2D>(@"Images/zombie_0"),
                new Vector2(400, 400), new Point(128, 128), 45, new Point(0, 0),
                new Point(36, 5), new Vector2(0, 0), 50,
                0, 0, 0, true, false, false, false, false, -1, 0));//new addons for zombie only

            base.LoadContent();
        }

        public SpriteManager(Game game)
            : base(game)
        {
            //TargetElapsedTime = new TimeSpan(0, 0, 0, 0, 50);
            // TODO: Construct any child components here
        }

        /// <summary>
        /// Allows the game component to perform any initialization it needs to before starting
        /// to run.  This is where it can query for any required services and load content.
        /// </summary>
        public override void Initialize()
        {
            // TODO: Add your initialization code here

            base.Initialize();
        }

        /// <summary>
        /// Allows the game component to update itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        public override void Update(GameTime gameTime)
        {
            // TODO: Add your update code here
            //Update Player
            player.Update(gameTime, Game.Window.ClientBounds);

            //Update all Zombie0 sprites
            foreach (Zombie0 s in zombie0List)
            {
                s.Zombie0UpdateAI(s);
                s.timeSinceLastFrame += gameTime.ElapsedGameTime.Milliseconds;
                if (s.timeSinceLastFrame > s.millisecondsPerFrame)
                {
                    s.timeSinceLastFrame -= s.millisecondsPerFrame;
                    s.Zombie0UpdateAnim(s);
                }
                s.Update(gameTime, Game.Window.ClientBounds);

                //Check for collisions and exit game if there is one
                if (s.collisionRect.Intersects(player.collisionRect))
                {
                    Game.Exit();//OMG the game died
                }
            }

            base.Update(gameTime);
        }
        public override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin(SpriteBlendMode.AlphaBlend,
                SpriteSortMode.FrontToBack, SaveStateMode.None);

            //Draw the Player
            player.Draw(gameTime, spriteBatch);

            //Draw all sprites
            foreach (Zombie0 s in zombie0List)
            {
                s.Draw(gameTime, spriteBatch);
            }

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}