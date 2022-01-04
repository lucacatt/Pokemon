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
        Pokemons pScelti = new Pokemons();
        public MainWindow()
        {
            InitializeComponent();

            Tipi.Instance.leggi(AppDomain.CurrentDomain.BaseDirectory + "tipi.txt");
            p.leggi(AppDomain.CurrentDomain.BaseDirectory + "pokemon.txt");
            showImg(p.getImg(posScelta));
            //mod bonfi
            lbl_nome_pkm.Content = p.getPkm(posScelta).Nome;
            Uri uri = new Uri(AppDomain.CurrentDomain.BaseDirectory + "sfondopkm.jpg");
            BitmapImage img = new BitmapImage(uri);
            ImageBrush brush = new ImageBrush(img);
            this.Background = brush;
            Uri uri_b = new Uri(AppDomain.CurrentDomain.BaseDirectory + "freccia_b.png");
            BitmapImage img_b = new BitmapImage(uri_b);
            ImageBrush brush_b = new ImageBrush(img_b);
            btnIdietro.Background = brush_b;
            Uri uri_f = new Uri(AppDomain.CurrentDomain.BaseDirectory + "freccia_f.png");
            BitmapImage img_f = new BitmapImage(uri_f);
            ImageBrush brush_f = new ImageBrush(img_f);
            btnAvanti.Background = brush_f;
            Uri uri_s = new Uri(AppDomain.CurrentDomain.BaseDirectory + "seleziona.png");
            BitmapImage img_s = new BitmapImage(uri_s);
            ImageBrush brush_s = new ImageBrush(img_s);
            btnSeleziona.Background = brush_s;
            Uri uri_l = new Uri(AppDomain.CurrentDomain.BaseDirectory + "lotta.png");
            BitmapImage img_l = new BitmapImage(uri_l);
            ImageBrush brush_l = new ImageBrush(img_l);
            btnLotta.Background = brush_l;
            Uri uri_st = new Uri(AppDomain.CurrentDomain.BaseDirectory + "statistiche.png");
            BitmapImage img_st = new BitmapImage(uri_st);
            ImageBrush brush_st = new ImageBrush(img_st);
            btnStats.Background = brush_st;
        }


        private void btnIdietro_Click(object sender, RoutedEventArgs e)
        {
            if (posScelta > 0)
            {
                posScelta--;
                var fullFilePath = p.getImg(posScelta);
                showImg(fullFilePath);
                //mod bonfi
                lbl_nome_pkm.Content = p.getPkm(posScelta).Nome;
            }
            //mod bonfi
            else
            {
                posScelta = p.getSize() - 1;
                var fullFilePath = p.getImg(posScelta);
                showImg(fullFilePath);
                lbl_nome_pkm.Content = p.getPkm(posScelta).Nome;
            }
        }

        private void showImg(string fullFilePath)
        {
            BitmapImage bitmap = new BitmapImage();
            bitmap.BeginInit();
            bitmap.UriSource = new Uri(fullFilePath, UriKind.Absolute);
            bitmap.EndInit();
            pkm.Stretch = Stretch.Fill;
            pkm.StretchDirection = StretchDirection.Both;
            pkm.Source = bitmap;
        }

        private void btnAvanti_Click(object sender, RoutedEventArgs e)
        {
            if (posScelta < p.getSize() - 1)
            {
                posScelta++;
                var fullFilePath = p.getImg(posScelta);
                showImg(fullFilePath);
                //mod bonfi
                lbl_nome_pkm.Content = p.getPkm(posScelta).Nome;
            }
            //mod bonfi
            else
            {
                posScelta = 0;
                var fullFilePath = p.getImg(posScelta);
                showImg(fullFilePath);
                lbl_nome_pkm.Content = p.getPkm(posScelta).Nome;
            }
        }

        private void btnSeleziona_Click(object sender, RoutedEventArgs e)
        {
            if (pScelti.getPokems().Count < 6)
            {
                pScelti.addPkm(p.getPkm(posScelta));
                lb.Items.Add(p.getPkm(posScelta).Nome);
            }
            else
                MessageBox.Show("Squadra al completo", "Impossibile aggiungere", MessageBoxButton.OK, MessageBoxImage.Warning);
        }

        private void btnStats_Click(object sender, RoutedEventArgs e)
        {
            Statistiche s = new Statistiche(p.getPkm(posScelta));
            s.Show();
        }

        private void btnRimuovi_Click(object sender, RoutedEventArgs e)
        {
            if (lb.SelectedIndex >= 0)
            {
                lb.Items.Remove(lb.SelectedIndex);
                pScelti.remove_pokemon(lb.SelectedIndex);
            }
            else
            {
                MessageBox.Show("Seleziona il pokémon che vuoi togliere dalla squadra", "Impossibile eseguire", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void btnLotta_Click(object sender, RoutedEventArgs e)
        {
            if (pScelti.getPokems().Count == 6)
            {
                if (txtNome.Text != "")
                {
                    Mostra_Squadra pregame = new Mostra_Squadra(pScelti, txtNome.Text);
                    this.Hide();
                    pregame.Show();
                }
                else
                {
                    MessageBox.Show("Inserire il nome", "Impossibile continuare", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
            else
            {
                MessageBox.Show("Completa la squadra", "Impossibile continuare", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
    }
}
