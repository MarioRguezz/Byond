using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Xamarin.Forms;

namespace Byond
{
	public partial class Subtema : BasePage
	{
		public static List<Subtemas> _subtemas = null;
		ObservableCollection<Subtemas> _itemsList = new ObservableCollection<Subtemas>();
		public Topic _tema = null;
		public ResponseExam _exam = null;
		public Boolean all = true;
		public Subtema(Topic tema)
		{
			InitializeComponent();
			_tema = tema;
			topicname.Text = _tema.Nombre;
			NavigationPage.SetHasNavigationBar(this, false);
		}


		protected override void OnAppearing()
		{
			base.OnAppearing();
			GetSubtemas();
			GetExam();
		}

		async void GetSubtemas()
		{
			var user = PropertiesManager.GetUserInfo();
			ShowProgress("Actualizando subtemas");
			_subtemas = await ClientByond.Subtemas(_tema.IDex + "", user.api_token);
			if (_subtemas != null)
			{
				_subtemas = _subtemas.ToList();
				_itemsList.Clear();
				foreach (var item in _subtemas)
				{
					if (item.visto == false)
					{
						_itemsList.Add(item);
						all = false;
						break;
					}
					else if (item.visto == true)
					{
						_itemsList.Add(item);
					}
				}

				Device.BeginInvokeOnMainThread(() =>
				{
					if (ListView.ItemsSource != _itemsList)
						ListView.ItemsSource = _itemsList;
				});
			}

			HideProgress();
		}

		async void GetExam()
		{

			var user = PropertiesManager.GetUserInfo();
			ShowProgress("Actualizando subtemas");
			_exam = await ClientByond.Exam(_tema.IDex);
			if (_exam != null)
			{
				if (_exam.data != null && _exam.data.preguntas.Count > 0)
				{
					var x = _exam.data.preguntas[0].JsonObject;
				}
				examen.IsVisible = true;
			}

			HideProgress();
		}

		async void BackTapped(object sender, System.EventArgs e)
		{
			await Navigation.PopAsync();

		}

		async void exam(object sender, System.EventArgs e)
		{
			if (all) //si todos los temas vistos
			{
				await Navigation.PushAsync(new Exam(_exam));
			}
			else
			{
				DisplayAlert("Byond", "Complete todas las actividades", "Aceptar");
			}
		}



		async void TapItem(object sender, System.EventArgs e)
		{
			var stack = (StackLayout)sender;
			await stack.ScaleTo(0.9, 100, Easing.SinIn);
			await stack.ScaleTo(1, 100, Easing.SinIn);
			if (stack.BindingContext is Subtemas)
			{
				var subtema = stack.BindingContext as Subtemas;

				await Navigation.PushAsync(new Activity(subtema));
			}
		}
	}
}






