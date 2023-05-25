using Microsoft.EntityFrameworkCore;
using System;


namespace EmpAPI.Models
{
	public class EmployeeContext: DbContext
	{
		public EmployeeContext(DbContextOptions<EmployeeContext> options) : base(options)
		{
			Database.EnsureCreated();

		}

		public DbSet<Employee> employees { get; set; }
	}
}

