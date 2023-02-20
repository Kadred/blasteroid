using System;
using UnityEngine;
using Utils;

namespace Views
{
    public class BaseView : MonoBehaviour, IPositionableView
    {
        #region Fields

        public event Action<bool> OnMoving;
        public event Action<RotationDirection> OnRotating;

        private Transform cachedTransform;

        #endregion


        #region Properties

        public Transform CachedTransform => cachedTransform == null ? cachedTransform = transform : cachedTransform;

        public Rect CollisionRect { get; set; }
        
        #endregion


        #region Methods

        public virtual void Initialize()
        {
        }


        public virtual void Deinitialize()
        {
            Destroy(gameObject);
        }


        protected void MoveEvent(bool isMoving) => OnMoving?.Invoke(isMoving);


        protected void RotateEvent(RotationDirection direction) => OnRotating?.Invoke(direction);


        public void MoveTo(Vector2 newPosition) => CachedTransform.position = newPosition;


        public void RotateTo(float rotate) => transform.rotation = Quaternion.Euler(0, 0, rotate);

        
        private void OnDrawGizmos()
        {
            EditorUtils.DrawRectGizmos(CollisionRect, Color.blue);
        }
        
        #endregion
    }
}