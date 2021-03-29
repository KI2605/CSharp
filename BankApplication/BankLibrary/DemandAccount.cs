using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankLibrary
{
    //класс, который будет представлять счет до востребования
    class DemandAccount :Account
    {
        public DemandAccount(decimal sum, int percentage) : base(sum, percentage)
        {

        }
        protected internal override void Open()
        {
            base.OnOpened(new AccountEvent($"Открыт новый счет до востребования! Id счета: {this.Id}", this.Sum));
        }
    }

}
