namespace LMMS.UI.Models
{
    public class EmpLeaveBalViewModel
    {
      
            public int EmployeeLeaveBalanceId { get; set; }

            public int Id { get; set; }

            public string Name { get; set; } //username

            public int LeaveTypeId { get; set; }

            public string LeaveTypeName { get; set; }  //leave name

            public int AvailableDays { get; set; }
   

    }
}
