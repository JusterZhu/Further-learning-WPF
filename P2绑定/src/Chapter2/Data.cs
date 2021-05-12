using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter2
{
    public class Data
    {
        private string processSomeData = "done";

        public string ProcessSomeData
        {
            get 
            {
                Task.Delay(2000).Wait();
                return processSomeData;
            }
        }

        private string myData = "donwload data.";

        public string MyData
        {
            get
            {
                Task.Delay(1000).Wait();
                return myData;
            }
        }

        private int age;

        public int Age
        {
            get
            {
                return age;
            }

            set { age = value; }
        }
    }
}
