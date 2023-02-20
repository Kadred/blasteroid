using System;

namespace Common
{
    public class StatisticService
    {
        public event Action<int> OnChangeScore;

        public int Score { get; private set; }

        
        public void Reset()
        {
            Score = 0;
        }

        
        public void AddScore(int value)
        {
            Score += value;
            OnChangeScore?.Invoke(Score);
        }
    }
}