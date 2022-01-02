using System;
using System.Collections.Generic;
using System.Text;

namespace Pokemon
{
    class condivisa
    {
        private string received_message;

        public string Received_message { get => received_message; set => received_message = value; }

        public condivisa()
        {
            Received_message = "";
        }
    }
}
