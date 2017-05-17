/*
 * Creado por SharpDevelop.
 * Usuario: tetra
 * Fecha: 17/05/2017
 * Hora: 21:23
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
using Microsoft.Win32;
using PokemonGBAFrameWork;
namespace UniversalEditorPokemon
{
	/// <summary>
	/// Interaction logic for Window1.xaml
	/// </summary>
	public partial class Window1 : Window
	{
		RomData romCargada;
		
		public Window1()
		{
			InitializeComponent();
		}
		void MiCargarRom_Click(object sender, RoutedEventArgs e)
		{
			Image imgPokemon;
			OpenFileDialog openRom=new OpenFileDialog();
			openRom.Filter="Pokemon GBA|*.gba";
			
			if(romCargada!=null&&MessageBox.Show("Quieres guardar los cambios?","Atención",MessageBoxButton.YesNo,MessageBoxImage.Question)==MessageBoxResult.Yes)
				MiGuardarCambios_Click();
			if(openRom.ShowDialog().GetValueOrDefault())
			{
				romCargada=new RomData(openRom.FileName);
				
				epPokemonActual.Rom=romCargada;
				Title="Editando:\t"+romCargada.Rom.Nombre;
				romCargada.Pokedex.Sort();
				ugPokedex.Children.Clear();
				for(int i=0;i<romCargada.Pokedex.Count;i++)
				{
					imgPokemon=new Image();
					imgPokemon.Tag=romCargada.Pokedex[i];
					imgPokemon.SetImage(romCargada.Pokedex[i].Sprites.SpritesFrontales);
					imgPokemon.MouseLeftButtonUp+=PonPokemon;
					ugPokedex.Children.Add(imgPokemon);
					
				}
				epPokemonActual.PokemonActual=romCargada.Pokedex[0];
			}else{
				if(romCargada!=null)
					MessageBox.Show("No se ha cambiado la rom");
				else MessageBox.Show("No hay rom cargada!");
			}
		}

		void PonPokemon(object sender, MouseButtonEventArgs e)
		{
			epPokemonActual.PokemonActual=((Image)sender).Tag as Pokemon;
		}

		void MiGuardarCambios_Click(object sender=null, RoutedEventArgs e=null)
		{
			epPokemonActual.Guardar();
			try{
				romCargada.Rom.Save();
				MessageBox.Show("Se ha guardado correctamente","Todo esta bien",MessageBoxButton.OK,MessageBoxImage.Information);
			}catch{
				MessageBox.Show("No se ha podido guardar en el archivo actual...\n"+romCargada.Rom.BackUp(),"Se ha hecho un backup");
				
			}
		}
		void MiSobre_Click(object sender, RoutedEventArgs e)
		{
			MessageBox.Show("Desarrollador: Pikachu240\nCreditos a los usuarios de Wahack que han hecho posible el desarrollo con su investigacion y tutoriales");
		}
	}
}