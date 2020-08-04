using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    [RequireComponent(typeof(GameFlow))]
    public class HubState : State
    {
        private void Awake()
        {
            mGameFlow = GetComponent<GameFlow>();

            mHubUiEvents.OnPlayClicked += OnPlayClicked;
            mHubUiEvents.OnNailShapesClicked += OnNailShapesClicked;
            mHubUiEvents.OnToolsClicked += OnToolsClicked;
            mHubUiEvents.OnSalonClicked += OnSalonClicked;
            mHubUi.SetActive(false);
        }

        private void OnDestroy()
        {
            mHubUiEvents.OnPlayClicked -= OnPlayClicked;
            mHubUiEvents.OnNailShapesClicked -= OnNailShapesClicked;
            mHubUiEvents.OnToolsClicked -= OnToolsClicked;
            mHubUiEvents.OnSalonClicked -= OnSalonClicked;
        }

        public override void OnEnter() 
        {
            mHubUi.SetActive(true);
        }

        public override void OnExit() 
        {
            mHubUi.SetActive(false);
        }

        private void OnPlayClicked()
        {
            mGameFlow._SwitchState(GameState.Play);
        }

        private void OnNailShapesClicked()
        {
            mGameFlow._SwitchState(GameState.Items);
        }

        private void OnToolsClicked()
        {
            mGameFlow._SwitchState(GameState.Tools);
        }

        private void OnSalonClicked()
        {
            mGameFlow._SwitchState(GameState.Salon);
        }

        private GameFlow mGameFlow;

        [SerializeField]
        private GameObject mHubUi;

        [SerializeField]
        private HubUiEvents mHubUiEvents;
    }
}
