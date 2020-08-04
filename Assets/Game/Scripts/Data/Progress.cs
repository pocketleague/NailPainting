using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public struct UnlockInfo
    {
        public float unlockProgressRatio;
        public Item nextItem;
    }

    public struct CustomerRequest
    {
        public NailShape nailShape;
        public Powder powder;
    }

    public class Progress
    {
        public event System.Action OnCurrencyChanged;
        public event System.Action OnCurrentLevelChanged;
        public event System.Action OnCurrentMilestoneChanged;
        public event System.Action OnSalonUpgraded;

        public int Currency
        {
            get => mData.currency;

            set
            {
                Debug.Assert(value >= 0);
                mData.currency = value;
                Save();
                OnCurrencyChanged?.Invoke();
            }
        }

        public bool CanAfford(int price)
        {
            return (Currency >= price);
        }

        public int CurrentLevel
        {
            get => mData.currentLevel;

            set
            {
                int lastMilestone = CurrentMilestone;

                mData.currentLevel = value;
                Save();

                OnCurrentLevelChanged?.Invoke();
                if (CurrentMilestone != lastMilestone)
                    OnCurrentMilestoneChanged?.Invoke();
            }
        }

        public int CurrentMilestone
        {
            get => ProgressUtils.GetMilestoneFromLevel(CurrentLevel);
        }

        public CustomerRequest GetNextCustomerRequest()
        {
            Debug.Assert(CurrentLevel > 0);
            var (nailShape, powder) = Config.CUSTOMER_REQUESTS[(CurrentLevel - 1) % Config.CUSTOMER_REQUESTS.Length];

            return new CustomerRequest
            {
                nailShape = nailShape,
                powder = powder
            };
        }

        public UnlockInfo GetNextUnlockInfo()
        {
            int lowerBound = ProgressUtils.GetLevelOfLastItemUnlock(CurrentLevel);
            var (item, upperBound) = ProgressUtils.GetNextItemToUnlock(CurrentLevel);

            float unlockProgress = 0f;
            if (upperBound > lowerBound)
                unlockProgress = (float)(CurrentLevel - lowerBound) / (float)(upperBound - lowerBound);

            return new UnlockInfo
            {
                unlockProgressRatio = unlockProgress,
                nextItem = item
            };
        }

        public ItemStatus GetNailShapeStatus(NailShape nailShape)
        {
            foreach (var (item, level) in Config.ITEM_UNLOCK_LEVELS)
            {
                if (item.IsNailShape() && item.NailShape == nailShape)
                    return (CurrentLevel < level) ? ItemStatus.Locked : ItemStatus.Unlocked;
            }

            Debug.Assert(false);
            return ItemStatus.Locked;
        }

        public ItemStatus GetPowderStatus(Powder powder)
        {
            foreach (var (item, level) in Config.ITEM_UNLOCK_LEVELS)
            {
                if (item.IsPowder() && item.Powder == powder)
                    return (CurrentLevel < level) ? ItemStatus.Locked : ItemStatus.Unlocked;
            }

            Debug.Assert(false);
            return ItemStatus.Locked;
        }

        public int InteriorLevel
        {
            get => mData.interiorLevel;

            set
            {
                Debug.Assert(value > 0);
                mData.interiorLevel = value;
                Save();
                OnSalonUpgraded?.Invoke();
            }
        }

        public int WallLevel
        {
            get => mData.wallLevel;

            set
            {
                Debug.Assert(value > 0);
                mData.wallLevel = value;
                Save();
                OnSalonUpgraded?.Invoke();
            }
        }

        public int FloorLevel
        {
            get => mData.floorLevel;

            set
            {
                Debug.Assert(value > 0);
                mData.floorLevel = value;
                Save();
                OnSalonUpgraded?.Invoke();
            }
        }

        public int GetInteriorPrice()
        {
            return GetUpgradePrice(InteriorLevel, Config.INTERIOR_PRICES);
        }

        public int GetWallPrice()
        {
            return GetUpgradePrice(WallLevel, Config.WALL_PRICES);
        }

        public int GetFloorPrice()
        {
            return GetUpgradePrice(FloorLevel, Config.FLOOR_PRICES);
        }

        private static int GetUpgradePrice(int currentUpgradeLevel, int[] prices)
        {
            Debug.Assert(currentUpgradeLevel > 0);
            --currentUpgradeLevel;

            if (currentUpgradeLevel < prices.Length)
                return prices[currentUpgradeLevel];
            else
                return prices[prices.Length - 1];
        }

        public static Progress Instance
        {
            get
            {
                if (smInstance == null)
                    smInstance = new Progress();

                return smInstance;
            }
        }

        private Progress()
        {
            mData = JsonUtility.FromJson<ProgressData>(PlayerPrefs.GetString(PROGRESS_KEY, "{}"));
            Debug.Log("level "+mData.currentLevel);
        }

        private void Save()
        {
            PlayerPrefs.SetString(PROGRESS_KEY, JsonUtility.ToJson(mData));
        }

        private ProgressData mData;
        private static Progress smInstance;

        private const string PROGRESS_KEY = "progress";
    }

    class ProgressData
    {
        public int currency;
        public int currentLevel = 1;

        // Salon upgrade level
        public int interiorLevel = 1;
        public int wallLevel = 1;
        public int floorLevel = 1;
    }
}
