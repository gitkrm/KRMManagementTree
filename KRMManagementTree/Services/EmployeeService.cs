using Dto;
using KRMManagementTree.Models;
using System.Threading.Tasks;

namespace KRMManagementTree.Services
{
    public class EmployeeService : IEmployeeService
    {
        // This would be used for saving to DB implemented using DI
        public Employees Create(EmployeeDto dto) =>
           new Employees()
            {
                Id = dto.Id,
                Name = dto.Name,
                ManagerId = dto.ManagerId,
            };

}
}
