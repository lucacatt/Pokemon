using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows;
using Microsoft.VisualBasic;

namespace Pokemon
{
    public class comunicazione
    {
        condivisa c;
        Lotta l;
        static Lotta lotta;
        Mostra_Squadra ms;
        Pokemons pScelti;
        static bool turno { get; set; }
        public string nome { get; set; }
        bool control;
        IndirizziIP ip;

        public comunicazione(Mostra_Squadra m)
        {
            pScelti = Mostra_Squadra.pScelti_per_lotta;
            c = new condivisa();
            l = new Lotta(Mostra_Squadra.pScelti_per_lotta);
            lotta = l;
            ms = m;
            turno = true;
            ip = new IndirizziIP();
            ip.leggi();
            control = true;
        }

        public void setTurno(int setter)
        {
            if (setter == 0)
                turno = false;
            else
                turno = true;
        }

        public static bool getTurno()
        {
            return turno;
        }

        public static string Ip { get; set; }

        public static Lotta getL()
        {
            return lotta;
        }

        public static void send_packet(string action, string message)
        {
            try
            {
                UdpClient sender = new UdpClient();
                if (action == "at")
                {
                    turno = false;
                }
                if (action == "og")
                {
                    turno = false;
                }
                string to_send = action + ";" + message;
                byte[] data = Encoding.ASCII.GetBytes(to_send);
                //MessageBox.Show(Ip);
                sender.Send(data, data.Length, Ip, 12345);
            }
            catch (Exception e)
            {
                MessageBox.Show("Indirizzo ip errato! Controlla la sintassi dell'indirizzo immesso ricordandoti che un indirizzo IP è composto come NNN.NNN.NNN.NNN", "ERRORE!", MessageBoxButton.OK, MessageBoxImage.Error);
                //MessageBox.Show(e.Message);
            }
        }

        public bool send_packet(string m)
        {
            UdpClient sender = new UdpClient();
            byte[] data = Encoding.ASCII.GetBytes(m);
            sender.Send(data, data.Length, "localhost", 12345);
            return true;
        }

        public void receive_packet()
        {
            UdpClient receiver = new UdpClient(12345);
            IPEndPoint riceveEP = new IPEndPoint(IPAddress.Any, 0);
            byte[] dataReceived = receiver.Receive(ref riceveEP);
            string messaggio_ricevuto = Encoding.ASCII.GetString(dataReceived);
        }

        public void thread_listen_port()
        {
            try
            {
                UdpClient listener = new UdpClient(12345);
                IPEndPoint riceveEP = new IPEndPoint(IPAddress.Any, 0);
                while (c.Received_message == "")
                {
                    byte[] dataReceived = listener.Receive(ref riceveEP);
                    Ip = riceveEP.Address.ToString();
                    c.Received_message = Encoding.ASCII.GetString(dataReceived);
                    message_control();
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message + nome);
            }
        }

        public void message_control()
        {
            string[] splitted_message = c.Received_message.Split(";");
            if (splitted_message[1] != "")
            {
                if (control == true)
                {
                    c.Opponent = splitted_message[1];
                    l.set_nOpp(splitted_message[1]);
                    control = false;
                }
            }
            if (splitted_message[0] == "a")
            {
                // message box --> accetta richiesta si/no
                c.Received_message = "";
                if (MessageBox.Show("Accettare la richiesta di gioco da " + c.Opponent + "?", "Richiesta di gioco", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    //invia y
                    send_packet("y", nome);
                    setTurno(0);
                }
                else
                {
                    // invia n
                    send_packet("n", "");
                }
            }
            else if (splitted_message[0] == "y" && splitted_message[1] != "")
            {
                // message box --> sicuro? 
                // invia y
                c.Received_message = "";
                if (MessageBox.Show("Vuoi davvero accedere al gioco contro " + c.Opponent + "?", "Accedere?", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    //invia y
                    send_packet("y", "");
                    setTurno(1);
                    IndirizzoIP i = new IndirizzoIP(c.Opponent, Ip);
                    if (!ip.contains(i))
                    {
                        ip.aggiungiIndirizzo(i);
                        ip.scrivi();
                    }
                    MessageBox.Show("Connessione con " + c.Opponent + " stabilita con successo!", "Connessione stabilita", MessageBoxButton.OK, MessageBoxImage.Information);
                    Application.Current.Dispatcher.Invoke(new Action(() =>
                    {
                        l.Show();
                    }));
                }
                else
                {
                    // invia n
                    send_packet("n", "");
                    Application.Current.Dispatcher.Invoke(new Action(() =>
                    {
                        Mostra_Squadra m = new Mostra_Squadra(pScelti, nome, 'n');
                        m.Show();
                        MessageBox.Show("Hai rifiutato la richiesta di " + c.Opponent, "Connessione fallita", MessageBoxButton.OK, MessageBoxImage.Warning);
                    }));

                }
            }
            else if (splitted_message[0] == "y")
            {
                c.Received_message = "";
                IndirizzoIP i = new IndirizzoIP(c.Opponent, Ip);
                if (!ip.contains(i))
                {
                    ip.aggiungiIndirizzo(i);
                    ip.scrivi();
                }
                MessageBox.Show("Connessione con " + c.Opponent + " stabilita con successo!", "Connessione stabilita", MessageBoxButton.OK, MessageBoxImage.Information);
                Application.Current.Dispatcher.Invoke(new Action(() =>
                {
                    ms.Close();
                    l.Show();
                }));
            }
            else if (splitted_message[0] == "n")
            {
                // chiude
                c.Received_message = "";
                Application.Current.Dispatcher.Invoke(new Action(() =>
                {
                    Mostra_Squadra m = new Mostra_Squadra(pScelti, nome, 'n');
                    m.Show();
                    MessageBox.Show(c.Opponent + " ha rifiutato la tua richiesta", "Connessione fallita", MessageBoxButton.OK, MessageBoxImage.Warning);
                }));
            }
            else if (splitted_message[0] == "p")
            {
                // pokemon evocato dall'altro giocatore (nome, vita rimanente)
                // pokemon rimanenti (numero)
                c.Received_message = "";
                string pkm_name = splitted_message[1];
                int hp_pkm = Convert.ToInt32(splitted_message[2]);
                int pkm_remained = Convert.ToInt32(splitted_message[3]);
                Pokem pkm_opp = new Pokem(pkm_name, hp_pkm);
                pkm_opp.imgBack = splitted_message[4];
                l.pkm_opp_received(pkm_opp, pkm_remained);
            }
            else if (splitted_message[0] == "at")
            {
                // attacco (nome mossa, danno, effetto)
                c.Received_message = "";
                double molt = calcoloDanno(splitted_message[4]);
                int danno = (int)(42 * (Convert.ToInt32(splitted_message[2]) / l.pScelto.Def) / 50 * molt);
                if (danno == 0)
                    MessageBox.Show("Danno Inefficace, il Pokémon è immune all'attacco inflitto", "Immune", MessageBoxButton.OK, MessageBoxImage.Information);
                int temp = (l.pScelto.remHp - danno);
                if (temp <= 0)

                {
                    l.pScelto.remHp = 0;
                    l.pkLeft--;
                    l.change_progress(0);
                    l.change();
                }
                else
                {
                    l.pScelto.remHp = temp;
                    l.change_progress(l.pScelto.remHp);
                }
                if (splitted_message[3] != "")
                {
                    if (splitted_message[3] == "PARALIZZA")
                    {
                        MessageBox.Show("Paralizzato");
                        l.pScelto.p.isPar = true;
                    }
                    else if (splitted_message[3] == "SCOTTA")
                    {
                        MessageBox.Show("Scottato");
                        l.pScelto.b.isBurned = true;
                    }
                    else if (splitted_message[3] == "ADDORMENTA")
                    {
                        MessageBox.Show("Addormentato");
                        l.pScelto.s.isSleep = true;
                    }
                    else if (splitted_message[3].Split(' ')[1] == "vita")
                    {
                        l.pScelto.remHp += Convert.ToInt32(splitted_message[3].Split(' ')[0].Substring(1));
                        l.change_progress(l.pScelto.remHp);
                    }
                }
                //l.check_HP();
                setTurno(1);
                send_packet("hp", l.pScelto.remHp.ToString());
            }
            else if (splitted_message[0] == "hp")
            {
                c.Received_message = "";
                int temp = Convert.ToInt32(splitted_message[1]);
                if (temp <= 0)
                {
                    l.pOpp.remHp = 0;
                    //l.pkLeft--;
                    l.change_progressOpponent(0);
                }
                else
                {
                      l.pOpp.remHp = temp;
                    l.change_progressOpponent(l.pOpp.remHp);
                }
            }
            else if (splitted_message[0] == "og")
            {
                // oggetto (nome oggetto)
                setTurno(1);
                c.Received_message = "";
                if (splitted_message[1] == "pozione")
                {
                    l.pOpp.remHp += 20;
                    l.change_progressOpponent(l.pOpp.remHp);
                    MessageBox.Show("L'avversario ha usato pozione");
                }
                else if (splitted_message[1] == "superpozione")
                {
                    l.pOpp.remHp += 60;
                    l.change_progressOpponent(l.pOpp.remHp);
                    MessageBox.Show("L'avversario ha usato superpozione");
                }
                else if (splitted_message[1] == "ricaricatotale")
                {
                    l.pOpp.remHp = l.pOpp.Hp;
                    l.change_progressOpponent(l.pOpp.remHp);
                    l.pScelto.b.burnCount = 5;
                    l.pScelto.b.isBurned = false;
                    l.pScelto.s.sleepCount = 5;
                    l.pScelto.s.isSleep = false;
                    l.pScelto.p.parCount = 5;
                    l.pScelto.p.isPar = false;
                    MessageBox.Show("L'avversario ha usato ricaricatotale");
                }
                else if (splitted_message[1] == "revitalizzante")
                {
                    l.pOpp.remHp = l.pOpp.Hp / 2;
                    l.change_progressOpponent(l.pOpp.remHp);
                    MessageBox.Show("L'avversario ha usato revitalizzante");
                }
                else if (splitted_message[1] == "proteina")
                {
                    l.pScelto.Atk += 10;
                    l.change_atk();
                    MessageBox.Show("L'avversario ha usato proteina");
                }
                else if (splitted_message[1] == "ferro")
                {
                    l.pScelto.Def += 10;
                    l.change_def();
                    MessageBox.Show("L'avversario ha usato ferro");
                }
            }
            else if (splitted_message[0] == "c")
            {
                Application.Current.Dispatcher.Invoke(new Action(() =>
                {
                    // chiusura partita esce vinto/perso
                    scoreboard score = new scoreboard(c.Opponent, "Vittoria");
                    scoreboards s = new scoreboards();
                    s.aggiungiScore(score);
                    s.scrivi();
                    Vittoria vittoria = new Vittoria();
                    l.Close();
                    vittoria.Show();
                }));                
            }
        }

        public void start_thread_listen()
        {
            Thread thread = new Thread(new ThreadStart(thread_listen_port));
            thread.Start();
        }

        public double calcoloDanno(string tipo)
        {
            double multiplier = 1.0;
            for (int j = 0; j < l.pScelto.Tipo.Count; j++)
            {
                for (int i = 0; i < l.pScelto.Tipo[j].super.Count; i++)
                {
                    if (tipo == l.pScelto.Tipo[j].super[i])
                    {
                        multiplier *= 0.5;
                    }
                }
                for (int i = 0; i < l.pScelto.Tipo[j].less.Count; i++)
                {
                    if (tipo == l.pScelto.Tipo[j].less[i])
                    {
                        multiplier *= 2.0;
                    }
                }
                for (int i = 0; i < l.pScelto.Tipo[j].no.Count; i++)
                {
                    if (tipo == l.pScelto.Tipo[j].no[i])
                    {
                        multiplier *= 0.0;
                    }
                }
            }
            return multiplier;
        }
    }
}
