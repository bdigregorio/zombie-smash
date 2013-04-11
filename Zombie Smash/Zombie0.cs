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
    class Zombie0: Sprite
    {
        int action = 0;//0 standing,1 walking,2 attacking(slam),3 attacking(bite),4 blocking,5 dying,6 exploding
        int facing = 0;//0 left,1 upper left,2 up,3 upper right,4 right,5 lower right,6 down,7 lower left
        bool sequenceIsDone = true;//keeps AI actions from taking place until a given animation is played out. *to prevent visual frame errors
        /* Easy to implement toward AI programming, just write a check before executing the next action by saying if(zsequenceIsDone) */
        bool stillBlocking = false;//zombie is not blocking
        bool dead = false;
        bool down = false;
        bool killSwitch = false;
        int AI = -1;
        public int millisecondsPerFrame = 50;//accessed in sprite manager
        public int timeSinceLastFrame = 0;//accessed in sprite manager
        new Vector2 position = Vector2.Zero;//accessed in zwalk method inside of Zombie0 class
        Point currentFrame = new Point(0, 0);
        int slamSequence = 0;

        //customized method
        public void zwalk(Zombie0 enemy, int directionWalked)
        {
            int zspeed = 10;//zombie walk speed
            if (directionWalked == 0)//zombie walk left
            {
                enemy.position.X -= zspeed;
            }
            if (directionWalked == 1)//zombie walk upperleft
            {
                enemy.position.X -= zspeed;
                enemy.position.Y -= zspeed;
            }
            if (directionWalked == 2)//zombie walk up
            {
                enemy.position.Y -= zspeed;
            }
            if (directionWalked == 3)//zombie walk upperright
            {
                enemy.position.X += zspeed;
                enemy.position.Y -= zspeed;
            }
            if (directionWalked == 4)//zombie walk right
            {
                enemy.position.X += zspeed;
            }
            if (directionWalked == 5)//zombie walk lowerright
            {
                enemy.position.X += zspeed;
                enemy.position.Y += zspeed;
            }
            if (directionWalked == 6)//zombie walk down
            {
                enemy.position.Y += zspeed;
            }
            if (directionWalked == 7)//zombie walk lowerleft
            {
                enemy.position.X -= zspeed;
                enemy.position.Y += zspeed;
            }
        }
        public void setAction(Zombie0 enemy, int act)
        {
            enemy.AI = act;
        }
        //start the class file's main constructor
        public Zombie0(Texture2D textureImage, Vector2 position, Point frameSize,
            int collisionOffset, Point currentFrame, Point sheetSize, Vector2 speed,
            int millisecondsPerFrame,//add-ins below
            int action, int facing, int slamsequence, bool sequenceIsDone, bool stillBlocking, bool dead, bool down, bool killSwitch, int AI, int timeSinceLastFrame)
            : base(textureImage, position, frameSize, collisionOffset, currentFrame,
            sheetSize, speed, millisecondsPerFrame)
        {

        }
        public Zombie0 Zombie0UpdateAI(Zombie0 enemy)
        {
            //make all the variable referenced correctly
            //zombie attack sequence
            int action = enemy.action;//0 standing,1 walking,2 attacking(slam),3 attacking(bite),4 blocking,5 dying,6 exploding
            int facing = enemy.facing;//0 left,1 upper left,2 up,3 upper right,4 right,5 lower right,6 down,7 lower left
            bool sequenceIsDone = enemy.sequenceIsDone;//keeps AI actions from taking place until a given animation is played out. *to prevent visual frame errors
            /* Easy to implement toward AI programming, just write a check before executing the next action by saying if(zsequenceIsDone) */
            bool stillBlocking = enemy.stillBlocking;//zombie is not blocking
            bool dead = enemy.dead;
            bool down = enemy.down;
            bool killSwitch = enemy.killSwitch;
            int AI = enemy.AI;

            /* Test code to control zombie */
            if (AI == 0)//zombie instant in-sequence killing -must already be marked for death
            {
                if (dead || down)
                {
                    killSwitch = true;//goes through 1 final frame before pulling the plug
                }
                //otherwise duh the zombie ain't dead
            }
            if (AI == 1)//zombie death
            {
                down = true;
            }
            if (AI == 2)//zombie critical death
            {
                dead = true;
            }

            if (AI == 3)//zombie resurect
            {
                if (dead)//makes it so if the zombie isn't incapacitated then a key press will have no effect!
                {
                    //execute
                    dead = false;//we just brought the zombie back from extinction
                }
            }
            if (AI == 4)//zombie reanimate
            {
                if (down)//makes it so if the zombie isn't incapacitated then a key press will have no effect!
                {
                    //execute
                    down = false;//we just woke the zombie from his nap
                }
            }
            if (AI == 5)//zombie walk left
            {
                if (sequenceIsDone)
                {
                    //execute
                    facing = 0;
                    action = 1;
                }
            }
            else if (AI == 6)//zombie walk upperleft
            {
                if (sequenceIsDone)
                {
                    //execute
                    facing = 1;
                    action = 1;
                }

            }
            else if (AI == 7)//zombie walk up
            {
                if (sequenceIsDone)
                {
                    //execute
                    facing = 2;
                    action = 1;
                }

            }
            else if (AI == 8)//zombie walk upperright
            {
                if (sequenceIsDone)
                {
                    //execute
                    facing = 3;
                    action = 1;
                }

            }
            else if (AI == 9)//zombie walk right
            {
                if (sequenceIsDone)
                {
                    //execute
                    facing = 4;
                    action = 1;
                }

            }
            else if (AI == 10)//zombie walk lowerright
            {
                if (sequenceIsDone)
                {
                    //execute
                    facing = 5;
                    action = 1;
                }

            }
            else if (AI == 11)//zombie walk down
            {
                if (sequenceIsDone)
                {
                    //execute
                    facing = 6;
                    action = 1;
                }

            }
            else if (AI == 12)//zombie walk lowerleft
            {
                if (sequenceIsDone)
                {
                    //execute
                    facing = 7;
                    action = 1;
                }

            }
            else if (AI == 13)//zombie attack slam
            {
                if (sequenceIsDone)
                {
                    //execute
                    action = 2;
                }

            }
            else if (AI == 14)//zombie attack bite
            {
                if (sequenceIsDone)
                {
                    //execute
                    action = 3;
                }

            }
            else if (AI == 15)//zombie blocking
            {
                if (sequenceIsDone)
                {
                    //execute
                    action = 4;
                }

            }
            else//zombie is otherwise standing
            {
                if (sequenceIsDone)//sequence is open and the zombie isn't dead
                {
                    if (dead)//if a zombie is killed and previous animation is done playing prior to killing off the zombie w/ critical
                    {
                        //execute
                        action = 6;
                    }
                    else if (down)//if a zombie is killed and previous animation is done playing prior to killing off the zombie
                    {
                        //execute
                        action = 5;
                    }
                    else
                    {
                        //execute
                        action = 0;
                        //and the zombie is not blocking
                        stillBlocking = false;
                    }
                }

            }
            //After keyboard mapping post-changes if any needed
            if (killSwitch)
            {
                if (dead)//if a zombie is killed, killing off the zombie w/ critical
                {
                    //execute
                    action = 6;
                }
                else if (down)//if a zombie is killed, killing off the zombie
                {
                    //execute
                    action = 5;
                }
                killSwitch = false;//turn off the toggle
            }
            //reassign variables back into enemy object to be passed back to sprite manager
            enemy.action = action;
            enemy.facing = facing;
            enemy.sequenceIsDone = sequenceIsDone;
            enemy.stillBlocking = stillBlocking;
            enemy.dead = dead;
            enemy.down = down;
            enemy.killSwitch = killSwitch;
            enemy.AI = AI;

            return enemy;
        }
        public Zombie0 Zombie0UpdateAnim(Zombie0 enemy)
        {
            //change all object variables into local variables
            int action = enemy.action;//0 standing,1 walking,2 attacking(slam),3 attacking(bite),4 blocking,5 dying,6 exploding
            int facing = enemy.facing;//0 left,1 upper left,2 up,3 upper right,4 right,5 lower right,6 down,7 lower left
            bool sequenceIsDone = enemy.sequenceIsDone;//keeps AI actions from taking place until a given animation is played out. *to prevent visual frame errors
            /* Easy to implement toward AI programming, just write a check before executing the next action by saying if(zsequenceIsDone) */
            bool stillBlocking = enemy.stillBlocking;//zombie is not blocking
            bool dead = enemy.dead;
            bool down = enemy.down;
            bool killSwitch = enemy.killSwitch;
            int AI = enemy.AI;
            Point currentFrame = enemy.currentFrame;
            int slamSequence = enemy.slamSequence;

            currentFrame.Y = facing;//set direction facing in the enemy logic *Or can be set in the actual AI area
            /* May cause logic errors if the zombie is facing a direction in variables but not yet drawn that way because of waiting for frametime */
            //the above is true if an algorithm is used to act on the zombie facing a certain direction.
            if (action == -2)//dead from critical hit
            {
                //end the loop and check no other values, because zombie is beyond dead
                if (!dead)
                {
                    //if for some reason the zombie is back alive again, then resurect him to life
                    if (currentFrame.X == 35)
                    {
                        currentFrame.X = 34;
                    }
                    else if (currentFrame.X == 34)
                        currentFrame.X = 33;
                    else if (currentFrame.X == 33)
                        currentFrame.X = 32;
                    else if (currentFrame.X == 32)
                        currentFrame.X = 31;
                    else if (currentFrame.X == 31)
                        currentFrame.X = 30;
                    else if (currentFrame.X == 30)
                        currentFrame.X = 29;
                    else if (currentFrame.X == 29)
                    {
                        currentFrame.X = 28;
                        sequenceIsDone = true;//allows for access to walking and control to the zombie once again
                        //also returns zombie automatically to standing fashion
                    }
                }
            }
            else if (action == -1)//normal death
            {
                //end the loop and check no other values, because zombie is dead
                if (!down)
                {
                    //if for some reason the zombie is back alive again, then reanimate him to life
                    if (currentFrame.X == 27)
                    {
                        currentFrame.X = 26;
                    }
                    else if (currentFrame.X == 26)
                        currentFrame.X = 25;
                    else if (currentFrame.X == 25)
                        currentFrame.X = 24;
                    else if (currentFrame.X == 24)
                        currentFrame.X = 23;
                    else if (currentFrame.X == 23)
                    {
                        currentFrame.X = 22;
                        sequenceIsDone = true;//allows for access to walking and control to the zombie once again
                        //also returns zombie automatically to standing fashion
                    }
                }
            }
            else if (action == 0)//no changes to zsequenceIsDone here, because actions can be performed at any time durring stance animation
            {
                //the zombie is standing @ 4 frames
                if (currentFrame.X == 0)
                    currentFrame.X = 1;
                else if (currentFrame.X == 1)
                    currentFrame.X = 2;
                else if (currentFrame.X == 2)
                    currentFrame.X = 3;
                else if (currentFrame.X == 3)
                    currentFrame.X = 0;
                else
                {
                    currentFrame.X = 0;
                }
            }
            else if (action == 1)
            {
                //the zombie is walking @ 8 frames
                if (currentFrame.X == 4)
                {
                    currentFrame.X = 5;
                    sequenceIsDone = false;//you can't friggin walk if you are dead, so death was added in the stand controls to not have to comment this out
                    zwalk(enemy, facing);
                }
                else if (currentFrame.X == 5)
                {
                    currentFrame.X = 6;
                    zwalk(enemy, facing);
                }
                else if (currentFrame.X == 6)
                {
                    currentFrame.X = 7;
                    zwalk(enemy, facing);
                }
                else if (currentFrame.X == 7)
                {
                    currentFrame.X = 8;
                    zwalk(enemy, facing);
                }
                else if (currentFrame.X == 8)
                {
                    currentFrame.X = 9;
                    zwalk(enemy, facing);
                }
                else if (currentFrame.X == 9)
                {
                    currentFrame.X = 10;
                    zwalk(enemy, facing);
                }
                else if (currentFrame.X == 10)
                {
                    currentFrame.X = 11;
                    zwalk(enemy, facing);
                }
                else if (currentFrame.X == 11)
                {
                    currentFrame.X = 4;
                    sequenceIsDone = true;
                }
                else
                {
                    currentFrame.X = 4;
                }
            }
            else if (action == 2)
            {
                //the zombie is slaming @ 6 logical frames *actually using 4 frames but cycling in reverse for full range
                if (slamSequence == 0)
                {
                    currentFrame.X = 14;//this is frame 14 upswing; does no damage
                    sequenceIsDone = false;
                    //make upswing possibly disarm/startle/or prevent human from firing temporarily.
                }
                else if (slamSequence == 1)
                {
                    currentFrame.X = 13;
                }
                else if (slamSequence == 2)
                {
                    currentFrame.X = 12;
                }
                else if (slamSequence == 3)
                {
                    currentFrame.X = 13;
                }
                else if (slamSequence == 4)
                {
                    currentFrame.X = 14;
                    //do damage to player if player is hit on frame 14(downswing)
                    //also play human getting hit sound
                }
                else if (slamSequence == 5)
                {
                    currentFrame.X = 15;
                    slamSequence = 0;
                    sequenceIsDone = true;
                }
                slamSequence++;
            }
            else if (action == 3)
            {
                //the zombie is biting @ 4 frames
                if (currentFrame.X == 16)
                {
                    currentFrame.X = 17;
                    //heal zombie if player was hit on frame 19
                    sequenceIsDone = true;
                }
                else if (currentFrame.X == 17)
                {
                    currentFrame.X = 18;
                    sequenceIsDone = false;
                }
                else if (currentFrame.X == 18)
                {
                    currentFrame.X = 19;
                    //do damage to player if player is hit on frame 19
                }
                else if (currentFrame.X == 19)
                    currentFrame.X = 16;
                else
                {
                    currentFrame.X = 18;//must start here to calculate the hit
                    sequenceIsDone = false;
                }
            }
            else if (action == 4)
            {
                //the zombie is blocking @ 2 frames
                if (stillBlocking)
                {
                    currentFrame.X = 21;
                    //keeps going until AI decides to unblock or dies
                }
                else
                {
                    currentFrame.X = 20;
                    stillBlocking = true;
                }
            }
            else if (action == 5)
            {
                /* Can possibly add an alternate gameplay style and make it so that the dead reanimate unless a critical hit is scored */
                //the zombie is dying @ 6 frames
                sequenceIsDone = false;//and it will stay this way because the zombie is now dead
                if (currentFrame.X == 22)
                {
                    currentFrame.X = 23;
                }
                else if (currentFrame.X == 23)
                    currentFrame.X = 24;
                else if (currentFrame.X == 24)
                    currentFrame.X = 25;
                else if (currentFrame.X == 25)
                    currentFrame.X = 26;
                else if (currentFrame.X == 26)
                {
                    //stays on frame 27
                    currentFrame.X = 27;
                    action = -1;//represents death; no action can be taken **also ends access to the loop
                    down = true;
                }
                else
                {
                    currentFrame.X = 22;
                }
            }
            else if (action == 6)
            {
                //the zombie is dying from critical @ 8 frames
                sequenceIsDone = false;//and it will stay this way because the zombie is now dead FOR GOOD!
                if (currentFrame.X == 28)
                {
                    currentFrame.X = 29;
                }
                else if (currentFrame.X == 29)
                    currentFrame.X = 30;
                else if (currentFrame.X == 30)
                    currentFrame.X = 31;
                else if (currentFrame.X == 31)
                    currentFrame.X = 32;
                else if (currentFrame.X == 32)
                    currentFrame.X = 33;
                else if (currentFrame.X == 33)
                    currentFrame.X = 34;
                else if (currentFrame.X == 34)
                {
                    //stays on frame 35
                    currentFrame.X = 35;
                    action = -2;//represents critical death; no action can be taken **also ends access to the loop
                    dead = true;
                }
                else
                {
                    currentFrame.X = 28;
                }
            }
            //reassign variables back into enemy object to be passed back to sprite manager
            enemy.action = action;
            enemy.facing = facing;
            enemy.sequenceIsDone = sequenceIsDone;
            enemy.stillBlocking = stillBlocking;
            enemy.dead = dead;
            enemy.down = down;
            enemy.killSwitch = killSwitch;
            enemy.AI = AI;
            enemy.currentFrame = currentFrame;

            return enemy;
        }
        public override Vector2 direction
        {
            get
            {
                return speed;
            }
        }
        public override void Update(GameTime gameTime, Rectangle clientBounds)
        {

            base.Update(gameTime, clientBounds);
        }

    }
}
