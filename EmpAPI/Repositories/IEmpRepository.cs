using System;
using EmpAPI.Models;

namespace EmpAPI.Repositories
{
	public interface IEmpRepository
	{
		Task<IEnumerable<Employee>> Get();
		Task<Employee> Get(int EmpId);

		Task<Employee> Create(Employee employee);
		Task Update(Employee employee);
		Task Delete(int EmpId);

	}
}

