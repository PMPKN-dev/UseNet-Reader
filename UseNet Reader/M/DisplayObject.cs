using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Diagnostics;


namespace UseNet_Reader.M
{
    //this used to hold the favorites button but that function has been removed due to me not being able to figure out a way to make it look good
    internal class DisplayObject : StackPanel
    {
        string name;
        TextBlock NameDisplay;
        

        public DisplayObject(string name) 
        {
            this.name = name;
            
            this.Orientation=Orientation.Horizontal;
            SetupNameDisplay();
            Debug.WriteLine($"Created DosplayObject: {NameDisplay}");

            this.Children.Add(NameDisplay);


        }

        public void SetupNameDisplay()
        {
            NameDisplay = new TextBlock
            {
                Text = this.name,
                HorizontalAlignment = System.Windows.HorizontalAlignment.Stretch,
            };
        }


    }
}
