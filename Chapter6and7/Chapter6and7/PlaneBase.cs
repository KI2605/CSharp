using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter6and7
{
    public partial class Plane
    {
        partial void DoSomethingElse();
        public void Move()
        {
            DoSomethingElse();
            Console.WriteLine("I am a plane- and I am moving");
        }
    }
}
