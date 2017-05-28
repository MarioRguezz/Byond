using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

using Xamarin.Forms;

namespace Byond
{
	public partial class Activity : BasePage
	{
		public static readonly Regex YoutubeVideoRegex = new Regex(@"youtu(?:\.be|be\.com)/(?:(.*)v(/|=)|(.*/)?)([a-zA-Z0-9-_]+)", RegexOptions.IgnoreCase);
		Subtemas _subtema = null;
		public string youtubeID = null;
		public Activity(Subtemas subtema)
		{
			InitializeComponent();
			_subtema = subtema;
			subtopicname.Text = _subtema.Nombre;
			NavigationPage.SetHasNavigationBar(this, false);
		}

		protected override void OnAppearing()
		{
			base.OnAppearing();
			if (_subtema.visto != true)
			{
				UpdateView();
			}


			if (_subtema.materialaudio.Count != 0)
			{
				var htmlSource = new HtmlWebViewSource();
				//var corrupted = "..\\/Mat_Audio\\/audio_58d0205cba4143.18511970.mp3";
				var corrupted = _subtema.materialaudio[0].ubica;
				var charsToRemove = new string[] { "\\" };
				foreach (var c in charsToRemove)
				{
					corrupted = corrupted.Replace(c, string.Empty);
				}
				var file = corrupted;
				Regex pattern = new Regex("[.]{2}");
				var url = pattern.Replace(file, "http://localhost/Seminarios/public");
				htmlSource.Html = @"<!DOCTYPE html>
			<html>
				<head>
   				 <title>html5 audio player on iPhone</title>
				    <meta name='viewport' content='width=device-width, initial-scale=1'>
				<style>
				audio::-internal-media-controls-download-button {
				    display:none;
				}
				audio::-webkit-media-controls-enclosure {
				    overflow:hidden;
				}
				audio::-webkit-media-controls-panel {
				    width: calc(100% + 33px);
				}  
				</style>
				</head>
				<body>
					<audio controls style='width:100%;'>
						<source src = '";
				htmlSource.Html += url;
				htmlSource.Html += "' type='audio/mpeg'>\n\t\t\t\t\t\t\tYour browser does not support the audio element.\n\t\t\t\t\t</audio>\n\t\t\t\t</body>\n\t\t\t</html>";
				_webView.Source = htmlSource;
				//{"IDMAudio":12,"id_Subtema":"B8478","ubica":"..\/Mat_Audio\/audio_58d0205cba4143.18511970.mp3","descarga":1}
			}
			else if (_subtema.materialdoc.Count != 0)
			{
				//var urlPDF = "http://www.pdf995.com/samples/pdf.pdf";
				var corrupted = _subtema.materialdoc[0].ubica;
				var charsToRemove = new string[] { "\\" };
				foreach (var c in charsToRemove)
				{
					corrupted = corrupted.Replace(c, string.Empty);
				}
				var file = corrupted;
				Regex pattern = new Regex("[.]{2}");
				var urlPDF = pattern.Replace(file, "http://localhost/Seminarios/public");
				if (Device.OS == TargetPlatform.Android)
				{
					urlPDF = "https://docs.google.com/viewer?url=" + urlPDF;
				}
				_webView.Source = urlPDF;
				//{"IDMDoc":27,"id_Subtema":"X6252","ubica":"..\/Mat_Doc\/pdf_58d01fc4de9a81.97430157.pdf","descarga":1}
			}
			else
			{
				youtubeID = ParseURL(_subtema.materialvideo[0].ubica);
				_webView.Source = "https://www.youtube.com/embed/" + youtubeID;
			}
		}




		async void BackTapped(object sender, System.EventArgs e)
		{
			await Navigation.PopAsync();
		}


		async void UpdateView()
		{
			ShowProgress("Validando");
			var user = PropertiesManager.GetUserInfo();
			var response = await ClientByond.SubtemaVisto(_subtema.id_Subtema, user.Mat_Alumno);
			HideProgress();
		}

		string ParseURL(string v)
		{
			var youtubeMatch =
			new Regex(@"youtu(?:\.be|be\.com)/(?:.*v(?:/|=)|(?:.*/)?)([a-zA-Z0-9-_]+)")
			.Match(v);

			if (youtubeMatch.Success)
			{
				return youtubeMatch.Groups[1].Value;
			}
			else
			{
				return string.Empty;
			}

		}
	}
}





