using System.Linq;

namespace front.Helper
{
    public class PasswordValidator
    {
        public bool Validate(string password)
        {
            return  IsMatchingLength(password) &&
                    IsHavingNumber(password) &&
                    IsHavingSpecial(password) &&
                    IsHavingLowercaseLetter(password) &&
                    IsHavingUppercaseLetter(password);
        }

        private bool IsMatchingLength(string password)
        {
            return password.Length >= 8 && password.Length <= 64;
        }

        private bool IsHavingUppercaseLetter(string password)
        {
            return password.Any(char.IsUpper);
        }

        private bool IsHavingLowercaseLetter(string password)
        {
            return password.Any(char.IsLower);
        }

        private bool IsHavingNumber(string password)
        {
            return password.Any(char.IsDigit);
        }

        private bool IsHavingSpecial(string password)
        {
            return password.Any(x => !char.IsLetterOrDigit(x));
        }
    }
}