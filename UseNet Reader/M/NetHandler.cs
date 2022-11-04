using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace UseNet_Reader.M
{
    internal class NetHandler
    {
        StreamReader reader;
        StreamWriter writer;
        Stream stream;
        string response = "";
        UseNetConnection netCon;

        public NetHandler()
        {
            netCon = new UseNetConnection();
            reader = netCon.getReader();
            writer = netCon.getWriter();
            stream = netCon.getStream();
            writer.AutoFlush = true;

        }

        public void await(string response)
        {
            while (reader.ReadLine() != response)
            {
                Debug.WriteLine($"Awaiting: {response}");
                Thread.Sleep(1000);
                response = reader.ReadLine();
                Debug.WriteLine($"Recieved: {response}");

            }
        }

        public void AwaitOtherThan(string response)
        {
            while (reader.ReadLine() == response)
            {
                Debug.WriteLine($"Awaiting something else than: {response}");
                Thread.Sleep(1000);
                response = reader.ReadLine();
                Debug.WriteLine($"Recieved: {response}");

            }
        }

        public List<string> List()
        {

            Debug.WriteLine("Creating new List<string> named result");
            List<string> result = new List<string>();


            //Debug.WriteLine("writer writing 'list'");
            //writer.WriteLine("list\n");

            //Debug.WriteLine("sleeping thread for 2000ms in order to (hopefully) prevent reading old responses");
            //Thread.Sleep(2000);


            Debug.WriteLine("Creating temp string based on reader.ReadLine");
            //string temp = reader.ReadLine();
            //Debug.WriteLine(temp);
            /*
            Debug.WriteLine("Starting loop");
            while (temp!= null)
            {
                result.Add(temp);
                temp = reader.ReadLine();
            }*/
            writer.WriteLine("list");
            netCon.getReader().Close();
            reader = netCon.getNewReader();

            string line = reader.ReadLine();
            while (line != null)
            {
                Debug.WriteLine(line);
                line = reader.ReadLine();
            }


            Debug.WriteLine("Returning result at intended point");
            return result;


        }

        public void login()
        {
            #region login
            Debug.WriteLine("Writing Hello Server ");
            writer.WriteLine("Hello Server\n");

            try
            {
                do
                {
                    Debug.WriteLine("Writing user id");
                    writer.WriteLine("authinfo user mich416m@easv365.dk\n");

                    Debug.WriteLine("Reading Response");
                    response = reader.ReadLine();
                    Debug.WriteLine($"Response was {response}");

                    Debug.WriteLine("sleeping thread");
                    Thread.Sleep(1000);

                } while (response != "381 PASS required");

                do
                {
                    Debug.WriteLine("writing password");
                    writer.WriteLine("authinfo pass 1ea6ee\n");

                    Debug.WriteLine("reading response");
                    response = reader.ReadLine();
                    Debug.WriteLine($"response was {response}");

                    Debug.WriteLine("sleeping thread");
                    Thread.Sleep(1000);

                } while (response != "281 Ok");
                stream.Flush();

                #endregion
            } catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }

        

    }
}
