using System;
namespace Byond
{
	public enum WEB_METHODS
	{
		Autenticate,
		Cursos,
		CrearUsuario,
		Temas,
		Subtemas,
		Examen,
		SubtemaVisto,
		Respuesta
	}

	public enum WEB_ERROR
	{
		Error,
		NoError,
		EmailExists,
		ParseError,
		ServerError
	}

	public class Config
	{
		public static string URL = "http://localhost/Seminarios/public/api/";

		public static string GetURLForMethod(WEB_METHODS method)
		{

			switch (method)
			{
				case WEB_METHODS.Autenticate:
					return "usuarios/login";
				case WEB_METHODS.Cursos:
					return "cursos/get?";
				case WEB_METHODS.CrearUsuario:
					return "usuario/create";
				case WEB_METHODS.Temas:
					return "temas/get?";
				case WEB_METHODS.Subtemas:
					return "temas/subtemas?";
				case WEB_METHODS.Examen:
					return "temas/examen?";
				case WEB_METHODS.SubtemaVisto:
					return "temas/subtema-visto";
				case WEB_METHODS.Respuesta:
					return "temas/contestar-examen";



				default:

					break;
			}

			return null;
		}

	}
}
