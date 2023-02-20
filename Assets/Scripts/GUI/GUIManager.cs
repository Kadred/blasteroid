using System;
using System.Collections.Generic;
using Common;
using UnityEngine;


namespace GUI
{
    public class GUIManager : MonoBehaviour
    {
        [Serializable]
        private class GUIScreenInfo
        {
            public GameState gameState;
            public GUIScreen screen;
        }


        #region Fields

        [SerializeField] private GameManager gameManager;
        [SerializeField] private List<GUIScreenInfo> screens;

        private GUIScreenInfo currentScreen;

        #endregion


        #region Properties

        public GameManager GameManager => gameManager;

        #endregion


        #region Methods

        void Awake()
        {
            gameManager.OnChangeGameState += GameManager_OnChangeGameState;

            foreach (GUIScreenInfo screenInfo in screens)
            {
                screenInfo.screen.Initialize(this);
                screenInfo.screen.onShown += Screen_OnShown;
                screenInfo.screen.onHidden += Screen_OnHidden;
            }
        }


        private void OnDestroy()
        {
            gameManager.OnChangeGameState -= GameManager_OnChangeGameState;

            foreach (GUIScreenInfo screenInfo in screens)
            {
                screenInfo.screen.onShown -= Screen_OnShown;
                screenInfo.screen.onHidden -= Screen_OnHidden;
            }
        }

        #endregion


        #region Event handlers

        private void Screen_OnHidden()
        {
        }


        private void Screen_OnShown()
        {
        }


        private void GameManager_OnChangeGameState(GameState gameState)
        {
            if (currentScreen != null && currentScreen.screen.IsShow)
            {
                currentScreen.screen.Hide();
            }

            currentScreen = screens.Find(t => t.gameState == gameState);
            currentScreen.screen.Show();
        }

        #endregion
    }
}