using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Network
{
    public class Client
    {
        private int _port;
        private string _ip;
        private TcpClient _client;

        public int Port { get => _port; }

        public Client(int port)
        {
            _ip = GetLocalIPAddress();
            _port = port;
        }

        public Client(string ip, int port)
        {
            _ip = ip;
            _port = port;
        }


        private void Connect()
        {
            try
            {
                _client = new TcpClient(_ip, _port);
            }
            catch (Exception)
            {
                Console.WriteLine("Connecting to server...");
            }
        }

        public void Write(string request)
        {
            while (_client == null || _client.Connected == false)
            {
                Connect();
            }

            try
            {
                byte[] data = Encoding.ASCII.GetBytes($"{request}\n");
                _client.GetStream().Write(data, 0, data.Length);
            }
            catch (Exception)
            {
                throw;
            }

        }

        public string GetResponse()
        {
            StreamReader sr = new StreamReader(_client.GetStream());

            string response = null;

            while (sr.Peek() != -1)
            {
                response += $"{sr.ReadLine()}\n";
            }

            return response.TrimEnd('\n');
        }

        private string GetLocalIPAddress()
        {
            var host = Dns.GetHostEntry(Dns.GetHostName());

            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    return ip.ToString();
                }
            }

            throw new Exception();
        }
    }
}
