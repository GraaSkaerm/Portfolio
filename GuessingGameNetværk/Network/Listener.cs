using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Network
{
    public class Listener
    {
        private int _port;
        private bool _isDebugging;

        private TcpListener _listener;
        private IRequestHandler[] _requestHandlers;
        private Dictionary<string, Client> _clients;

        public bool IsDebuging { get => _isDebugging; set => _isDebugging = value; }
        public Dictionary<string, Client> Clients { get => _clients; }

        public Listener(int port)
        {
            _port = port;
            _requestHandlers = null;
            _clients = new Dictionary<string, Client>();
            _listener = new TcpListener(IPAddress.Any, _port);
        }
        public Listener(int port, IRequestHandler requestHandler)
        {
            _port = port;
            _clients = new Dictionary<string, Client>();
            _listener = new TcpListener(IPAddress.Any, _port);
            _requestHandlers = new IRequestHandler[] { requestHandler };
        }
        public Listener(int port, IRequestHandler[] requestHandlers)
        {
            _port = port;
            _requestHandlers = requestHandlers;
            _clients = new Dictionary<string, Client>();
            _listener = new TcpListener(IPAddress.Any, _port);
        }




        public void AcceptNewClientsLoop()
        {
            _listener.Start();

            while (true)
            {
                TcpClient client = _listener.AcceptTcpClient();
                new Thread(HandleClient).Start(client);
            }
        }

        private void HandleClient(object obj)
        {
            TcpClient client = (TcpClient)obj;
            string endPoint = client.Client.RemoteEndPoint.ToString();
            string fromIp = endPoint.Split(':')[0];

            while (true)
            {
                try
                {
                    AddClient(endPoint, fromIp);

                    string request = GetReceivedRequest(client);
                    string response = GetResponse(endPoint, request);
                    SendResponse(client, response);

                }
                catch (Exception)
                {
                    DisconnectClient(client, endPoint);
                    return;
                }
            }
        }

        private void AddClient(string endPoint, string fromIp)
        {
            if (_clients.Keys.Contains(endPoint) == false)
            {
                Interlocked.Increment(ref _port);
                _clients.Add(endPoint, new Client(fromIp, _port));
            }
        }
        private void SendResponse(TcpClient client, string response)
        {
            StreamWriter sw = new StreamWriter(client.GetStream());
            sw.WriteLine(response);
            sw.Flush();

            if (_isDebugging)
            {
                Console.WriteLine($"{client.Client.RemoteEndPoint} -> RESPONSE: {response}");
            }
        }
        private void DisconnectClient(TcpClient client, string endPoint)
        {
            _clients.Remove(endPoint);



            if (_isDebugging)
            {
                Console.WriteLine($"{client.Client.RemoteEndPoint}: DISCONNECTED");
            }
        }

        private string GetReceivedRequest(TcpClient client)
        {
            NetworkStream stream = client.GetStream();
            string request = GetRequestFromData(stream);

            if (_isDebugging)
            {
                Console.WriteLine($"{client.Client.RemoteEndPoint} -> REQUESTED: {request.ToUpper()}");
            }

            return request;
        }
        private string GetResponse(string fromIp, string request)
        {
            string response = null;

            if (_requestHandlers == null || _requestHandlers.Length == 0) return null;

            foreach (IRequestHandler r in _requestHandlers)
            {
                response = r.GetResponse(fromIp, request);
                if (response != null) break;
            }


            return response;
        }
        private string GetRequestFromData(NetworkStream stream)
        {
            StreamReader sr = new StreamReader(stream);

            string response = null;

            while (sr.Peek() != -1)
            {
                response += $"{sr.ReadLine()}\n";
            }

            return response.TrimEnd('\n');
        }


    }
}
