using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter6
{
    public class MainModel
    {
        public string Name { get; set; }

        public int Age { get; set; }

        public string Message { get; set; }

        public override string ToString()
        {
            return $"{ Name } { Age } { Message }";
        }
    }
}
