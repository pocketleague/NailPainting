using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    [RequireComponent(typeof(RewardPhasesControl))]
    public class ItemUnlockState : State
    {
        private void Awake()
        {
            mRewardPhasesControl = GetComponent<RewardPhasesControl>();

            mItemUnlockUi.SetActive(false);
        }

        public override void OnEnter()
        {
            Item unlockedItem = ProgressUtils.GetItemToUnlockOnLevel(Progress.Instance.CurrentLevel);
            if (unlockedItem.IsValid())
                mItemUnlockUi.SetActive(true);
            else
                mRewardPhasesControl._OnPhaseComplete();
        }

        public override void OnExit()
        {
            mItemUnlockUi.SetActive(false);
        }

        [SerializeField]
        private GameObject mItemUnlockUi;

        private RewardPhasesControl mRewardPhasesControl;
    }
}
