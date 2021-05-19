using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter5
{
    public enum Person
    {
        One = 1,
        Two,
        Three,
        Four,
        Five,
        Six,
        Seven
    }

    public class MainModel
    {
        public string Name { get; set; }

        public Person Person { get; set; }

        public string Color { get; set; }
    }
}
