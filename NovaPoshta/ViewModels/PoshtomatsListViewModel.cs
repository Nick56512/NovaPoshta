using NovaPoshta.BusinessLogic.Context;
using NovaPoshta.BusinessLogic.Repositories;
using NovaPoshta.Infrastructure;
using NovaPoshta.Views.Poshtomats;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace NovaPoshta.ViewModels
{
    public class PoshtomatsListViewModel:BaseNotifyOfPropertyChanged
    {
        IRepository<Poshtomat> poshtomatRepository;
        public Poshtomat SelectedPoshtomat { get; set; }
        ObservableCollection<Poshtomat> poshtomats;
        public ObservableCollection<Poshtomat> Poshtomats
        {
            get
            {
                return poshtomats;
            }

            set
            {
                poshtomats = value;
                NotifyPropertyChanged();
            }

        }
        public ICommand AddPoshtomatCommand { get; set; }
        public ICommand RemovePoshtomatCommand { get; set; }
        public ICommand UpdatePoshtomatCommand { get; set; }
        public PoshtomatsListViewModel()
        {
            poshtomatRepository=new PoshtomatRepository();
            Poshtomats=new ObservableCollection<Poshtomat>(poshtomatRepository.GetAll());
            InitCommand();
        }

        private void InitCommand()
        {
            AddPoshtomatCommand = new RelayCommand((obj) =>
            {
                Switcher.Switch(new AddPoshtomatView());

            });

            RemovePoshtomatCommand = new RelayCommand((obj) =>
            {
                if (SelectedPoshtomat != null)
                {
                    poshtomatRepository.Delete(SelectedPoshtomat);
                    poshtomatRepository.SaveChangesAsync();
                    Poshtomats.Remove(SelectedPoshtomat);
                }

            });
            UpdatePoshtomatCommand = new RelayCommand((obj) => {

                if (SelectedPoshtomat != null)
                {
                    UserControl updatingView = new EditPoshtomatView();
                    EditPoshtomatViewModel vm = new EditPoshtomatViewModel();
                    vm.UpdatingPoshtomat = SelectedPoshtomat;
                    updatingView.DataContext = vm;
                    Switcher.Switch(updatingView);
                }
                
            
            });
        }
    }
}
