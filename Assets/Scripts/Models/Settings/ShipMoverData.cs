using System;

namespace Models
{
    [Serializable]
    public class ShipMoverData
    {
        public float moveUnitsPerSecond;
        public float maxSpeed;
        public float secondsToStop;
        public float degreesPerSecond;
    }
}