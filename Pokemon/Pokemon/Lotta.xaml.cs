using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace Pokemon
{
    /// <summary>
    /// Logica di interazione per Lotta.xaml
    /// </summary>
    public partial class Lotta : Window
    {
        public Pokemons pScelti { get; set; }
        List<Mossa> mosse;
        public Pokem pScelto { get; set; }
        public Pokem pOpp { get; set; }
        public int pkLeft { get; set; }
        comunicazione c;

        public Lotta(Pokemons pScelti, comunicazione cc)
        {
            InitializeComponent();
            pkLeft = 6;
            this.pScelti = pScelti;
            this.mosse = new List<Mossa>();
            set_listbox();
            set_scenery();
            c = cc;
        }

        public void pkm_opp_received(Pokem pkm_opp, int pkm_remained)
        {
            Dispatcher.BeginInvoke(DispatcherPriority.Input, new ThreadStart(() =>
            {
                try
                {
                    this.pOpp = pkm_opp;
                    BitmapImage bitmap = new BitmapImage();
                    bitmap.BeginInit();
                    bitmap.UriSource = new Uri(pkm_opp.imgFront, UriKind.Absolute);
                    bitmap.EndInit();
                    img_pkm_opp.Stretch = Stretch.Fill;
                    img_pkm_opp.StretchDirection = StretchDirection.Both;
                    img_pkm_opp.Source = bitmap;
                    prg_hp_pkm_opp.Maximum = pkm_opp.Hp;
                    prg_hp_pkm_opp.Value = pkm_opp.remHp;
                }
                catch
                {
                    MessageBox.Show("Something went wrong... try again!", "Oops!", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }));
        }


        private void set_listbox()
        {

            for (int i = 0; i < pScelti.getSize(); i++)
            {
                lb_squadra.Items.Add(pScelti.getPkm(i).Nome);
            }
        }
        private void set_scenery()
        {
            Uri uri_p = new Uri(AppDomain.CurrentDomain.BaseDirectory + "la_tua_squadra.png");
            BitmapImage img_p = new BitmapImage(uri_p);
            ImageBrush brush_p = new ImageBrush(img_p);
            lbl_pkm.Background = brush_p;
            Uri uri_l = new Uri(AppDomain.CurrentDomain.BaseDirectory + "seleziona.png");
            BitmapImage img_l = new BitmapImage(uri_l);
            ImageBrush brush_l = new ImageBrush(img_l);
            btn_selez.Background = brush_l;
            Uri uri_u = new Uri(AppDomain.CurrentDomain.BaseDirectory + "usa.png");
            BitmapImage img_u = new BitmapImage(uri_u);
            ImageBrush brush_u = new ImageBrush(img_u);
            btn_usa.Background = brush_u;
            btn_usa.IsEnabled = false;
            Uri uri_b = new Uri(AppDomain.CurrentDomain.BaseDirectory + "background.png");
            BitmapImage img_b = new BitmapImage(uri_b);
            background.Stretch = Stretch.Fill;
            background.StretchDirection = StretchDirection.Both;
            background.Source = img_b;
        }

        private void lb_squadra_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            lb_mosse.Items.Clear();
            img_pkm.Source = set_pkm_image(lb_squadra.SelectedIndex, 'f');
            lbl_hp_pkm.Content = pScelti.getPkm(lb_squadra.SelectedIndex).Hp;
            lbl_atk_pkm.Content = pScelti.getPkm(lb_squadra.SelectedIndex).Atk;
            lbl_df_pkm.Content = pScelti.getPkm(lb_squadra.SelectedIndex).Def;
            prg_hp_pkm.Maximum = pScelti.getPkm(lb_squadra.SelectedIndex).Hp;
            prg_hp_pkm.Value = pScelti.getPkm(lb_squadra.SelectedIndex).remHp;
            mosse = pScelti.getPkm(lb_squadra.SelectedIndex).Mosse;
            for (int i = 0; i < pScelti.getPkm(lb_squadra.SelectedIndex).Mosse.Count; i++)
            {
                lb_mosse.Items.Add(pScelti.getPkm(lb_squadra.SelectedIndex).getMossa(i).nome);
            }
        }

        private BitmapImage set_pkm_image(int pos, char controllo)
        {
            BitmapImage bitmap = new BitmapImage();
            bitmap.BeginInit();
            if (controllo == 'f')
                bitmap.UriSource = new Uri(pScelti.getImg(pos), UriKind.Absolute);
            else
                bitmap.UriSource = new Uri(pScelti.getPkm(pos).imgBack);
            bitmap.EndInit();
            img_pkm.Stretch = Stretch.Fill;
            img_pkm.StretchDirection = StretchDirection.Both;
            return bitmap;
        }

        private void lb_mosse_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lb_mosse.SelectedIndex > -1)
            {
                lbl_tipo.Content = mosse[lb_mosse.SelectedIndex].tipo.nome;
                if (mosse[lb_mosse.SelectedIndex].danno == 0)
                    lbl_danno.Content = "-";
                else
                    lbl_danno.Content = mosse[lb_mosse.SelectedIndex].danno;

                if (mosse[lb_mosse.SelectedIndex].effetto == "")
                    lbl_effetto.Content = "-";
                else
                    lbl_effetto.Content = mosse[lb_mosse.SelectedIndex].effetto;
                btn_usa.IsEnabled = true;
            }
            else
            {
                lbl_danno.Content = "";
                lbl_effetto.Content = "";
                lbl_effetto.Content = "";
            }
        }

        private void btn_selez_Click(object sender, RoutedEventArgs e)
        {
            comunicazione.send_packet("p", pScelti.getPkm(lb_squadra.SelectedIndex).Nome + ";" + pScelti.getPkm(lb_squadra.SelectedIndex).Hp + ";" + pkLeft + ";" + pScelti.getPkm(lb_squadra.SelectedIndex).imgFront + ";");
            img_pkm.Source = set_pkm_image(lb_squadra.SelectedIndex, 'b');
            pScelto = pScelti.getPkm(lb_squadra.SelectedIndex);
            prg_hp_pkm.Value = pScelto.Hp;
        }

        private void btn_usa_Click(object sender, RoutedEventArgs e)
        {
            comunicazione.send_packet("at", mosse[lb_mosse.SelectedIndex].nome + ";" + mosse[lb_mosse.SelectedIndex].danno + ";" + mosse[lb_mosse.SelectedIndex].effetto + ";");
        }
        public void change_progress(int hp)
        {
            Dispatcher.BeginInvoke(DispatcherPriority.Input, new ThreadStart(() =>
            {
                prg_hp_pkm.Value = hp;
            }));
        }

        public void change_progressOpponent(int hp)
        {
            Dispatcher.BeginInvoke(DispatcherPriority.Input, new ThreadStart(() =>
            {
                prg_hp_pkm_opp.Value = hp;
            }));
        }

        public void change()
        {
            Dispatcher.BeginInvoke(DispatcherPriority.Input, new ThreadStart(() =>
            {
                for (int i = 0; i < pScelti.getSize(); i++)
                {
                    if (pScelti.getPkm(i).Hp > 0)
                    {
                        pScelto = pScelti.getPkm(i);
                        comunicazione.send_packet("p", pScelti.getPkm(i).Nome + ";" + pScelti.getPkm(i).Hp + ";" + pkLeft + ";" + pScelti.getPkm(i).imgFront + ";");
                        img_pkm.Source = set_pkm_image(i, 'b');
                        pScelto = pScelti.getPkm(i);
                        prg_hp_pkm.Value = pScelto.Hp;
                        lb_mosse.Items.Clear();
                        for (int j = 0; j < pScelti.getPkm(i).Mosse.Count; j++)
                        {
                            lb_mosse.Items.Add(pScelti.getPkm(i).getMossa(j).nome);
                        }
                        break;
                    }
                }
            }));
        }
    }
}
