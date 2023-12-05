using ConsoleTools;
using FCW0VU_HFT_2023241.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Numerics;

namespace FCW0VU_HFT_2023241.Client
{
    internal class Program
    {
        static RestService rest;
        static void Create(string entity)
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
            }

            Console.ReadLine();
        }
        static void Update(string entity)
        {
            if (entity == "Actor")
            {
                Console.Write("Enter Actor's id to update: ");
                int id = int.Parse(Console.ReadLine());
                Employee one = rest.Get<Employee>(id, "actor");
                Console.Write($"New name [old: {one.Name}]: ");
                string name = Console.ReadLine();
                one.Name = name;
                rest.Put(one, "actor");
            }
        }
        static void Delete(string entity)
        {
            Console.WriteLine(entity + " delete");
            Console.ReadLine();
        }

        static void Main(string[] args)
        {
            rest = new RestService("http://localhost:13109", "/Department");

            var employeeSubMenu = new ConsoleMenu(args, level: 1)
                .Add("List", () => List("Employee"))
                .Add("Create", () => Create("Employee"))
                .Add("Delete", () => Delete("Employee"))
                .Add("Update", () => Update("Employee"))
                .Add("Exit", ConsoleMenu.Close);

            var departmentSubMenu = new ConsoleMenu(args, level: 1)
                .Add("List", () => List("Department"))
                .Add("Create", () => Create("Department"))
                .Add("Delete", () => Delete("Department"))
                .Add("Update", () => Update("Department"))
                .Add("Exit", ConsoleMenu.Close);

            var locationSubMenu = new ConsoleMenu(args, level: 1)
                .Add("List", () => List("Location"))
                .Add("Create", () => Create("Location"))
                .Add("Delete", () => Delete("Location"))
                .Add("Update", () => Update("Location"))
                .Add("Exit", ConsoleMenu.Close);


            var menu = new ConsoleMenu(args, level: 0)
                .Add("Employee", () => employeeSubMenu.Show())
                .Add("Department", () => departmentSubMenu.Show())
                .Add("Location", () => locationSubMenu.Show())
                .Add("Exit", ConsoleMenu.Close);

            menu.Show();
        }
    }
}
