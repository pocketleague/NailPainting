﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Game
{
    public class ItemsPopupUi : Popup
    {
        private void OnEnable()
        {
            System.Text.StringBuilder builder = new System.Text.StringBuilder();

            foreach (var (item, level) in Config.ITEM_UNLOCK_LEVELS)
            {
                string itemName = "?";
                if (item.IsNailShape())
                    itemName = item.NailShape.ToString();
                else if (item.IsPowder())
                    itemName = item.Powder.ToString();

                int milestone = ProgressUtils.GetMilestoneFromLevel(level);

                builder.Append($"{itemName} on Day {milestone}\n");
            }

            mText.text = builder.ToString();
        }

        [SerializeField]
        Text mText;
    }
}
