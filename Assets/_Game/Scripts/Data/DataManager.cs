using System;
using System.Collections.Generic;
using _Game.Scripts.Base;
using Assets.HeroEditor.Common.Scripts.CharacterScripts;
using Assets.HeroEditor.Common.Scripts.Common;
using Assets.HeroEditor.Common.Scripts.ExampleScripts;
using Assets.HeroEditor.InventorySystem.Scripts.Data;
using UnityEditor.PackageManager;
using UnityEngine;

namespace _Game.Scripts.Data
{
    public class DataManager : BaseMonoSingleton<DataManager>
    {
        private string _playerId;
        private string _characterJson;
        private string _inventoryJson;
        public override void DoAwake()
        {
            base.DoAwake();
            LoadAllData();
        }

        private void LoadAllData()
        {
            LoadCharacter();
            LoadInventory();
        }

        private void SaveAllData()
        {
            DoSaveCharacter();
            DoSaveInventory();
            Debug.Log($"save data to path:{Application.persistentDataPath}");
            PlayerPrefs.Save();
        }

        public void AssignInventory(ref List<Item> items)
        {
            if (!_inventoryJson.IsEmpty())
            {
                items.Clear();
                items = ItemSerializer.JsonToItems(_inventoryJson);
            }
        }
        
        private void LoadInventory()
        {
            var inventoryKey = GetLocalStorageKey(Constants.InventoryInfo);
            if (PlayerPrefs.HasKey(inventoryKey))
            {
                _inventoryJson = PlayerPrefs.GetString(inventoryKey);
            }
        }

        public void SaveInventory(List<Item> items)
        {
            _inventoryJson = ItemSerializer.ItemsToJson(items);
            DoSaveInventory(true);
        }

        private void DoSaveInventory(bool immediateSave = false)
        {
            var inventoryKey = GetLocalStorageKey(Constants.InventoryInfo);
            PlayerPrefs.SetString(inventoryKey, _inventoryJson);
            Debug.Log($"set {inventoryKey} = {_inventoryJson}");
            if(immediateSave) PlayerPrefs.Save();
        }

        public void AssignCharacter(ref Character character)
        {
            if(!_characterJson.IsEmpty())
                character.FromJson(_characterJson);
        }
        
        private void LoadCharacter()
        {
            var characterKey = GetLocalStorageKey(Constants.CharacterInfo);
            if (PlayerPrefs.HasKey(characterKey))
            {
                _characterJson = PlayerPrefs.GetString(characterKey);
            }
        }

        public void SaveCharacter(Character character)
        {
            _characterJson = character.ToJson();
            DoSaveCharacter(true);
        }

        private void DoSaveCharacter(bool immediateSave = false)
        { 
            var characterKey = GetLocalStorageKey(Constants.CharacterInfo);
            PlayerPrefs.SetString(characterKey, _characterJson);
            Debug.Log($"set {characterKey} = {_characterJson}");
            if(immediateSave) PlayerPrefs.Save();
        }

        private string GetLocalStorageKey(string bareKey)
        {
            return $"{GetPlayerId()}_{bareKey}";
        }
        
        private string GetPlayerId()
        {
            if (!_playerId.IsEmpty()) return _playerId;

            if (PlayerPrefs.HasKey(Constants.PlayerId))
            {
                _playerId = PlayerPrefs.GetString(Constants.PlayerId);
                return _playerId;
            }

            return LoadPlayerIdForce();
        }

        private string LoadPlayerIdForce()
        {
            _playerId = GeneratePlayerId();
            PlayerPrefs.SetString(Constants.PlayerId, _playerId);
            PlayerPrefs.Save();
            return _playerId;
        }

        private string GeneratePlayerId()
        {
            return Guid.NewGuid().ToString("N");
        }

        private void OnDestroy()
        {
            SaveAllData();
        }
    }
}