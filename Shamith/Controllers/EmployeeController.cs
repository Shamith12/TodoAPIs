using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shamith.Models;

namespace Shamith.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly Employee employee;

        public EmployeeController()
        {
            employee = new Employee();
        }

        //Get All
        [HttpGet]
        [Route("Get")]
        public IEnumerable<Uoj> GetAll()
        {
            return employee.GetAll();
        }

        //Insert
        [HttpPost]

        public String Post([FromBody] Uoj uoj)
        {
            if (ModelState.IsValid)
            {
                employee.Add(uoj);
                return "Success";

            }
            else
            {
                return "NotSuccess";
            }
        }

        //Update
        [HttpPut("{id}")]
        public String Put(int id,[FromBody] Uoj Uoj)
        {
            Uoj.Todo_Id = id;
            if (ModelState.IsValid)
            {
                employee.Update(Uoj);
                return "Success";
            }
            else
            {
                return "NotSuccess";
            }
        }

        //Delete
        [HttpDelete]
        public String Delete(int id)
        {
            employee.Delete(id);
            return "Success";
        }
    }
}

