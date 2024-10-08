using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPIPro.DataAccess.IRepositories;
using WebAPIPro.DataAccess.Repositories;
using WebAPIPro.Models;

namespace WebAPIPro.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeptWebAPIController : ControllerBase
    {
        // Create DeptRepository Class Instance [It Will Not Possible]
        //public DeptRepository x = new DeptRepository();

        // Dependency Process to create Interface Reference
        public IDeptRepository deptRef;
        public DeptWebAPIController(IDeptRepository _deptRef)
        {
            deptRef = _deptRef;
        }

        // Web API Method / Web API End Point / Api for Insert Department Data
        [HttpPost]
        [Route("InsertDepartment")]
        public async Task<IActionResult> InsertDepartment(Department Dept)
        {
            try
            {
                var count = await deptRef.InsertDepartment(Dept);
                if (count > 0)
                {
                    return Ok(count + " record inserted...!");
                }
                else
                {
                    return BadRequest("Data not inserted...!");
                }
            }
            catch (Exception ex)
            {
                return BadRequest("Sorry for inconvineancs...!\nWe will solve this issue soon...!\n" + ex.Message);
            }
        }

        // Web API Method / Web API End Point / Api for Read Departments Data
        [HttpGet]
        [Route("AllDepartments")]
        public async Task<IActionResult> AllDepartments()
        {
            try
            {
                var Depts = await deptRef.AllDepartment();
                if (Depts.Count > 0)
                {
                    return Ok(Depts);
                }
                else
                {
                    return NotFound("There is no data available...!");
                }
            }
            catch (Exception ex)
            {
                return BadRequest("Sorry for inconvineancs...!\nWe will solve this issue soon...!\n" + ex.Message);
            }
        }

        // Web API Method / Web API End Point / Api for Read Department Data with DeptNo
        [HttpGet]
        [Route("DepartmentByDeptNo")]
        public async Task<IActionResult> DepartmentByDeptNo(int DeptNo)
        {
            try
            {
                var Dept = await deptRef.GetDepartmentByDeptNo(DeptNo);
                if (Dept != null)
                {
                    return Ok(Dept);
                }
                else
                {
                    return NotFound("Depatment with DeptNo : " + DeptNo + " is not available...!");
                }
            }
            catch (Exception ex)
            {
                return BadRequest("Sorry for inconvineancs...!\nWe will solve this issue soon...!\n" + ex.Message);
            }
        }

        // Web API Method / Web API End Point / Api for Update Department Data
        [HttpPut]
        [Route("UpdateDepartment")]
        public async Task<IActionResult> UpdateDepartment(Department Dept)
        {
            try
            {
                var count = await deptRef.UpdateDepartment(Dept);
                if (count > 0)
                {
                    return Ok(count + " record updated...!");
                }
                else
                {
                    return BadRequest("Data not updated...!");
                }
            }
            catch (Exception ex)
            {
                return BadRequest("Sorry for inconvineancs...!\nWe will solve this issue soon...!\n" + ex.Message);
            }
        }

        // Web API Method / Web API End Point / Api for Delete Department Data
        [HttpDelete]
        [Route("DeleteDepartment")]
        public async Task<IActionResult> DeleteDepartment(int DeptNo)
        {
            try
            {
                var count = await deptRef.DeleteDepartment(DeptNo);
                if (count > 0)
                {
                    return Ok(count + " record deleted...!");
                }
                else
                {
                    return BadRequest("Data not deleted...!");
                }
            }
            catch (Exception ex)
            {
                return BadRequest("Sorry for inconvineancs...!\nWe will solve this issue soon...!\n" + ex.Message);
            }
        }
    }
}
