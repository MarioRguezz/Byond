using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Xamarin.Forms;

namespace Byond
{
	public partial class LoginPage : BasePage
	{
		public LoginPage()
		{
			InitializeComponent();
			NavigationPage.SetHasNavigationBar(this, false);
		}

		public LoginPage(string email)
		{
			InitializeComponent();
			EntryEmail.Text = email;

		}

		bool clicked = false;

		async void LoginClicked(object sender, System.EventArgs e)
		{
			if (clicked)
				return;
			clicked = true;

			if (ValidateUI())
			{
				ShowProgress("Validando");
				var response = await ClientByond.LoginUser(EntryEmail.Text, EntryPass.Text);

				if (ValidateResponse(response))
				{
					var user = JsonConvert.DeserializeObject<RootObject>(response);
					PropertiesManager.SaveUserInfo(user.data);
					ShowProgress(IProgressType.LogedIn);
					await Task.Delay(600);
					HideProgress();
					await Navigation.PushModalAsync(new NavigationPage(new RootPage()));
				}

				HideProgress();
			}

			clicked = false;

		}

		bool ValidateResponse(string response)
		{
			if (ClientByond.IsError(response))
			{
				DisplayAlert("Error","Verifique sus campos","Aceptar");
				return false;
			}
			else
			{
				return true;
			}
		}

		bool ValidateUI()
		{
			if (string.IsNullOrEmpty(EntryEmail.Text) || !Regex.IsMatch(EntryEmail.Text, @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z", RegexOptions.IgnoreCase))
			{
				DisplayAlert("Error", "Verifique su correo", "Aceptar" );

				return false;
			}


			if (string.IsNullOrEmpty(EntryPass.Text))
			{
				DisplayAlert("Error", "Verifique su contraseña","Aceptar" );
				return false;
			}

			return true;
		}
	}
}
