using NovaPoshta.Infrastrcture;
using NovaPoshta.Infrastructure;
using NovaPoshta.Views.Employees;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace NovaPoshta.ViewModels
{
    internal class HomeViewModel:BaseNotifyOfPropertyChanged,INavigator
    {
        UserControl currentHomePage;
        public UserControl CurrentHomePage
        {
            get
            {
                return currentHomePage;
            }
            set
            {
                currentHomePage= value;
                NotifyPropertyChanged();
            }
        }
        public HomeViewModel() {
            HomeSwitcher.ContentArea = this;
            HomeSwitcher.Switch(new EmployeesListView());
        }

        public void Navigate(UserControl page)
        {
           this.CurrentHomePage = page;
        }
    }
}
