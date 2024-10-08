using WebAPIPro.Models;

namespace WebAPIPro.DataAccess.IRepositories
{
    public interface IDeptRepository
    {
        // Declare Methods : 
        Task<int> InsertDepartment(Department Dept);
        Task<List<Department>> AllDepartment();
        Task<Department> GetDepartmentByDeptNo(int DeptNo);
        Task<List<Department>> GetDepartmentsByLocation(string Location);
        Task<int> UpdateDepartment(Department Dept);
        Task<int> DeleteDepartment(int DeptNo);
        Task<int> DeleteAllDepartments();
    }
}
