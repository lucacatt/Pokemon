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
    /// Logica di interazione per Sconfitta.xaml
    /// </summary>
    public partial class Sconfitta : Window
    {
        public Sconfitta()
        {
            InitializeComponent();
            Uri uri_b = new Uri(AppDomain.CurrentDomain.BaseDirectory + "home.png");
            BitmapImage img_b = new BitmapImage(uri_b);
            ImageBrush brush_b = new ImageBrush(img_b);
            btnLotta.Background = brush_b;
        }

        private void btnLotta_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            Close();
            mainWindow.Show();
        }
    }
}
