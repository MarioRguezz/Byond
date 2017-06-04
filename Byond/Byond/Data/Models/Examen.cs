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

		public Json JsonObject
		{
			get
			{
				try
				{
					var x = Newtonsoft.Json.JsonConvert.DeserializeObject<Json>(json);
					return x;
				}
				catch (Exception ex)
				{
					System.Diagnostics.Debug.WriteLine(ex.Message);
				}


				return null;

			}
		}

	}

	public class Examen
	{
		public int Idesx { get; set; }
		public string ID_Examen { get; set; }
		public string id_Tema { get; set; }
		public string created_at { get; set; }
		public string updated_at { get; set; }
		public int? id_Subtema { get; set; }
		public List<Pregunta> preguntas { get; set; }
	}

	//"json": "{\"id\":null,\"inputTitulo\":null,\"guid\":\"f41722f0-076c-6883-e59b-52b4883d8016\",\"respuestas\":[{\"casilla\":\"09922fb1-af1d-bc74-b71f-32cb03d9db0d\",\"item\":\"0197d37e-b5c7-5661-fd62-acd02a67881d\"},{\"casilla\":\"04298678-2580-bf9b-f647-1c040ed52ce3\",\"item\":\"1367b38d-e64c-1973-c098-0589f2846595\"},{\"casilla\":\"6fa46d39-a150-d699-004c-5b1c11d30b39\",\"item\":\"dff83589-7094-a63c-4d24-3756e614250a\"}],\"items\":[{\"nombre\":\"Item1\",\"guid\":\"0197d37e-b5c7-5661-fd62-acd02a67881d\"},{\"nombre\":\"Item2\",\"guid\":\"1367b38d-e64c-1973-c098-0589f2846595\"},{\"nombre\":\"Item3\",\"guid\":\"dff83589-7094-a63c-4d24-3756e614250a\"}],\"casillas\":[{\"nombre\":\"Casilla1\",\"guid\":\"09922fb1-af1d-bc74-b71f-32cb03d9db0d\",\"remove\":{\"0\":{\"jQuery1112085525041434574\":\"80\"},\"length\":\"1\"}},{\"nombre\":\"Casilla2\",\"guid\":\"04298678-2580-bf9b-f647-1c040ed52ce3\",\"remove\":{\"0\":{\"jQuery1112085525041434574\":\"94\"},\"length\":\"1\"}},{\"nombre\":\"Casilla3\",\"guid\":\"6fa46d39-a150-d699-004c-5b1c11d30b39\",\"remove\":{\"0\":{\"jQuery1112085525041434574\":\"98\"},\"length\":\"1\"}}],\"btnLeft\":{\"0\":{\"jQuery1112085525041434574\":\"84\"},\"length\":\"1\"},\"btnRight\":{\"0\":{\"jQuery1112085525041434574\":\"86\"},\"length\":\"1\"},\"contenedor\":{\"length\":\"1\",



	public class Json
	{
		public string id { get; set; }
		public string inputTitulo { get; set; }
		public string guid { get; set; }
		public List<Object> respuestas { get; set; }
		public List<ChooseObject> choices { get; set; }
		public List<ItemObject> items { get; set; }
		public List<CasillasObject> casillas { get; set; }
		public Object btnLeft { get; set; }
		public Object btnRight { get; set; }
		public Contenedor contenedor { get; set; }
	}


	public class ItemObject
	{
		public string nombre { get; set; }
		public string guid { get; set; }
	}

	public class CasillasObject
	{
		public string nombre { get; set; }
		public string guid { get; set; }
	}



	public class ChooseObject
	{
		public string name { get; set; }
		public string guid { get; set; }
		public string value { get; set; }
		public string group { get; set; }

	}

	public class Contenedor
	{
		public string length { get; set; }
	}

	public class ResponseExam
	{
		public bool success { get; set; }
		public List<object> errors { get; set; }
		public int status { get; set; }
		public Examen data { get; set; }
	}

	public class Respuesta
	{
		public string Mat_Alumno { get; set; }
		public string IDTema { get; set; }
		public string Respuestas { get; set; }
	}


	public class Respuestas
	{
		public string id { get; set; }
		public string id_pregunta { get; set; }
		public object respuestas { get; set; }
	}




}