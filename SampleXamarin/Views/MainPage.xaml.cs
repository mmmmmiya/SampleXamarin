using System;
using System.Diagnostics;
using SampleXamarin.ViewModels;
using Xamarin.Forms;

namespace SampleXamarin.Views
{
	public partial class MainPage : ContentPage
	{
		public MainPage()
		{
			InitializeComponent();
		}

		public void OnItemTapped(object sender, SelectedItemChangedEventArgs e)
		{
			if (e.SelectedItem == null)
			{
				return;
			}

			var listView = (ListView)sender;

			var itemData = (ItemData)e.SelectedItem;

			listView.SelectedItem = null;

			Debug.WriteLine("["+itemData.Id+"]:"+itemData.Message);

			var mainPageViewModel = (MainPageViewModel)this.BindingContext;
			mainPageViewModel.DeleteCommand.Execute(itemData);
		}
	}
}

