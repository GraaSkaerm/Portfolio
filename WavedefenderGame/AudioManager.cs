using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Media;

namespace FørsteSemesterEksamen
{

    public static class AudioManager
    {
        public enum Track { SeaShanty}
        public enum Sound { Gunshot, Oof  }

        private static Dictionary<Sound, SoundEffect> soundEffects = new Dictionary<Sound, SoundEffect>();
        private static Dictionary<Track, Song> songs = new Dictionary<Track, Song>();

        private static List<SoundEffectInstance> soundInstances = new List<SoundEffectInstance>();

        public static void LoadAudio()
        {
            soundEffects.Add(Sound.Oof, Gameworld.content.Load<SoundEffect>("Audio/Oof"));
            soundEffects.Add(Sound.Gunshot, Gameworld.content.Load<SoundEffect>("Audio/Gunshot"));

            songs.Add(Track.SeaShanty, Gameworld.content.Load<Song>("Audio/SeaShanty"));
        }

        public static void PlaySound(Sound sound)
        {
            SoundEffectInstance soundEffectInstance = soundEffects[sound].CreateInstance();
            soundEffectInstance.Play();

            switch (sound)
            {
                case Sound.Gunshot: 
                    soundEffectInstance.Volume = 0.5f;
                    break;
                case Sound.Oof: 
                    soundEffectInstance.Volume = 1f;
                    break;
            }

            soundInstances.Add(soundEffectInstance);  
        }

        public static void PlaySong(Track song)
        {
            MediaPlayer.Play(songs[song]);
            MediaPlayer.IsRepeating = true;
            MediaPlayer.Volume = 0.4f;
        }

        public static void StopAllAudio()
        {
            foreach (SoundEffectInstance sound in soundInstances)
            {
                sound.Stop();
            }

            soundInstances.Clear();

            MediaPlayer.Stop();
        }
    }
}
