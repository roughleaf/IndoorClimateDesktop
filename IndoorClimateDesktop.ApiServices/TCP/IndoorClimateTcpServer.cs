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

                byte[] bytes = new byte[8192];
                byte[] headerBytes = new byte[2];
                //ushort dataLength = 0;
                string data = null;
                string returnString = "Data Received";
                int i = 0;
                int bytesRead = 0;
                int bytesToRead = 0;

                // Perform a blocking call to accept requests.
                TcpClient client = server.AcceptTcpClient();
                
                NetworkStream stream = client.GetStream();

                stream.Read(headerBytes, 0, 2);
                if (!BitConverter.IsLittleEndian)       // The client machine is constant, the server must change to adapt to the clinet.
                    Array.Reverse(headerBytes);

                bytesToRead = BitConverter.ToUInt16(headerBytes, 0);    // type conversion should be fine as long as value is not negative

                do
                {
                    i = stream.Read(bytes, bytesRead, bytesToRead);
                    bytesRead += i;
                    bytesToRead -= i;
                }
                while (bytesToRead > 0);

                data = System.Text.Encoding.ASCII.GetString(bytes, 0, bytesRead);

                byte[] msg = System.Text.Encoding.ASCII.GetBytes(returnString);

                stream.Write(msg, 0, msg.Length);

                client.Close();

                return data;
            }
            catch (SocketException e)
            {
                Console.WriteLine("SocketException: {0}", e);
            }
            finally
            {
                server.Stop();
            }
            return null;
        }
    }
}
