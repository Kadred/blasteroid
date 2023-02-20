using System;
using Utils.Updater;
using UnityEngine;
using Utils;


namespace Models
{
    public class SpaceshipMover : IUpdatable
    {
        #region Fields

        public Action<Vector2> OnMove;
        public Action<float> OnRotate;

        private readonly SpaceshipSetting spaceshipSetting;
        private readonly IUpdaterService updaterService;
        private readonly Positionable movingObject;

        #endregion


        #region Properties

        public Vector2 Acceleration { get; private set; }

        public bool IsMoving { get; set; }

        public RotationDirection RotationDirection { get; set; } = RotationDirection.Center;

        #endregion


        #region Methods

        public SpaceshipMover(SpaceshipSetting spaceshipSetting, IUpdaterService updaterService,
            Positionable movingObject)
        {
            this.spaceshipSetting = spaceshipSetting;
            this.updaterService = updaterService;
            this.movingObject = movingObject;
        }


        public void Initialize()
        {
            updaterService.Register(this);
        }


        public void Deinitialize()
        {
            updaterService.Unregister(this);
        }


        private void Accelerate(float deltaTime)
        {
            Acceleration += movingObject.Forward * (spaceshipSetting.MoverData.moveUnitsPerSecond * deltaTime);
            Acceleration = Vector2.ClampMagnitude(Acceleration, spaceshipSetting.MoverData.maxSpeed);
        }


        private void Slowdown(float deltaTime)
        {
            Acceleration -= Acceleration * (deltaTime / spaceshipSetting.MoverData.secondsToStop);
        }


        private void Move(bool isMoving, float fixedDeltaTime)
        {
            if (isMoving)
            {
                Accelerate(fixedDeltaTime);
            }
            else
            {
                Slowdown(fixedDeltaTime);
            }

            var nextPosition = movingObject.Position + Acceleration;

            OnMove?.Invoke(nextPosition);
        }


        private void Rotate(RotationDirection rotationDirection, float fixedDeltaTime)
        {
            if (rotationDirection == RotationDirection.Center)
            {
                return;
            }

            float rotation = (int)rotationDirection * fixedDeltaTime * spaceshipSetting.MoverData.degreesPerSecond;
            OnRotate?.Invoke(rotation);
        }


        public void CustomUpdate(float deltaTime)
        {
            Rotate(RotationDirection, deltaTime);
            Move(IsMoving, deltaTime);
        }

        #endregion
    }
}