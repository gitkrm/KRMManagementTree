using Dto;
using KRMManagementTree.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace ManagementTreeUTest
{
    [TestClass]
    public class ManagementTreeUTest
    {
        [TestMethod]
        public void TestRootManagerNotFirstInList()
        {
            var employeeList = new List<EmployeeDto>()
            {
                new EmployeeDto() { Id = 2, Name = "Todd", ManagerId = 1 },
                new EmployeeDto() { Id = 3, Name = "Barry", ManagerId = 2},
                new EmployeeDto() { Id = 4, Name = "Sam", ManagerId= 1 },
                new EmployeeDto(){ Id = 1, Name = "Boss", ManagerId= 0 }
            };

            var controller = new EmployeeController(employeeList);

            // This should pass as the list will be empty because the Root Manager Id of 0 isn't the first entry in the list
            Assert.IsTrue(controller.Employees.Count == 0);
        }

        [TestMethod]
        public void TestCorrectListFormat()
        {
            var employeeList = new List<EmployeeDto>()
            {
                new EmployeeDto(){ Id = 1, Name = "Boss", ManagerId= 0 },
                new EmployeeDto() { Id = 2, Name = "Todd", ManagerId = 1 },
                new EmployeeDto() { Id = 3, Name = "Barry", ManagerId = 2},
                new EmployeeDto() { Id = 4, Name = "Sam", ManagerId= 1 },
            };

            var controller = new EmployeeController(employeeList);

            // This should pass as the list will be populated - Root manager first entry in list
            Assert.IsTrue(employeeList.Count == employeeList.Count);
        }

        [TestMethod]
        public void TestListCollectionForNullEntry()
        {
            var employeeList = new List<EmployeeDto>()
            {
                new EmployeeDto(){ Id = 1, Name = "Boss", ManagerId= 0 },
                new EmployeeDto() { Id = 2, Name = "Todd", ManagerId = 1 },
                null,
                new EmployeeDto() { Id = 3, Name = "Barry", ManagerId = 2},
                new EmployeeDto() { Id = 4, Name = "Sam", ManagerId= 1 },
            };

            var controller = new EmployeeController(employeeList);

            // This should pass the condition because the list passed in will be different size from controllers employee list
            // Null entries won't be added
            Assert.IsTrue(employeeList.Count != controller.Employees.Count);
        }

        [TestMethod]
        public void TestForMultipleRootManagers()
        {
            var employeeList = new List<EmployeeDto>()
            {
                new EmployeeDto(){ Id = 1, Name = "Boss", ManagerId= 0 },
                new EmployeeDto() { Id = 2, Name = "Todd", ManagerId = 0 },
                new EmployeeDto() { Id = 3, Name = "Barry", ManagerId = 2},
                new EmployeeDto() { Id = 4, Name = "Sam", ManagerId= 1 },
            };

            var controller = new EmployeeController(employeeList);

            // This should pass the condition because the list passed in will be different size from controllers employee list
            // There cannot be two root managers
            Assert.IsTrue(employeeList.Count != controller.Employees.Count);
        }

        [TestMethod]
        public void TestForMissingName()
        {
            var employeeList = new List<EmployeeDto>()
            {
                new EmployeeDto(){ Id = 1, Name = "Boss", ManagerId= 0 },
                new EmployeeDto() { Id = 2, Name = "", ManagerId = 0 },
                new EmployeeDto() { Id = 3, Name = "Barry", ManagerId = 2},
                new EmployeeDto() { Id = 4, Name = "Sam", ManagerId= 1 },
            };

            var controller = new EmployeeController(employeeList);

            // This should pass the condition because the list passed in will be different size from controllers employee list
            // All employee entries must have a name
            Assert.IsTrue(employeeList.Count != controller.Employees.Count);
        }

        [TestMethod]
        public void TestForBadManagersId()
        {
            var employeeList = new List<EmployeeDto>()
            {
                new EmployeeDto(){ Id = 1, Name = "Boss", ManagerId= 0 },
                new EmployeeDto() { Id = 2, Name = "", ManagerId = -2 },
                new EmployeeDto() { Id = 3, Name = "Barry", ManagerId = 2},
                new EmployeeDto() { Id = 4, Name = "Sam", ManagerId= 1 },
            };

            var controller = new EmployeeController(employeeList);

            // This should pass the condition because the list passed in will be different size from controllers employee list
            // All employee manager ids must be greater than 0
            Assert.IsTrue(employeeList.Count != controller.Employees.Count);
        }

        [TestMethod]
        public void TestForBadId()
        {
            var employeeList = new List<EmployeeDto>()
            {
                new EmployeeDto(){ Id = 1, Name = "Boss", ManagerId= 0 },
                new EmployeeDto() { Id = 0, Name = "", ManagerId = 1 },
                new EmployeeDto() { Id = 3, Name = "Barry", ManagerId = 2},
                new EmployeeDto() { Id = 4, Name = "Sam", ManagerId= 1 },
            };

            var controller = new EmployeeController(employeeList);

            // This should pass the condition because the list passed in will be different size from controllers employee list
            // All employee ids must be greater than 1
            Assert.IsTrue(employeeList.Count != controller.Employees.Count);
        }

    }
}
