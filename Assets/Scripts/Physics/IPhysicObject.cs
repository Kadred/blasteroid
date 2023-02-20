using UnityEngine;


namespace Physics
{
    public interface IPhysicObject
    {
        ColliderData ColliderData { get; }

        Vector2 Position { get; }

        Rect CollisionRect { get; }

        void MoveTo(Vector2 position);
        
        void OnCollision(IPhysicObject physicObject);
    }
}