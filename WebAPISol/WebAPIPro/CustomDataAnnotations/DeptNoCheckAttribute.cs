using System.ComponentModel.DataAnnotations;

namespace WebAPIPro.CustomDataAnnotations
{
    public class DeptNoCheckAttribute : ValidationAttribute
    {
        public override bool IsValid(object? value)
        {
            int DeptNo = Convert.ToInt32(value);
            if(DeptNo <= 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
