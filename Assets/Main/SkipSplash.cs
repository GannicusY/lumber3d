using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Rendering;

namespace _Game.Scripts
{
    public class SkipSplash
    {
        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSplashScreen)]
        private static void DoSkip()
        {
            Task.Run(() =>
            {
                SplashScreen.Stop(SplashScreen.StopBehavior.StopImmediate);
            });
        }
    }
}