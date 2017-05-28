using System;
using System.IO;
using System.Collections.Generic;
using Newtonsoft.Json;


namespace Byond
{

	public class Pregunta
	{
		public int ID_Pregunta { get; set; }
		public int tipo { get; set; }
		public int ID_Examen { get; set; }
		public string ID_Subtema { get; set; }
		public string json { get; set; }
		public string titulo { get; set; }
		public string created_at { get; set; }
		public string updated_at { get; set; }
	}

	public class Examen
	{
		public int Idesx { get; set; }
		public string ID_Examen { get; set; }
		public string id_Tema { get; set; }
		public string created_at { get; set; }
		public string updated_at { get; set; }
		public int id_Subtema { get; set; }
		public List<Pregunta> preguntas { get; set; }
	}

	public class ResponseExam
	{
		public bool success { get; set; }
		public List<object> errors { get; set; }
		public int status { get; set; }
		public Examen data { get; set; }
	}

}