using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankLibrary
{
    class DepositAccount : Account
    {
        public DepositAccount(decimal sum, int percentage) : base(sum, percentage)
        {

        }
        protected internal override void Open()
        {
            base.OnOpened(new AccountEvent($"Открыт новый депозитный счет! Id счета: {this.Id}", this.Sum));
        }
        public override void Put(decimal sum)
        {
            if (days % 30 == 0)
                base.Put(sum);
            else
                base.OnAdded(new AccountEvent("На счет можно положить только после 30-ти дневного периода", 0));
        }
        protected internal override void Calculate()
        {
            if (days % 30 == 0)
                base.Calculate();
        }
    }
    }

