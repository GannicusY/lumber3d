using System;
using System.Collections.Generic;
using System.Linq;
using Assets.HeroEditor.Common.Scripts.CharacterScripts;
using Assets.HeroEditor.Common.Scripts.Common;
using Assets.HeroEditor.InventorySystem.Scripts.Data;
using Assets.HeroEditor.InventorySystem.Scripts.Enums;
using HeroEditor.Common.Enums;
using UnityEngine;

namespace Assets.HeroEditor.InventorySystem.Scripts.Helpers
{
    public class CharacterInventorySetup
    {
        public static void Setup(Character character, List<Item> equipped)
        {
            character.ResetEquipment();
            
            foreach (var item in equipped)
            {
                character.Equip(item);
            }

            character.GetReady();
            character.Initialize();
        }
    }
}