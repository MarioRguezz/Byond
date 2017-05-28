using System;
using System.IO;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Byond
{

public class Pivot
{
	public string Mat_Alumno { get; set; }
	public int id_Curso { get; set; }
}

public class Datum
{
	public int id_Curso { get; set; }
	public string nombre { get; set; }
	public string porcentaje { get; set; }
	public string estatus { get; set; }
	public Pivot pivot { get; set; }
}

public class ResponseGetCursos
{
	public bool success { get; set; }
	public List<object> errors { get; set; }
	public int status { get; set; }
	public List<Datum> data { get; set; }
}

}