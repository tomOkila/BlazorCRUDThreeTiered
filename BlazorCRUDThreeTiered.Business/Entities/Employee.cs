using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorCRUDThreeTiered.Business.Entities
{
    public class Employee
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? EmailAddress { get; set; }
        public Department? Department { get; set; }
        public int? DepartmentId { get; set; }
        public string? ProfilePic { get; set; }
        public string? CVDocument { get; set; }
    }
}
