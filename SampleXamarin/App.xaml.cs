﻿using Prism.Unity;
using SampleXamarin.Views;
using SampleXamarin.Services;
using Xamarin.Forms;

namespace SampleXamarin
{
	public partial class App : PrismApplication
	{
		public App(IPlatformInitializer initializer = null) : base(initializer) { }

		protected override void OnInitialized()
		{
			InitializeComponent();

			NavigationService.NavigateAsync("NavigationPage/MainPage");
		}

		protected override void RegisterTypes()
		{
			Container.RegisterTypeForNavigation<MainPage>();
			Container.RegisterTypeForNavigation<NavigationPage>();
		}
	}
}

