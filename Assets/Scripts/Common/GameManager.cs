using System;
using Utils.Updater;
using Physics;
using Models;
using UnityEngine;


namespace Common
{
    public class GameManager : MonoBehaviour, IGameManager
    {
        #region Fields

        public event Action<GameState> OnChangeGameState;

        [SerializeField] private LevelSetting levelSetting;
        [SerializeField] private PresentersFactory factory;

        private Level level;
        private IPhysicService physicService;
        private StatisticService statisticService;

        private GameState currentGameState = GameState.None;

        #endregion


        #region Properties

        public PresentersFactory Factory => factory;

        public GameState GameState
        {
            get => currentGameState;

            private set
            {
                if (currentGameState != value)
                {
                    currentGameState = value;
                    OnChangeGameState?.Invoke(currentGameState);
                }
            }
        }

        public StatisticService StatisticService => statisticService;

        public IUpdaterService Updater { get; private set; }

        public Level Level => level;

        public IPhysicService PhysicService => physicService;

        #endregion


        #region Methods

        private void Awake()
        {
            Updater = new UpdaterService();

            physicService = new PhysicService();
            physicService.Initialize(Updater);

            statisticService = new StatisticService();

            level = new Level(levelSetting, this);
        }


        private void Start()
        {
            ShowMenu();
        }


        private void OnDestroy()
        {
            physicService.Deinitialize();

            level.Deinitialize();
        }


        private void Update()
        {
            Updater.CustomUpdate(Time.deltaTime);
        }


        private void FixedUpdate()
        {
            Updater.CustomFixedUpdate(Time.fixedDeltaTime);
        }


        private void LateUpdate()
        {
            Updater.CustomLateUpdate(Time.deltaTime);
        }


        public void StartGame()
        {
            statisticService.Reset();
            level.Initialize();
            GameState = GameState.Game;
        }


        public void FinishGame()
        {
            level.Deinitialize();
            GameState = GameState.Result;
        }


        public void ShowMenu()
        {
            GameState = GameState.Menu;
        }

        #endregion
    }
}