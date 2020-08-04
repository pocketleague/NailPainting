using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Game
{
    public class HubUi : MonoBehaviour
    {
        // TODO: remove
        public void SimulateProgress()
        {
            ++Progress.Instance.CurrentLevel;
        }

        private void Awake()
        {
            UpdateDayText();
            UpdateUnlockProgress();
            UpdateCustomerRequest();
            UpdateCurrentLevelText();

            Progress.Instance.OnCurrentLevelChanged += OnCurrentLevelChanged;
            Progress.Instance.OnCurrentMilestoneChanged += UpdateDayText;
        }

        private void OnDestroy()
        {
            Progress.Instance.OnCurrentLevelChanged -= OnCurrentLevelChanged;
            Progress.Instance.OnCurrentMilestoneChanged -= UpdateDayText;
        }

        private void OnCurrentLevelChanged()
        {
            UpdateCurrentLevelText();
            UpdateUnlockProgress();
            UpdateCustomerRequest();
        }

        private void UpdateDayText()
        {
            mDayText.text = $"Day {Progress.Instance.CurrentMilestone}";
        }

        private void UpdateUnlockProgress()
        {
            string itemName = "";
            UnlockInfo info = Progress.Instance.GetNextUnlockInfo();
            if (info.nextItem.IsNailShape())
                itemName = info.nextItem.NailShape.ToString();
            else if (info.nextItem.IsPowder())
                itemName = info.nextItem.Powder.ToString();

            mUnlockProgress.text = $"{itemName}\n{(int)(info.unlockProgressRatio * 100f)}%";
        }

        private void UpdateCustomerRequest()
        {
            CustomerRequest request = Progress.Instance.GetNextCustomerRequest();
            mCustomerRequest.text = $"{request.nailShape}\n{request.powder}";
        }

        private void UpdateCurrentLevelText()
        {
            int milestone = ProgressUtils.GetMilestoneFromLevel(Progress.Instance.CurrentLevel);
            int firstLevelInMilestone = ProgressUtils.GetFirstLevelOfMilestone(milestone);
            int firstLevelInNextMilestone = ProgressUtils.GetFirstLevelOfMilestone(milestone + 1);

            int levelNumberInMilestone = Progress.Instance.CurrentLevel - firstLevelInMilestone + 1;
            int levelCountInMilestone = firstLevelInNextMilestone - firstLevelInMilestone;
            mCurrentLevelText.text = $"Level {levelNumberInMilestone} of {levelCountInMilestone}";
        }

        [SerializeField]
        private Text mDayText;

        [SerializeField]
        private Text mUnlockProgress;

        [SerializeField]
        private Text mCustomerRequest;

        [SerializeField]
        private Text mCurrentLevelText;
    }
}
