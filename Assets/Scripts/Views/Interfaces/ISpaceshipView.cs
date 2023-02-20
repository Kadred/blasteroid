using System;


namespace Views
{
    public interface ISpaceshipView
    {
        event Action<bool> OnBulletShot;

        event Action<bool> OnLaserShot;
    }
}