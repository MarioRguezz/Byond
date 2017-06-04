using System;
using System.IO;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Byond
{

	public class Subtemas
	{
		public int IDes { get; set; }
		public int id_Curso { get; set; }
		public string id_Tema { get; set; }
		public string id_Subtema { get; set; }
		public string Nombre { get; set; }
		public string Descrip { get; set; }
		public int Orden { get; set; }
		public object created_at { get; set; }
		public object updated_at { get; set; }
		public bool visto { get; set; }
		public List<Audio> materialaudio { get; set; }
		public List<Documento> materialdoc { get; set; }
		public List<Video> materialvideo { get; set; }


		public string Imagen
		{
			get
			{
				var img = "";

				if (materialaudio != null && materialaudio.Count > 0)
				{
					img = "headphones.png";
				}

				if (materialdoc != null && materialdoc.Count > 0)
				{
					img = "file.png";
				}

				if (materialvideo != null && materialvideo.Count > 0)
				{
					img = "play.png";
				}

				return img;
			}
		}

	}


	public class SubtemaVisto
	{
		public string IdSubtema { get; set; }
		public string Mat_Alumno { get; set; }
	}

	public class Audio
	{
		public int IDMAudio { get; set; }
		public string id_Subtema { get; set; }
		public string ubica { get; set; }
		public int descarga { get; set; }
	}

	public class Video
	{
		public int IDMVideo { get; set; }
		public string id_Subtema { get; set; }
		public string ubica { get; set; }
		public int descarga { get; set; }
	}

	public class Documento
	{
		public int IDMDoc { get; set; }
		public string id_Subtema { get; set; }
		public string ubica { get; set; }
		public int descarga { get; set; }
	}

	public class ResponseSub
	{
		public bool success { get; set; }
		public List<object> errors { get; set; }
		public int status { get; set; }
		public List<Subtemas> data { get; set; }
	}


}