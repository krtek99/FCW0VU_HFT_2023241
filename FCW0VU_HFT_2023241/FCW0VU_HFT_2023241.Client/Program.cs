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
            if (entity == "Employee")
            {
                Console.Write("Enter employee's id to update: ");
                int id = int.Parse(Console.ReadLine());
                Employee one = rest.Get<Employee>(id, "employee");

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
            if (entity == "Department")
            {
                Console.Write("Enter department's id to update: ");
                int id = int.Parse(Console.ReadLine());
                Department one = rest.Get<Department>(id, "department");

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
            if (entity == "Location")
            {
                Console.Write("Enter location's id to update: ");
                int id = int.Parse(Console.ReadLine());
                Location one = rest.Get<Location>(id, "employee");

                Console.Write($"New name [old: {one.Name}]: ");
                string name = Console.ReadLine();
                one.Name = name;

                Console.Write($"New address [old: {one.Address}]: ");
                string address = Console.ReadLine();
                one.Address = address;

                rest.Put(one, "location");
            }
        }
        static void Delete(string entity)
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
