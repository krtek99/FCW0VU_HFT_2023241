using ConsoleTools;
using System;

namespace FCW0VU_HFT_2023241.Client
{
    internal class Program
    {
        static EmployeeLogic employeeLogic;
        static DepartmentLogic departmentLogic;
        static LocationLogic locationLogic;

        static void Create(string entity)
        {
            Console.WriteLine(entity + " create");
            Console.ReadLine();
        }
        static void List(string entity)
        {
            if (entity == "Employee")
            {
                var items = employeeLogic.ReadAll();
                Console.WriteLine("Id" + "\t" + "Name" + "\t" + "Salary" + "\t" + "DepartmentId");
                foreach (var item in items)
                {
                    Console.WriteLine(item.Id + "\t" + item.Name + "\t" + item.Salary + "\t" + item.DepartmentId);
                }
            }
            if (entity == "Employee")
            {
                var items = departmentLogic.ReadAll();
                Console.WriteLine("Id" + "\t" + "Name" + "\t" + "Income" + "\t" + "Expenses" + "\t" + "LocationId");
                foreach (var item in items)
                {
                    Console.WriteLine(item.Id + "\t" + item.Name + "\t" + item.Income + "\t" + item.Expenses + "\t" + item.LocationId);
                }
            }
            if (entity == "Location")
            {
                var items = locationLogic.ReadAll();
                Console.WriteLine("Id" + "\t" + "Name" + "\t" + "Adress");
                foreach (var item in items)
                {
                    Console.WriteLine(item.Id + "\t" + item.Name + "\t" + item.Address);
                }
            }

            Console.ReadLine();
        }
        static void Update(string entity)
        {
            Console.WriteLine(entity + " update");
            Console.ReadLine();
        }
        static void Delete(string entity)
        {
            Console.WriteLine(entity + " delete");
            Console.ReadLine();
        }

        static void Main(string[] args)
        {
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
