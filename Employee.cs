using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
namespace DemoWPF
{
    // Employee.cs
    public class Employee
    {
        public int EmployeeID { get; set; }
        public string? Name { get; set; }
        public string? Position { get; set; }
        public int Age { get; set; }
        public decimal Salary { get; set; }
    }

// SampleDbContext.cs


public class SampleDbContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }

        public SampleDbContext() : base("name=SampleDbConnectionString")
        {
        }
    }

}
