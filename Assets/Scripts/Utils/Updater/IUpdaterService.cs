using System;

namespace Utils.Updater
{
    public interface IUpdaterService : IUpdatable, IFixedUpdatable, ILateUpdatable
    {
        void Register(Object obj);

        void Unregister(Object obj);
    }
}