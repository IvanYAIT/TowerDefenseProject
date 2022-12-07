using State;
using System;

namespace Core
{
    public class Game
    {
        private int progressBarValue;

        public static Action<Type> OnWin;

        public void CheckWin(float progressBarValue, float progressBarMaxValue)
        {
            if (progressBarValue == progressBarMaxValue)
                OnWin?.Invoke(typeof(WinState));
        }   
    }
}

