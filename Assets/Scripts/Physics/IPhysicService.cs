using Utils.Updater;


namespace Physics
{
    public interface IPhysicService
    {
        void Initialize(IUpdaterService updater);

        void Deinitialize();

        void Register(IPhysicObject obj);

        void Unregister(IPhysicObject obj);
    }
}