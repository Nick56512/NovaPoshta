using NovaPoshta.BusinessLogic.Context;
using NovaPoshta.BusinessLogic.Repositories;
using NovaPoshta.Infrastructure;
using NovaPoshta.Model;
using NovaPoshta.Views.Employees;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace NovaPoshta.ViewModels
{
    public enum SortEmployeeType
    {
        ByFullName,
        ByDateOfBirth,
        ByNumberPhone,
        ByPoshtomat
    }
    public class EmployeesListViewModel:BaseNotifyOfPropertyChanged
    {
        IRepository<Employee> _employeesRepository;
        public ICommand AddEmployeeCommand { get; set; }
        public ICommand RemoveEmployeeCommand { get; set; }
        public ICommand UpdateEmployeeCommand { get; set; }
        public ICommand SearchEmployeeCommand { get; set; }
        public string SearchString { get; set; }
        public string LoggedUser { get; set; } = $"{AuthenticationService.CurrentUser.Name} {AuthenticationService.CurrentUser.LastName}";

        ObservableCollection<Employee> employees;
        public ObservableCollection<Employee> Employees
        {
            get => employees;
            set
            {
                employees = value;
                NotifyPropertyChanged();
            }
        }
        public Employee SelectedEmployee { get; set; }
        SortEmployeeType sortType;
        public SortEmployeeType SortType
        {
            get => sortType;
            set
            {
                sortType = value;
                SortEmployees();
                NotifyPropertyChanged();
            }
        }
        public EmployeesListViewModel()
        {
            _employeesRepository = new EmployeeRepository();
            UploadEmployees();
            InitCommands();
        }



        private void InitCommands()
        {
            AddEmployeeCommand = new RelayCommand((obj) =>
            {
                Switcher.Switch(new AddEmployeeView());
            });
            RemoveEmployeeCommand = new RelayCommand((obj) =>
            {
                _employeesRepository.Delete(SelectedEmployee);
                Employees.Remove(SelectedEmployee);

            }, (obj) => SelectedEmployee != null);
        }
        private async void UploadEmployees()
        {
            Employees = new ObservableCollection<Employee>(await _employeesRepository.GetAllAsync());
        }
        private void SortEmployees()
        {

        }
    }
}
