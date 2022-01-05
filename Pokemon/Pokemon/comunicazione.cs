﻿using System;
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
        Mostra_Squadra ms;
        static bool turno { get; set; }
        public string nome { get; set; }
        public comunicazione(Mostra_Squadra m)
        {
            c = new condivisa();
            l = new Lotta(Mostra_Squadra.pScelti_per_lotta, this);
            ms = m;
            turno = true;
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

        public static void send_packet(string action, string message)
        {
            UdpClient sender = new UdpClient();
            if (action == "at")
            {
                turno = false;
            }
            string to_send = action + ";" + message;
            byte[] data = Encoding.ASCII.GetBytes(to_send);
            sender.Send(data, data.Length, "localhost", 12346);
        }

        public bool send_packet(string m)
        {
            UdpClient sender = new UdpClient();
            byte[] data = Encoding.ASCII.GetBytes(m);
            sender.Send(data, data.Length, "localhost", 12346);
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
                c.Opponent = splitted_message[1];
            }
            if (splitted_message[0] == "a")
            {
                // message box --> accetta richiesta si/no
                c.Received_message = "";
                if (MessageBox.Show("Accettare la richiesta di gioco da " + c.Opponent + "?", "Richiesta di gioco", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    //invia y
                    send_packet("y", nome); // da vedere nome!!
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
                    send_packet("y", ""); // da vedere nome!!
                    setTurno(1);
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
                }
            }
            else if (splitted_message[0] == "y")
            {
                c.Received_message = "";
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
                int temp = (l.pScelto.remHp -= Convert.ToInt32(splitted_message[2]));
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
                    l.pkLeft--;
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
                c.Received_message = "";
            }
            else if (splitted_message[0] == "c")
            {
                // chiusura partita esce vinto/perso
                c.Received_message = "";
            }
        }

        public void start_thread_listen()
        {
            Thread thread = new Thread(new ThreadStart(thread_listen_port));
            thread.Start();
        }
    }
}
