using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Pokemon
{
    /// <summary>
    /// Logica di interazione per Statistiche.xaml
    /// </summary>
    public partial class Statistiche : Window
    {
        public Statistiche()
        {
            InitializeComponent();
        }
        public Statistiche(Pokem pokemon)
        {
            InitializeComponent();
            Uri uri = new Uri(AppDomain.CurrentDomain.BaseDirectory + "sfondo_stat.png");
            BitmapImage img = new BitmapImage(uri);
            ImageBrush brush = new ImageBrush(img);
            this.Background = brush;
            lblTipo.BorderBrush = Brushes.Black;
            lblTipo2.BorderBrush = Brushes.Black;
            lblnome.Content = pokemon.Nome;
            lblAtk.Content = pokemon.Atk;
            lblDf.Content = pokemon.Def;
            lblHp.Content = pokemon.Hp;
            lblTipo.Content = pokemon.Tipo[0].nome.ToUpper();
            BitmapImage bitmap = new BitmapImage();
            bitmap.BeginInit();
            bitmap.UriSource = new Uri(pokemon.imgFront, UriKind.Absolute);
            bitmap.EndInit();
            img_pkm.Stretch = Stretch.Fill;
            img_pkm.StretchDirection = StretchDirection.Both;
            img_pkm.Source = bitmap;
            bitmap = new BitmapImage();
            bitmap.BeginInit();
            bitmap.UriSource = new Uri(pokemon.imgBack, UriKind.Absolute);
            bitmap.EndInit();
            img_pkm_b.Stretch = Stretch.Fill;
            img_pkm_b.StretchDirection = StretchDirection.Both;
            img_pkm_b.Source = bitmap;
            if (pokemon.Tipo[0].nome == "buio")
            {
                lblTipo.Foreground = Brushes.White;
            }
            else if (pokemon.Tipo[1].nome == "buio")
            {
                lblTipo2.Foreground = Brushes.White;
            }
            lblTipo.Background = new BrushConverter().ConvertFromString(pokemon.Tipo[0].colore) as SolidColorBrush;
            if (pokemon.Tipo.Count == 2)
            {
                lblTipo2.Content = pokemon.Tipo[1].nome.ToUpper();
                lblTipo2.Background = new BrushConverter().ConvertFromString(pokemon.Tipo[1].colore) as SolidColorBrush;
            }
            mossa1.Fill = new BrushConverter().ConvertFromString(pokemon.Mosse[0].tipo.colore) as SolidColorBrush;
            mossa2.Fill = new BrushConverter().ConvertFromString(pokemon.Mosse[1].tipo.colore) as SolidColorBrush;
            mossa3.Fill = new BrushConverter().ConvertFromString(pokemon.Mosse[2].tipo.colore) as SolidColorBrush;
            mossa4.Fill = new BrushConverter().ConvertFromString(pokemon.Mosse[3].tipo.colore) as SolidColorBrush;
            n1.Content = pokemon.Mosse[0].nome;
            n2.Content = pokemon.Mosse[1].nome;
            n3.Content = pokemon.Mosse[2].nome;
            n4.Content = pokemon.Mosse[3].nome;
            lbltipom1.Content = pokemon.Mosse[0].tipo.nome.ToUpper();
            lbltipom2.Content = pokemon.Mosse[1].tipo.nome.ToUpper();
            lbltipom3.Content = pokemon.Mosse[2].tipo.nome.ToUpper();
            lbltipom4.Content = pokemon.Mosse[3].tipo.nome.ToUpper();
            d1.Content = pokemon.Mosse[0].danno;
            d2.Content = pokemon.Mosse[1].danno;
            d3.Content = pokemon.Mosse[2].danno;
            d4.Content = pokemon.Mosse[3].danno;
            e1.Content = pokemon.Mosse[0].effetto;
            e2.Content = pokemon.Mosse[1].effetto;
            e3.Content = pokemon.Mosse[2].effetto;
            e4.Content = pokemon.Mosse[3].effetto;
        }
    }
}
