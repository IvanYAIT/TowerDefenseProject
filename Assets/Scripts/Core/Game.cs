using State;
using System;

namespace Core
{
    public class Game
    {
        private int progressBarValue;
        private bool isTimerEnd;

        public static Action<Type> OnWin;

        public Game()
        {
            Timer.onTimerEnd += WhenTimerEnd;
        }

        public void CheckWin(float progressBarValue, float progressBarMaxValue)
        {
            if (progressBarValue == progressBarMaxValue && isTimerEnd)
                OnWin?.Invoke(typeof(WinState));
        }

        private void WhenTimerEnd() => isTimerEnd = true;
    }
}

