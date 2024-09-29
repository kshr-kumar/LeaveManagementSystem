using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMMS.Models
{
    public class EmpLeaveModel
    {
        public int EmployeeLeaveId { get; set; }

        public int Id { get; set; }
        public string Name { get; set; }  //User Name
        public int LeaveTypeId { get; set; }
        public string LeaveTypeName { get; set; }    //casual leave

        public DateOnly LeaveStartDate { get; set; }

        public DateOnly LeaveEndDate { get; set; }

        public int DaysTaken { get; set; }

        //navigation Properties
        public LeaveTypeModel LeaveTypeModel { get; set; }

        public UserModel UserModel { get; set; }
    
    }
}
