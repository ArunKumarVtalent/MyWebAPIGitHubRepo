using System.ComponentModel.DataAnnotations;

namespace WebAPIPro.CustomDataAnnotations
{
    public class PasswordCheckAttribute : ValidationAttribute
    {
        public override bool IsValid(object? value)
        {
            string Pwd = Convert.ToString(value); //value.ToString();
            // Logic to validare Password 
            List<char> SpecChars = new List<char>() { '@', '#', '$', '^', '&' };
            List<char> ChapsChars = new List<char>() { 'A', 'B', 'C', 'D', 'E' };
            List<char> SmallChars = new List<char>() { 'a', 'b', 'c', 'd', 'e' };
            List<char> Numbers = new List<char>() { '0', '1', '2', '3', '4', '5' };
            int count = 0;

            if ((Pwd.Length < 8) || (Pwd.Length > 16))
            {
                return false;
            }
            else
            {
                for (int i = 0; i < Pwd.Length; i++) // 1234@6789
                {
                    foreach (char c in SpecChars)
                    {
                        if (c == Pwd[i])
                        {
                            count++;
                        }
                    }
                }
                if (count == 0)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
