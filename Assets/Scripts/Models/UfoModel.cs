using System;
using Utils.Updater;
using Physics;
using UnityEngine;


namespace Models
{
    public class UfoModel : Positionable, IUpdatable, IEnemy
    {
        #region Fields

        public event Action<Positionable, string> OnDamageReceived;

        private readonly Positionable target;
        private readonly EnemySetting setting;

        #endregion


        #region Properties

        public int Score => setting.Score;

        #endregion


        #region Methods

        public UfoModel(Vector2 position, Positionable target, EnemySetting setting, IPhysicService physic) :
            base(position, 0.0f, setting.ColliderData, physic)
        {
            this.target = target;
            this.setting = setting;
        }


        public override void OnCollision(IPhysicObject physicObject)
        {
            OnDamageReceived?.Invoke(this, physicObject.ColliderData.tag);
        }


        public void CustomUpdate(float deltaTime)
        {
            Vector2 nextPosition = Vector2.MoveTowards(Position, target.Position, setting.Speed * deltaTime);
            MoveTo(nextPosition);

            RotateTo(Vector2.SignedAngle(Quaternion.Euler(0, 0, Rotation) * Vector3.up, (Position - target.Position)));
        }

        #endregion
    }
}