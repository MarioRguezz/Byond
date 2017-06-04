using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Xamarin.Forms;

namespace Byond
{
	public partial class Exam : BasePage
	{
		public ResponseExam _exam = null;
		//List<Opcion> listaOpciones;
		//List<Object> Respuestas;
		List<Respuestas> Respuestas = new List<Respuestas>();
		List<Object> valoresPregunta = new List<Object>();


		public Exam(ResponseExam exam)
		{
			InitializeComponent();
			NavigationPage.SetHasNavigationBar(this, false);
			_exam = exam;
		}

		protected override void OnAppearing()
		{
			base.OnAppearing();
			BackgroundImage = "FONDO2.png";
			AddItems();
		}

		async void send(object sender, System.EventArgs e)
		{

			var user = PropertiesManager.GetUserInfo();
			ShowProgress("Validando");
			//	var response = await ClientByond.RespuestaExamen("", "","");
			//"data":0
			foreach (var pregunta in valoresPregunta)
			{
				Respuestas _res = new Respuestas();

				if (pregunta is OpcionInput)
				{
					var oinput = pregunta as OpcionInput;
					var x = oinput.Entry.Text;
					_res.id = oinput.id;
					_res.id_pregunta = oinput.id_pregunta+"";
					_res.respuestas = x;
				}

				if (pregunta is RadioButtonGroup)
				{
					var radio = pregunta as RadioButtonGroup;

					var x = radio.SelectedIndex;
					_res.id = radio.id;
					_res.id_pregunta = radio.id_pregunta+"";
					_res.respuestas = x;
				}

				if (pregunta is ListaConRelacion)
				{
					var listaRelacionada = pregunta as ListaConRelacion;
					var lista = new List<RelacionObj>();

					foreach (var item in listaRelacionada.Respuestas)
					{
						lista.Add(new RelacionObj
						{
							item = item.Item,
							casilla = item.Casilla,
						});
					}

					_res.id = listaRelacionada.id;
					_res.id_pregunta = listaRelacionada.id_pregunta+"";
					_res.respuestas = lista;
				}

				Respuestas.Add(_res);
			}
			var response = await ClientByond.RespuestaExamen(user.Mat_Alumno, _exam.data.id_Tema, Respuestas);

			HideProgress();
		}


		void AddItems()
		{

			foreach (var pregunta in _exam.data.preguntas)
			{
				if (pregunta.tipo == 1)
				{

					var input = new OpcionInput();
					input.Label.Text = pregunta.titulo;
					input.Label.TextColor = Color.FromHex("FFF");
					input.id = pregunta.JsonObject.guid;
					input.id_pregunta = pregunta.ID_Pregunta;
					input.Entry.TextChanged += (sender, e) =>
					{
						input.respuestas = e.NewTextValue;
						System.Diagnostics.Debug.WriteLine("INPUT CHANGED: {0}", e.NewTextValue);
					};
					//Respuestas.Add(input);
					valoresPregunta.Add(input);
					_stack.Children.Add(input);
				}

				else if (pregunta.tipo == 2)
				{

					string[] names = new string[pregunta.JsonObject.choices.Count];
					foreach (ChooseObject choice in pregunta.JsonObject.choices)
					{
						for (int i = 0; i < pregunta.JsonObject.choices.Count; i++)
						{
							names[i] = pregunta.JsonObject.choices[i].name;
						}

					}
					var radioGroup = new RadioButtonGroup(names);
					radioGroup.id = pregunta.JsonObject.guid;
					radioGroup.id_pregunta = pregunta.ID_Pregunta;
					radioGroup.Label.Text = pregunta.titulo;
					radioGroup.Label.TextColor = Color.FromHex("FFF");

					radioGroup.ItemSelected += (sender, e) =>
					{

						radioGroup.respuestas = radioGroup.SelectedIndex;
						System.Diagnostics.Debug.WriteLine("RADIO SELECTED: {0} ID: {1}", radioGroup.Values[0], radioGroup.SelectedIndex);
					};
					//	Respuestas.Add(radioGroup);
					valoresPregunta.Add(radioGroup);
					_stack.Children.Add(radioGroup);
				}
				else //tipo 3
				{

					ListItem[] items = new ListItem[pregunta.JsonObject.items.Count];
					foreach (ItemObject choice in pregunta.JsonObject.items)
					{
						for (int i = 0; i < pregunta.JsonObject.items.Count; i++)
						{
							items[i] = new ListItem()
							{
								Value = pregunta.JsonObject.items[i].nombre,
								Item = pregunta.JsonObject.items[i].guid,
							};
						}

					}

					ListItem[] casillas = new ListItem[pregunta.JsonObject.casillas.Count];
					foreach (CasillasObject choice in pregunta.JsonObject.casillas)
					{
						for (int i = 0; i < pregunta.JsonObject.casillas.Count; i++)
						{
							casillas[i] = new ListItem()
							{
								Value = pregunta.JsonObject.casillas[i].nombre,
								Casilla = pregunta.JsonObject.casillas[i].guid,
							};
						}

					}

					var listaRelacionada2 = new ListaConRelacion();
					listaRelacionada2.SetItems(pregunta.titulo, items.ToList(),
											   casillas.ToList());
					listaRelacionada2.BackgroundColor = Color.Transparent;
					listaRelacionada2.id = pregunta.JsonObject.guid;
					listaRelacionada2.id_pregunta = pregunta.ID_Pregunta;

					//Respuestas.Add(listaRelacionada2);
					valoresPregunta.Add(listaRelacionada2);
					_stack.Children.Add(listaRelacionada2);
				}


			}

			NavigationPage.SetHasNavigationBar(this, false);
		}




		async void BackTapped(object sender, System.EventArgs e)
		{
			await Navigation.PopAsync();
		}

		async void exam(object sender, System.EventArgs e)
		{
			if (true) //si todos los temas vistos
			{
				await Navigation.PushAsync(new Exam(_exam));
			}
		}
	}


	public class RelacionObj
	{
		public string casilla { get; set; }
		public string item { get; set; }
	}

}



