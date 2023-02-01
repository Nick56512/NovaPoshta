using NovaPoshta.BusinessLogic.Context;
using NovaPoshta.BusinessLogic.Repositories;
using NovaPoshta.Infrastructure;
using NovaPoshta.Views.HomeView;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace NovaPoshta.ViewModels
{
    public class AddEmployeeViewModel:BaseNotifyOfPropertyChanged
    {
        IRepository<Employee> employeeRepository;
        IRepository<Poshtomat> poshtomatRepository;

        ObservableCollection<Poshtomat> poshtomats;
        public ObservableCollection<Poshtomat> Poshtomats 
        {
            get
            {
                return poshtomats;
            }

            set
            {
                poshtomats= value;
                NotifyPropertyChanged();
            } 
        
        }
        public Guid PoshtomatId { get; set; }
        public Employee NewEmployee { get; set; }
        public ICommand AddNewEmployeeCommand { get; set; }
        public AddEmployeeViewModel()
        {
            employeeRepository = new EmployeeRepository();
            poshtomatRepository = new PoshtomatRepository();
            NewEmployee = new Employee();
            AddNewEmployeeCommand = new RelayCommand((obj) =>
            {
                employeeRepository.Create(NewEmployee);
                employeeRepository.SaveChangesAsync();
                Switcher.Switch(new HomeView());
            });
        }
    }
}
