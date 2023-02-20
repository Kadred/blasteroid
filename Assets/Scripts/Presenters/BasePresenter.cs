using System;
using Utils.Updater;
using Models;
using UnityEngine;
using Views;

public class BasePresenter : IUpdatable
{
    #region Fields

    public Action OnDestroy;

    private Positionable model;
    private BaseView view;
    private IUpdatable updatable = null;
    private IUpdaterService updaterService;

    #endregion


    #region Properties

    public Positionable Model => model;

    #endregion


    #region Methods

    public BasePresenter(Positionable model, BaseView view, IUpdaterService updaterService)
    {
        this.model = model;
        this.view = view;
        this.updaterService = updaterService;
    }


    public virtual void Initialize()
    {
        if (model is IUpdatable)
        {
            updatable = (IUpdatable)model;
        }

        model.Initialize();
        view.Initialize();

        model.OnChangePosition += Model_OnChangePosition;
        model.OnChangeRotate += Model_OnChangeRotate;
        model.Destroying += Model_OnDestroying;

        updaterService.Register(this);
    }


    public void Deinitialize()
    {
        updaterService.Unregister(this);

        model.OnChangePosition -= Model_OnChangePosition;
        model.OnChangeRotate -= Model_OnChangeRotate;
        model.Destroying -= Model_OnDestroying;

        model.Deinitialize();
        view.Deinitialize();

        OnDestroy?.Invoke();
    }


    public void CustomUpdate(float deltaTime) => updatable?.CustomUpdate(deltaTime);


    private void Model_OnChangePosition(Vector2 newPosition)
    {
        view.MoveTo(newPosition);

        view.CollisionRect = model.CollisionRect;
    }


    private void Model_OnChangeRotate(float rotation)
    {
        view.RotateTo(rotation);

        view.CollisionRect = model.CollisionRect;
    }


    private void Model_OnDestroying() => Deinitialize();

    #endregion
}