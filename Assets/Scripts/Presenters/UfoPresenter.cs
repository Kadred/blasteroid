using Utils.Updater;
using Models;
using Views;


namespace Presenters
{
    public class UfoPresenter : BasePresenter
    {
        #region Methods

        public UfoPresenter(Positionable model, BaseView view, IUpdaterService updaterService) :
            base(model, view, updaterService)
        {
        }

        #endregion
    }
}