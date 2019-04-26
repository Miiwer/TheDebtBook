using Debt_Refactor.Model;
using Debt_Refactor.View;
using Debt_Refactor.CommandHandling;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Debt_Refactor.Annotations;

namespace Debt_Refactor.ViewModel
{
    public class mainViewModel :INotifyPropertyChanged
    {
        private ObservableCollection<Person> _persons;
        public static ObservableCollection<Person> people = new ObservableCollection<Person>();

        #region properties

        private string _currentPersonName;
        private string _newValue;
        private Person _currentPerson = null;

        public ObservableCollection<Person> Persons
        {
            get { return _persons; }
        }

        public string CurrentPersonName
        {
            get { return _currentPersonName; }
            set
            {
                if (_currentPersonName != value)
                {
                    _currentPersonName = value;
                    NotifyPropertyChanged();
                }
            }
        }


        public string NewValue
        {
            get { return _newValue; }
            set
            {
                if (_newValue != value)
                {
                    _newValue = value;
                    NotifyPropertyChanged();
                }
            }
        }

        #endregion


        public Person _Target;

        public mainViewModel()
        {
            _persons = people;
        }





        private ICommand _addDebtClickCommand;
        public ICommand AddDebtClickCommand

        #region Add_Button
        {
            get
            {
                return _addDebtClickCommand ??
                       (_addDebtClickCommand = new CommandHandler(
                           () => OnClickAdd(), true));
            }
        }

        private void OnClickAdd()
        {
            double addvalue;
            if (people.Count == 0)
            {
                if (double.TryParse(_newValue, out addvalue))
                {
                    people.Add(new Person(_currentPersonName, addvalue));
                    NotifyPropertyChanged();
                }
                else
                {
                    people.Add(new Person(_currentPersonName, 0));
                    NotifyPropertyChanged();
                }
            }
            else

            foreach (var d in people)
            {
                
                if (d.name == _currentPersonName)
                {
                    if (double.TryParse(_newValue, out addvalue))
                    {
                        try
                        {
                            var per = new Debt();
                            per.amount = addvalue;
                            per.date = DateTime.Now;
                            _Target.addAmount(per);
                        }
                        catch (Exception e)
                        {

                        }
                        finally
                        {
                            _newValue = string.Empty;
                            NotifyPropertyChanged("_newValue");
                            NotifyPropertyChanged("GetTransactionSum");
                            _Target.Invoke(new PropertyChangedEventArgs(""));
                        }
                      
                    }
                    else
                    {
                        people.Add(new Person(_currentPersonName, 0));
                    }
                }
                else
                {
                    if (double.TryParse(_newValue, out addvalue))
                    {
                        people.Add(new Person(_currentPersonName,addvalue));
                        NotifyPropertyChanged();
                        }
                    else
                    {
                        people.Add(new Person(_currentPersonName, 0));
                        NotifyPropertyChanged();

                    }
                }
            }
        }
        

        #endregion

        private ICommand _openPersonalDebts;
        public ICommand openPersonalDebts
        {
            get
            {
                return _openPersonalDebts ?? (_openPersonalDebts = new CommandHandler(() => openPersonHistory(), true));
            }
        }

        #region History_button

        public void openPersonHistory()
        {
            if (_currentPerson != null)
            {
                var createModel = new PersonViewModel();

                var personView = new PersonView();
                personView.DataContext = createModel;
                personView.Show();
            }
        }

        #endregion

        #region INotifyPropertyChanged implementation

        public event PropertyChangedEventHandler PropertyChanged;


        private void NotifyPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
