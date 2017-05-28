using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Xamarin.Forms;

namespace Byond
{
	public partial class Topics : BasePage
	{
		public static List<Topic> _temas = null;
		ObservableCollection<Topic> _itemsList = new ObservableCollection<Topic>();
		Dictionary<int, Topic> _pedidosDict = new Dictionary<int, Topic>();
		public Datum _curso = null;

		public Topics(Datum curso)
		{
			InitializeComponent();
			_curso = curso;
			cursename.Text = curso.nombre;

			NavigationPage.SetHasNavigationBar(this, false);
		}


		protected override void OnAppearing()
		{
			base.OnAppearing();
			GetTemas();
		}

		async void GetTemas()
		{
			ShowProgress("Actualizando temas");
			_temas = await ClientByond.Temas(_curso.id_Curso + "");
			if (_temas != null)
			{
				_temas = _temas.ToList(); 
				_itemsList.Clear();
				foreach (var item in _temas)
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

		async void BackTapped(object sender, System.EventArgs e)
		{
			await Navigation.PopAsync();
		}

		async void TapItem(object sender, System.EventArgs e)
		{
			var stack = (StackLayout)sender;
			await stack.ScaleTo(0.9, 100, Easing.SinIn);
			await stack.ScaleTo(1, 100, Easing.SinIn);
			if (stack.BindingContext is Topic)
			{
				var topic = stack.BindingContext as Topic;

				await Navigation.PushAsync(new Subtema(topic));
			}
		}
	}
}
