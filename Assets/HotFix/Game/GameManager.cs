using System;
using _Game.Scripts.Base;
using _Game.Scripts.Data;
using _Game.Scripts.UI;
using Assets.HeroEditor.Common.Scripts.CharacterScripts;
using Assets.HeroEditor.InventorySystem.Scripts.Data;
using HotFix.Game;
using HotFix.Game.UI;
using Main.Base;
using UnityEngine;
using UnityEngine.UI;

namespace _Game.Scripts
{
    public class GameManager : BaseMonoSingleton<GameManager>
    {
        public LumberInventory Inventory;
        public Button BtnAttackTouch;
        public Button BtnAttack;
        public Button BtnPack;
        public Character Axeman;

        private bool _blockAttack;

        private void Start()
        {
            DataManager.Instance.AssignCharacter(ref Axeman);
            BtnAttack.onClick.AddListener(OnAttackClick);
            BtnAttackTouch.onClick.AddListener(OnAttackClick);
            BtnPack.onClick.AddListener(OnPackClick);
            Inventory.OnEquip = OnInventoryEquip;
        }

        private void OnPackClick()
        {
            GameMode.UI.Push(NoticeUIView.AssetPath);
        }

        private void OnAttackClick()
        {
            if(_blockAttack) return;
            
            _blockAttack = true;
            Axeman.GetComponent<CharacterAttack>().Attack();
        }

        private void OnDestroy()
        {
            BtnAttack.onClick.RemoveListener(OnAttackClick);
            BtnAttackTouch.onClick.RemoveListener(OnAttackClick);
            BtnPack.onClick.RemoveListener(OnPackClick);
        }

        public void OnRewardItem(Item item)
        {
            _blockAttack = false;
            // do popup reward window
            Inventory.TryEquipNewItem(item);
        }

        private void OnInventoryEquip(Item item)
        {
            DataManager.Instance.SaveCharacter(Axeman);
            DataManager.Instance.SaveInventory(Inventory.Equipment.Items);
        }
    }
}