using System.Collections.Generic;
using System.Linq;
using Utils.Updater;


namespace Physics
{
    public class PhysicService : IPhysicService, IUpdatable
    {
        #region Fields

        private Dictionary<string, List<IPhysicObject>> physicObjects = new();
        private IUpdaterService updater;

        #endregion


        #region Methods

        public void Initialize(IUpdaterService updater)
        {
            this.updater = updater;

            this.updater.Register(this);
        }


        public void Deinitialize()
        {
            updater.Unregister(this);

            foreach (KeyValuePair<string, List<IPhysicObject>> keyValuePair in physicObjects)
            {
                keyValuePair.Value.Clear();
            }

            physicObjects.Clear();
        }


        public void Register(IPhysicObject physicObject)
        {
            if (physicObjects.TryGetValue(physicObject.ColliderData.tag, out var objects))
            {
                objects.Add(physicObject);
            }
            else
            {
                objects = new List<IPhysicObject>(1);
                objects.Add(physicObject);
                physicObjects.Add(physicObject.ColliderData.tag, objects);
            }
        }


        public void Unregister(IPhysicObject physicObject)
        {
            if (physicObjects.TryGetValue(physicObject.ColliderData.tag, out var objects))
            {
                objects.Remove(physicObject);
            }
        }


        public void CustomUpdate(float deltaTime)
        {
            var objects = physicObjects.Values.ToArray();

            for (int i = 0; i < objects.Length; i++)
            {
                for (int j = 0; j < objects[i].Count; j++)
                {
                    CheckCollision(objects[i][j]);
                }
            }
        }


        private IReadOnlyList<IPhysicObject> GetPhysicObjectsWithTag(string tag)
        {
            if (physicObjects.TryGetValue(tag, out var objects))
            {
                return objects;
            }

            return new List<IPhysicObject>();
        }


        private void CheckCollision(IPhysicObject physicObject)
        {
            for (int index = 0; index < physicObject.ColliderData.collisionTags.Length; index++)
            {
                IReadOnlyList<IPhysicObject> objects =
                    GetPhysicObjectsWithTag(physicObject.ColliderData.collisionTags[index]);

                for (int j = 0; j < objects.Count; j++)
                {
                    IPhysicObject collisionObject = objects[j];

                    if (collisionObject == null || physicObject == null)
                    {
                        continue;
                    }

                    bool isCollision = physicObject.CollisionRect.Overlaps(collisionObject.CollisionRect);

                    if (isCollision)
                    {
                        collisionObject.OnCollision(physicObject);
                        physicObject.OnCollision(collisionObject);
                    }
                }
            }
        }

        #endregion
    }
}