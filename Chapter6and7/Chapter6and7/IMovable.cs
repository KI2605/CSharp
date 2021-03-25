using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter6and7
{
    interface IMovable
    {
        const int minSpeed = 0;
        private static int maxSpeed = 60;
        static double GetTime(double distance,int speed)
        {
            return distance / speed;
        }
        static int MaxSpeed
        {
            get { return maxSpeed; }
            set
            {
                if (value > 0) maxSpeed = value;
            }
        }
        void Move()
        {
            Console.WriteLine("Going with speed"+MaxSpeed);
        }
    }
}
