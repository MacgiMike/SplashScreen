using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SplashScreen
{
    class SplashScreenSettings
    {
        public bool IsFadingToDark { get; set; }
        public Queue<string> TextBlock1 { get; set; }
        public Queue<string> TextBlock2 { get; set; }
    }
}
