using System;
using UnityEngine;
using Utils;

namespace Views
{
    public interface IPositionableView : IInitializable
    {
        event Action<bool> OnMoving;

        event Action<RotationDirection> OnRotating;

        void MoveTo(Vector2 newPosition);

        void RotateTo(float rotate);
    }
}