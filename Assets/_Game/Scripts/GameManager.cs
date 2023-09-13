using System;
using Assets.HeroEditor.Common.Scripts.CharacterScripts;
using Assets.HeroEditor.InventorySystem.Scripts.Data;
using UnityEngine;
using UnityEngine.UI;

namespace _Game.Scripts
{
    public class GameManager : MonoBehaviour
    {
        public LumberInventory Inventory;
        public Button BtnAttack;
        public Tree Tree;
        public Character Axeman;

        private bool _blockAttack;
        public static GameManager Instance{ get; private set; }

        private void Awake()
        {
            if (null == Instance)
            {
                Instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject);
                return;
            }
            // do other awake stuffs after instance
        }

        private void Start()
        {
            BtnAttack.onClick.AddListener(OnAttackClick);
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
        }

        public void OnRewardItem(Item item)
        {
            _blockAttack = false;
            // do popup reward window
            Inventory.TryEquipNewItem(item);
        }
    }
}