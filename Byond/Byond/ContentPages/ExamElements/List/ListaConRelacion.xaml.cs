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

		public ObservableCollection<ListItem> Respuestas = new ObservableCollection<ListItem>();
		public string id { get; set; }
		public int id_pregunta { get; set; }


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


					var z = x.Value + " - " + y.Value;
					Respuestas.Add(new ListItem()
					{
						Value = z,
						Item = x.Item,
						Casilla = y.Casilla,
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
						Item = x.Item,
						Casilla = y.Casilla,
					});

					_listItems.ListView.SelectedItem = null;
					_listCasillas.ListView.SelectedItem = null;
				}
			};


			_listRespuestas.ItemSelected += (sender, e) =>
			{
				if (e.SelectedItem == null)
					return;

				var item = e.SelectedItem as ListItem;

				var str = item.Value.Split('-');
				var strItem = str[0].Trim();
				var strCasilla = str[1].Trim();


				CurrentCasillas.Add(new ListItem()
				{
					Casilla = item.Casilla,
					Value = strCasilla,
				});

				CurrentItems.Add(new ListItem()
				{
					Item = item.Item,
					Value = strItem,
				});

				Respuestas.Remove(item);


				_listRespuestas.SelectedItem = null;
			};
		}


		public void SetItems(string titulo, List<ListItem> items, List<ListItem> casillas)
		{
			_titulo.Text = titulo;
			_titulo.TextColor = Color.FromHex("FFF");

			_listItems.Label.Text = "ITEMS";
			_listItems.Label.TextColor = Color.FromHex("FFF");

			//Items = items;
			CurrentItems = new ObservableCollection<ListItem>();
			foreach (var item in items)
				CurrentItems.Add(item);
			_listItems.Values = CurrentItems;

			_listCasillas.Label.Text = "CASILLAS";
			_listCasillas.Label.TextColor = Color.FromHex("FFF");
			//Casillas = casillas;
			CurrentCasillas = new ObservableCollection<ListItem>();
			foreach (var item in casillas)
				CurrentCasillas.Add(item);
			_listCasillas.Values = CurrentCasillas;

			_listRespuestas.ItemsSource = Respuestas;

		}
	}
}
