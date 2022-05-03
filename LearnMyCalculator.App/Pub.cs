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
            //Initialize MyEventArgs object with some random value
            MyEventArgs eventArgs = new MyEventArgs(33);

            //Create list of exception
            List<Exception> exceptions = new List<Exception>();

            //Invoke OnChange Action by iterating on all subscribers event handlers
            foreach (Delegate handler in OnChange.GetInvocationList())
            {
                try
                {
                    //pass sender object and eventArgs while
                    handler.DynamicInvoke(this, eventArgs);
                }
                catch (Exception e)
                {
                    // Add exception in exception list if occured any
                    exceptions.Add(e);
                }
            }
            //Check if any exception occured while 
            //invoking the subscribers event handlers
            if (exceptions.Any())
            {
                //Throw aggregate exception of all exceptions 
                //occured while invoking subscribers event handlers

                throw new AggregateException(exceptions);
            }
        }
    }
}
