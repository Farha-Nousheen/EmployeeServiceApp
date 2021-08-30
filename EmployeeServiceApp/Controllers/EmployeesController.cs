using EmployeeServiceApp.Data;
using EmployeeServiceApp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeServiceApp.Controllers
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        EmployeeContext _context;
        public EmployeesController(EmployeeContext context)
        {
            _context = context;
        }
        [HttpPost]
        public IActionResult CreateEmployee(Employee emp)
        {
            _context.Employee.Add(emp);
            _context.SaveChanges();
            return Ok();
        }
        [HttpGet]
        public List<Employee> GetEmployee()
        {
            var emp = _context.Employee.ToList();
            return emp;
        }
        // PUT: api/Employees/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public IActionResult UpdateEmployee(Employee emp)
        {
            var result = _context.Employee.FirstOrDefault(e => e.Id == emp.Id);
            if (result != null)
            {
                result.Age = emp.Age;
                result.Name = emp.Name;
                result.Country = emp.Country;
                result.Designation = emp.Designation;
                result.ContactNumber = emp.ContactNumber;
                _context.SaveChanges();
                return Ok();
            }
            return NotFound();
        }
        [HttpPost]
        public string Getusername(string Email)
        {
            var name = Email.Split('@')[0];
            return name;
        }
        // GET: api/Employees/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Employee>> GetEmployee(int id)
        {
            var employee = await _context.Employee.FindAsync(id);



            if (employee == null)
            {
                return NotFound();
            }



            return employee;
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            var employee = await _context.Employee.FindAsync(id);
            if (employee == null)
            {
                return NotFound();
            }

            _context.Employee.Remove(employee);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EmployeeExists(int id)
        {
            throw new NotImplementedException();
        }
    }
}
