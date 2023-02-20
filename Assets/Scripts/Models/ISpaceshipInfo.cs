using UnityEngine;

namespace Models
{
    public interface ISpaceshipInfo
    {
        Vector2 Position { get; }

        float Rotation { get; }

        Vector2 Acceleration { get; }
        
        int LaserShots { get; }
        
        int MaxLaserShots { get; }
        
        float RechargeLaserCooldown { get; }
    }
}