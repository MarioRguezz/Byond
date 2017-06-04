using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace Byond
{
	public class RadioButtonGroup : StackLayout
	{

		public event EventHandler ItemSelected;

		List<RadioButton> optionRatingList;
		string[] optionTextArray;
		public Label Label;

		public string id { get; set; }
		public int id_pregunta { get; set; }
		public int respuestas { get; set; }


		public List<string> Values
		{
			get { return (List<string>)GetValue(RatingValuesProperty); }
			set
			{
				SetValue(RatingValuesProperty, value);
			}
		}

		public int SelectedIndex { get; set; }

		public static readonly BindableProperty RatingValuesProperty =
			BindableProperty.Create<RadioButtonGroup, List<string>>(
				ratingView => ratingView.Values,
				new List<string>()
			);


		static string[] defalutValue = new string[] { "" };

		public RadioButtonGroup(string[] options)
		{
			optionRatingList = new List<RadioButton>();
			//optionTextArray = new string []
			//{
			//	"Ventas",
			//	"Imagen",
			//	"Estrategias",
			//	"Otro"
			//};

			if (options != null)
			{
				optionTextArray = options;
			}
			else
			{
				optionTextArray = new string[] { };
			}

			Label = new Label();
			Label.HorizontalTextAlignment = TextAlignment.Center;
			Label.HorizontalOptions = LayoutOptions.FillAndExpand;

			/* Initial setup of RatingValues */
			Values = new List<string>();

			/* Set up view */
			Orientation = StackOrientation.Vertical;
			Spacing = 10;


			var stackChecks = new StackLayout()
			{
				Orientation = StackOrientation.Vertical,
				Spacing = 10,
				HorizontalOptions = LayoutOptions.FillAndExpand,
			};



			/* Add subviews: StackLayouts(horizontal) with checkbox and text */
			for (int i = 1; i <= optionTextArray.Length; i++)
			{
				var option = CreateOption(i);
				var optionStack = CreateOptionStack(option, optionTextArray[i - 1]);

				var vertStack = new StackLayout
				{
					Orientation = StackOrientation.Vertical,
					Spacing = 0,
				};

				vertStack.Children.Add(optionStack);
				if (i < optionTextArray.Length)
					vertStack.Children.Add(new BoxView()
					{
						HeightRequest = 1,
						HorizontalOptions = LayoutOptions.FillAndExpand,
						BackgroundColor = Color.FromHex("CFD0D0"),
					});

				stackChecks.Children.Add(vertStack);
				optionRatingList.Add(option);
			}

			Children.Add(Label);
			Children.Add(stackChecks);
		}

		public List<string> GetRatingValues()
		{
			return Values;
		}

		RadioButton CreateOption(int optionId)
		{
			var option = new RadioButton(optionId)
			{
				HorizontalOptions = LayoutOptions.Start,
				VerticalOptions = LayoutOptions.CenterAndExpand
			};

			return option;
		}

		StackLayout CreateOptionStack(RadioButton option, string optionText, bool last = false)
		{
			var optionStack = new StackLayout
			{
				Orientation = StackOrientation.Horizontal,
				HorizontalOptions = LayoutOptions.FillAndExpand,
				Spacing = 10,
				Padding = 5,
			};
			optionStack.Children.Add(option);
			optionStack.Children.Add(CreateOptionLabel(optionText));
			optionStack.GestureRecognizers.Add(CreateOptionTappedRecognizer());

			return optionStack;
		}

		Label CreateOptionLabel(string optionText)
		{
			var optionLabel = new Label
			{
				Text = optionText,
				TextColor = Color.FromHex("FFF"),
				HorizontalOptions = LayoutOptions.FillAndExpand,
				VerticalTextAlignment = TextAlignment.Center,
				HorizontalTextAlignment = TextAlignment.Start,
			};

			return optionLabel;
		}

		TapGestureRecognizer CreateOptionTappedRecognizer()
		{
			var optionTapEventHandler = new EventHandler(delegate (object sender, EventArgs e)
			{
				var optionStackTapped = (StackLayout)sender;
				var optionTapped = (RadioButton)optionStackTapped.Children[0];
				UpdateRating(optionTapped.GetOptionId());
			});

			var optionTap = new TapGestureRecognizer();
			optionTap.NumberOfTapsRequired = 1;
			optionTap.Tapped += optionTapEventHandler;

			return optionTap;
		}

		void UpdateRating(int optionId)
		{
			foreach (RadioButton radio in optionRatingList)
			{
				radio.TurnRadioButtonOff();
			}

			Values.Clear();


			RadioButton radioButton = optionRatingList[optionId - 1];
			radioButton.TurnRadioButtonOn();
			Values.Add(optionTextArray[optionId - 1]);

			SelectedIndex = optionId;

			if (ItemSelected != null)
				ItemSelected(this, null);

			//if (radioButton.IsChecked ()) {
			//	radioButton.TurnRadioButtonOff ();
			//	Values.Remove (optionTextArray [optionId - 1]);
			//} else {
			//	radioButton.TurnRadioButtonOn ();
			//	Values.Add (optionTextArray [optionId - 1]);
			//}
		}




	}
}
