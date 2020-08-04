using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    enum PlayState
    {
        PlayPhases,
        RewardPhases
    }

    [RequireComponent(typeof(GameFlow))]
    public class GameplayState : State
    {
        private void Awake()
        {
            mGameFlow = GetComponent<GameFlow>();

            mStateMachine = new StateMachine<PlayState>(
                (PlayState.PlayPhases, mPlayPhasesControl),
                (PlayState.RewardPhases, mRewardPhasesControl)
            );

            mPlayPhasesControl.OnAllPhasesComplete += OnGameplayComplete;
            mPlayPhasesControl.OnGameplayCanceled += OnGameplayCanceled;
            mRewardPhasesControl.OnRewardsComplete += OnRewardsComplete;
        }

        private void OnDestroy()
        {
            mPlayPhasesControl.OnAllPhasesComplete -= OnGameplayComplete;
            mPlayPhasesControl.OnGameplayCanceled -= OnGameplayCanceled;
            mRewardPhasesControl.OnRewardsComplete -= OnRewardsComplete;
        }

        public override void OnEnter()
        {
            mStateMachine.SwitchState(PlayState.PlayPhases);
        }

        public override void OnExit()
        {
        }

        public override bool OnBackButtonPressed()
        {
            State currentState = mStateMachine.GetCurrentState();
            if (currentState != null)
                return currentState.OnBackButtonPressed();
            else
                return false;
        }

        private void OnGameplayComplete()
        {
            mStateMachine.SwitchState(PlayState.RewardPhases);
        }

        private void OnGameplayCanceled()
        {
            mGameFlow._SwitchState(GameState.Hub);
        }

        private void OnRewardsComplete()
        {
            ++Progress.Instance.CurrentLevel;
            mGameFlow._SwitchState(GameState.Hub);
        }

        private GameFlow mGameFlow;
        private StateMachine<PlayState> mStateMachine;

        [SerializeField]
        private PlayPhasesControl mPlayPhasesControl;

        [SerializeField]
        private RewardPhasesControl mRewardPhasesControl;
    }
}
