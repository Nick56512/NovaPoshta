using NovaPoshta.BusinessLogic.Context;
using NovaPoshta.BusinessLogic.Repositories;
using NovaPoshta.Infrastrcture;
using NovaPoshta.Infrastructure;
using NovaPoshta.Views.HomeView;
using NovaPoshta.Views.Poshtomats;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace NovaPoshta.ViewModels
{
    public class AddPoshtomatViewModel
    {
        IRepository<Poshtomat> poshtomatRepository;
        public Poshtomat NewPoshtomat { get; set; }
        public ICommand AddNewPoshtomatCommand { get; set; }
        
        public AddPoshtomatViewModel()
        {
            poshtomatRepository=new PoshtomatRepository();
            NewPoshtomat= new Poshtomat();
            AddNewPoshtomatCommand = new RelayCommand((obj) =>
            {
                NewPoshtomat.Id=Guid.NewGuid();
                poshtomatRepository.Create(NewPoshtomat);
                poshtomatRepository.SaveChangesAsync();

                Switcher.Switch(new HomeView());
                HomeSwitcher.Switch(new PoshtomatsListView());
            });
        }
    }
}
