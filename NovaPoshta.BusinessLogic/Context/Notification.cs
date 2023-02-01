using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NovaPoshta.BusinessLogic.Context
{
    public class Notification
    {
        public Guid Id { get; set; }
        public DateTime DateTime { get; set; }
        public DateTime StartTime { get; set; }
        public Guid EmployeeId { get; set; }
        public virtual Employee Employee { get; set; }
    }
}
