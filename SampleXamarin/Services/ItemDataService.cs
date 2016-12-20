using System;
using System.Collections.ObjectModel;
using System.Linq;
using Realms;

namespace SampleXamarin.Services
{
	public interface IItemDataService
	{
		ObservableCollection<ItemData> GetAll();
		ItemData GetById(string id);
		void Insert(ItemData itemData);
		void Delete(string id);
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
			return new ObservableCollection<ItemData>(items);
		}

		public ItemData GetById(string id)
		{
			return realm.All<ItemData>().ToList().FirstOrDefault(i => i.Id == id);
		}

		public void Delete(string id)
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