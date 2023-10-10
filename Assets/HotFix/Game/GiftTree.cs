using System;
using System.Collections.Generic;
using System.Linq;
using _Game.Scripts;
using Assets.HeroEditor.Common.Scripts.CharacterScripts;
using Assets.HeroEditor.Common.Scripts.Common;
using Assets.HeroEditor.FantasyHeroes.TestRoom.Scripts.Tweens;
using Assets.HeroEditor.InventorySystem.Scripts;
using Assets.HeroEditor.InventorySystem.Scripts.Data;
using Assets.HeroEditor.InventorySystem.Scripts.Elements;
using Assets.HeroEditor.InventorySystem.Scripts.Enums;
using HeroEditor.Common;
using HeroEditor.Common.Data;
using HotFix.Game.Specs;
using UnityEditor;
using UnityEngine;
using Item = Assets.HeroEditor.InventorySystem.Scripts.Data.Item;
using Random = System.Random;

namespace HotFix.Game
{
    /// <summary>
    /// The main script to control monsters.
    /// </summary>
    public class GiftTree : MonoBehaviour
    {
        public Character Character;
        public GameObject RewardPrefab;
        public Transform RewardHolder;
        public LootTable LootTable;
        
        public void Start()
        {
            Character = FindObjectOfType<Character>();

            if (Character != null)
            {
                Character.Animator.GetComponent<AnimationEvents>().OnCustomEvent += OnAnimationEvent;
            }
        }

        public void OnDestroy()
        {
            if (Character != null)
            {
                Character.Animator.GetComponent<AnimationEvents>().OnCustomEvent -= OnAnimationEvent;
            }
        }

        private void OnAnimationEvent(string eventName)
        {
            if (eventName == "Hit")
            {
                ScaleSpring.Begin(this, 1f, 1.05f, 40, 2);
                OnRewardDrop();
            }
        }

        private void OnRewardDrop()
        {
            var rewardItem = Instantiate(RewardPrefab, RewardHolder).GetComponent<RewardItem>();
            rewardItem.DropItemReward(new Item(RandomItemByLootTable()));
        }

        private string RandomItemByLootTable()
        {
            List<Loot> items = new();
            LootTable.GetLootItems(items);
            
            if (items.Count <= 0) {
                Debug.LogError("loot table is empty, pls check it!");
                return ""; 
            }
            
            var totalWeight = items.Sum(item => item.weight);
            var random = new Random(DateTime.UtcNow.Millisecond);
            var randomValue = random.Next(0, totalWeight);
            // Debug.Log($"random value:{randomValue}");
            var curWeight = 0;
            foreach (var item in items)
            {
                curWeight += item.weight;
                if (curWeight > randomValue)
                {
                    return item.key;
                }
            }

            Debug.LogError($"random value:{randomValue} out of range:0-{totalWeight}");
            return items.Last().key;
        }

        private string RandomItemIdByParam()
        {
            var random = new Random(DateTime.UtcNow.Millisecond);
            var randItemIndex = random.Next(ItemCollection.Active.Items.Count);
            Debug.Log($"randItemIndex={randItemIndex}");
            return ItemCollection.Active.Items[randItemIndex].Id;
        }

        private string RandomItemIdBySprite()
        {
            var random = new Random(DateTime.UtcNow.Millisecond);
            var spriteCollectionIndex = random.Next(ItemCollection.Active.IconCollections.Count);
            var spriteCollection = ItemCollection.Active.SpriteCollections[spriteCollectionIndex];
            var allItemSprite = spriteCollection.Armor.Union(spriteCollection.Helmet)
                .Union(spriteCollection.MeleeWeapon1H).Union(spriteCollection.MeleeWeapon2H)
                // .Union(spriteCollection.Bow).Union(spriteCollection.Firearm1H).Union(spriteCollection.Firearm2H)
                .Union(spriteCollection.Shield).Union(spriteCollection.Supplies).ToList();

            ItemCollection.Active.Items = allItemSprite.Select(i => CreateFakeItemParams(new Item(i.Id), i, spriteCollection)).ToList();
            var randItemIndex = random.Next(ItemCollection.Active.Items.Count);
            Debug.Log($"randItemIndex={randItemIndex}");
            // SaveItems();
            return ItemCollection.Active.Items[randItemIndex].Id;
        }

        private void SaveItems()
        {
            // EditorUtility.SetDirty(ItemCollection.Active);
            // AssetDatabase.SaveAssets();
        }
        
        private ItemParams CreateFakeItemParams(Item item, ItemSprite itemSprite, SpriteCollection spriteCollection)
        {
            var spriteId = itemSprite?.Id;
            var iconId = itemSprite?.Id;

            var itemParams = new ItemParams
            {
                Id = item.Id, 
                IconId = iconId, 
                SpriteId = spriteId, 
                Type = GetItemType(itemSprite, spriteCollection),
                // Meta = itemSprite == null ? null : Serializer.Serialize(itemSprite.Tags)
            };
            if (IsTwoHand(itemSprite, spriteCollection))
            {
                itemParams.Tags.Add(ItemTag.TwoHanded);
            }

            itemParams.Class = GetItemClass(itemSprite, spriteCollection);
            return itemParams;
        }

        private ItemClass GetItemClass(ItemSprite itemSprite, SpriteCollection spriteCollection)
        {
            if (spriteCollection.Firearm1H.Contains(itemSprite) ||
                spriteCollection.Firearm2H.Contains(itemSprite))
                return ItemClass.Firearm;
            return ItemClass.Unknown;
        }

        private bool IsTwoHand(ItemSprite itemSprite, SpriteCollection spriteCollection)
        {
            return spriteCollection.MeleeWeapon2H.Contains(itemSprite) ||
                   spriteCollection.Firearm2H.Contains(itemSprite);
        }
        
        private ItemType GetItemType(ItemSprite itemSprite, SpriteCollection spriteCollection)
        {
            if (spriteCollection.Armor.Contains(itemSprite))
            {
                return ItemType.Armor;
            }

            if (spriteCollection.Helmet.Contains(itemSprite))
            {
                return ItemType.Helmet;
            }
            
            if (spriteCollection.MeleeWeapon1H.Contains(itemSprite) ||
                spriteCollection.MeleeWeapon2H.Contains(itemSprite) || 
                spriteCollection.Bow.Contains(itemSprite) || 
                spriteCollection.Firearm1H.Contains(itemSprite) ||
                spriteCollection.Firearm2H.Contains(itemSprite))
            {
                return ItemType.Weapon;
            }
            
            if (spriteCollection.Shield.Contains(itemSprite))
            {
                return ItemType.Shield;
            }

            if (spriteCollection.Supplies.Contains(itemSprite))
            {
                return ItemType.Supply;
            }
            
            return ItemType.Undefined;
        }
    }
}