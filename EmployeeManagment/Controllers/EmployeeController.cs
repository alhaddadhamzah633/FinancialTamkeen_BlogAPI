using EmployeeManagment.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagment.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class EmployeeController : ControllerBase
    {
        private readonly EmployeeDbContext _employeeDbContext;
        public EmployeeController(EmployeeDbContext myEmployeeDbContext)
        {
            _employeeDbContext = myEmployeeDbContext;
        }
        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            var Employee = await _employeeDbContext.employee.ToListAsync();
            return Ok(Employee);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            if (id < 1)
                return BadRequest();
            var employee = await _employeeDbContext.employee.FirstOrDefaultAsync(m => m.EmployeeID == id);
            if (employee == null)
                return NotFound("The Employee Is Not Found !!!");
            return Ok(employee);

        }

        [HttpPost("/Create")]
        public async Task<IActionResult> Post([FromBody] Employee employee)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return UnprocessableEntity(ModelState);
                }
                _employeeDbContext.Add(employee);
                await _employeeDbContext.SaveChangesAsync();
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest("Employee is not Update, there's error!!!");
            }
        }
        [HttpPut("/Update")]
        
        public async Task<IActionResult> Put([FromBody]  Employee employeeData)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return UnprocessableEntity(ModelState);
                }
                
                if (employeeData == null || employeeData.EmployeeID == 0 )
                    return NotFound("Employee Is Not Found!!");

                var employee = await _employeeDbContext.employee.FindAsync(employeeData.EmployeeID);
                if (employee == null)
                    return NotFound();
                employee.FirstName = employeeData.FirstName;
                employee.LastName = employeeData.LastName;
                employee.Department = employeeData.Department;
                employee.salary = employeeData.salary;
                await _employeeDbContext.SaveChangesAsync();
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest("Employee is not Update, there's error!!!");
            }
        }
       
    }
}
