using System;
using System.IO;
using Newtonsoft.Json;

namespace Byond
{

	public class Alumno
	{
		public int Id { get; set; }
		public string Mat_Alumno { get; set; }
		public string fotografia { get; set; }
		public object profesion { get; set; }
		public object institucion { get; set; }
		public object adscripcion { get; set; }
		public string email { get; set; }
		public object constancia { get; set; }
		public int estatus { get; set; }
		public int id_cliente_administrador { get; set; }
		public object created_at { get; set; }
		public object updated_at { get; set; }
		public int IdPersona { get; set; }
	}

	public class Data
	{
		public int IdPersona { get; set; }
		public string APaterno { get; set; }
		public string AMaterno { get; set; }
		public string Nombre { get; set; }
		public string email { get; set; }
		public string TUser { get; set; }
		public string Estado { get; set; }
		public string Municipio { get; set; }
		public string TelOfi { get; set; }
		public string TelCas { get; set; }
		public string Celular { get; set; }
		public string Sexo { get; set; }
		public string Status { get; set; }
		public object institucion { get; set; }
		public string created_at { get; set; }
		public string updated_at { get; set; }
		public object deleted_at { get; set; }
		public string api_token { get; set; }
		public string Mat_Alumno { get; set; }
		public string password { get; set; }
		public Alumno alumno { get; set; }
	}

	public class RootObject
	{
		public Data data { get; set; }
		public int status { get; set; }
		public bool success { get; set; }
	}

}