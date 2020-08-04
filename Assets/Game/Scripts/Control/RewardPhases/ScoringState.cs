using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    [RequireComponent(typeof(RewardPhasesControl))]
    public class ScoringState : State
    {
        private void Awake()
        {
            mRewardPhasesControl = GetComponent<RewardPhasesControl>();

            mScoringUi.SetActive(false);
        }

        public override void OnEnter()
        {
            mScoringUi.SetActive(true);

            Progress.Instance.Currency += 25; //< TODO: update
        }

        public override void OnExit()
        {
            mScoringUi.SetActive(false);
        }

        [SerializeField]
        private GameObject mScoringUi;

        private RewardPhasesControl mRewardPhasesControl;
    }
}
