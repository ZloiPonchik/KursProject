namespace StorehouseOfAppliancesPasswordCheckerPasswordChecker
{
    public static class PasswordComplexetyLevelHelper
    {
        public static string ToName(this PasswordComplexityLevel level)
        {
            switch (level)
            {
                case PasswordComplexityLevel.UNRELIABLE:
                    return "Не надежный";
                case PasswordComplexityLevel.SIMPLE:
                    return "Простой";
                case PasswordComplexityLevel.GOOD:
                    return "Хороший";
                default:
                    return "Сложный";
            }
        }

        public static string ToHex(this PasswordComplexityLevel level)
        {
            switch (level)
            {
                case PasswordComplexityLevel.UNRELIABLE:
                    return "#ff0000";
                case PasswordComplexityLevel.SIMPLE:
                    return "#ffaa00";
                case PasswordComplexityLevel.GOOD:
                    return "#fff700";
                default:
                    return "#3cff00";
            }
        }
    }
}
