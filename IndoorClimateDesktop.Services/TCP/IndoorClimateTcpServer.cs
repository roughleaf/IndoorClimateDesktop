using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace IndoorClimateDesktop.Services.TCP
{
    class IndoorClimateTcpServer
    {
       public static string Listen(int port)
        {
            TcpListener server = null;
            try
            {
                string hostName = Dns.GetHostName();

                IPHostEntry ipHostEntry = Dns.GetHostEntry(hostName);
                IPAddress[] address = ipHostEntry.AddressList;

                string myIP = address[3].ToString();

                IPAddress localAddr = IPAddress.Parse(myIP);
                server = new TcpListener(localAddr, port);

                server.Start();

                // Buffer for reading data
                Byte[] bytes = new Byte[8192];
                String data = null;
                String returnString = "Data Received";

                    //Console.Write("Waiting for a connection... ");

                    // Perform a blocking call to accept requests.
                    // You could also use server.AcceptSocket() here.
                    TcpClient client = server.AcceptTcpClient();
                    Console.WriteLine("Connected!");

                    data = null;

                    // Get a stream object for reading and writing
                    NetworkStream stream = client.GetStream();

                    int i;

                    while ((i = stream.Read(bytes, 0, bytes.Length)) != 0)
                    {
                        data = System.Text.Encoding.ASCII.GetString(bytes, 0, i);



                        byte[] msg = System.Text.Encoding.ASCII.GetBytes(returnString);

                        // Send back a response.
                        stream.Write(msg, 0, msg.Length);
                        Console.WriteLine("Sent: {0}", returnString);
                    }
                   
                    client.Close();

                    return data;
            }
            catch (SocketException e)
            {
                Console.WriteLine("SocketException: {0}", e);
            }
            finally
            {
                // Stop listening for new clients.
                server.Stop();
            }
            return null;
        }
    }
}
