using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net.Sockets;
using System.Threading;
using System.Diagnostics;


namespace UseNet_Reader.M
{
    class UseNetConnection
    {
        string serverName = "news.dotsrc.org";
        int port = 119;

        TcpClient? socket;
        NetworkStream? stream;
        StreamReader? reader;
        StreamWriter? writer;

        public UseNetConnection()
        {
            try
            {
                this.socket = new TcpClient(serverName, port);
                this.stream = socket.GetStream();
                this.reader = new StreamReader(stream, Encoding.UTF8);
                this.writer = new StreamWriter(stream);

            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
            }
        }

        

        public NetworkStream getStream()
        {
            if (stream == null)
            {
                stream = socket.GetStream();
                return stream;
            }
            else
            {
                return stream;
            }
        }

        public StreamReader getReader()
        {
            if (reader == null)
            {
                reader = new StreamReader(stream);
                return reader;
            }
            else
            {
                return reader;
            }
        }

        public StreamReader getNewReader()
        {
            return new StreamReader(stream);
        }

        public StreamWriter getWriter()
        {
            if(writer == null)
            {
                writer = new StreamWriter(stream);
                return writer;
            }
            else
            {
                return writer;
            }
        }

    }
       
}
