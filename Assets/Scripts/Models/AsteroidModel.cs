using System;
using Utils.Updater;
using Physics;
using UnityEngine;


namespace Models
{
    public class AsteroidModel : Positionable, IUpdatable, IEnemy
    {
        #region Fields

        public event Action<Positionable, string> OnDamageReceived;

        private readonly Vector2 direction;
        private readonly EnemySetting setting;

        #endregion


        #region Properties

        public int Score => setting.Score;

        #endregion


        #region Methods

        public AsteroidModel(Vector2 position, Vector2 direction, EnemySetting setting, IPhysicService physic) :
            base(position, 0.0f, setting.ColliderData, physic)
        {
            this.direction = direction;
            this.setting = setting;
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