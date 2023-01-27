﻿
using NovaPoshta.Infrastructure;
using NovaPoshta.Views.Login;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace NovaPoshta.ViewModels
{
    internal class MainViewModel:BaseNotifyOfPropertyChanged,INavigator
    {
        UserControl currentView;
        public UserControl CurrentView
        {
            get => currentView;
            set
            {
                currentView = value;
                NotifyPropertyChanged();
            }
        }
        public MainViewModel()
        {
            Switcher.ContentArea = this;
            Switcher.Switch(new LoginView());
        }

        public void Navigate(UserControl page)
        {
           CurrentView= page;
        }
    }
}