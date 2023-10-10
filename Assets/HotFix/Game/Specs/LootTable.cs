//----------------------------------------------
//    Auto Generated. DO NOT edit manually!
//----------------------------------------------

#pragma warning disable 649

using System;
using UnityEngine;
using System.Collections.Generic;

namespace HotFix.Game.Specs {

	public partial class LootTable : ScriptableObject {

		public enum eItemType {
			Default, Currency, Loot, Material, Supply, Weapon, Armor, Helmet, Shield
		}

		public enum eItemSubType {
			Default, Sword, Axe, Food, 
		}

		public enum eQuality {
			Default, Legacy, Basic, Common, Rare, Epic, Legendary, 
		}

		[NonSerialized]
		private int mVersion = 1;

		[SerializeField]
		private Loot[] _LootItems;
		public int GetLootItems(List<Loot> items) {
			int len = _LootItems.Length;
			for (int i = 0; i < len; i++) {
				items.Add(_LootItems[i].Init(mVersion, DataGetterObject));
			}
			return len;
		}

		public Loot GetLoot(int id) {
			int min = 0;
			int max = _LootItems.Length;
			while (min < max) {
				int index = (min + max) >> 1;
				Loot item = _LootItems[index];
				if (item.id == id) { return item.Init(mVersion, DataGetterObject); }
				if (id < item.id) {
					max = index;
				} else {
					min = index + 1;
				}
			}
			return null;
		}

		[SerializeField]
		private Item[] _ItemItems;
		public int GetItemItems(List<Item> items) {
			int len = _ItemItems.Length;
			for (int i = 0; i < len; i++) {
				items.Add(_ItemItems[i].Init(mVersion, DataGetterObject));
			}
			return len;
		}

		public Item GetItem(int id) {
			int min = 0;
			int max = _ItemItems.Length;
			while (min < max) {
				int index = (min + max) >> 1;
				Item item = _ItemItems[index];
				if (item.id == id) { return item.Init(mVersion, DataGetterObject); }
				if (id < item.id) {
					max = index;
				} else {
					min = index + 1;
				}
			}
			return null;
		}

		public void Reset() {
			mVersion++;
		}

		public interface IDataGetter {
			Loot GetLoot(int id);
			Item GetItem(int id);
		}

		private class DataGetter : IDataGetter {
			private Func<int, Loot> _GetLoot;
			public Loot GetLoot(int id) {
				return _GetLoot(id);
			}
			private Func<int, Item> _GetItem;
			public Item GetItem(int id) {
				return _GetItem(id);
			}
			public DataGetter(Func<int, Loot> getLoot, Func<int, Item> getItem) {
				_GetLoot = getLoot;
				_GetItem = getItem;
			}
		}

		[NonSerialized]
		private DataGetter mDataGetterObject;
		private DataGetter DataGetterObject {
			get {
				if (mDataGetterObject == null) {
					mDataGetterObject = new DataGetter(GetLoot, GetItem);
				}
				return mDataGetterObject;
			}
		}
	}

	[Serializable]
	public class Loot {

		[SerializeField]
		private int _Id;
		public int id { get { return _Id; } }

		[SerializeField]
		private string _Key;
		public string key { get { return _Key; } }

		[SerializeField]
		private int _Weight;
		public int weight { get { return _Weight; } }

		[NonSerialized]
		private int mVersion = 0;
		public Loot Init(int version, LootTable.IDataGetter getter) {
			if (mVersion == version) { return this; }
			mVersion = version;
			return this;
		}

		public override string ToString() {
			return string.Format("[Loot]{{id:{0}, key:{1}, weight:{2}}}",
				id, key, weight);
		}

	}

	[Serializable]
	public class Item {

		[SerializeField]
		private int _Id;
		public int id { get { return _Id; } }

		[SerializeField]
		private string _Key;
		public string key { get { return _Key; } }

		[SerializeField]
		private LootTable.eItemType _Type;
		public LootTable.eItemType type { get { return _Type; } }

		[SerializeField]
		private LootTable.eItemSubType _Sub_type;
		public LootTable.eItemSubType sub_type { get { return _Sub_type; } }

		[SerializeField]
		private LootTable.eQuality _Rarity;
		public LootTable.eQuality rarity { get { return _Rarity; } }

		[SerializeField]
		private int _Level;
		public int level { get { return _Level; } }

		[SerializeField]
		private int _Price;
		public int price { get { return _Price; } }

		[SerializeField]
		private int _Loss;
		public int loss { get { return _Loss; } }

		[SerializeField]
		private int _Stack;
		public int stack { get { return _Stack; } }

		[SerializeField]
		private string _Desc;
		public string desc { get { return _Desc; } }

		[SerializeField]
		private string _Icon;
		public string icon { get { return _Icon; } }

		[SerializeField]
		private string _Sprite;
		public string sprite { get { return _Sprite; } }

		[NonSerialized]
		private int mVersion = 0;
		public Item Init(int version, LootTable.IDataGetter getter) {
			if (mVersion == version) { return this; }
			mVersion = version;
			return this;
		}

		public override string ToString() {
			return string.Format("[Item]{{id:{0}, key:{1}, type:{2}, sub_type:{3}, rarity:{4}, level:{5}, price:{6}, loss:{7}, stack:{8}, desc:{9}, icon:{10}, sprite:{11}}}",
				id, key, type, sub_type, rarity, level, price, loss, stack, desc, icon, sprite);
		}

	}

}
