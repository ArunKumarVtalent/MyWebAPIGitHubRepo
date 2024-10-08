using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPIPro.DataAccess.IRepositories;
using WebAPIPro.Filters;
using WebAPIPro.Models;

namespace WebAPIPro.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [MyExceptionFilter]
    public class EmpWebAPIController : ControllerBase
    {
        public IEmpRepository empRef;

        public EmpWebAPIController(IEmpRepository _empRef)
        {
            empRef = _empRef;
        }

        [HttpPost]
        [Route("InsertEmployee")]
        public async Task<IActionResult> InsertEmployee([FromBody] Employee Emp)
        {
            //try
            //{
                if (ModelState.IsValid)
                {
                    var count = await empRef.InsertEmployee(Emp);
                    if (count > 0)
                    {
                        return Ok(count + " : record inserted...!");
                    }
                    else
                    {
                        return BadRequest("Recored not inserted...!");
                    }
                }
                else
                {
                    return BadRequest(ModelState);
                }
            //}
            //catch(Exception ex)
            //{
            //    return BadRequest("Sorry for inconvineancs...!\nWe will solve this issue soon...!\n" + ex.Message);
            //}
        }

        [HttpPut]
        [Route("UpdateEmployee")]
        public async Task<IActionResult> UpdateEmployee([FromBody] Employee Emp)
        {
            //try
            //{
                var count = await empRef.UpdateEmployee(Emp);
                if (count > 0)
                {
                    return Ok(count + " : record updated...!");
                }
                else
                {
                    return BadRequest("Recored not update...!");
                }
            //}
            //catch (Exception ex)
            //{
            //    return BadRequest("Sorry for inconvineancs...!\nWe will solve this issue soon...!\n" + ex.Message);
            //}
        }

        [HttpDelete]
        [Route("DeleteEmployee")]
        public async Task<IActionResult> DeleteEmployee(int EmpId)
        {
            //try
            //{
                var count = await empRef.DeleteEmployee(EmpId);
                if (count > 0)
                {
                    return Ok(count + " : record delete...!");
                }
                else
                {
                    return BadRequest("Recored is not deleted...!");
                }
            //}
            //catch (Exception ex)
            //{
            //    return BadRequest("Sorry for inconvineancs...!\nWe will solve this issue soon...!\n" + ex.Message);
            //}
        }


        [HttpGet]
        [Route("AllEmployees")]
        [MyActionFilter]
        [MyResultFilter]
        [MyExceptionFilter]
        public async Task<IActionResult> AllEmployees()
        {
            //try
            //{
            //throw new DivideByZeroException();
            //throw new ApplicationException("My Custme Exception...!");
                var EmpList = await empRef.GetAllEmployees();
                if (EmpList.Count > 0)
                {
                    return Ok(EmpList);
                }
                else
                {
                    return BadRequest("Recoreds are not available...!");
                }
            //}
            //catch (Exception ex)
            //{
            //    return BadRequest("Sorry for inconvineancs...!\nWe will solve this issue soon...!\n" + ex.Message);
            //}
        }

        [HttpGet]
        [Route("EmployeeByEmpId")]
        public async Task<IActionResult> EmployeeByEmpId(int EmpId)
        {
            //try
            //{
                var Emp = await empRef.GetEmployeeByEmpId(EmpId);
                if (Emp != null)
                {
                    return Ok(Emp);
                }
                else
                {
                    return BadRequest("Recored is not available...!");
                }
            //}
            //catch (Exception ex)
            //{
            //    return BadRequest("Sorry for inconvineancs...!\nWe will solve this issue soon...!\n" + ex.Message);
            //}
        }

        [HttpGet]
        [Route("EmployeeByEmailAndPassword")]
        public async Task<IActionResult> EmployeeByEmailAndPassword(string Email, string Password)
        {
            //try
            //{
                var Emp = await empRef.GetEmployeeByEmailAndPassword(Email, Password);
                if (Emp != null)
                {
                    return Ok(Emp);
                }
                else
                {
                    return BadRequest("Recored is not available...!");
                }
            //}
            //catch (Exception ex)
            //{
            //    return BadRequest("Sorry for inconvineancs...!\nWe will solve this issue soon...!\n" + ex.Message);
            //}
        }

        [HttpGet]
        [Route("EmployeesByDeptNo")]
        public async Task<IActionResult> EmployeesByDeptNo(int DeptNo)
        {
            //try
            //{
                var Emps = await empRef.GetEmployeesByDeptNo(DeptNo);
                if (Emps.Count != 0)
                {
                    return Ok(Emps);
                }
                else
                {
                    return BadRequest("Recoreds are not available...!");
                }
            //}
            //catch (Exception ex)
            //{
            //    return BadRequest("Sorry for inconvineancs...!\nWe will solve this issue soon...!\n" + ex.Message);
            //}
        }
    }
}
