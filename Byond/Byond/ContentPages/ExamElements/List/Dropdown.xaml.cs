using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Byond
{
	public partial class DropDown : ContentView
	{

		public Label Label
		{
			get
			{
				return LabelRef;
			}
		}

		public IList<string> Values
		{
			get
			{
				return PickerRef.Items;
			}
			set
			{

				PickerRef.Items.Clear();

				foreach (var item in value)
				{
					PickerRef.Items.Add(item);
				}
			}
		}

		public DropDown()
		{
			InitializeComponent();
		}
	}
}


