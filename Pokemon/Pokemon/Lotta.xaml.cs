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
        public oggetti Objs { get; set; }
        int obj_1_rem;
        int obj_2_rem;
        int obj_3_rem;
        int obj_4_rem;
        int obj_5_rem;
        int obj_6_rem;
        int nTurno;
        public Lotta(Pokemons pScelti)
        {
            InitializeComponent();
            pkLeft = 6;
            this.pScelti = pScelti;
            this.mosse = new List<Mossa>();
            this.Objs = new oggetti();
            Objs.leggi(AppDomain.CurrentDomain.BaseDirectory + "oggetti.txt");
            nTurno = 0;
            set_listbox();
            set_scenery();
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
                pScelti.getPkm(i).Index = i;
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
            btn_ogg1.Content = Objs.getobj(0).Nome.ToUpper();
            btn_ogg2.Content = Objs.getobj(1).Nome.ToUpper();
            btn_ogg3.Content = Objs.getobj(2).Nome.ToUpper();
            btn_ogg4.Content = Objs.getobj(3).Nome.ToUpper();
            btn_ogg5.Content = Objs.getobj(4).Nome.ToUpper();
            btn_ogg6.Content = Objs.getobj(5).Nome.ToUpper();
            obj_1_rem = Objs.getobj(0).Quantita;
            obj_2_rem = Objs.getobj(1).Quantita;
            obj_3_rem = Objs.getobj(2).Quantita;
            obj_4_rem = Objs.getobj(3).Quantita;
            obj_5_rem = Objs.getobj(4).Quantita;
            obj_6_rem = Objs.getobj(5).Quantita;
            lbl_rem1.Content = obj_1_rem;
            lbl_rem2.Content = obj_2_rem;
            lbl_rem3.Content = obj_3_rem;
            lbl_rem4.Content = obj_4_rem;
            lbl_rem5.Content = obj_5_rem;
            lbl_rem6.Content = obj_6_rem;
        }

        private void lb_squadra_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            lb_mosse.Items.Clear();
            img_pkm.Source = set_pkm_image(lb_squadra.SelectedIndex, 'f');
            lbl_hp_pkm.Content = pScelti.getPkm(lb_squadra.SelectedIndex).remHp;
            lbl_atk_pkm.Content = pScelti.getPkm(lb_squadra.SelectedIndex).Atk;
            lbl_df_pkm.Content = pScelti.getPkm(lb_squadra.SelectedIndex).Def;
            prg_hp_pkm.Maximum = pScelti.getPkm(lb_squadra.SelectedIndex).Hp;
            prg_hp_pkm.Value = pScelti.getPkm(lb_squadra.SelectedIndex).remHp;
            mosse = pScelti.getPkm(lb_squadra.SelectedIndex).Mosse;
            check_HP(pScelti.getPkm(lb_squadra.SelectedIndex).remHp, pScelti.getPkm(lb_squadra.SelectedIndex).Index);
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
            if (comunicazione.getTurno() == true || nTurno == 0)
            {
                nTurno++;
                comunicazione.send_packet("p", pScelti.getPkm(lb_squadra.SelectedIndex).Nome + ";" + pScelti.getPkm(lb_squadra.SelectedIndex).remHp + ";" + pkLeft + ";" + pScelti.getPkm(lb_squadra.SelectedIndex).imgFront + ";");
                img_pkm.Source = set_pkm_image(lb_squadra.SelectedIndex, 'b');
                pScelto = pScelti.getPkm(lb_squadra.SelectedIndex);
                prg_hp_pkm.Maximum = pScelto.Hp;
                prg_hp_pkm.Value = pScelto.remHp;
            }
            else
            {
                MessageBox.Show("Aspetta il tuo turno!", "Aspetta!", MessageBoxButton.OK, MessageBoxImage.Error);
                img_pkm.Source = set_pkm_image(pScelto.Index, 'b');
                lbl_hp_pkm.Content = pScelto.remHp;
                lbl_atk_pkm.Content = pScelto.Atk;
                lbl_df_pkm.Content = pScelto.Def;
                prg_hp_pkm.Maximum = pScelto.Hp;
                prg_hp_pkm.Value = pScelto.remHp;
            }
        }

        private void btn_usa_Click(object sender, RoutedEventArgs e)
        {
            Dispatcher.BeginInvoke(DispatcherPriority.Input, new ThreadStart(() =>
            {
                if (comunicazione.getTurno() == true)
                    comunicazione.send_packet("at", mosse[lb_mosse.SelectedIndex].nome + ";" + mosse[lb_mosse.SelectedIndex].danno + ";" + mosse[lb_mosse.SelectedIndex].effetto + ";" + mosse[lb_mosse.SelectedIndex].tipo.nome + ";");
                else
                    MessageBox.Show("Aspetta il tuo turno!", "Aspetta!", MessageBoxButton.OK, MessageBoxImage.Error);
            }));
        }
        public void change_progress(int hp)
        {
            Dispatcher.BeginInvoke(DispatcherPriority.Input, new ThreadStart(() =>
            {
                prg_hp_pkm.Maximum = pScelto.Hp;
                prg_hp_pkm.Value = hp;
                lbl_hp_pkm.Content = hp;
                pScelti.getPkm(lb_squadra.SelectedIndex).remHp = hp;
                check_HP(pScelto.remHp, pScelto.Index);
            }));
        }

        public void change_progressOpponent(int hp)
        {
            Dispatcher.BeginInvoke(DispatcherPriority.Input, new ThreadStart(() =>
            {
                prg_hp_pkm_opp.Maximum = pOpp.Hp;
                prg_hp_pkm_opp.Value = hp;
            }));
        }

        public void change()
        {
            Dispatcher.BeginInvoke(DispatcherPriority.Input, new ThreadStart(() =>
            {
                for (int i = 0; i < pScelti.getSize(); i++)
                {
                    if (pScelti.getPkm(i).remHp > 0)
                    {
                        pScelto = pScelti.getPkm(i);
                        comunicazione.send_packet("p", pScelti.getPkm(i).Nome + ";" + pScelti.getPkm(i).remHp + ";" + pkLeft + ";" + pScelti.getPkm(i).imgFront + ";");
                        img_pkm.Source = set_pkm_image(i, 'b');
                        pScelto = pScelti.getPkm(i);
                        prg_hp_pkm.Maximum = pScelto.Hp;
                        prg_hp_pkm.Value = pScelto.remHp;
                        lbl_atk_pkm.Content = pScelto.Atk;
                        lbl_df_pkm.Content = pScelto.Def;
                        lbl_hp_pkm.Content = pScelto.Hp;
                        check_HP(pScelto.remHp, pScelto.Index);
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

        public void first_dead()
        {
            Dispatcher.BeginInvoke(DispatcherPriority.Input, new ThreadStart(() =>
            {
                for (int i = 0; i < pScelti.getSize(); i++)
                {
                    if (pScelti.getPkm(i).remHp < 0)
                    {
                        pScelto = pScelti.getPkm(i);
                        comunicazione.send_packet("p", pScelti.getPkm(i).Nome + ";" + pScelti.getPkm(i).remHp + ";" + pkLeft + ";" + pScelti.getPkm(i).imgFront + ";");
                        img_pkm.Source = set_pkm_image(i, 'b');
                        pScelto = pScelti.getPkm(i);
                        prg_hp_pkm.Maximum = pScelto.Hp;
                        prg_hp_pkm.Value = pScelto.remHp;
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

        public void check_HP(int hp, int index)
        {
            if (hp > (get_by_index(index).Hp * 0.75))
                change_GREENYELLOW();
            else if (hp > (get_by_index(index).Hp * 0.5))
                change_LIGHTGREEN();
            else if (hp > (get_by_index(index).Hp * 0.3))
                change_YELLOW();
            else if (hp > (get_by_index(index).Hp * 0.2))
                change_ORANGE();
            else if (hp > (get_by_index(index).Hp * 0.1))
                change_ORANGERED();
            else if (hp == 0)
                change_RED();
        }
        
        public Pokem get_by_index(int index)
        {
            for (int i = 0; i < pScelti.getSize(); i++)
            {
                if (index == pScelti.getIndex(i))
                {
                    return pScelti.getPkm(i);
                }
            }
            return new Pokem();
        }
        public void change_RED()
        {
            lbl_hp_pkm.Background = Brushes.Red;
        }

        public void change_ORANGERED()
        {
            lbl_hp_pkm.Background = Brushes.OrangeRed;
        }
        public void change_ORANGE()
        {
            lbl_hp_pkm.Background = Brushes.Orange;
        }
        public void change_GREENYELLOW()
        {
            lbl_hp_pkm.Background = Brushes.GreenYellow;
        }
        public void change_LIGHTGREEN()
        {
            lbl_hp_pkm.Background = Brushes.LightGreen;
        }
        public void change_YELLOW()
        {
            lbl_hp_pkm.Background = Brushes.Yellow;
        }

        public void change_SELECTION()
        {
            lbl_hp_pkm.Background = Brushes.Transparent;
        }

        private void btn_ogg1_Click(object sender, RoutedEventArgs e)
        {
            Dispatcher.BeginInvoke(DispatcherPriority.Input, new ThreadStart(() =>
            {

                if (comunicazione.getTurno() == true)
                {
                    if (MessageBox.Show(Objs.getobj(0).Nome + " " + Objs.getobj(0).Effetto + "\nVuoi davvero usarlo?", "Usare " + Objs.getobj(0).Nome + "?", MessageBoxButton.YesNo, MessageBoxImage.Information) == MessageBoxResult.Yes)
                    {
                        if (obj_1_rem > 0)
                        {
                            if ((pScelto.remHp + 20) < pScelto.Hp)
                            {
                                pScelto.remHp += 20;
                                obj_1_rem -= 1;
                                lbl_rem1.Content = obj_1_rem;
                                check_HP(pScelto.remHp, pScelto.Index);
                                prg_hp_pkm.Maximum = pScelto.Hp;
                                prg_hp_pkm.Value = pScelto.remHp;
                                lbl_hp_pkm.Content = pScelto.remHp;
                            }
                            else
                            {
                                pScelto.remHp = pScelto.Hp;
                                obj_1_rem -= 1;
                                lbl_rem1.Content = obj_1_rem;
                                check_HP(pScelto.remHp, pScelto.Index);
                                prg_hp_pkm.Maximum = pScelto.Hp;
                                prg_hp_pkm.Value = pScelto.remHp;
                                lbl_hp_pkm.Content = pScelto.remHp;
                            }
                            comunicazione.send_packet("og", Objs.getobj(0).Nome + ";");
                        }
                        else
                            MessageBox.Show("Hai finito " + Objs.getobj(0).Nome + "!", "Oops!", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
                else
                    MessageBox.Show("Aspetta il tuo turno!", "Aspetta!", MessageBoxButton.OK, MessageBoxImage.Error);
            }));
        }

        private void btn_ogg2_Click(object sender, RoutedEventArgs e)
        {
            Dispatcher.BeginInvoke(DispatcherPriority.Input, new ThreadStart(() =>
            {

                if (comunicazione.getTurno() == true)
                {
                    if (MessageBox.Show(Objs.getobj(1).Nome + " " + Objs.getobj(1).Effetto + "\nVuoi davvero usarlo?", "Usare " + Objs.getobj(1).Nome + "?", MessageBoxButton.YesNo, MessageBoxImage.Information) == MessageBoxResult.Yes)
                    {
                        if (obj_2_rem > 0)
                        {
                            if ((pScelto.remHp + 60) < pScelto.Hp)
                            {
                                pScelto.remHp += 60;
                                obj_2_rem -= 1;
                                lbl_rem2.Content = obj_2_rem;
                                check_HP(pScelto.remHp, pScelto.Index);
                                prg_hp_pkm.Maximum = pScelto.Hp;
                                prg_hp_pkm.Value = pScelto.remHp;
                                lbl_hp_pkm.Content = pScelto.remHp;
                            }
                            else
                            {
                                pScelto.remHp = pScelto.Hp;
                                obj_2_rem -= 1;
                                lbl_rem1.Content = obj_2_rem;
                                check_HP(pScelto.remHp, pScelto.Index);
                                prg_hp_pkm.Maximum = pScelto.Hp;
                                prg_hp_pkm.Value = pScelto.remHp;
                                lbl_hp_pkm.Content = pScelto.remHp;
                            }
                            comunicazione.send_packet("og", Objs.getobj(1).Nome + ";");
                        }
                        else
                            MessageBox.Show("Hai finito " + Objs.getobj(1).Nome + "!", "Oops!", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
                else
                    MessageBox.Show("Aspetta il tuo turno!", "Aspetta!", MessageBoxButton.OK, MessageBoxImage.Error);
            }));
        }

        private void btn_ogg3_Click(object sender, RoutedEventArgs e)
        {
            Dispatcher.BeginInvoke(DispatcherPriority.Input, new ThreadStart(() =>
            {
                if (comunicazione.getTurno() == true)
                {
                    if (MessageBox.Show(Objs.getobj(2).Nome + " " + Objs.getobj(2).Effetto + "\nVuoi davvero usarlo?", "Usare " + Objs.getobj(2).Nome + "?", MessageBoxButton.YesNo, MessageBoxImage.Information) == MessageBoxResult.Yes)
                    {
                        if (obj_3_rem > 0)
                        {
                            //DA VEDERE EFFETTI
                            pScelto.remHp = pScelto.Hp;
                            obj_3_rem -= 1;
                            check_HP(pScelto.remHp, pScelto.Index);
                            lbl_rem3.Content = obj_3_rem;
                            prg_hp_pkm.Maximum = pScelto.Hp;
                            prg_hp_pkm.Value = pScelto.remHp;
                            lbl_hp_pkm.Content = pScelto.remHp;
                            comunicazione.send_packet("og", Objs.getobj(2).Nome + ";");
                        }
                        else
                            MessageBox.Show("Hai finito " + Objs.getobj(2).Nome + "!", "Oops!", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
                else
                    MessageBox.Show("Aspetta il tuo turno!", "Aspetta!", MessageBoxButton.OK, MessageBoxImage.Error);
            }));
        }

        private void btn_ogg4_Click(object sender, RoutedEventArgs e)
        {
            Dispatcher.BeginInvoke(DispatcherPriority.Input, new ThreadStart(() =>
            {
                if (comunicazione.getTurno() == true)
                {
                    if (MessageBox.Show(Objs.getobj(3).Nome + " " + Objs.getobj(3).Effetto + "\nVuoi davvero usarlo?", "Usare " + Objs.getobj(3).Nome + "?", MessageBoxButton.YesNo, MessageBoxImage.Information) == MessageBoxResult.Yes)
                    {
                        if (obj_4_rem > 0)
                        {
                            first_dead();
                            pScelto.remHp = (pScelto.Hp / 2);
                            obj_4_rem -= 1;
                            lbl_rem4.Content = obj_4_rem;
                            check_HP(pScelto.remHp, pScelto.Index);
                            prg_hp_pkm.Maximum = pScelto.Hp;
                            prg_hp_pkm.Value = pScelto.remHp;
                            lbl_hp_pkm.Content = pScelto.remHp;
                            comunicazione.send_packet("og", Objs.getobj(3).Nome + ";");
                        }
                        else
                            MessageBox.Show("Hai finito " + Objs.getobj(3).Nome + "!", "Oops!", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
                else
                    MessageBox.Show("Aspetta il tuo turno!", "Aspetta!", MessageBoxButton.OK, MessageBoxImage.Error);
            }));
        }

        private void btn_ogg5_Click(object sender, RoutedEventArgs e)
        {
            Dispatcher.BeginInvoke(DispatcherPriority.Input, new ThreadStart(() =>
            {
                if (comunicazione.getTurno() == true)
                {
                    if (MessageBox.Show(Objs.getobj(4).Nome + " " + Objs.getobj(4).Effetto + "\nVuoi davvero usarlo?", "Usare " + Objs.getobj(4).Nome + "?", MessageBoxButton.YesNo, MessageBoxImage.Information) == MessageBoxResult.Yes)
                    {
                        if (obj_5_rem > 0)
                        {
                            pScelto.Atk += 10;
                            lbl_atk_pkm.Content = pScelto.Atk;
                            obj_5_rem -= 1;
                            lbl_rem5.Content = obj_5_rem;
                            comunicazione.send_packet("og", Objs.getobj(4).Nome + ";");
                        }
                        else
                            MessageBox.Show("Hai finito " + Objs.getobj(4).Nome + "!", "Oops!", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
                else
                    MessageBox.Show("Aspetta il tuo turno!", "Aspetta!", MessageBoxButton.OK, MessageBoxImage.Error);
            }));
        }

        private void btn_ogg6_Click(object sender, RoutedEventArgs e)
        {
            Dispatcher.BeginInvoke(DispatcherPriority.Input, new ThreadStart(() =>
            {
                if (comunicazione.getTurno() == true)
                {
                    if (MessageBox.Show(Objs.getobj(5).Nome + " " + Objs.getobj(5).Effetto + "\nVuoi davvero usarlo?", "Usare " + Objs.getobj(5).Nome + "?", MessageBoxButton.YesNo, MessageBoxImage.Information) == MessageBoxResult.Yes)
                    {
                        if (obj_6_rem > 0)
                        {
                            pScelto.Atk += 10;
                            lbl_atk_pkm.Content = pScelto.Atk;
                            obj_6_rem -= 1;
                            lbl_rem6.Content = obj_6_rem;
                            comunicazione.send_packet("og", Objs.getobj(5).Nome + ";");
                        }
                        else
                            MessageBox.Show("Hai finito " + Objs.getobj(5).Nome + "!", "Oops!", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
                else
                    MessageBox.Show("Aspetta il tuo turno!", "Aspetta!", MessageBoxButton.OK, MessageBoxImage.Error);
            }));
        }
    }
}
