using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankLibrary
{
    public delegate void AccountStateHandler(object sender, AccountEvent e);
    public class AccountEvent
    {
        //message
        public string Message { get; set; }
        //sum changes
        public decimal Sum { get; private set; }
        public AccountEvent(string mes,decimal sum)
        {
            Message = mes;
            Sum = sum;
        }
    }
}
