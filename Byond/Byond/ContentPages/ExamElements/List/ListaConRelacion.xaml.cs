using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Xamarin.Forms;

namespace Byond
{
	public partial class ListaConRelacion : Grid
	{
		List<string> Items = new List<string>();
		ObservableCollection<ListItem> CurrentItems = new ObservableCollection<ListItem>();
		List<string> Casillas = new List<string>();
		ObservableCollection<ListItem> CurrentCasillas = new ObservableCollection<ListItem>();

		ObservableCollection<ListItem> Respuestas = new ObservableCollection<ListItem>();


		public ListaConRelacion()
		{
			InitializeComponent();

			_listItems.ListView.ItemSelected += (sender, e) =>
			{
				//System.Diagnostics.Debug.WriteLine("asd");
				if (e.SelectedItem == null)
					return;

				//System.Diagnostics.Debug.WriteLine("asd");
				if (_listCasillas.SelectedItem != null)
				{
					var x = _listItems.SelectedItem;
					var y = _listCasillas.SelectedItem;

					CurrentItems.Remove(x);
					CurrentCasillas.Remove(y);


					var z = x + " - " + y;
					Respuestas.Add(new ListItem()
					{
						Value = z,
					});

					_listItems.ListView.SelectedItem = null;
					_listCasillas.ListView.SelectedItem = null;
				}
			};

			_listItems.ListView.ItemTapped += (sender, e) =>
			{
				if (_listItems.SelectedItem != null && (e.Item != null) && (e.Item == _listItems.SelectedItem))
				{

				}
			};

			_listCasillas.ListView.ItemSelected += (sender, e) =>
			{

				if (e.SelectedItem == null)
					return;

				//System.Diagnostics.Debug.WriteLine("asd");
				if (_listItems.SelectedItem != null)
				{
					var x = _listItems.SelectedItem as ListItem;
					var y = _listCasillas.SelectedItem as ListItem;

					CurrentItems.Remove(x);
					CurrentCasillas.Remove(y);


					var z = x.Value + " - " + y.Value;
					Respuestas.Add(new ListItem()
					{
						Value = z,
					});

					_listItems.ListView.SelectedItem = null;
					_listCasillas.ListView.SelectedItem = null;
				}
			};


			_listRespuestas.ItemSelected += (sender, e) =>
			{
				if (e.SelectedItem == null)
					return;
				_listRespuestas.SelectedItem = null;
			};
		}


		public void SetItems(string titulo, List<string> items, List<string> casillas)
		{
			_titulo.Text = titulo;

			_listItems.Label.Text = "ITEMS";

			Items = items;
			CurrentItems = new ObservableCollection<ListItem>();
			foreach (var item in Items)
				CurrentItems.Add(new ListItem() { Value = item });
			_listItems.Values = CurrentItems;

			_listCasillas.Label.Text = "CASILLAS";

			Casillas = casillas;
			CurrentCasillas = new ObservableCollection<ListItem>();
			foreach (var item in Casillas)
				CurrentCasillas.Add(new ListItem() { Value = item });
			_listCasillas.Values = CurrentCasillas;

			_listRespuestas.ItemsSource = Respuestas;

		}
	}
}
