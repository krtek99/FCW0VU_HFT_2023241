using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FCW0VU_HFT_2023241.Models;

namespace FCW0VU_HFT_2023241.Repository
{
    public class EducationDbContext : DbContext
    {
        public DbSet<University> Universities { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Student> Students { get; set; }

        public EducationDbContext()
        {
            this.Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();
            optionsBuilder.UseInMemoryDatabase("EduDb");
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>(x => x.
            HasOne<University>().WithMany().
            HasForeignKey(x => x.UniversityID).
            OnDelete(DeleteBehavior.Cascade));

            modelBuilder.Entity<Student>(x => x.
            HasOne<Course>().WithMany().
            HasForeignKey(x => x.CourseID).
            OnDelete(DeleteBehavior.Cascade));

            modelBuilder.Entity<University>().HasData(
                new University("1#Eötvös Loránd Egyetem#Budapest#1635#30000"),
                new University("2#Pécsi Tudományegyetem#Pécs#1367#20000"),
                new University("3#Debreceni Egyetem#Debrecen#1912#25000"),
                new University("4#Szegedi Tudományegyetem#Szeged#1921#28000"),
                new University("5#Budapesti Műszaki és Gazdaságtudományi Egyetem#Budapest#1782#21000")
                );

            modelBuilder.Entity<Course>().HasData(
                new Course("1#Algoritmizálás#5"),
                new Course("2#Adatbázisok#4"),
                new Course("3#Webfejlesztés#6"),
                new Course("4#Programozás alapjai#4"),
                new Course("5#Mesterséges intelligencia#7"),
                new Course("6#Matematika alapjai#4"),
                new Course("7#Angol nyelvű irodalom#5"),
                new Course("8#Grafikus tervezés#6"),
                new Course("9#Mikrobiológia#5"),
                new Course("10#Pénzügyi számvitel#4")
                );

            modelBuilder.Entity<Student>().HasData(
                new Student("1#Kovács Gábor#ABC123#2#4"),
                new Student("2#Nagy Eszter#XYZ456#3#6"),
                new Student("3#Szabó Anna#DEF789#4#8"),
                new Student("4#Tóth Péter#UVW321#1#5"),
                new Student("5#Horváth Zsuzsa#GHI654#2#2"),
                new Student("6#Kiss Bence#ABC999#3#9"),
                new Student("7#Molnár Viktória#XYZ777#4#7"),
                new Student("8#Németh Dániel#DEF555#1#10"),
                new Student("9#Farkas Csilla#UVW888#3#3"),
                new Student("10#Papp Ádám#GHI333#2#1")
                );
        }
    }
}
