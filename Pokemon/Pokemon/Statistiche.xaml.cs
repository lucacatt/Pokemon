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
            //string a = "Yellow";
            InitializeComponent();
            lblnome.Content = pokemon.Nome.ToUpper();
            lblAtk.Content = pokemon.Atk;
            lblDf.Content = pokemon.Def;
            lblHp.Content = pokemon.Hp;
            //lblHp.BorderThickness= new Thickness(3, 3, 3, 3);
            //lblHp.BorderBrush = new BrushConverter().ConvertFromString(a) as SolidColorBrush; ;
        }
    }
}
