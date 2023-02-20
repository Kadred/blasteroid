using System;
using Physics;
using UnityEngine;

namespace Models
{
    [Serializable]
    public class BulletWeaponData
    {
        public GameObject prefab;
        public float rechargeTime;
        public float speed;
        public ColliderData colliderData;
    }


    [Serializable]
    public class LaserWeaponData
    {
        public GameObject prefab;
        public float speed;
        public int maxShots;
        public float rechargeTime;
        public ColliderData colliderData;
    }


    [Serializable]
    public class ShipShootingData
    {
        public BulletWeaponData BulletWeapon;
        public LaserWeaponData LaserWeapon;
    }
}