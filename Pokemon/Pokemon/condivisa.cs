using System;
using System.Collections.Generic;
using System.Text;

namespace Pokemon
{
    class condivisa
    {
        private string received_message;
        private string opponent;

        public string Received_message { get => received_message; set => received_message = value; }
        public string Opponent { get => opponent; set => opponent = value; }

        public condivisa()
        {
            Received_message = "";
            Opponent = "";
        }
    }
}
