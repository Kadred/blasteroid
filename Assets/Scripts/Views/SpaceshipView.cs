using System;
using UnityEngine;
using UnityEngine.InputSystem;
using Utils;

namespace Views
{
    public class SpaceshipView : BaseView
    {
        #region Fields

        public event Action<bool> OnBulletShot;
        public event Action<bool> OnLaserShot;

        private SpaceshipInput spaceshipInput;
        private int barrelIndex = 0;

        #endregion


        #region Methods

        public override void Initialize()
        {
            base.Initialize();

            spaceshipInput = new SpaceshipInput();

            spaceshipInput.Spaceship.Move.started += Input_OnMove;
            spaceshipInput.Spaceship.Move.canceled += Input_OnMove;

            spaceshipInput.Spaceship.Rotate.started += Input_OnRotate;
            spaceshipInput.Spaceship.Rotate.canceled += Input_OnRotate;

            spaceshipInput.Spaceship.Shot.started += Input_OnFirstWeaponShot;
            spaceshipInput.Spaceship.Shot.canceled += Input_OnFirstWeaponShot;

            spaceshipInput.Spaceship.Laser.started += Input_OnSecondWeaponShot;

            spaceshipInput.Enable();
        }


        public void Deinitialize()
        {
            spaceshipInput.Disable();

            spaceshipInput.Spaceship.Move.started -= Input_OnMove;
            spaceshipInput.Spaceship.Move.canceled -= Input_OnMove;

            spaceshipInput.Spaceship.Rotate.started -= Input_OnRotate;
            spaceshipInput.Spaceship.Rotate.canceled -= Input_OnRotate;

            spaceshipInput.Spaceship.Shot.started -= Input_OnFirstWeaponShot;
            spaceshipInput.Spaceship.Shot.canceled -= Input_OnFirstWeaponShot;

            spaceshipInput.Spaceship.Laser.started -= Input_OnSecondWeaponShot;

            base.Deinitialize();
        }


        private void Input_OnMove(InputAction.CallbackContext context)
        {
            MoveEvent(context.started);
        }


        private void Input_OnRotate(InputAction.CallbackContext context)
        {
            RotateEvent((RotationDirection)(-context.ReadValue<Vector2>().x));
        }


        private void Input_OnSecondWeaponShot(InputAction.CallbackContext context)
        {
            OnLaserShot?.Invoke(true);
        }


        private void Input_OnFirstWeaponShot(InputAction.CallbackContext context)
        {
            OnBulletShot?.Invoke(context.started);
        }

        #endregion
    }
}