using Microsoft.EntityFrameworkCore;
using WebAPIPro.DataAccess.IRepositories;
using WebAPIPro.DBContext;
using WebAPIPro.Models;

namespace WebAPIPro.DataAccess.Repositories
{
    public class DeptRepository : IDeptRepository
    {
        // Context Class object Creation
        public ProjectDBContext dbContext;

        public DeptRepository(ProjectDBContext _dbContext)
        {
            dbContext = _dbContext;
        }

        public async Task<List<Department>> AllDepartment()
        {
            return await dbContext.Departments.ToListAsync();
        }

        public async Task<int> DeleteAllDepartments()
        {
            var DeptList = await dbContext.Departments.ToListAsync();
            dbContext.Departments.RemoveRange(DeptList);
            return await dbContext.SaveChangesAsync();
        }

        public async Task<int> DeleteDepartment(int DeptNo)
        {
            var Dept = await dbContext.Departments.FindAsync(DeptNo);
            dbContext.Departments.Remove(Dept);
            return await dbContext.SaveChangesAsync();
        }

        public async Task<Department> GetDepartmentByDeptNo(int DeptNo)
        {
            return await dbContext.Departments.FindAsync(DeptNo);
        }

        public async Task<List<Department>> GetDepartmentsByLocation(string Location)
        {
            return await dbContext.Departments.Where(x => x.Location == Location).ToListAsync();
        }

        // Define Methods : 
        public async Task<int> InsertDepartment(Department Dept)
        {
            // Write a logic to insert department data into Database
            await dbContext.Departments.AddAsync(Dept);
            return await dbContext.SaveChangesAsync();
        }

        public async Task<int> UpdateDepartment(Department Dept)
        {
            dbContext.Departments.Update(Dept);
            return await dbContext.SaveChangesAsync();
        }
    }
}
