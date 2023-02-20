using Utils.Updater;
using Models;
using Views;

namespace Presenters
{
    public class ProjectilePresenter : BasePresenter
    {
        public ProjectilePresenter(Positionable model, BaseView view, IUpdaterService updaterService) :
            base(model, view, updaterService)
        {
            view.MoveTo(model.Position);
            view.RotateTo(model.Rotation);
        }
    }
}