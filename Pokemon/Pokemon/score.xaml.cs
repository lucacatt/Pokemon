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
    /// Logica di interazione per score.xaml
    /// </summary>
    public partial class score : Window
    {
        scoreboards scores;
        public score()
        {
            InitializeComponent();
            scores = new scoreboards();
            set_scenery();
            setDataGrid();
        }

        public void set_scenery()
        {
            Uri uri = new Uri(AppDomain.CurrentDomain.BaseDirectory + "scoreboard.png");
            BitmapImage img = new BitmapImage(uri);
            ImageBrush brush = new ImageBrush(img);
            lbl_scoreboard.Background = brush;

            Uri uri_b = new Uri(AppDomain.CurrentDomain.BaseDirectory + "sfondo_stat.png");
            BitmapImage img_b = new BitmapImage(uri_b);
            ImageBrush brush_b = new ImageBrush(img_b);
            this.Background = brush_b;

            Uri uri_h = new Uri(AppDomain.CurrentDomain.BaseDirectory + "home.png");
            BitmapImage img_h = new BitmapImage(uri_h);
            ImageBrush brush_h = new ImageBrush(img_h);
            btn_home.Background = brush_h;

            rct.Fill = Brushes.White;
        }

        public void setDataGrid()
        {
            grd_scores.ItemsSource = scores.getList(); ;
        }

        public void setDataConditions(char cond)
        {
            grd_scores.ItemsSource = new List<scoreboard>();
            List<scoreboard> events = new List<scoreboard>();
            
            if (cond == 'v')
            {
                for (int i = 0; i < scores.getList().Count; i++)
                {
                    if (scores.getList()[i].Risultato == "Vittoria")
                    {
                        events.Add(scores.getList()[i]);
                    }
                }

            }
            else if (cond == 's')
            {
                for (int i = 0; i < scores.getList().Count; i++)
                {
                    if (scores.getList()[i].Risultato == "Sconfitta")
                    {
                        events.Add(scores.getList()[i]);
                    }
                }
            }

            grd_scores.ItemsSource = events;
        }

        private void sconfitta_Checked(object sender, RoutedEventArgs e)
        {
            setDataConditions('s');
        }

        private void vittoria_Checked(object sender, RoutedEventArgs e)
        {
            setDataConditions('v');
        }

        private void btn_home_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
