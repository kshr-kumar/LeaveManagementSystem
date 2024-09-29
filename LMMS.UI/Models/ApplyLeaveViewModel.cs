using LMMS.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace LMMS.UI.Models
{
    public class ApplyLeaveViewModel
    {
        public int EmployeeLeaveId { get; set; }
        public int Id { get; set; }
        public string? Name { get; set; }  //User Name
        public int LeaveTypeId { get; set; }
        public string? LeaveTypeName { get; set; }    //casual leave

        public DateOnly LeaveStartDate { get; set; }

        public DateOnly LeaveEndDate { get; set; }

        public int DaysTaken { get; set; }

        // Add this property to hold the list of leave types for the dropdown
        
    }
}
