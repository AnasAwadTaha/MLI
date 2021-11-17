using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MLI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MLI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
       private readonly AppDbContext _appDbContext;
        public EmployeeController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        // GET: api/<EmployeeController>
        [HttpGet]
        public IActionResult Get()
        {
           var List = _appDbContext.Employees.ToList().FirstOrDefault();
            return Ok(List);
        }

        // GET api/<EmployeeController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var _emp = _appDbContext.Employees.FirstOrDefault(n => n.Id == id);
            return Ok(_emp);
        }

        // POST api/<EmployeeController>
        [HttpPost("Create")]
        public void Post([FromBody] Employee employee)
        {
            _appDbContext.Add(employee);
            _appDbContext.SaveChanges();
        }
        [HttpGet]
        public List<Employee> Getemp([FromBody] Employee employee)
        {
            var _emp = _appDbContext.Employees.Where(e => e.EmpName.Contains(employee.EmpName)).ToList();

            return _emp;
        }

        // PUT api/<EmployeeController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Employee employee)
        {
            _appDbContext.Entry(employee).State = EntityState.Modified;
            _appDbContext.SaveChanges();
        }

        // DELETE api/<EmployeeController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var _emp = _appDbContext.Employees.FirstOrDefault(n => n.Id == id);
            _appDbContext.Remove(_emp);
            _appDbContext.SaveChanges();
        }
    }
}
