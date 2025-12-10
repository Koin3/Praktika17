using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sstarr17
{
    //заданме 1
    public struct Color
    {
        public byte R { get; set; }
        public byte G { get; set; }
        public byte B { get; set; }

        public Color(byte r, byte g, byte b)
        {
            R = r;
            G = g;
            B = b;
        }
        public override string ToString()
        {
            return $"RGB ({R}, {G}, {B})";
        }
    }
    //заданме 2
    public class Order
    {
        public int Id { get; set; }
        public decimal Total { get; set; }

        public Order(int id, decimal total)
        {
            Id = id;
            Total = total;
        }
    }
    //заданме 3
    [Flags]
    public enum FileAccess
    {
        None = 0,
        Read = 1,
        Write = 2,
        Execute = 4
    }
    public struct File
    {
        public FileAccess Permissions { get; set; }

        public bool CanRead()
        {
            return Permissions.HasFlag(FileAccess.Read);
        }

        public bool CanWrite()
        {
            return Permissions.HasFlag(FileAccess.Write);
        }
    }
    //заданме 4
    public struct Weather
    {
        public string City { get; set; }
        public double? Temperature { get; set; }
        public override string ToString()
        {
            string tempDisplay = Temperature?.ToString("F1") ?? "Нет данных.";
            return $"{City}: {tempDisplay}";
        }
    }
    //задание 5 
    public enum EmploymentStatus
    {
        Active,
        OnLeave,
        Terminated
    }
    public class Employee
    {
        public string Name { get; set; }
        public DateTime? HireDate { get; set; }
        public EmploymentStatus Status { get; set; }
        public int GetYearsWorked()
        {
            if (HireDate == null)
                return -1;
            DateTime currentDate = DateTime.Now;
            int years = currentDate.Year - HireDate.Value.Year;
            if (currentDate < HireDate.Value.AddYears(years))
            {
                years--;
            }
            return years;
        }
        public override string ToString()
        {
            string experience = HireDate == null ? "не указан." : $"{GetYearsWorked()} лет";
            return $"{Name}, статус: {Status}, стаж: {experience}";
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {

            //выдод 1 
            var c1 = new Color(255, 128, 0);
            var c2 = c1;
            c2.R = 100;
            Console.WriteLine(c1);
            Console.WriteLine(c2);
            Console.WriteLine();

            //вывод 2 
            var order1 = new Order(1001, 1500.50m);
            var order2 = order1;
            order2.Total = 2000.00m;
            Console.WriteLine(order1.Total);
            Console.WriteLine();

            //вывод 3 
            var f = new File { Permissions = FileAccess.Read | FileAccess.Write };
            Console.WriteLine(f.CanRead());
            Console.WriteLine(f.CanWrite());
            Console.WriteLine();

            //вывод 4 
            var w1 = new Weather { City = "Москва", Temperature = 22.5 };
            var w2 = new Weather { City = "Сочи", Temperature = null };
            Console.WriteLine(w1);
            Console.WriteLine(w2);
            Console.WriteLine(w2.Temperature ?? -999);
            Console.WriteLine();

            //вывод 5 
            var emp = new Employee
            {
                Name = "Илюха Монеси",
                HireDate = new DateTime(2020, 3, 15),
                Status = EmploymentStatus.Active
            };
            Console.WriteLine(emp.GetYearsWorked());
            emp.HireDate = null;
            Console.WriteLine(emp.GetYearsWorked());
            Console.WriteLine(emp);

        }
    }
}
