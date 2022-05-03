using LearnMyCalculator.App;
using System;

namespace LearnMyCalculatorApp
{
    class Program
    {
        static void Main(string[] args)
        {
            //Initialize pub class  object
            Pub p = new Pub();
            p.Raise();
            //Register for OnChange event  subscriber 1
            p.OnChange += (sender, e) => Console.WriteLine("Subscriber 1!");

            //Register for event subscriber 2
            p.OnChange += (sender, e) => Console.WriteLine("Subscriber 2!");

            //Raise the event 
            p.Raise();

            //After this Raise() method is called
            //all subscribers callback methods will get invoked

            //Console.WriteLine("Press enter to terminate!");
            //Console.ReadLine();
        }
    }
}
