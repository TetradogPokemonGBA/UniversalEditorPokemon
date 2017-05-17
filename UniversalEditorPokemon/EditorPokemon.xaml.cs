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
			if(Rom!=null&&PokemonActual!=null)
				Pokemon.SetPokemon(Rom,PokemonActual);
		}

		void PonPokemon()
		{
			throw new NotImplementedException();
		}
	}
}