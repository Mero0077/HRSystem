namespace HRSystem.Common.Constants
{
    public class Constants
    {
        public static string BranchNameNotEmptyValidator => "Branch name is required";

        public static string BranchNameMaximumLengthValidator => "Branch name cannot exceed 50 characters.";

        public static string BranchDescriptionNotEmptyValidator => "Branch Description is required";

        public static string BranchDescriptionMaximumLengthValidator => "Description cannot exceed 150 characters.";

        public static string BranchLocationNotEmptyValidator => "Branch Location is required";

        public static string JwtKeyName = "JWT_SECRET_KEY";

        public static double JwtExpiredRefreshTokenDays = 7;
        public static double JwtExpiredAcessTokenHours = 2;
        public static string PasswordNotEmptyLogin = "The Password Field Shouldn't be Empty";

        public static string UserNameNotEmptyLogin = "The UserName Field Shouldn't be Empty";
        public static string BranchLocationMaximumLengthValidator => "Location cannot exceed 100 characters.";
    }
}
