using System.Collections.Generic;
using Utils.Updater;
using Physics;
using Models.Weapons;
using UnityEngine;
using Utils;


namespace Models
{
    public class SpaceshipModel : Positionable, IUpdatable, ISpaceshipInfo
    {
        #region Fields

        private readonly SpaceshipMover mover;
        private BaseWeapon firstWeaponSlot;
        private BaseWeapon secondWeaponSlot;
        private List<IUpdatable> updatables = new();

        #endregion


        #region Properties

        public bool IsMoving => mover.IsMoving;

        public RotationDirection RotationDirection => mover.RotationDirection;

        public Vector2 Acceleration => mover.Acceleration;

        public int LaserShots
        {
            get
            {
                if (firstWeaponSlot is LaserWeapon firstLaserWeapon)
                {
                    return firstLaserWeapon.LaserShots;
                }

                if (secondWeaponSlot is LaserWeapon secondLaserWeapon)
                {
                    return secondLaserWeapon.LaserShots;
                }

                return 0;
            }
        }

        public int MaxLaserShots
        {
            get
            {
                if (firstWeaponSlot is LaserWeapon firstLaserWeapon)
                {
                    return firstLaserWeapon.MaxLaserShots;
                }

                if (secondWeaponSlot is LaserWeapon secondLaserWeapon)
                {
                    return secondLaserWeapon.MaxLaserShots;
                }

                return 0;
            }
        }

        public float RechargeLaserCooldown
        {
            get
            {
                if (firstWeaponSlot is LaserWeapon firstLaserWeapon)
                {
                    return firstLaserWeapon.RechargeLaserCooldown;
                }

                if (secondWeaponSlot is LaserWeapon secondLaserWeapon)
                {
                    return secondLaserWeapon.RechargeLaserCooldown;
                }

                return 0;
            }
        }

        #endregion


        #region Methods

        public SpaceshipModel(SpaceshipSetting spaceshipSetting, IUpdaterService updaterService,
            IPhysicService physicService, Vector2 position, float rotation) : base(position, rotation,
            spaceshipSetting.ShipColliderData, physicService)
        {
            mover = new SpaceshipMover(spaceshipSetting, updaterService, this);
        }


        public override void Initialize()
        {
            base.Initialize();

            mover.Initialize();
            mover.OnMove += MoveTo;
            mover.OnRotate += RotateTo;
        }


        public override void Deinitialize()
        {
            mover.OnMove -= MoveTo;
            mover.OnRotate -= RotateTo;
            mover.Deinitialize();

            base.Deinitialize();
        }


        public void SetMoving(bool isMoving) => mover.IsMoving = isMoving;


        public void SetRotationDirection(RotationDirection rotationDirection) =>
            mover.RotationDirection = rotationDirection;


        public void BindWeaponToFirstSlot(BaseWeapon weapon)
        {
            if (firstWeaponSlot != null)
            {
                RemoveFromUpdatables(firstWeaponSlot as IUpdatable);
            }

            firstWeaponSlot = weapon;

            AddToUpdatables(firstWeaponSlot as IUpdatable);
        }


        public void BindWeaponToSecondSlot(BaseWeapon weapon)
        {
            if (secondWeaponSlot != null)
            {
                RemoveFromUpdatables(secondWeaponSlot as IUpdatable);
            }

            secondWeaponSlot = weapon;

            AddToUpdatables(secondWeaponSlot as IUpdatable);
        }


        public void FirstSlootShoot(bool isShooting) => firstWeaponSlot.Shoot(isShooting);


        public void SecondSlootShoot(bool isShooting) => secondWeaponSlot.Shoot(isShooting);


        public override void OnCollision(IPhysicObject physicObject)
        {
            if (physicObject.ColliderData.tag == PhysicTags.Asteroid ||
                physicObject.ColliderData.tag == PhysicTags.Ufo)
            {
                Destroy();
            }
        }

        public void CustomUpdate(float deltaTime)
        {
            for (int i = 0; i < updatables.Count; i++)
            {
                updatables[i].CustomUpdate(deltaTime);
            }
        }


        private void RemoveFromUpdatables(IUpdatable updatable)
        {
            if (updatables.Contains(updatable))
            {
                updatables.Remove(updatable);
            }
        }


        private void AddToUpdatables(IUpdatable updatable)
        {
            if (updatable != null)
            {
                updatables.Add(updatable);
            }
        }

        #endregion
    }
}