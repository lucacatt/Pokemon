using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Pokemon
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int posScelta = 0;
        Pokemons p = new Pokemons();
        public MainWindow()
        {
            InitializeComponent();
            Tipi.Instance.leggi(AppDomain.CurrentDomain.BaseDirectory + "tipi.txt");
            p.leggi(AppDomain.CurrentDomain.BaseDirectory + "pokemon.txt");
            showImg(p.getImg(posScelta));
        }

        private void btnIdietro_Click(object sender, RoutedEventArgs e)
        {
            if (posScelta > 0)
            {
                posScelta--;
                var fullFilePath = p.getImg(posScelta);
                showImg(fullFilePath);
            }
        }
        private void showImg(string fullFilePath)
        {
            BitmapImage bitmap = new BitmapImage();
            bitmap.BeginInit();
            bitmap.UriSource = new Uri(fullFilePath, UriKind.Absolute);
            bitmap.EndInit();
            pkm.Source = bitmap;
        }

        private void btnAvanti_Click(object sender, RoutedEventArgs e)
        {
            if (posScelta < p.getSize() - 1)
            {
                posScelta++;
                var fullFilePath = p.getImg(posScelta);
                showImg(fullFilePath);
            }
        }

        private void btnSeleziona_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnStats_Click(object sender, RoutedEventArgs e)
        {
            Statistiche s = new Statistiche(p.getPkm(posScelta));
            s.Show();
        }
    }
}
