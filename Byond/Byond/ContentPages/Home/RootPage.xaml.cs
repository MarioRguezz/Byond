using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Xamarin.Forms;

namespace Byond
{
	public partial class RootPage : BasePage
	{
		public static List<Datum> _cursos = null;

		ObservableCollection<Datum> _itemsList = new ObservableCollection<Datum>();
		public RootPage()
		{
			InitializeComponent();
			var user = PropertiesManager.GetUserInfo();
			username.Text = "Cursos de: " + user.Nombre;

			NavigationPage.SetHasNavigationBar(this, false);
		}

		protected override void OnAppearing()
		{
			base.OnAppearing();
			GetPedidos();
		}

		async void Singout(object sender, System.EventArgs e)
		{
			PropertiesManager.LogOut();
			await Navigation.PushModalAsync(new NavigationPage(new LoginPage()));
		}


		async void GetPedidos()
		{
			ShowProgress("Actualizando cursos");
			_cursos = await ClientByond.Cursos(PropertiesManager.GetUserInfo().api_token);
			if (_cursos != null)
			{
				_cursos = _cursos.ToList();
				_itemsList.Clear();
				foreach (var item in _cursos)
				{
					_itemsList.Add(item);
				}

				Device.BeginInvokeOnMainThread(() =>
				{
					if (ListView.ItemsSource != _itemsList)
						ListView.ItemsSource = _itemsList;
				});
			}

			HideProgress();
		}

		async void TapItem(object sender, System.EventArgs e)
		{
			var stack = (StackLayout)sender;
			await stack.ScaleTo(0.9, 100, Easing.SinIn);
			await stack.ScaleTo(1, 100, Easing.SinIn);
			if (stack.BindingContext is Datum)
			{
				var curso = stack.BindingContext as Datum;

				await Navigation.PushAsync(new Topics(curso));
				//await new NavigationPage(new Topics(curso));
			}
		}
	}
}
