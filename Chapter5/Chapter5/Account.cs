using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter5
{
    class Account
    {
        public delegate void AccountStateHandler(string message);
        AccountStateHandler asd;
        private event AccountStateHandler _notify;
        public event AccountStateHandler Notify
        {
            add
            {
                _notify += value;
                Console.WriteLine($"{value.Method.Name} добавлен");
            }
            remove
            {
                _notify -= value;
                Console.WriteLine($"{value.Method.Name} удален");
            }
        }
        //public void RegisterHandler(AccountStateHandler accountState)
        //{
        //    asd += accountState;
        //}
        //public void DeleteHandler(AccountStateHandler accountState)
        //{
        //    asd -= accountState;
        //}
        int _sum; // Переменная для хранения суммы

        public Account(int sum)
        {
            _sum = sum;
        }

        public int CurrentSum
        {
            get { return _sum; }
        }

        public void Put(int sum)
        {
            _sum += sum;
            _notify?.Invoke($"На счет поступило: {sum}");
        }

        public void Withdraw(int sum)
        {
            if (sum <= _sum)
            {
                _sum -= sum;

                _notify?.Invoke($"Со счета снято: {sum}");
            }
            else
            {
                _notify?.Invoke($"Недостаточно денег на счете. Текущий баланс: {_sum}"); ;
            }
        }
    }
    
    
}
