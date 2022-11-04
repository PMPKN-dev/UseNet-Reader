using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using UseNet_Reader.M;
using System.Diagnostics;

namespace UseNet_Reader
{

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        
        UseNetConnection con;
        NetHandler handler;
        string textForMarvin = "";
        public MainWindow()
        {

            Debug.WriteLine("Progam booted");
            handler = new NetHandler();

            


            
            InitializeComponent();
            handler.login();
            SetupList();

        }
        /*
        public void SetupList()
        {
            int start = 0;
            int end = 10;

            Debug.WriteLine("asking for con.List(start,end)");

            List<string> list = con.List(start,end);
            
            foreach (string item in list)
            {
                DisplayObject temp = new DisplayObject(item);
                DisplayList.Items.Add(temp);
            }
            
        }
        */

        private void SetupList()
        {
            /*List<string> list = new List<string>
            {
                "First",
                "Second",
                "Third",
            };*/

            List<string> list = handler.List();


            foreach(string item in list)
            {
                Marvin.Text += item;

                DisplayObject temp = new DisplayObject(item);
                DisplayList.Items.Add(temp);
            }

        }


        private void RunCommand_Click(object sender, RoutedEventArgs e)
        {

        }

        private void AddToFavorites_Click(object sender, RoutedEventArgs e)
        {

        }

        private void RemoveFromFavorites_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            Debug.WriteLine("List Button Clicked");
            Debug.WriteLine("Setting up lists");
            Marvin.Text = "";
            DisplayList.Items.Clear();
            
            ThreadStart listthread = new ThreadStart(SetupList);
            Debug.WriteLine("Thread Created");
            listthread.Invoke();
            Debug.WriteLine("Thread Invoked");


        }
    }
}
