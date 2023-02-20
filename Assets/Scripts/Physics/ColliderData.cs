using System;
using UnityEngine;

namespace Physics
{
    [Serializable]
    public class ColliderData
    {
        public string tag;
        public Vector2 size;
        public string[] collisionTags;
    }
}