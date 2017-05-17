/*
 * Creado por SharpDevelop.
 * Usuario: tetra
 * Fecha: 05/17/2017
 * Hora: 21:35
 * Licencia GNU GPL V3
 * Para cambiar esta plantilla use Herramientas | Opciones | Codificación | Editar Encabezados Estándar
 */
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using Gabriel.Cat.Extension;
using PokemonGBAFrameWork;
namespace UniversalEditorPokemon
{
	/// <summary>
	/// Interaction logic for EditorPokemon.xaml
	/// </summary>
	public partial class EditorPokemon : UserControl
	{
		Pokemon pokemonActual;
		RomData rom;
		
		public EditorPokemon()
		{
			InitializeComponent();
		}

		public RomData Rom {
			get {
				return rom;
			}
			set {
				rom = value;
			}
		}

		public Pokemon PokemonActual {
			get {
				return pokemonActual;
			}
			set {
				Guardar();
				pokemonActual = value;
				PonPokemon();
			}
		}
		public void Guardar()
		{
			if(Rom!=null&&PokemonActual!=null){
				
				//información básica
				PokemonActual.Nombre.Texto=tbxNombre.Text;
				PokemonActual.Descripcion.Descripcion=tbxDescripcion.Text;
				PokemonActual.Descripcion.Altura=(short)(Convert.ToInt32(tbxAltura.Text)*100);
				PokemonActual.Descripcion.Peso=(short)(Convert.ToInt32(tbxPeso.Text)*100);
				
				Pokemon.SetPokemon(Rom,PokemonActual);
			}
		}

		void PonPokemon()
		{
			imgPokemon.SetImage(PokemonActual.Sprites.SpritesFrontales[0]);
			tbxNombre.Text=PokemonActual.Nombre;
			tbxDescripcion.Text=PokemonActual.Descripcion.Descripcion;
			tbxAltura.Text=(PokemonActual.Descripcion.Altura/100.0)+"";
			tbxPeso.Text=(PokemonActual.Descripcion.Peso/100.0)+"";
			
		}
	}
}