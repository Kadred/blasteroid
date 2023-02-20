using Utils.Updater;
using Physics;

namespace Common
{
    public interface IGameManager
    {
        PresentersFactory Factory { get; }

        GameState GameState { get; }

        IUpdaterService Updater { get; }

        Level Level { get; }

        IPhysicService PhysicService { get; }

        StatisticService StatisticService { get; }

        void StartGame();

        void FinishGame();

        void ShowMenu();
    }
}