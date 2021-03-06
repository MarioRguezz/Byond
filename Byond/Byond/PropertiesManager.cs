﻿using System;
using Newtonsoft.Json;
using Xamarin.Forms;

namespace Byond
{
	public class PropertiesManager
	{

		static string USER_INFO_KEY = "USER_INFO";

		public static bool IsLogedIn()
		{
			if (Application.Current.Properties.ContainsKey(USER_INFO_KEY))
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		public static async void SaveUserInfo(Data user)
		{
			Application.Current.Properties[USER_INFO_KEY] = JsonConvert.SerializeObject(user);
			await Application.Current.SavePropertiesAsync();
		}

		public static Data GetUserInfo()
		{
			if (IsLogedIn())
			{
				var userJson = Application.Current.Properties[USER_INFO_KEY].ToString();
				return JsonConvert.DeserializeObject<Data>(userJson);
			}

			return null;
		}

		public static async void LogOut()
		{
			Application.Current.Properties.Remove(USER_INFO_KEY);
			await Application.Current.SavePropertiesAsync();
		}
	}
}