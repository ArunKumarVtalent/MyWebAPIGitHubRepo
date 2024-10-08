using WebAPIPro.Models;

namespace WebAPIPro.DataAccess.IRepositories
{
    public interface IEmpRepository
    {
        // Declarations :
        Task<int> InsertEmployee(Employee Emp);
        Task<List<Employee>> GetAllEmployees();
        Task<Employee> GetEmployeeByEmpId(int EmpId);
        Task<List<Employee>> GetEmployeesByGender(string Gender);
        Task<Employee> GetEmployeeByEmailAndPassword(string Email, string Password);
        Task<List<Employee>> GetEmployeesByDeptNo(int DeptNo);
        Task<int> UpdateEmployee(Employee Emp);
        Task<int> DeleteEmployee(int EmpId);
    }
}
