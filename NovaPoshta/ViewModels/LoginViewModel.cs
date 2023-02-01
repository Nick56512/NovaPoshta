using NovaPoshta.BusinessLogic.Context;
using NovaPoshta.Infrastructure;
using NovaPoshta.Model;
using NovaPoshta.Views.HomeView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Authentication;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace NovaPoshta.ViewModels
{
    public class LoginViewModel:BaseNotifyOfPropertyChanged
    {
        public string Login { get; set; }
        public string Password { get; set; }
        AuthenticationService authenticationService;
        public ICommand LoginCommand { get; set; }
        public LoginViewModel() {
            authenticationService= new AuthenticationService();
            LoginCommand = new RelayCommand((obj) =>
            {
                Employee employee= authenticationService.Login(Login, Password);
                if(employee != null)
                {
                    Switcher.Switch(new HomeView());
                }
            });
        }
    }
}
