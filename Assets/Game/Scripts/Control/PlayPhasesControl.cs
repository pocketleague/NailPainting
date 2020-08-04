using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class PlayPhasesControl : State
    {
        public event System.Action OnAllPhasesComplete;
        public event System.Action OnGameplayCanceled;

        public override void OnEnter()
        {
            mGameplayUi.SetActive(true);

            mCurrentPhaseNumber = 0;
            mPhaseCursor = (Progress.Instance.CurrentLevel >= Config.LEVEL_OF_FIRST_SANDING_APPEARANCE) ? 0 : 1;
            mTotalPhaseCount = System.Enum.GetNames(typeof(PlayPhase)).Length - mPhaseCursor;

            BeginNextPhase();
        }

        public override void OnExit()
        {
        }

        public override bool OnBackButtonPressed()
        {
            if (!PopupManager.Instance.OnBackButtonPressed())
            {
                mConfirmationUi.ShowConfirmation(
                    () => {
                        PopupManager.Instance.PopPopup();
                        StopPlay();
                    },
                    () => {
                        PopupManager.Instance.PopPopup();
                    }
                );
            }

            return true;
        }

        private void StopPlay()
        {
            mGameplayUi.SetActive(false);
            mPlayPhasesStateMachine.Reset();
            OnGameplayCanceled?.Invoke();
        }

        private void Awake()
        {
            mGameplayUi.SetActive(false);

            mPlayPhasesStateMachine = new StateMachine<PlayPhase>(
                (PlayPhase.Sanding, GetComponent<SandingState>()),
                (PlayPhase.Powdering, GetComponent<PowderingState>()),
                (PlayPhase.Filling, GetComponent<FillingState>()),
                (PlayPhase.Polishing, GetComponent<PolishingState>())
            );
        }

        private void BeginNextPhase()
        {
            mPlayPhasesStateMachine.SwitchState(PHASES[mPhaseCursor]);
            mPlayPhasesUi.SetProgress(PHASES[mPhaseCursor], mCurrentPhaseNumber + 1, mTotalPhaseCount);
        }

        // To be called by the states
        public void _OnPhaseFinished()
        {
            ++mPhaseCursor;
            ++mCurrentPhaseNumber;
            if (mCurrentPhaseNumber == mTotalPhaseCount)
            {
                mGameplayUi.SetActive(false);
                mPlayPhasesStateMachine.Reset();
                OnAllPhasesComplete?.Invoke();
            }
            else
            {
                BeginNextPhase();
            }
        }

        [SerializeField]
        GameObject mGameplayUi;

        [SerializeField]
        PlayPhasesUi mPlayPhasesUi;

        [SerializeField]
        ConfirmationUi mConfirmationUi;

        private StateMachine<PlayPhase> mPlayPhasesStateMachine;
        private int mTotalPhaseCount;
        private int mCurrentPhaseNumber;
        private int mPhaseCursor;

        // In order of play
        private static readonly PlayPhase[] PHASES =
        {
            PlayPhase.Sanding,
            PlayPhase.Powdering,
            PlayPhase.Filling,
            PlayPhase.Polishing
        };
    }
}
