using System;
using System.Collections.Generic;
using Assets.HeroEditor.Common.Scripts.ExampleScripts;
using Assets.HeroEditor.InventorySystem.Scripts;
using Assets.HeroEditor.InventorySystem.Scripts.Data;
using HeroEditor.Common;
using UnityEngine;

namespace _Game.Scripts
{
    /// <summary>
    /// The main script to control monsters.
    /// </summary>
    public class RewardItem : MonoBehaviour
    {
        private Item _item;
        
        public void DropItemReward(Item item)
        {
            _item = item;
            GetComponent<SpriteRenderer>().sprite = _item.Icon.Sprite;
            GetComponent<Animator>().SetTrigger("drop");
        }

        // invoke in animation System
        public void RaiseEvent(string animEventName)
        {
            Debug.Log($"RaiseEvent {animEventName}");
            if (animEventName == "DropDown")
            {
                GameManager.Instance.OnRewardItem(_item);
            }
            else if (animEventName == "disappear")
            {
                Destroy(gameObject);
            }
        }
    }
}