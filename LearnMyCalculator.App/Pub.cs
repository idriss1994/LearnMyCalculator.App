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
        public Action OnChange { get; set; }

        public void Raise()
        {
            //Check if OnChange Action set before invoking it 
            if (OnChange != null)
            {
                //Invoke OnChange action
                OnChange();
            }
        }
    }
}
