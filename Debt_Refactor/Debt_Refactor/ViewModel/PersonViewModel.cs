using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Collections.ObjectModel;
using System.Linq;
using Debt_Refactor.Model;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Debt_Refactor.View;
using Debt_Refactor.CommandHandling;


namespace Debt_Refactor.ViewModel
{ 
    public class PersonViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] string propertyName = null)
        {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


       
        public string DebitValue { get; set; }


    }
}
