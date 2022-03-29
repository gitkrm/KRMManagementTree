
namespace Dto
{
    public class EmployeeDto
    {
        // data transfer object - carries data between processes
        public int Id { get; set; }
        public string Name { get; set; }    
        public int ManagerId { get; set; }

        public EmployeeDto() { }
    }
}
