using Utils.Updater;
using Models;
using Views;
using Utils;


namespace Presenters
{
    public class SpaceshipPresenter : BasePresenter
    {
        #region Fields
        
        private SpaceshipModel spaceshipModel;
        private SpaceshipView spaceshipView;

        #endregion


        #region Properties

        public ISpaceshipInfo Spaceship => spaceshipModel;

        #endregion


        #region Methods

        public SpaceshipPresenter(Positionable model, BaseView view, IUpdaterService updaterService) :
            base(model, view, updaterService)
        {
            spaceshipModel = (SpaceshipModel)model;
            spaceshipView = (SpaceshipView)view;
        }


        public override void Initialize()
        {
            base.Initialize();

            spaceshipView.OnMoving += View_OnMoving;
            spaceshipView.OnRotating += View_OnRotating;
            spaceshipView.OnBulletShot += View_OnBulletShot;
            spaceshipView.OnLaserShot += View_OnLaserShot;
        }


        public void Deinitialize()
        {
            spaceshipView.OnMoving -= View_OnMoving;
            spaceshipView.OnRotating -= View_OnRotating;
            spaceshipView.OnBulletShot -= View_OnBulletShot;
            spaceshipView.OnLaserShot -= View_OnLaserShot;
            
            base.Deinitialize();
        }


        private void View_OnRotating(RotationDirection direction) => spaceshipModel.SetRotationDirection(direction);


        private void View_OnMoving(bool isMoving) => spaceshipModel.SetMoving(isMoving);


        private void View_OnBulletShot(bool isShooting) => spaceshipModel.FirstSlootShoot(isShooting);


        private void View_OnLaserShot(bool isShooting) => spaceshipModel.SecondSlootShoot(isShooting);

        #endregion
    }
}