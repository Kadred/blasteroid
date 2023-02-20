using System;
using Utils.Updater;
using Physics;
using UnityEngine;


namespace Models
{
    public class FragmentModel : Positionable, IUpdatable, IEnemy
    {
        #region Fields

        public event Action<Positionable, string> OnDamageReceived;

        private readonly Vector2 direction;
        private readonly EnemySetting setting;
        private IPhysicService physic;

        #endregion


        #region Properties

        public int Score => setting.Score;

        #endregion


        #region Methods

        public FragmentModel(Vector2 position, Vector2 direction, EnemySetting setting, IPhysicService physic) :
            base(position, 0.0f, setting.ColliderData, physic)
        {
            this.direction = direction;
            this.setting = setting;
            this.physic = physic;
        }


        public override void OnCollision(IPhysicObject physicObject)
        {
            OnDamageReceived?.Invoke(this, physicObject.ColliderData.tag);
        }


        public void CustomUpdate(float deltaTime)
        {
            MoveTo(Position + direction * setting.Speed * deltaTime);
        }

        #endregion
    }
}