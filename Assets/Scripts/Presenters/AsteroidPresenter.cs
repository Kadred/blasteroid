using Utils.Updater;
using Models;
using Views;


namespace Presenters
{
    public class AsteroidPresenter : BasePresenter
    {
        #region Methods

        public AsteroidPresenter(Positionable model, BaseView view, IUpdaterService updaterService) :
            base(model, view, updaterService)
        {
        }

        #endregion
    }
}