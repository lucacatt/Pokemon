using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace Pokemon
{
    class comunicazione
    {

        public comunicazione()
        {

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
            while (true)
            {
                byte[] dataReceived = listener.Receive(ref riceveEP);
                string messaggio_ricevuto = Encoding.ASCII.GetString(dataReceived);
                //esegui.PacketContent_control(messaggio_ricevuto);
            }
        }

        public void start_thread_listen()
        {
            Thread thread = new Thread(new ThreadStart(thread_listen_port));
            thread.Start();
        }
    }
}
