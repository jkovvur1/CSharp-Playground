using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmpAPI.Models;
using EmpAPI.Repositories;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EmpAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmpRepository _empRepository;

        public EmployeesController(IEmpRepository empRepository)
        {
            _empRepository = empRepository;

        }

        [HttpGet]
        public async Task<IEnumerable<Employee>> GetEmployees()
        {
            return await _empRepository.Get();
        }

        [HttpGet("{EmpId}")]
        public async Task<ActionResult<Employee>> GetEmployees(int EmpId)
        {
            return await _empRepository.Get(EmpId);
        }

        [HttpPost]
        public async Task<ActionResult<Employee>> PostEmployees([FromBody] Employee employee)
        {
            var newEmployee = await _empRepository.Create(employee);
            return CreatedAtAction(nameof(GetEmployees), new { EmpId = newEmployee.EmpId }, newEmployee);
        }

        [HttpPut]
        public async Task<ActionResult<Employee>> PutEmployees(int EmpId, [FromBody] Employee employee)
        {
            if(EmpId != employee.EmpId)
            {
                return BadRequest();
            }

            await _empRepository.Update(employee);
            return NoContent();
        }

        [HttpDelete("{EmpId}")]
        public async Task<ActionResult> Delete(int EmpId)
        {
            var employeeToDelete = await _empRepository.Get(EmpId);
            if(employeeToDelete == null)
            {
                return NotFound();
            }

            await _empRepository.Delete(employeeToDelete.EmpId);
            return NoContent();
        }
    }
}

