using Physics;
using UnityEngine;

namespace Models
{
    [CreateAssetMenu]
    public class EnemySetting : ScriptableObject
    {
        #region Fields

        [SerializeField] protected float speed;
        [SerializeField] protected int score;
        [SerializeField] private ColliderData colliderData;

        #endregion


        #region Properties

        public float Speed => speed;

        public int Score => score;

        public ColliderData ColliderData => colliderData;

        #endregion
    }
}