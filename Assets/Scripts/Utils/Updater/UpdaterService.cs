using System;

namespace Utils.Updater
{
    public class UpdaterService : IUpdaterService
    {
        #region Fields

        private const float OneSecond = 1.0f;

        private Action<float> onUpdate;
        private Action<float> onFixedUpdate;
        private Action<float> onLateUpdate;
        private Action<float> onOneSecondUpdate;

        private float secondsCounter = 0;

        #endregion


        #region Unity lifecycle

        public void CustomUpdate(float deltaTime)
        {
            onUpdate?.Invoke(deltaTime);

            if (secondsCounter > OneSecond)
            {
                onOneSecondUpdate?.Invoke(secondsCounter);
                secondsCounter = 0.0f;
            }
            else
            {
                secondsCounter += deltaTime;
            }
        }


        public void CustomFixedUpdate(float fixedDeltaTime)
        {
            onFixedUpdate?.Invoke(fixedDeltaTime);
        }


        public void CustomLateUpdate(float deltaTime)
        {
            onLateUpdate?.Invoke(deltaTime);
        }

        #endregion


        #region Methods

        public void Register(object obj)
        {
            if (obj is IUpdatable updatable)
            {
                onUpdate += updatable.CustomUpdate;
            }

            if (obj is IFixedUpdatable fixedUpdatable)
            {
                onFixedUpdate += fixedUpdatable.CustomFixedUpdate;
            }

            if (obj is ILateUpdatable lateUpdatable)
            {
                onLateUpdate += lateUpdatable.CustomLateUpdate;
            }

            if (obj is IOneSecondUpdatable oneSecondUpdatable)
            {
                onOneSecondUpdate += oneSecondUpdatable.OneSecondUpdate;
            }
        }


        public void Unregister(object obj)
        {
            if (obj is IUpdatable updatable)
            {
                onUpdate -= updatable.CustomUpdate;
            }

            if (obj is IFixedUpdatable fixedUpdatable)
            {
                onFixedUpdate -= fixedUpdatable.CustomFixedUpdate;
            }

            if (obj is ILateUpdatable lateUpdatable)
            {
                onLateUpdate -= lateUpdatable.CustomLateUpdate;
            }

            if (obj is IOneSecondUpdatable oneSecondUpdatable)
            {
                onOneSecondUpdate -= oneSecondUpdatable.OneSecondUpdate;
            }
        }

        #endregion
    }
}