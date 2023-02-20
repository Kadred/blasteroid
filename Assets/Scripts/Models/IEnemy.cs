using System;

namespace Models
{
    public interface IEnemy
    {
        event Action<Positionable, string> OnDamageReceived;
        
        int Score { get; }
    }
}