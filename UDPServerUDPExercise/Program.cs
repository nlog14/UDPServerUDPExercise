﻿using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace UDPServerUDPExercise
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("UDP SERVER");
            StartListener();
        }

        public static void StartListener()
        {
            using (UdpClient socket = new UdpClient())
            {
                socket.Client.Bind(new IPEndPoint(IPAddress.Any, 10100));

                while (true)
                {
                    IPEndPoint from = null;
                    byte[] data = socket.Receive(ref from);
                    string recieved = Encoding.UTF8.GetString(data);
                    Console.WriteLine("Server receieved: " + recieved);
                    Console.WriteLine("Client address: " + from.Address);

                    socket.Send(data, data.Length, from);
                }
            }
        }
    }
}
