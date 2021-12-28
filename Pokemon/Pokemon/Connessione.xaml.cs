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
    /// Logica di interazione per Connessione.xaml
    /// </summary>
    public partial class Connessione : Window
    {
        Pokemons squadra = new Pokemons();
        public Connessione()
        {
            InitializeComponent();
        }
        public Connessione(Pokemons p)
        {
            InitializeComponent();
            squadra.setPokems(p.getPokems());
        }
    }
}
