using System;
using System.Collections.Generic;
using System.Linq;
using _Game.Scripts.Data;
using Assets.HeroEditor.InventorySystem.Scripts.Data;
using Assets.HeroEditor.InventorySystem.Scripts.Elements;
using Assets.HeroEditor.InventorySystem.Scripts.Enums;
using UnityEngine;

namespace _Game.Scripts
{
    public class LumberInventory : ItemWorkspace
    {
        public Equipment Equipment;
        public AudioClip EquipSound;
        public AudioSource AudioSource;
        
        
        public Func<Item, bool> CanEquip = i => i.IsEquipment; // auto equip if attribute approve
        public Action<Item> OnEquip;

        private List<Item> _items = new();
        public void Awake()
        {
            Assets.HeroEditor.InventorySystem.Scripts.ItemCollection.Active = ItemCollection;
        }

        private void Start()
        {
            LoadEquipItemsData();
            Initialize(ref _items, 3, null);
        }

        private void LoadEquipItemsData()
        {
            DataManager.Instance.AssignInventory(ref _items);
        }
        
        private void Initialize(ref List<Item> equippedItems, int bagSize, Action onRefresh)
        {
            RegisterCallbacks();
            Equipment.SetBagSize(bagSize);
            Equipment.Initialize(ref equippedItems);
            Equipment.OnRefresh = onRefresh;

            // if (!Equipment.SelectAny())
            // {
            //     ItemInfo.Reset();
            // }
        }
        
        public void RegisterCallbacks()
        {
            InventoryItem.OnLeftClick = SelectItem;
            // InventoryItem.OnRightClick = InventoryItem.OnDoubleClick = QuickAction;
        }
        
        public void SelectItem(Item item)
        {
            if(null == item) return;
            SelectedItem = item;
            ItemInfo.Initialize(SelectedItem, SelectedItem.Params.Price);
            Refresh();
        }

        private void QuickAction(Item item)
        {
            SelectItem(item);

            if (Equipment.Items.Contains(item))
            {
                Remove();
            }
            else if (CanEquipSelectedItem())
            {
                DoEquip(item);
            }
        }
        
        private bool CanEquipSelectedItem()
        {
            return Equipment.Slots.Any(i => i.Supports(SelectedItem)) && SelectedItem.Params.Class != ItemClass.Booster;
        }
        
        private void DoEquip(Item item)
        {
            // if (!CanEquip(item)) return;

            var equipped = item.IsFirearm
                ? Equipment.Items.Where(i => i.IsFirearm).ToList()
                : Equipment.Items.Where(i => i.Params.Type == item.Params.Type && !i.IsFirearm).ToList();

            if (equipped.Any())
            {
                AutoRemove(equipped, item, Equipment.Slots.Count(i => i.Supports(item)));
            }

            if (item.IsTwoHanded) AutoRemove(Equipment.Items.Where(i => i.IsShield).ToList(), item);
            if (item.IsShield) AutoRemove(Equipment.Items.Where(i => i.IsWeapon && i.IsTwoHanded).ToList(), item);

            if (item.IsFirearm) AutoRemove(Equipment.Items.Where(i => i.IsShield).ToList(), item);
            if (item.IsFirearm) AutoRemove(Equipment.Items.Where(i => i.IsWeapon && i.IsTwoHanded).ToList(), item);
            if (item.IsTwoHanded || item.IsShield) AutoRemove(Equipment.Items.Where(i => i.IsWeapon && i.IsFirearm).ToList(), item);

            EquipItem(item, Equipment);
            AudioSource.PlayOneShot(EquipSound, SfxVolume);
            OnEquip?.Invoke(item);
        }
        
        private void AutoRemove(List<Item> items, Item keepItem, int max = 1)
        {
            long sum = 0;

            foreach (var p in items)
            {
                sum += p.Count;
            }

            if (sum >= max)
            {
                RemoveItemSilent(items.LastOrDefault(i => i.Id != keepItem.Id) ?? items.Last(), Equipment);
            }
        }

        public void Remove()
        {
            RemoveItemSilent(SelectedItem, Equipment);
            SelectItem(null);
            AudioSource.PlayOneShot(EquipSound, SfxVolume);
        }

        public override void Refresh()
        {
            if (SelectedItem == null)
            {
                ItemInfo.Reset();
            }
        }

        public void TryEquipNewItem(Item item)
        {
            DoEquip(item);
        }
    }
}