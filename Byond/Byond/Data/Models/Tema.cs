using System;
using System.IO;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Byond
{



	public class Topic
	{
		public int IDex { get; set; }
		public int id_Curso { get; set; }
		public string id_Tema { get; set; }
		public string Nombre { get; set; }
		public string fecha { get; set; }
		public object created_at { get; set; }
		public object updated_at { get; set; }
	}

	public class ResponseTopic
	{
		public bool success { get; set; }
		public int status { get; set; }
		public List<object> errors { get; set; }
		public List<Topic> data { get; set; }
	}
}