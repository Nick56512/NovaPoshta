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

        public PoshtomatsListViewModel()
        {
            poshtomatRepository=new PoshtomatRepository();
            Poshtomats=new ObservableCollection<Poshtomat>(poshtomatRepository.GetAll());
        }
    }
}
