using Portals;
using Models;
using Models.Projectile;
using Models.Weapons;
using Presenters;
using UnityEngine;
using Views;


namespace Common
{
    public class PresentersFactory : MonoBehaviour
    {
        #region Fields

        [SerializeField] private PortalController portalsTemplate;
        [SerializeField] private BaseView spaceshipTemplate;
        [SerializeField] private BaseView laserProjectileTemplate;
        [SerializeField] private BaseView bulletProjectileTemplate;
        [SerializeField] private BaseView asteroidTemplate;
        [SerializeField] private BaseView fragmentTemplate;
        [SerializeField] private BaseView ufoTemplate;

        [SerializeField] private Transform respawnRoot;
        [SerializeField] private GameManager gameManager;

        #endregion


        #region Methods

        public SpaceshipPresenter CreateSpaceship(SpaceshipSetting setting)
        {
            BaseView spaceshipView = Instantiate(spaceshipTemplate, respawnRoot);

            SpaceshipModel spaceshipModel =
                new SpaceshipModel(setting, gameManager.Updater, gameManager.PhysicService, Vector2.zero, 0.0f);

            BulletWeapon bulletWeapon = new BulletWeapon(setting.ShootingData.BulletWeapon, spaceshipModel);
            bulletWeapon.OnShot += CreateBullet;
            LaserWeapon laserWeapon = new LaserWeapon(setting.ShootingData.LaserWeapon, spaceshipModel);
            laserWeapon.OnShot += CreateBullet;

            spaceshipModel.BindWeaponToFirstSlot(bulletWeapon);
            spaceshipModel.BindWeaponToSecondSlot(laserWeapon);

            SpaceshipPresenter spaceshipPresenter =
                new SpaceshipPresenter(spaceshipModel, (SpaceshipView)spaceshipView, gameManager.Updater);
            spaceshipPresenter.Initialize();

            return spaceshipPresenter;
        }


        public PortalController CreatePortals(Rect respawnRect)
        {
            PortalController portals = Instantiate(portalsTemplate, respawnRoot);
            portals.transform.position = Vector3.zero;

            portals.Initialize(respawnRect, gameManager.PhysicService);

            return portals;
        }


        public void CreateBullet(BaseProjectileModel projectile)
        {
            BaseView view = projectile is LaserModel
                ? Instantiate(laserProjectileTemplate, respawnRoot)
                : Instantiate(bulletProjectileTemplate, respawnRoot);
            ProjectilePresenter presenter = new ProjectilePresenter(projectile, view, gameManager.Updater);

            presenter.Initialize();
        }


        public AsteroidPresenter CreateAsteroid(Rect respawn, EnemySetting setting)
        {
            BaseView view = Instantiate(asteroidTemplate, respawnRoot);

            Vector2 position =
                new Vector2(Random.Range(respawn.x * 0.9f, respawn.x + respawn.width * 0.9f), -respawn.y * 0.8f);
            Vector2 direction = (new Vector2(Random.value, Random.value) - position).normalized;

            AsteroidModel model = new AsteroidModel(position, direction, setting, gameManager.PhysicService);

            AsteroidPresenter presenter = new AsteroidPresenter(model, view, gameManager.Updater);
            presenter.Initialize();

            return presenter;
        }


        public AsteroidPresenter CreateFragment(Positionable target, EnemySetting setting)
        {
            BaseView view = Instantiate(fragmentTemplate, respawnRoot);

            Vector2 position = target.Position;
            Vector2 direction = (new Vector2(Random.value, Random.value) - position).normalized;
            FragmentModel model = new FragmentModel(position, direction, setting, gameManager.PhysicService);

            AsteroidPresenter presenter = new AsteroidPresenter(model, view, gameManager.Updater);
            presenter.Initialize();

            return presenter;
        }


        public UfoPresenter CreateUfo(Positionable target, Rect respawn, EnemySetting setting)
        {
            BaseView view = Instantiate(ufoTemplate, respawnRoot);

            Vector2 position =
                new Vector2(Random.Range(respawn.x * 0.9f, respawn.x + respawn.width * 0.9f), -respawn.y * 0.8f);

            UfoModel model = new UfoModel(position, target, setting, gameManager.PhysicService);

            UfoPresenter presenter = new UfoPresenter(model, view, gameManager.Updater);
            presenter.Initialize();

            return presenter;
        }

        #endregion
    }
}