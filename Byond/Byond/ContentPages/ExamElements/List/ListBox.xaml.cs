using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Xamarin.Forms;

namespace Byond
{
	public partial class ListBox : ContentView
	{

		public Label Label
		{
			get
			{
				return LabelRef;
			}
		}

		public ListView ListView
		{
			get
			{
				return ListViewRef;
			}
		}

		public ObservableCollection<ListItem> Values
		{
			set
			{
				ListView.ItemsSource = value;
				ListView.HeightRequest = value.Count * 50;
			}
		}

		public ListBox()
		{
			InitializeComponent();
		}

		public ListItem SelectedItem
		{
			get
			{
				if (ListViewRef.SelectedItem != null)
				{
					var item = ListViewRef.SelectedItem as ListItem;
					return item;
				}

				return null;
			}
		}

	}


	public class ListItem
	{
		public string Value { get; set; }
	}
}

