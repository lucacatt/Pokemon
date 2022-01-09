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
    /// Logica di interazione per Mostra_Squadra.xaml
    /// </summary>
    public partial class Mostra_Squadra : Window
    {
        Pokemons pScelti;
        comunicazione c;
        public static Pokemons pScelti_per_lotta;
        IndirizziIP ip;

        public Mostra_Squadra(Pokemons pScelti, string nome)
        {
            InitializeComponent();
            this.pScelti = pScelti;
            pScelti_per_lotta = pScelti;
            c = new comunicazione(this);
            ip = new IndirizziIP();

            set_scenery();
            set_names();
            set_img();
            set_stats();
            set_ip();

            c = new comunicazione(this);
            c.nome = nome;
            c.start_thread_listen();
        }

        public Mostra_Squadra(Pokemons pScelti, string nome, char do_not_start_thread)
        {
            InitializeComponent();
            this.pScelti = pScelti;
            pScelti_per_lotta = pScelti;
            c = new comunicazione(this);

            set_scenery();
            set_names();
            set_img();
            set_stats();
            set_ip();
            c = new comunicazione(this);
            c.nome = nome;
        }

        public void set_ip()
        {
            ip.leggi();
            for (int i = 0; i < ip.getSize(); i++)
            {
                cmb_ip.Items.Add(ip.getNome(i) + " --> " + ip.getIndirizzo(i));
            }
        }

        private void set_names()
        {
            lbl_nome_pkm1.Content = pScelti.getPkm(0).Nome;
            lbl_nome_pkm2.Content = pScelti.getPkm(1).Nome;
            lbl_nome_pkm3.Content = pScelti.getPkm(2).Nome;
            lbl_nome_pkm4.Content = pScelti.getPkm(3).Nome;
            lbl_nome_pkm5.Content = pScelti.getPkm(4).Nome;
            lbl_nome_pkm6.Content = pScelti.getPkm(5).Nome;
        }

        private void set_img()
        {
            img_pkm1.Stretch = Stretch.Fill;
            img_pkm1.StretchDirection = StretchDirection.Both;
            img_pkm2.Stretch = Stretch.Fill;
            img_pkm2.StretchDirection = StretchDirection.Both;
            img_pkm3.Stretch = Stretch.Fill;
            img_pkm3.StretchDirection = StretchDirection.Both;
            img_pkm4.Stretch = Stretch.Fill;
            img_pkm4.StretchDirection = StretchDirection.Both;
            img_pkm5.Stretch = Stretch.Fill;
            img_pkm5.StretchDirection = StretchDirection.Both;
            img_pkm6.Stretch = Stretch.Fill;
            img_pkm6.StretchDirection = StretchDirection.Both;

            var fullFilePath_1 = pScelti.getPkm(0).imgFront;
            img_pkm1.Source = showImg(fullFilePath_1);
            var fullFilePath_2 = pScelti.getPkm(1).imgFront;
            img_pkm2.Source = showImg(fullFilePath_2);
            var fullFilePath_3 = pScelti.getPkm(2).imgFront;
            img_pkm3.Source = showImg(fullFilePath_3);
            var fullFilePath_4 = pScelti.getPkm(3).imgFront;
            img_pkm4.Source = showImg(fullFilePath_4);
            var fullFilePath_5 = pScelti.getPkm(4).imgFront;
            img_pkm5.Source = showImg(fullFilePath_5);
            var fullFilePath_6 = pScelti.getPkm(5).imgFront;
            img_pkm6.Source = showImg(fullFilePath_6);
        }

        private BitmapImage showImg(string fullFilePath)
        {
            BitmapImage bitmap = new BitmapImage();
            bitmap.BeginInit();
            bitmap.UriSource = new Uri(fullFilePath, UriKind.Absolute);
            bitmap.EndInit();
            return bitmap;
        }

        private void set_stats()
        {
            lbl_hp_pkm1.Content = pScelti.getPkm(0).Hp;
            lbl_atk_pkm1.Content = pScelti.getPkm(0).Atk;
            lbl_df_pkm1.Content = pScelti.getPkm(0).Def;

            lbl_hp_pkm2.Content = pScelti.getPkm(1).Hp;
            lbl_atk_pkm2.Content = pScelti.getPkm(1).Atk;
            lbl_df_pkm2.Content = pScelti.getPkm(1).Def;

            lbl_hp_pkm3.Content = pScelti.getPkm(2).Hp;
            lbl_atk_pkm3.Content = pScelti.getPkm(2).Atk;
            lbl_df_pkm3.Content = pScelti.getPkm(2).Def;

            lbl_hp_pkm4.Content = pScelti.getPkm(3).Hp;
            lbl_atk_pkm4.Content = pScelti.getPkm(3).Atk;
            lbl_df_pkm4.Content = pScelti.getPkm(3).Def;

            lbl_hp_pkm5.Content = pScelti.getPkm(4).Hp;
            lbl_atk_pkm5.Content = pScelti.getPkm(4).Atk;
            lbl_df_pkm5.Content = pScelti.getPkm(4).Def;

            lbl_hp_pkm6.Content = pScelti.getPkm(5).Hp;
            lbl_atk_pkm6.Content = pScelti.getPkm(5).Atk;
            lbl_df_pkm6.Content = pScelti.getPkm(5).Def;
        }

        private void btn_home_Click(object sender, RoutedEventArgs e)
        {
            MainWindow home = new MainWindow(pScelti);
            this.Close();
            home.Show();
        }

        private void set_scenery()
        {

            Uri uri_s = new Uri(AppDomain.CurrentDomain.BaseDirectory + "la_tua_squadra.png");
            BitmapImage img_s = new BitmapImage(uri_s);
            ImageBrush brush_s = new ImageBrush(img_s);
            lbl_info.Background = brush_s;
            Uri uri_l = new Uri(AppDomain.CurrentDomain.BaseDirectory + "lotta.png");
            BitmapImage img_l = new BitmapImage(uri_l);
            ImageBrush brush_l = new ImageBrush(img_l);
            btnLotta.Background = brush_l;
            Uri uri_h = new Uri(AppDomain.CurrentDomain.BaseDirectory + "home.png");
            BitmapImage img_h = new BitmapImage(uri_h);
            ImageBrush brush_h = new ImageBrush(img_h);
            btn_home.Background = brush_h;

            Uri uri = new Uri(AppDomain.CurrentDomain.BaseDirectory + "sfondo_squadra.png");
            BitmapImage img = new BitmapImage(uri);
            ImageBrush brush = new ImageBrush(img);
            this.Background = brush;
        }

        private void btnLotta_Click(object sender, RoutedEventArgs e)
        {
            if (controlla_ip())
            {
                comunicazione.Ip = ip_dest.Text.Trim();
                comunicazione.send_packet("a", c.nome);
                Close();
            }
            else
                MessageBox.Show("Indirizzo IP errato!!", "IP Errato", MessageBoxButton.OK, MessageBoxImage.Error);

        }

        public bool controlla_ip()
        {
            string ip = ip_dest.Text.Trim();
            string[] controllo = ip.Split('.');
            try
            {
                if (controllo[0] == "localhost")
                    return true;
                else if (Convert.ToInt32(controllo[0]) >= 0 && Convert.ToInt32(controllo[0]) <= 223)
                {
                    if (Convert.ToInt32(controllo[1]) > 0 && Convert.ToInt32(controllo[1]) < 255)
                    {
                        if (Convert.ToInt32(controllo[2]) > 0 && Convert.ToInt32(controllo[2]) < 255)
                        {
                            if (Convert.ToInt32(controllo[3]) > 0 && Convert.ToInt32(controllo[3]) < 255)
                                return true;
                            else
                                return false;
                        }
                        else
                            return false;
                    }
                    else
                        return false;
                }
                else
                    return false;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        private void cmb_ip_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ip_dest.Text = ip.getIndirizzo(cmb_ip.SelectedIndex);
        }

        private void txt_ip_TextChanged(object sender, TextChangedEventArgs e)
        {
            //cmb_ip.SelectedIndex = -1;
        }
    }
}
