using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Runtime.InteropServices;

namespace MO_Lab_1
{

    class Speedometer
    {
        [DllImport("kernel32.dll")]
        extern static short QueryPerformanceCounter(ref long X) ;
        [DllImport("kernel32.dll")]
        extern static short QueryPerformanceFrequency(ref long X);
        static long timeStart = 0, timeStop = 0;

        static public string Duration
        {
            get
            {
                long freq = 0;
                QueryPerformanceFrequency(ref freq);
                return ((timeStop - timeStart) * 1000f / freq) +" мс";
                //* 1.0f / freq
            }
        }

        /// <summary>
        /// Старт таймера
        /// </summary>
        static public void Start()
        {
            QueryPerformanceCounter(ref timeStart);
        }

        /// <summary>
        /// Стоп таймера
        /// </summary>
        static public void Stop()
        {
            QueryPerformanceCounter(ref timeStop);
        }

    }

}

