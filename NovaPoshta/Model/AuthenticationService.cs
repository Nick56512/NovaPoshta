using NovaPoshta.BusinessLogic.Context;
using NovaPoshta.BusinessLogic.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NovaPoshta.Model
{
    public class AuthenticationService
    {
        IRepository<Employee> repository { get; set; }
        public static Employee CurrentUser { get; set; }
        public AuthenticationService() { 
            repository=new EmployeeRepository();
        }
        public Employee Login(string login,string password)
        {
            CurrentUser=repository
                .GetAll()
                .FirstOrDefault(x => x.Login==login&&x.Password==password);
            return CurrentUser;
        }

    }
}
