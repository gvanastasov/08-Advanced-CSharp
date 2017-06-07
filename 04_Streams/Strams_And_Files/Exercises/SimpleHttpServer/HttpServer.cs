namespace Exercises.SimpleHttpServer
{
    using Exercises.Tasks;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Net;
    using System.Net.Sockets;
    using System.Text;
    using System.Threading.Tasks;

    public class HttpServer : TaskBase
    {
        private const int PortNumber = 8081;

        // HAS NO ROUTING and only shows index :)
        private const string indexPage = "../../../Resources/index.html";

        public enum ResponseStatusCode
        {
            Ok = 200,
            NotFound = 404,
        }

        public override void Execute()
        {
            var tcpListener = new TcpListener(IPAddress.Any, PortNumber);

            tcpListener.Start();
            Console.WriteLine("Listening on port {0}...", PortNumber);

            while (true)
            {
                using (NetworkStream stream = tcpListener.AcceptTcpClient().GetStream())
                {
                    // ge the request sent to the webserver
                    byte[] request = new byte[4096];
                    int readBytes = stream.Read(request, 0, 4096);
                    Console.WriteLine($"{new string('-', 3)} Request {new string('-', 50)}");
                    var requestString = Encoding.UTF8.GetString(request, 0, readBytes);
                    Console.WriteLine(requestString);
                    Console.WriteLine($"{new string('-', 50)}");
                    Console.WriteLine();

                    // create a response
                    var content = File.ReadAllText(indexPage);
                    var contentBytes = Encoding.UTF8.GetBytes(content);

                    var responseHeader = new StringBuilder();
                    responseHeader.AppendLine($"HTTP/1.1 {(int)ResponseStatusCode.Ok} {Enum.GetName(typeof(ResponseStatusCode), ResponseStatusCode.Ok)}");
                    responseHeader.AppendLine($"Content-type: text/html");
                    responseHeader.AppendLine("Content-Length: " + contentBytes.Length);
                    responseHeader.AppendLine();

                    var responseBytes = Encoding.UTF8.GetBytes(responseHeader.ToString());

                    // write response
                    stream.Write(responseBytes, 0, responseHeader.Length);
                    stream.Write(contentBytes, 0, contentBytes.Length);

                    Console.WriteLine($"{new string('-', 3)} Response {new string('-', 50)}");
                    Console.WriteLine(responseHeader);
                    Console.WriteLine(content);
                    Console.WriteLine($"{new string('-', 50)}");
                    Console.WriteLine();
                }
            }
        }

    }
}
