using Dto;
using KRMManagementTree.Models;
using KRMManagementTree.Services;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace KRMManagementTree.Controllers
{
    public class EmployeeController : IEmployeeService
    {
        /* 
         * Controller for creating default employees list
         * Validates creation of new list if list is passed in from external source
         * Builds management tree to be output
         * 
         */

        // List of employess
        public List<Employees> Employees { get; set; } = new List<Employees>();

        // Default constructor for populating list of employees when called
        public EmployeeController()
        {
            Employees.Add(new Employees() { Id = 1, Name = "Tom", ManagerId = 0 }); // Root manager
            Employees.Add(new Employees() { Id = 2, Name = "Mickey", ManagerId = 1 });
            Employees.Add(new Employees() { Id = 3, Name = "Jerry", ManagerId = 1 });
            Employees.Add(new Employees() { Id = 4, Name = "John", ManagerId = 2 });
            Employees.Add(new Employees() { Id = 5, Name = "Sarah", ManagerId = 1 });

            Employees.Sort();
        }

        // Constructor overload to allow for list to be populated from external source
        public EmployeeController(List<EmployeeDto> employees)
        {
            if (employees != null)
            {
                // initialise list
                Employees = new List<Employees>();
                var index = 1;

                foreach (var employee in employees)
                {
                    if (employee == null)
                    {
                        continue;
                    }

                    if (index == 1)
                    {
                        // first employee must be the root manager
                        if (!ValidEmployee(employee))
                            break;

                        Employees.Add(Create(employee));
                        index++;
                        continue;
                    }

                    if (ValidEmployee(employee))
                        Employees.Add(Create(employee));
                }

                Employees.Sort();
            }
        }

        // Validate Employee List
        public bool ValidEmployee(EmployeeDto employee)
        {
            // protect against bad entries
            if (employee == null)
                return false;

            // first entry must be root manager
            if (Employees.Count == 0 && employee.ManagerId != 0)
                return false;

            // Can only be one root manager
            if (Employees.Count >= 1 && employee.ManagerId == 0)
                return false;

            // must have name
            if (string.IsNullOrWhiteSpace(employee.Name))
                return false;

            // must have an id
            if (employee.Id <= 0)
                return false;

            var addToList = true;

            // validate unique Id
            foreach (var employeeInCurrentList in Employees)
            {
                if (employeeInCurrentList.Id == employee.Id)
                    addToList = false;
            }

            return addToList;
        }

        // Builds up management table to be displayed.
        public string DisplayManagementTable()
        {
            StringBuilder sb = new StringBuilder();

            if (Employees.Count == 0)
                return "Please verify that Employee list is correct - First entry must have a Managers Id of 0";

            foreach (var employee in Employees)
            {
                switch (employee.ManagerId)
                {
                    case 0:
                        sb.AppendLine($"->{employee.Name}");
                        break;
                    case 1:
                        sb.AppendLine($"->->{employee.Name}");
                        break;
                    case 2:
                        sb.AppendLine($"->->->{employee.Name}");
                        break;
                }
            }

            return sb.ToString();
        }

        // -- would be set up using constructor injection, service to create new employee
        public Employees Create(EmployeeDto dto) =>
            Create(dto);
        
    }
}
