using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace Byond
{
	public partial class OpcionInput : ContentView
	{
		public Label Label
		{
			get
			{
				return LabelRef;
			}
		}

		public Entry Entry
		{
			get
			{
				return TextRef;
			}
		}

		public OpcionInput()
		{
			InitializeComponent();
		}
	}
}

