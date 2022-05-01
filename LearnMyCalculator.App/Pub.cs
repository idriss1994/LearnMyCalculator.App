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
        public event Action OnChange = delegate { };

        public void Raise()
        {
            //Invoke OnChange action
            OnChange();
        }
    }
}
