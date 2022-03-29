using Dto;
using KRMManagementTree.Models;

namespace KRMManagementTree.Services
{
    public interface IEmployeeService
    {
        // Would be set up async in real world
        Employees CreateNewEmployee(EmployeeDto dto);
    }
}
