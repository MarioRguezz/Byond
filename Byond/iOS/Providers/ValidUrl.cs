using System;
using UIKit;
using Foundation;
using Xamarin.Forms;
using Byond.iOS;

[assembly: Dependency(typeof(ValidUrl))]
namespace Byond.iOS
{
	public class ValidUrl : IValidUrl
	{
		public bool Valid(string url)
		{
			var valid = UIApplication.SharedApplication.CanOpenUrl(new NSUrl(url));
			return valid;
		}
	}
}