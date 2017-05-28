using System;

using Xamarin.Forms;

namespace Byond
{
	public class RadioButton : Image
	{
		private bool isOn;
		private int optionId;

		public RadioButton(int number)
		{
			Source = "unchecked.png";
			WidthRequest = HeightRequest = 25;

			isOn = false;
			optionId = number;
		}

		public bool IsChecked()
		{
			return isOn;
		}

		private void ToggleCheckbox()
		{
			if (isOn)
			{
				Source = "unchecked.png";
			}
			else
			{
				Source = "checked.png";
			}

			isOn = !isOn;
		}
		public int GetOptionId()
		{
			return optionId;
		}

		public void TurnRadioButtonOn()
		{
			Source = "checked.png";
			isOn = true;
		}

		public void TurnRadioButtonOff()
		{
			Source = "unchecked.png";
			isOn = false;
		}
	}
}
