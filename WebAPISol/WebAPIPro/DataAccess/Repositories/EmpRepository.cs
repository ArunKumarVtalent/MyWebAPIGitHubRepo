using Microsoft.EntityFrameworkCore;
using WebAPIPro.DataAccess.IRepositories;
using WebAPIPro.DBContext;
using WebAPIPro.Models;

namespace WebAPIPro.DataAccess.Repositories
{
    public class EmpRepository : IEmpRepository
    {
        public ProjectDBContext dbContext;

        public EmpRepository(ProjectDBContext _dbContext) { dbContext = _dbContext; }

        public async Task<int> DeleteEmployee(int EmpId)
        {
            var emp = await dbContext.Employees.FindAsync(EmpId);
            dbContext.Employees.Remove(emp);
            return await dbContext.SaveChangesAsync();
        }

        public async Task<List<Employee>> GetAllEmployees()
        {
            return await dbContext.Employees.ToListAsync();
        }

        public async Task<Employee> GetEmployeeByEmailAndPassword(string Email, string Password)
        {
            //First and FirstOrDefault : Among multiple take only first
            //Single and SingleOrDefault : Here it will take only one record
            return await dbContext.Employees.Where(x => x.Email == Email && x.Password == Password).SingleOrDefaultAsync();
        }

        public async Task<Employee> GetEmployeeByEmpId(int EmpId)
        {
            return await dbContext.Employees.FindAsync(EmpId);
        }

        public async Task<List<Employee>> GetEmployeesByDeptNo(int DeptNo)
        {
            return await dbContext.Employees.Where(x => x.DeptNo == DeptNo).ToListAsync();
        }

        public async Task<List<Employee>> GetEmployeesByGender(string Gender)
        {
            return await dbContext.Employees.Where(x => x.Gender == Gender).ToListAsync();
        }

        // Definitions : 
        public async Task<int> InsertEmployee(Employee Emp)
        {
            await dbContext.Employees.AddAsync(Emp);
            return await dbContext.SaveChangesAsync();
        }

        public async Task<int> UpdateEmployee(Employee Emp)
        {
            dbContext.Employees.Update(Emp);
            return await dbContext.SaveChangesAsync();
        }
    }
}
