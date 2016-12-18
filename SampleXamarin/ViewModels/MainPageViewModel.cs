using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Collections.ObjectModel;
using System.Diagnostics;
using Realms;

namespace SampleXamarin.ViewModels
{
	public class MainPageViewModel : BindableBase, INavigationAware
	{

		public MainPageViewModel(IPageDialogService pageDialogService)
		{
			var realm = Realm.GetInstance();
			var items = realm.All<ItemData>();
			foreach (var item in items)
			{
				Items.Add(item);
			}

			SendCommand = new DelegateCommand(() =>
			{
				if (_text != null)
				{
					realm.Write(() =>
					{
						var Item = realm.CreateObject<ItemData>();
						Item.Id = items.Count();
						Item.Message = _text;

						Items.Add(Item);
					});

					items = realm.All<ItemData>();
					Debug.WriteLine(items.Count());

				}
				else
				{
					return;
				}
			});
		}

		// input text
		private string _text;
		public string Text { get { return _text; } set { SetProperty(ref _text, value); } }

		public ObservableCollection<ItemData> Items { get; set; } = new ObservableCollection<ItemData> { };

		// send button
		public DelegateCommand SendCommand { get; }

		public void OnNavigatedFrom(NavigationParameters parameters)
		{

		}

		public void OnNavigatedTo(NavigationParameters parameters)
		{
			
		}
	}
}

