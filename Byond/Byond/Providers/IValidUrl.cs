using System;
using System.Globalization;
using Xamarin.Forms;

namespace Byond
{
	public interface IValidUrl
	{
		bool Valid(string url);
	}
}