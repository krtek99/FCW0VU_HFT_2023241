using ConsoleTools;
using FCW0VU_HFT_2023241.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Numerics;

namespace FCW0VU_HFT_2023241.Client
{
    internal class Program
    {
        static RestService rest;
        static void Create(string entity)
        {
            try
            {
                if (entity == "Employee")
                {
                    Employee emp = new Employee();
                    Console.WriteLine("Enter employee's name:");
                    string name = Console.ReadLine();
                    emp.Name = name;

                    Console.WriteLine("Enter employee's salary:");
                    string salary = Console.ReadLine();
                    emp.Salary = int.Parse(salary);

                    Console.WriteLine("Enter employee's department id:");
                    string department = Console.ReadLine();
                    emp.DepartmentId = int.Parse(department);
                    rest.Post(emp, "employee");
                }
                if (entity == "Department")
                {
                    Department dep = new Department();
                    Console.WriteLine("Enter department's name:");
                    string name = Console.ReadLine();
                    dep.Name = name;

                    Console.WriteLine("Enter department's income:");
                    string income = Console.ReadLine();
                    dep.Income = int.Parse(income);

                    Console.WriteLine("Enter department's expenses:");
                    string expenses = Console.ReadLine();
                    dep.Expenses = int.Parse(expenses);

                    Console.WriteLine("Enter department's location id:");
                    string location = Console.ReadLine();
                    dep.Expenses = int.Parse(location);
                    rest.Post(dep, "department");
                }
                if (entity == "Location")
                {
                    Location loc = new Location();
                    Console.WriteLine("Enter location's name:");
                    string name = Console.ReadLine();
                    loc.Name = name;

                    Console.WriteLine("Enter location's address:");
                    string address = Console.ReadLine();
                    loc.Address = address;
                    rest.Post(loc, "location");
                }
            }
            catch
            {
                Console.WriteLine("Invalid input!");
                Console.ReadLine();
            }
        }
        static void List(string entity)
        {
            if (entity == "Employee")
            {
                List<Employee> employees = rest.Get<Employee>("employee");
                Console.WriteLine("Id\tName\t\tSalary\tDepartment_Id");
                foreach (var item in employees)
                {
                    Console.WriteLine(item.Id + "\t" + item.Name + "\t" + item.Salary + "\t" + item.DepartmentId);
                }
                Console.WriteLine();
            }
            if (entity == "Department")
            {
                List<Department> departments = rest.Get<Department>("department");
                Console.WriteLine("Id\tName\tIncome\tExpenses\tLocation_Id");
                foreach (var item in departments)
                {
                    Console.WriteLine(item.Id + "\t" + item.Name + "\t" + item.Income + "\t" + item.Expenses + "\t" + item.LocationId);
                }
                Console.WriteLine();
            }
            if (entity == "Location")
            {
                List<Location> locations = rest.Get<Location>("location");
                Console.WriteLine("Id\tCity\tAddress");
                foreach (var item in locations)
                {
                    Console.WriteLine(item.Id + "\t" + item.Name + "\t" + item.Address);
                }
                Console.WriteLine();
            }
            if(entity == "Stat/GetDepartmentNameDetails")
            {
                List<KeyValuePair<string, string>> q = rest.Get<KeyValuePair<string, string>>("Stat/GetDepartmentNameDetails");

                foreach (var item in q)
                {
                    Console.WriteLine(item.Key + "\t" + item.Value);
                }
            }
            if(entity == "Stat/GetAvgSalaryPerDepartment")
            {
                List<KeyValuePair<string, double>> q = rest.Get<KeyValuePair<string, double>>("Stat/GetAvgSalaryPerDepartment");

                foreach (var item in q)
                {
                    Console.WriteLine(item.Key + "\t" + item.Value);
                }
            }
            if (entity == "Stat/GetEmployeesPerDepartment")
            {
                List<KeyValuePair<string, int>> q = rest.Get<KeyValuePair<string, int>>("Stat/GetEmployeesPerDepartment");

                foreach (var item in q)
                {
                    Console.WriteLine(item.Key + "\t" + item.Value);
                }
            }
            if (entity == "Stat/GetLargestSalaryPerDepartment")
            {
                List<KeyValuePair<string, string>> q = rest.Get<KeyValuePair<string, string>>("Stat/GetLargestSalaryPerDepartment");

                foreach (var item in q)
                {
                    Console.WriteLine(item.Key + "\t" + item.Value);
                }
            }
            if (entity == "Stat/GetTotalSalaryCostPerDepartment")
            {
                List<KeyValuePair<string, int>> q = rest.Get<KeyValuePair<string, int>>("Stat/GetTotalSalaryCostPerDepartment");

                foreach (var item in q)
                {
                    Console.WriteLine(item.Key + "\t" + item.Value);
                }
            }

            Console.ReadLine();
        }
        static void Update(string entity)
        {
            if (entity == "Employee")
            {
                try
                {
                    Employee one = new Employee();
                    
                    Console.Write("Enter employee's id to update: ");
                    int id = int.Parse(Console.ReadLine());
                    one = rest.Get<Employee>(id, "employee");

                    if(one == null)
                    {
                        throw new ArgumentException("No employee found with given id.");
                    }

                    Console.Write($"New name [old: {one.Name}]: ");
                    string name = Console.ReadLine();
                    one.Name = name;

                    Console.Write($"New salary [old: {one.Salary}]: ");
                    string salary = Console.ReadLine();
                    one.Salary = int.Parse(salary);

                    Console.Write($"New department_id [old: {one.DepartmentId}]: ");
                    string dep = Console.ReadLine();
                    one.DepartmentId = int.Parse(dep);

                    rest.Put(one, "employee");
                }
                catch (ArgumentException e)
                {
                    Console.WriteLine(e.Message);
                    Console.ReadLine() ;
                }
                catch
                {
                    Console.WriteLine("Invalid input!");
                    Console.ReadLine();
                }
            }
            if (entity == "Department")
            {
                try
                {
                    Department one = new Department();

                    Console.Write("Enter department's id to update: ");
                    int id = int.Parse(Console.ReadLine());
                    one = rest.Get<Department>(id, "department");
                    
                    if(one == null)
                    {
                        throw new ArgumentException("No department found with given id.");
                    }

                    Console.Write($"New name [old: {one.Name}]: ");
                    string name = Console.ReadLine();
                    one.Name = name;

                    Console.Write($"New income [old: {one.Income}]: ");
                    string income = Console.ReadLine();
                    one.Income = int.Parse(income);

                    Console.Write($"New expenses [old: {one.Expenses}]: ");
                    string exp = Console.ReadLine();
                    one.Expenses = int.Parse(exp);

                    Console.Write($"New location id [old: {one.LocationId}]: ");
                    string loc = Console.ReadLine();
                    one.Expenses = int.Parse(loc);
                    rest.Put(one, "dpeartment");
                }
                catch (ArgumentException e)
                {
                    Console.WriteLine(e.Message);
                    Console.ReadLine();
                }
                catch
                {
                    Console.WriteLine("Invalid input!");
                    Console.ReadLine();
                }
            }
            if (entity == "Location")
            {
                try
                {
                    Location one = new Location();
                    
                    Console.Write("Enter location's id to update: ");
                    int id = int.Parse(Console.ReadLine());
                    one = rest.Get<Location>(id, "employee");

                    if(one == null)
                    {
                        throw new ArgumentException("No location found with given id.");
                    }

                    Console.Write($"New name [old: {one.Name}]: ");
                    string name = Console.ReadLine();
                    one.Name = name;

                    Console.Write($"New address [old: {one.Address}]: ");
                    string address = Console.ReadLine();
                    one.Address = address;

                    rest.Put(one, "location");
                }
                catch (ArgumentException e)
                {
                    Console.WriteLine(e.Message);
                    Console.ReadLine();
                }
                catch
                {
                    Console.WriteLine("Invalid input!");
                    Console.ReadLine();
                }
            }
        }
        static void Delete(string entity)
        {
            try
            {
                if (entity == "Employee")
                {
                    Console.Write("Enter employee's id to delete: ");
                    int id = int.Parse(Console.ReadLine());
                    rest.Delete(id, "employee");
                }
                if (entity == "Department")
                {
                    Console.Write("Enter department's id to delete: ");
                    int id = int.Parse(Console.ReadLine());
                    rest.Delete(id, "department");
                }
                if (entity == "Location")
                {
                    Console.Write("Enter location's id to delete: ");
                    int id = int.Parse(Console.ReadLine());
                    rest.Delete(id, "location");
                }
            }
            catch
            {
                Console.WriteLine($"No {entity.ToLower()} found with given id.");
                Console.ReadLine();
            }
        }
        static void Read(string entity)
        {
            if (entity == "Employee")
            {
                try
                {
                    Console.WriteLine("Id of requested employee: ");
                    int id = int.Parse(Console.ReadLine());
                    Employee result = rest.Get<Employee>(id, "employee");
                    if (result == null)
                    {
                        Console.WriteLine("This employee does not exist.");
                    }
                    else
                    {
                        Console.WriteLine(result.Id + "\t" + result.Name + "\t" + result.Salary + "\t" + result.DepartmentId);
                    }
                }
                catch
                {
                    Console.WriteLine("Invalid input.");
                }
                Console.ReadLine();
            }
            if (entity == "Department")
            {
                try
                {
                    Console.WriteLine("Id of requested department: ");
                    int id = int.Parse(Console.ReadLine());
                    Department result = rest.Get<Department>(id, "department");
                    if (result == null)
                    {
                        Console.WriteLine("This employee does not exist.");
                    }
                    else
                    {
                        Console.WriteLine(result.Id + "\t" + result.Name + "\t" + result.Income + "\t" + result.Expenses + "\t" + result.LocationId);
                    }
                }
                catch
                {
                    Console.WriteLine("Invalid input.");
                }
                Console.ReadLine();
            }
            if (entity == "Location")
            {
                try
                {
                    Console.WriteLine("Id of requested location: ");
                    int id = int.Parse(Console.ReadLine());
                    Location result = rest.Get<Location>(id, "location");
                    if (result == null)
                    {
                        Console.WriteLine("This employee does not exist."); ;
                    }
                    else
                    {
                        Console.WriteLine(result.Name + "\t" + result.Address);
                    }
                }
                catch
                {
                    Console.WriteLine("Invalid input.");
                }
                Console.ReadLine();
            }
        }

        static void Main(string[] args)
        {
            rest = new RestService("http://localhost:13109/", "Department");

            var employeeSubMenu = new ConsoleMenu(args, level: 1)
                .Add("Read", () => Read("Employee"))
                .Add("List", () => List("Employee"))
                .Add("Create", () => Create("Employee"))
                .Add("Delete", () => Delete("Employee"))
                .Add("Update", () => Update("Employee"))
                .Add("Exit", ConsoleMenu.Close);

            var departmentSubMenu = new ConsoleMenu(args, level: 1)
                .Add("Read", () => Read("Department"))
                .Add("List", () => List("Department"))
                .Add("Create", () => Create("Department"))
                .Add("Delete", () => Delete("Department"))
                .Add("Update", () => Update("Department"))
                .Add("Exit", ConsoleMenu.Close);

            var locationSubMenu = new ConsoleMenu(args, level: 1)
                .Add("Read", () => Read("Location"))
                .Add("List", () => List("Location"))
                .Add("Create", () => Create("Location"))
                .Add("Delete", () => Delete("Location"))
                .Add("Update", () => Update("Location"))
                .Add("Exit", ConsoleMenu.Close);

            var statSubMenu = new ConsoleMenu(args, level: 1)
                .Add("Department Details", () => List("Stat/GetDepartmentNameDetails"))
                .Add("Average Salary By Departments", () => List("Stat/GetAvgSalaryPerDepartment"))
                .Add("Employees By Departments", () => List("Stat/GetEmployeesPerDepartment"))
                .Add("Largest Salary By Departments", () => List("Stat/GetLargestSalaryPerDepartment"))
                .Add("Total Salary Cost By Departments", () => List("Stat/GetTotalSalaryCostPerDepartment"))
                .Add("Exit", ConsoleMenu.Close);


            var menu = new ConsoleMenu(args, level: 0)
                .Add("Employee", () => employeeSubMenu.Show())
                .Add("Department", () => departmentSubMenu.Show())
                .Add("Location", () => locationSubMenu.Show())
                .Add("Statistics",() => statSubMenu.Show())
                .Add("Exit", ConsoleMenu.Close);

            menu.Show();
        }
    }
}
