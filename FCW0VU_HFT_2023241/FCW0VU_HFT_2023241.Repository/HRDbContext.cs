using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FCW0VU_HFT_2023241.Models;

namespace FCW0VU_HFT_2023241.Repository
{
    public class HRDbContext : DbContext
    {
        public DbSet<Department> Departments { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Location> Locations { get; set; }

        public HRDbContext()
        {
            this.Database.EnsureCreated();
        }

        public HRDbContext(DbContextOptions<HRDbContext> options)
            : base(options)
        {
            this.Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured) // csak akkor, ha még nem történt meg a konfiguráció
            {
                optionsBuilder.UseLazyLoadingProxies();
                optionsBuilder.UseInMemoryDatabase("HRdb");
                base.OnConfiguring(optionsBuilder);

            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Department>(entity => 
                { entity
                .HasOne(department => department.Location)
                .WithMany(location => location.Departments)
                .HasForeignKey(department => department.LocationId)
                .OnDelete(DeleteBehavior.ClientSetNull);
                }
            );

            modelBuilder.Entity<Employee>(entity => 
                { entity
                .HasOne(employee => employee.Department)
                .WithMany(department => department.Employees)
                .HasForeignKey(employee => employee.DepartmentId).OnDelete(DeleteBehavior.ClientSetNull);
                }
            );

            modelBuilder.Entity<Department>().HasData(
                new Department("1#HR#3#150000#80000"),
                new Department("2#Finance#5#200000#120000"),
                new Department("3#IT#2#300000#150000"),
                new Department("4#Marketing#2#180000#90000"),
                new Department("5#Sales#1#250000#110000"),
                new Department("6#Production#4#220000#130000"),
                new Department("7#Research#5#280000#140000"),
                new Department("8#Customer Service#3#170000#95000"),
                new Department("9#Legal#1#190000#100000"),
                new Department("10#Administration#5#210000#105000")
                );

            modelBuilder.Entity<Employee>().HasData(
                new Employee("1#Kovács Gábor#250000#2"),
                new Employee("2#Nagy Eszter#180000#4"),
                new Employee("3#Szabó Anna#210000#6"),
                new Employee("4#Tóth Péter#300000#3"),
                new Employee("5#Horváth Zsuzsa#220000#1"),
                new Employee("6#Kiss Bence#260000#3"),
                new Employee("7#Molnár Viktória#190000#7"),
                new Employee("8#Németh Dániel#280000#4"),
                new Employee("9#Farkas Csilla#270000#5"),
                new Employee("10#Papp Ádám#200000#9"),
                new Employee("11#Kovács Dávid#240000#2"),
                new Employee("12#Nagy Emese#170000#4"),
                new Employee("13#Szabó Ádám#190000#6"),
                new Employee("14#Tóth Anna#280000#3"),
                new Employee("15#Horváth István#230000#3"),
                new Employee("16#Kiss Eszter#250000#3"),
                new Employee("17#Molnár Gábor#200000#7"),
                new Employee("18#Németh Anna#260000#10"),
                new Employee("19#Farkas István#250000#5"),
                new Employee("20#Papp Eszter#180000#9")
                );

            modelBuilder.Entity<Location>().HasData(
                new Location("1#Budapest#Deák tér 5."),
                new Location("2#Debrecen#Piac utca 10."),                
                new Location("3#Szeged#Kossuth Lajos sugárút 15."),
                new Location("4#Pécs#Alkotmány utca 8."),
                new Location("5#Győr#Kossuth tér 3.")
                );
        }
    }
}
