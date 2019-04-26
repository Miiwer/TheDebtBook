using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Debt_Refactor.Annotations;
using Debt_Refactor.Model;


namespace Debt_Refactor.Model
{
    public class Person : INotifyPropertyChanged
    {
        public string name { get; set; }
        public ObservableCollection<IDebt> Transactions;

        public static ObservableCollection<Person> people = new ObservableCollection<Person>();

        public Person()
        {
            Transactions = new ObservableCollection<IDebt>();
        }

        public Person(string name, double currentTransaction)
        {
            Transactions = new ObservableCollection<IDebt>();
            this.name = name;
            var newTransaction = new Debt();
            newTransaction.amount = currentTransaction;
            newTransaction.date = DateTime.Now;
            Transactions.Add(newTransaction);
        }

        public string getTransactionSum
        {
            get
            {
                double sum = 0;
                foreach (var transaction in Transactions)
                {
                    sum += transaction.amount;
                }

                return sum.ToString();
            }
            set
            {
                if (null != value)
                {
                    Debt aValue = new Debt();
                    aValue.amount = Convert.ToDouble(value);
                    aValue.date = DateTime.Now;
                    Transactions.Add(aValue);
                    OnPropertyChanged("GetSumFromViewModel");

                }
            }
        }


        public void addAmount(IDebt debit)
        {
            Transactions.Add(debit);
        }

        #region INotifyPropertyChanged & Invoke implementation
        
        public void Invoke(PropertyChangedEventArgs propertyChangedEventArgs)
        {
            PropertyChanged?.Invoke(this, propertyChangedEventArgs);
        }





        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion

    }
}
