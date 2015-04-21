using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls.Primitives;
using System.Windows.Media;

namespace WpfIntro
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public List<ObiektDanych> Kolekcja { get; set; }

		public ObiektDanych WybranyObiekt { get; set; }

		public MainWindow()
		{
			InitializeComponent();

			Kolekcja = Generator.ObiektyDanych;

			DataContext = this;
		}

		private void ZapiszObiektDanych(object sender, RoutedEventArgs e)
		{
			if (WybranyObiekt != null)
				MessageBox.Show(string.Format("Zapiszę obiekt \"{0}\"", WybranyObiekt.Nazwa));
			else
				MessageBox.Show("Nie wybrano obiektu!");
		}

		private void ZmieńKolorTła(object sender, RoutedEventArgs e)
		{
			var przycisk = sender as ButtonBase;
			if (przycisk == null)
				return;

			płótno.Background = przycisk.Tag as Brush;
		}
	}
}
