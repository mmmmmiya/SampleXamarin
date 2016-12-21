using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using Realms;

namespace SampleXamarin.Services
{
	public interface IItemDataService
	{
		ObservableCollection<ItemData> GetAll();
		ItemData GetById(int id);
		void Insert(ItemData itemData);
		void Delete(int id);
	}

	public class ItemDataService : IItemDataService
	{
		private Realm realm;
		public ItemDataService()
		{
			realm = Realm.GetInstance();
		}

		public ObservableCollection<ItemData> GetAll()
		{
			var items = realm.All<ItemData>().ToList();
			foreach (var item in items)
			{
				Debug.WriteLine("["+item.Id+"]:"+item.Message);
			}
			return new ObservableCollection<ItemData>(items);
		}

		public ItemData GetById(int id)
		{
			return realm.All<ItemData>().ToList().FirstOrDefault(i => i.Id == id);
		}

		public void Delete(int id)
		{
			var item = realm.All<ItemData>().ToList().FirstOrDefault(i => i.Id == id);
			if (item == null)
			{
				return;
			}

			using (var trans = realm.BeginWrite())
			{
				realm.Remove(item);
				trans.Commit();
			}
		}

		public void Insert(ItemData itemData)
		{
			realm.Write(() =>
			{
				var Item = realm.CreateObject<ItemData>();
				Item.Id = itemData.Id;
				Item.Message = itemData.Message;
			});
		}
	}
}