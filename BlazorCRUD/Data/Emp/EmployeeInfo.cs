using System.ComponentModel.DataAnnotations;

namespace BlazorCRUD.Data
{
    public class EmployeeInfo
    {
        [Key]
        public int EmpId { get; set; }
       
        public string Name { get; set; }
       
        public string City { get; set; }
       
        public string Country { get; set; }
       
        public string Gender { get; set; }
    }
}
