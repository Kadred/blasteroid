using Physics;
using UnityEngine;

namespace Portals
{
    [CreateAssetMenu]
    public class PortalsSetting : ScriptableObject
    {
        [SerializeField] private ColliderData colliderData;
        [SerializeField] private float portalWidth;

        public ColliderData ColliderData => colliderData;
        
        public float PortalWidth => portalWidth;
    }
}