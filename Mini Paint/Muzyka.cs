using NAudio;
using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Princes_Escape
{
    class Muzyka
    {

        public static void Play()
        {
            WaveOut waveOut = new WaveOut(); // or WaveOutEvent()
            waveOut.Init(new WaveFileReader(Properties.Resources.Muzyka_2));
            waveOut.Volume = (float)0.5;
            waveOut.Play();
            int i = 0;
            while (true)
            {
                i++;
            }
                
        }
    }
}
