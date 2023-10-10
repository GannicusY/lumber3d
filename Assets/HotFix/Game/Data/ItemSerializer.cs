using System;
using System.Collections.Generic;
using System.Linq;
using Assets.HeroEditor.Common.Scripts.Common;
using Assets.HeroEditor.InventorySystem.Scripts.Data;
using Assets.HeroEditor.InventorySystem.Scripts.Enums;
using UnityEngine;

namespace _Game.Scripts.Data
{
    /// <summary>
    /// Class for storing inventory data
    /// </summary>
    [Serializable]
    public class InventoryData
    {
        public List<Item> items;
    }
    
    public static class ItemSerializer
    {
        public static string ItemsToJson(List<Item> items)
        {
            var inventoryData = new InventoryData
            {
                items = items
            };

            return JsonUtility.ToJson(inventoryData);
        }

        public static List<Item> JsonToItems(string jsonItemsString)
        {
            return JsonUtility.FromJson<InventoryData>(jsonItemsString).items;
        }
    }
}