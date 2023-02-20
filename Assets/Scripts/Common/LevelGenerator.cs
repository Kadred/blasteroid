using System.Collections.Generic;
using Physics;
using Portals;
using Models;
using Models.Weapons;
using Presenters;
using UnityEngine;
using Random = UnityEngine.Random;


namespace Common
{
    public class LevelGenerator
    {
        #region Fields

        private readonly LevelSetting setting;
        private readonly Rect respawnRect;
        private readonly IGameManager gameManager;
        private PortalController portalController;
        private int countKillAsteroids;
        private SpaceshipPresenter spaceshipPresenter;
        private BulletWeapon bulletWeapon;
        private LaserWeapon laserWeapon;

        private readonly List<Positionable> levelObjects;

        #endregion


        #region Properties

        public ISpaceshipInfo Spaceship => spaceshipPresenter.Spaceship;

        #endregion


        #region Methods

        public LevelGenerator(LevelSetting setting, Rect respawnRect, IGameManager gameManager)
        {
            this.setting = setting;
            this.respawnRect = respawnRect;
            this.gameManager = gameManager;

            levelObjects = new List<Positionable>();
        }


        public void GenerateLevel()
        {
            CreatePortals();
            spaceshipPresenter = gameManager.Factory.CreateSpaceship(setting.SpaceshipSetting);
            spaceshipPresenter.OnDestroy += Spaceship_OnDead;

            CreateAsteroids();
        }


        public void ClearLevel()
        {
            foreach (Positionable levelObject in levelObjects)
            {
                levelObject.Destroy();
            }

            levelObjects.Clear();

            portalController.Deinitialize();

            spaceshipPresenter.OnDestroy -= Spaceship_OnDead;
            spaceshipPresenter.Deinitialize();
        }


        private void CreatePortals()
        {
            portalController = gameManager.Factory.CreatePortals(respawnRect);
        }


        private void CreateAsteroids()
        {
            int count = Random.Range(setting.MinRespawnAsteroids, setting.MaxRespawnAsteroids);

            for (int index = 0; index < count; index++)
            {
                AsteroidPresenter presenter = gameManager.Factory.CreateAsteroid(respawnRect, setting.AsteroidSetting);
                ((IEnemy)presenter.Model).OnDamageReceived += BasePresenter_OnDestroy;
                levelObjects.Add(presenter.Model);
            }

            countKillAsteroids = 0;
        }


        private void CreateUfo()
        {
            UfoPresenter presenter =
                gameManager.Factory.CreateUfo(spaceshipPresenter.Model, respawnRect, setting.UfoSetting);
            ((IEnemy)presenter.Model).OnDamageReceived += BasePresenter_OnDestroy;
            levelObjects.Add(presenter.Model);
        }


        private void CreateFragments(Positionable target)
        {
            int count = Random.Range(setting.MinRespawnFragments, setting.MaxRespawnFragments);

            for (int index = 0; index < count; index++)
            {
                AsteroidPresenter presenter = gameManager.Factory.CreateFragment(target, setting.FragmentSetting);
                ((IEnemy)presenter.Model).OnDamageReceived += BasePresenter_OnDestroy;
                levelObjects.Add(presenter.Model);
            }
        }


        private void BasePresenter_OnDestroy(Positionable model, string tag)
        {
            if (model is IEnemy enemy)
            {
                enemy.OnDamageReceived -= BasePresenter_OnDestroy;
                gameManager.StatisticService.AddScore(enemy.Score);
            }

            countKillAsteroids++;

            if (tag == PhysicTags.Bullet)
            {
                if (model is AsteroidModel)
                {
                    CreateFragments(model);
                }
            }

            levelObjects.Remove(model);

            model.Destroy();

            if (countKillAsteroids >= setting.CountKillForRespawnUfo)
            {
                CreateUfo();
                countKillAsteroids = 0;
            }

            if (levelObjects.Count == 0)
            {
                CreateAsteroids();
            }
        }


        private void Spaceship_OnDead()
        {
            gameManager.FinishGame();
        }

        #endregion
    }
}