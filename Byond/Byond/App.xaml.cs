using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace Byond
{
	public partial class App : Application
	{

		public static App CurrentApp { get; set; }

		public App()
		{
			CurrentApp = this;
			InitializeComponent();


			if (PropertiesManager.IsLogedIn())
			{
				MainPage = new NavigationPage(new RootPage());
			}
			else
			{
				MainPage = new NavigationPage(new LoginPage());
			}
		}

		protected override void OnStart()
		{
			// Handle when your app starts
		}

	

		async void Test()
		{
		}

		protected override void OnSleep()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume()
		{
			// Handle when your app resumes
		}
	}
}

