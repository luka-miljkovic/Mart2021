using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms.VisualStyles;

namespace Server
{
    public class Server
    {
        Socket socket;

        public bool PokreniServer()
        {
            try
            {
                socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                IPEndPoint ep = new IPEndPoint(IPAddress.Any, 9000);
                socket.Bind(ep);

                ThreadStart ts = Osluskuj;
                new Thread(ts).Start();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public void ZaustaviServer()
        {
            try
            {
                socket.Close();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Osluskuj()
        {
            try
            {
                while (true)
                {
                    socket.Listen(8);
                    Socket client = socket.Accept();
                    NetworkStream tok = new NetworkStream(client);
                    new NitKlijenta(tok);

                }
            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}
