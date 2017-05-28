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
		List<Opcion> listaOpciones;

		public Exam(ResponseExam exam)
		{
			InitializeComponent();
			NavigationPage.SetHasNavigationBar(this, false);
			//exam
		}

		protected override void OnAppearing()
		{
			base.OnAppearing();
			BackgroundImage = "FONDO2.png";
			AddItems();
			GetExam();
		}

		async void GetExam()
		{



		}



		void AddItems()
		{
			listaOpciones = new List<Opcion>();

			#region items

			listaOpciones.Add(new Opcion()
			{
				Tipo = EncuestaElemento.Label,
				Label = "Label Izquierda",
				HorizontalOption = LayoutOptions.Start,
			});

			listaOpciones.Add(new Opcion()
			{
				Tipo = EncuestaElemento.Label,
				Label = "Label Centrado",
				HorizontalOption = LayoutOptions.Center,
			});

			listaOpciones.Add(new Opcion()
			{
				Tipo = EncuestaElemento.Label,
				Label = "Label Derecha",
				HorizontalOption = LayoutOptions.End,
			});

			listaOpciones.Add(new Opcion()
			{
				Tipo = EncuestaElemento.Separador,
			});

			listaOpciones.Add(new Opcion()
			{
				Tipo = EncuestaElemento.Label,
				Label = "TextBox:",
			});

			listaOpciones.Add(new Opcion()
			{
				Tipo = EncuestaElemento.TextBox,
				Label = "TextBox1",
			});

			listaOpciones.Add(new Opcion()
			{
				Tipo = EncuestaElemento.TextBox,
				Label = "TextBox2",
				Values = new List<string>(){
					"con valor por default"
				},
			});

			listaOpciones.Add(new Opcion()
			{
				Tipo = EncuestaElemento.Separador,
			});

			listaOpciones.Add(new Opcion()
			{
				Tipo = EncuestaElemento.CheckBox,
				Label = "CheckBox",
				Values = new List<string>(){
					"opcion sola",
				},
			});

			listaOpciones.Add(new Opcion()
			{
				Tipo = EncuestaElemento.CheckBox,
				Label = "CheckBoxs",
				Values = new List<string>(){
					"opcion 1",
					"opcion 2",
					"opcion 3",
				},
			});

			listaOpciones.Add(new Opcion()
			{
				Tipo = EncuestaElemento.Separador,
			});

			listaOpciones.Add(new Opcion()
			{
				Tipo = EncuestaElemento.RadioButton,
				Label = "RadioButton",
				Values = new List<string>(){
					"opcion sola",
				},
			});

			listaOpciones.Add(new Opcion()
			{
				Tipo = EncuestaElemento.RadioButton,
				Label = "CheckBoxs",
				Values = new List<string>(){
					"opcion 1",
					"opcion 2",
					"opcion 3",
				},
			});

			listaOpciones.Add(new Opcion()
			{
				Tipo = EncuestaElemento.Separador,
			});

			listaOpciones.Add(new Opcion()
			{
				Tipo = EncuestaElemento.DropDown,
				Label = "DropDown",
				Values = new List<string>(){
					"opcion 1",
					"opcion 2",
					"opcion 3",
				},
			});

			listaOpciones.Add(new Opcion()
			{
				Tipo = EncuestaElemento.Separador,
			});


			listaOpciones.Add(new Opcion()
			{
				Tipo = EncuestaElemento.ListBox,
				Label = "ListBox",
				Values = new List<string>(){
					"opcion 1",
					"opcion 2",
					"opcion 3",
				},
			});

			#endregion


			RenderEncuesta();
		}


		async void RenderEncuesta()
		{
			foreach (var opcion in listaOpciones)
			{
				switch (opcion.Tipo)
				{
					case EncuestaElemento.Label:

						var label = new Label();
						label.Text = opcion.Label;
						label.HorizontalOptions = opcion.HorizontalOption;
						Container.Children.Add(label);

						break;
					case EncuestaElemento.TextBox:

						var input = new OpcionInput();
						input.Label.Text = opcion.Label;

						if (opcion.Values != null && opcion.Values.Count > 0)
							input.Entry.Text = opcion.Values[0];

						Container.Children.Add(input);

						break;
					case EncuestaElemento.CheckBox:

						if (opcion.Values != null)
						{
							var checkBoxGroup = new CheckBoxGroup(opcion.Values.ToArray());
							checkBoxGroup.Label.Text = opcion.Label;
							Container.Children.Add(checkBoxGroup);
						}


						break;
					case EncuestaElemento.RadioButton:

						if (opcion.Values != null)
						{
							var radioGroup = new RadioButtonGroup(opcion.Values.ToArray());
							radioGroup.Label.Text = opcion.Label;
							Container.Children.Add(radioGroup);
						}


						break;
					case EncuestaElemento.DropDown:

						if (opcion.Values != null)
						{
							var dropDown = new DropDown();
							dropDown.Label.Text = opcion.Label;
							dropDown.Values = opcion.Values;
							Container.Children.Add(dropDown);
						}

						break;
					case EncuestaElemento.ListBox:


						//var listView = new ListView ();
						//listView.HeightRequest = opcion.Values.Count * 50;
						//listView.ItemsSource = opcion.Values;
						//listView.RowHeight = 50;

						var listBox = new ListBox();
						listBox.Label.Text = opcion.Label;
						//listBox.Values = opcion.Values;

						Container.Children.Add(listBox);

						break;
					case EncuestaElemento.Separador:

						var boxView = new BoxView()
						{
							HeightRequest = 1,
							HorizontalOptions = LayoutOptions.FillAndExpand,
							BackgroundColor = Color.Gray,
						};

						Container.Children.Add(boxView);

						break;
				}

				//await Task.Delay (300);
			}
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


	class Opcion
	{
		public EncuestaElemento Tipo { get; set; }
		public string Label { get; set; }
		public List<string> Opciones { get; set; }
		public List<string> Values { get; set; }
		public LayoutOptions HorizontalOption { get; set; }
	}

	enum EncuestaElemento
	{
		Label,
		TextBox,
		CheckBox,
		RadioButton,
		DropDown,
		ListBox,
		Separador,
	}

}



