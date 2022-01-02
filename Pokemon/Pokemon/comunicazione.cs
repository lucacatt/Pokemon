using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows;

namespace Pokemon
{
    class comunicazione
    {
        condivisa c;
        public comunicazione()
        {
            c = new condivisa();
        }

        public void send_packet(string action, string message)
        {
            UdpClient sender = new UdpClient();
            string to_send = action + ";" + message;
            byte[] data = Encoding.ASCII.GetBytes(to_send);
            sender.Send(data, data.Length, "localhost", 12346);
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
            UdpClient listener = new UdpClient(12345);
            IPEndPoint riceveEP = new IPEndPoint(IPAddress.Any, 0);
            while (c.Received_message == "")
            {
                byte[] dataReceived = listener.Receive(ref riceveEP);
                c.Received_message = Encoding.ASCII.GetString(dataReceived);
                message_control();
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
                    send_packet("y", "user"); // da vedere nome!!
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
                    Lotta l = new Lotta(Mostra_Squadra.pScelti_per_lotta);
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
                // pokemon rimanenti (numero/nomi?)
                c.Received_message = "";
            }
            else if (splitted_message[0] == "at")
            {
                // attacco (nome mossa, danno, effetto)
                c.Received_message = "";
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
