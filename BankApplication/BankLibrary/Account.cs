using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankLibrary
{
   public abstract class Account:IAccount
    {
        //Событие, возникающее при выводе денег
        protected internal event AccountStateHandler WithDrawed;
        // Событие возникающее при добавление на счет
        protected internal event AccountStateHandler Added;
        // Событие возникающее при открытии счета
        protected internal event AccountStateHandler Opened;
        // Событие возникающее при закрытии счета
        protected internal event AccountStateHandler Closed;
        // Событие возникающее при начислении процентов
        protected internal event AccountStateHandler Calculated;

        static int counter = 0;
        protected int days = 0; // время с момента открытия счета

        public Account(decimal sum,int percentage)
        {
            Sum = sum;
            Percentage = percentage;
            Id = ++counter;
        }
        // Текущая сумма на счету
        public decimal Sum { get; private set; }
        // Процент начислений
        public int Percentage { get; private set; }
        // Уникальный идентификатор счета
        public int Id { get; private set; }


        // вызов событий
        private void CallEvent(AccountEvent e,AccountStateHandler handler)
        {
            if (e != null)
                handler?.Invoke(this, e);
        }

        // вызов отдельных событий. Для каждого события определяется свой витуальный метод
        protected virtual void OnOpened(AccountEvent e)
        {
            CallEvent(e, Opened);
        }
         protected virtual void OnWithdrawed(AccountEvent e)
        {
            CallEvent(e, WithDrawed);
        }
        protected virtual void OnAdded(AccountEvent e)
        {
            CallEvent(e, Added);
        }
        protected virtual void OnClosed(AccountEvent e)
        {
            CallEvent(e, Closed);
        }
        protected virtual void OnCalculated(AccountEvent e)
        {
            CallEvent(e, Calculated);
        }

        //Положили денюжку
        public virtual void Put(decimal sum)
        {
            Sum += sum;
            OnAdded(new AccountEvent("На счет поступило" + sum,sum));
        }
        //Сняли денюжку
        public decimal Withdraw(decimal sum)
        {
            decimal result = 0;
            if (Sum >= sum)
            {
                Sum -= sum;
                result = sum;
                OnWithdrawed(new AccountEvent($"Сумма {sum} снята со счета {Id}", sum));
            }
            else
            {
                OnWithdrawed(new AccountEvent($"Недостаточно денег на счете {Id}", 0));
            }
            return result;
        }
       
        // открытие счета
        protected internal virtual void Open()
        {
            OnOpened(new AccountEvent($"Открыт новый счет! Id счета: {Id}", Sum));
        }
        //закрітие счета
        protected internal virtual void Close()
        {
            OnClosed(new AccountEvent($"Счет номер: {Id} успешно закрыт.Итоговая сумма: {Sum}", Sum));
        }
        protected internal void IncrementDays()
        {
            days++;
        }
        // начисление процентов
        protected internal virtual void Calculate()
        {
            decimal increment = Sum * Percentage / 100;
            Sum = Sum + increment;
            OnCalculated(new AccountEvent($"Начислены проценты в размере: {increment}", increment));
        }


    }


}

