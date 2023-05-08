namespace StorehouseOfAppliancesPasswordCheckerPasswordChecker
{
    public class PasswordChecker : BaseChecker<string, PasswordComplexityLevel>
    {
        public override PasswordComplexityLevel Check(string password)
        {
            int passwordEvaluation = 0;

            if (password.Length >= 8)
            {
                passwordEvaluation++;
            }

            if (password.Any(char.IsUpper))
            {
                passwordEvaluation++;
            }

            if (password.Any(char.IsLower))
            {
                passwordEvaluation++;
            }

            if (password.Any(char.IsDigit))
            {
                passwordEvaluation++;
            }

            if (!password.All(char.IsLetterOrDigit))
            {
                passwordEvaluation++;
            }

            return ToPasswordComplexityLevel(passwordEvaluation);
        }

        private PasswordComplexityLevel ToPasswordComplexityLevel(int passwordEvaluation)
        {
            if (passwordEvaluation <= 1)
            {
                return PasswordComplexityLevel.UNRELIABLE;
            }

            if (passwordEvaluation > 1 && passwordEvaluation <= 3)
            {
                return PasswordComplexityLevel.SIMPLE;
            }

            if (passwordEvaluation == 4)
            {
                return PasswordComplexityLevel.GOOD;
            }

            return PasswordComplexityLevel.HARD;
        }
    }
}
