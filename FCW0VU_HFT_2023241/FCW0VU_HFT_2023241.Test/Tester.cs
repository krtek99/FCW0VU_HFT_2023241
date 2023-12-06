using FCW0VU_HFT_2023241.Logic;
using FCW0VU_HFT_2023241.Models;
using FCW0VU_HFT_2023241.Repository;
using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FCW0VU_HFT_2023241.Test
{
    [TestFixture]
    public class Tester
    {
        EmployeeLogic employeeLogic;
        Mock<IRepository<Employee>> mockEmployeeRepository;

        DepartmentLogic departmentLogic;
        Mock<IRepository<Department>> mockDepartmentRepository;

        LocationLogic locationLogic;
        Mock<IRepository<Location>> mockLocationRepository;

        [SetUp]
        public void Init()
        {
            List<Employee> employees = new List<Employee>()
            {
                new Employee("1#Asd Gábor#250000#2"),
                new Employee("2#Gipsz Jakab#170000#4"),
                new Employee("3#Asd Péter#190000#4"),
                new Employee("4#Minta Anna#100000#6"),
                new Employee("5#Kovács János#350000#6"),
                new Employee("6#Sample Steven#150000#6")
            }.ToList();

            List<Department> departments = new List<Department>()
            {
                new Department("2#Finance#5#2000000#1200000"),
                new Department("4#Marketing#2#1800000#900000"),
                new Department("6#Production#4#2200000#1300000")
            }.ToList();

            List<Location> locations = new List<Location>()
            {
                new Location("2#Debrecen#Piac utca 10."),
                new Location("4#Pécs#Alkotmány utca 8."),
                new Location("5#Győr#Kossuth tér 3.")
            }.ToList();

            mockEmployeeRepository = new Mock<IRepository<Employee>>();
            mockEmployeeRepository.Setup(t => t.ReadAll()).Returns(employees.AsQueryable());

            mockDepartmentRepository = new Mock<IRepository<Department>>();
            mockDepartmentRepository.Setup(t => t.ReadAll()).Returns(departments.AsQueryable());

            mockLocationRepository = new Mock<IRepository<Location>>();
            mockLocationRepository.Setup(t => t.ReadAll()).Returns(locations.AsQueryable());

            //add department for each employee
            employees.ForEach(t => { t.Department = departments.Find(x => x.Id == t.DepartmentId); });

            //add location for each department
            departments.ForEach(t => { t.Location = locations.Find(x => x.Id == t.LocationId); });

            employeeLogic = new EmployeeLogic(mockEmployeeRepository.Object);
            departmentLogic = new DepartmentLogic(mockDepartmentRepository.Object);
            locationLogic = new LocationLogic(mockLocationRepository.Object);
        }

        //non-crud
        [Test]
        public void EmployeesPerDepartmentTest()
        {
            var result = employeeLogic.GetEmployeesPerDepartment();

            var expected = new List<KeyValuePair<string, int>>()
            {
                new KeyValuePair<string, int>("Finance", 1),
                new KeyValuePair<string, int>("Marketing", 2),
                new KeyValuePair<string, int>("Production", 3),
            };

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void AvgSalaryPerDepartmentTest()
        {
            var result = employeeLogic.GetAvgSalaryPerDepartment();

            var expected = new List<KeyValuePair<string, double>>()
            {
                new KeyValuePair<string, double>("Finance", 250000),
                new KeyValuePair<string, double>("Marketing", 180000),
                new KeyValuePair<string, double>("Production", 200000)
            };

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void LargestSalaryPerDepartmentTest()
        {
            var expected = new List<KeyValuePair<string, string>>()
            {
                new KeyValuePair<string, string>("Finance", "Asd Gábor"),
                new KeyValuePair<string, string>("Marketing", "Asd Péter"),
                new KeyValuePair<string, string>("Production", "Kovács János")
            };
        }

        [Test]
        public void DepartmentDetailsTest()
        {
            var result = departmentLogic.GetDepartmentNameDetails();

            var expected = new List<KeyValuePair<string, string>>()
            {
                new KeyValuePair<string, string>("Finance", "Győr, Kossuth tér 3."),
                new KeyValuePair<string, string>("Marketing", "Debrecen, Piac utca 10."),
                new KeyValuePair<string, string>("Production", "Pécs, Alkotmány utca 8.")
            };

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void TotalSalaryCostPerDepartmentTest()
        {
            var result = employeeLogic.GetTotalSalaryCostPerDepartment();

            var expected = new List<KeyValuePair<string, int>>()
            {
                new KeyValuePair<string, int>("Finance", 250000),
                new KeyValuePair<string, int>("Marketing", 360000),
                new KeyValuePair<string, int>("Production", 600000)
            };

            Assert.AreEqual(expected, result);
        }

        //crud
        [Test]
        public void CreateEmployeeTest()
        {
            var employee = new Employee("7#Qwerty Béla#100000#2");
            employeeLogic.Create(employee);

            mockEmployeeRepository.Verify(x => x.Create(employee), Times.Once);
        }

        [Test]
        public void CreateDepartmentTest()
        {
            var department = new Department("7#Freeloaders#5#1#1000000");
            departmentLogic.Create(department);

            mockDepartmentRepository.Verify(x => x.Create(department), Times.Once);
        }

        [Test]
        public void CreateLocationTest()
        {
            var location = new Location("6#Gyöngyös#Széchenyi utca 31.");
            locationLogic.Create(location);

            mockLocationRepository.Verify(x => x.Create(location), Times.Once);
        }

        [Test]
        public void CreateWrongEmployeeTest()
        {
            var employee = new Employee("7#Qwerty Béla#-1#2");
            try
            {
                employeeLogic.Create(employee);
            }
            catch
            {

            }

            mockEmployeeRepository.Verify(x => x.Create(employee), Times.Never);
        }

        [Test]
        public void CreateWrongDepartmentTest()
        {
            var department = new Department("11##1#1#1");
            try
            {
                departmentLogic.Create(department);
            }
            catch
            {

            }
            mockDepartmentRepository.Verify(x => x.Create(department), Times.Never);
        }
    }
}
