using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NovaPoshta.BusinessLogic.Context
{
    public class Poshtomat
    {
        public Guid Id { get; set; }
        public string Number { get; set; }
        public string Address { get; set; }
        public int MaxQuantity { get; set; }
        public int CurrentQuantity { get; set; }
    }
}
