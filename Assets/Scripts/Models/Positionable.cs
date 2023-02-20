using System;
using Physics;
using UnityEngine;


namespace Models
{
    public abstract class Positionable : IPhysicObject
    {
        #region Fields

        public event Action<Vector2> OnChangePosition;
        public event Action<float> OnChangeRotate;
        public event Action Destroying;

        #endregion


        #region Properties

        public IPhysicService PhysicService { get; }

        public ColliderData ColliderData { get; }

        public Vector2 Position { get; private set; }

        public float Rotation { get; private set; }

        public Vector2 Forward => Quaternion.Euler(0, 0, Rotation) * Vector3.up;

        public Rect CollisionRect => new Rect(
            Position.x - ColliderData.size.x,
            Position.y - ColliderData.size.y,
            ColliderData.size.x * 2,
            ColliderData.size.y * 2);

        #endregion


        #region Methods

        public Positionable(Vector2 position, float rotation, ColliderData colliderData, IPhysicService physicService)
        {
            Position = position;
            Rotation = rotation;
            ColliderData = colliderData;
            PhysicService = physicService;
        }


        public virtual void Initialize()
        {
            PhysicService.Register(this);
        }


        public virtual void Deinitialize()
        {
            PhysicService.Unregister(this);
        }


        protected void RotateTo(float delta)
        {
            Rotation = Mathf.Repeat(Rotation + delta, 360);

            OnChangeRotate?.Invoke(Rotation);
        }


        public void MoveTo(Vector2 position)
        {
            Position = position;

            OnChangePosition?.Invoke(Position);
        }


        public void Destroy()
        {
            Destroying?.Invoke();
        }


        public abstract void OnCollision(IPhysicObject physicObject);

        #endregion
    }
}