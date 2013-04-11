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

namespace ZombieSmash {
    public class AudioFramework : Microsoft.Xna.Framework.GameComponent {

        static Song mainTheme;

        static SoundEffect heroDamaged;
        static SoundEffect heroDeath;
        static SoundEffect zombieDamaged;
        static SoundEffect zombieDeath;

        static SoundEffectInstance heroDamagedPlaying;
        static SoundEffectInstance heroDeathPlaying;
        static SoundEffectInstance zombieDamagedPlaying;
        static SoundEffectInstance zombieDeathPlaying;

        public static void initAudioFramework(ContentManager Content) {
            mainTheme = Content.Load<Song>("audio\\mainTheme");
            heroDamaged = Content.Load<SoundEffect>("audio\\heroDamaged");
            heroDeath = Content.Load<SoundEffect>("audio\\heroDeath");
            zombieDamaged = Content.Load<SoundEffect>("audio\\zombieDamaged");
            zombieDeath = Content.Load<SoundEffect>("audio\\zombieDeath");
        }

        public static void playHeroDamaged() {
            heroDamagedPlaying = heroDamaged.Play();
        }

        public static void playHeroDeath() {
            heroDeathPlaying = heroDeath.Play();
        }

        public static void playZombieDamaged() {
            zombieDamagedPlaying = zombieDamaged.Play();
        }

        public static void playZombieDeath() {
            zombieDeathPlaying = zombieDeath.Play();
        }

        public static void playMainTheme() {
            MediaPlayer.Play(mainTheme);
        }

        public AudioFramework(Game game)
            : base(game) {
        }
    }
}
