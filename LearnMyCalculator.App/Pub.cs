using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnMyCalculator.App
{
    //Publisher class
    public class Pub
    {
        //OnChange property contains all the
        //list of subscribers callback method
        //This is generic EventHandler delegate where 
        //we define the type of argument want to send 
        //while raising our event, MyEventArgs in our c
        public event EventHandler<MyEventArgs> OnChange = delegate { };

        public void Raise()
        {
            //Invoke OnChange action
            //Lets pass MyEventArgs object with some random value
            OnChange(this, new MyEventArgs(33));
        }
    }
}
