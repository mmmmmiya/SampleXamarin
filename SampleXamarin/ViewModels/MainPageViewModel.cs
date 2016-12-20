﻿using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Collections.ObjectModel;
using System.Diagnostics;
using SampleXamarin.Services;

namespace SampleXamarin.ViewModels
{
	public class MainPageViewModel : BindableBase, INavigationAware
	{
		public MainPageViewModel(IPageDialogService pageDialogService)
		{
			this.PageDialogService = pageDialogService;
			IItemDataService itemDataService = new ItemDataService();
			this.ItemDataService = itemDataService;
			//this.Items = itemDataService.GetAll();
			//this.ItemDataService = itemDataService;

			this.SendCommand = new DelegateCommand(this.AddItemData, () => !string.IsNullOrEmpty(this.Text)).ObservesProperty(() => this.Text);

			//this.DeleteCommand = new DelegateCommand<ItemData>(this.DeleteItemData);
		}

		// PageDialogService
		private IPageDialogService PageDialogService { get; }

		// ItemDataService
		private IItemDataService ItemDataService { get; }

		private int count = 0;

		// input text
		private string _text;
		public string Text { get { return _text; } set { SetProperty(ref _text, value); } }

		// list view data
		public ObservableCollection<ItemData> items;
		public ObservableCollection<ItemData> Items
		{
			get { return this.items; }
			set { this.SetProperty(ref this.items, value); }
		}

		// send button
		public DelegateCommand SendCommand { get; }

		// delete button
		public DelegateCommand<ItemData> DeleteCommand { get; }

		private void AddItemData()
		{
			this.ItemDataService.Insert(new ItemData{Id = count.ToString(), Message = this.Text });
			this.Text = "";
			this.Items = this.ItemDataService.GetAll();
			count++;
		}

		private void DeleteItemData(ItemData itemData)
		{
			this.ItemDataService.Delete(itemData.Id);
			this.Items = this.ItemDataService.GetAll();
		}

		public void OnNavigatedFrom(NavigationParameters parameters)
		{

		}

		public void OnNavigatedTo(NavigationParameters parameters)
		{
		}
	}
}

