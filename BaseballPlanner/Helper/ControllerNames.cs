namespace ClubGrid.Helper
{
    public static class ControllerNames
    {
        public const string HOME = "home";
        public const string ACCOUNT = "account";
        public const string USER = "user";
    }

    public static class MethodNames
    {
        public const string INDEX = "index";

        // Account
        public const string ACC_REGISTERED = "registered";
        public const string ACC_RESET_PASSWORD = "resetPassword";
        public const string ACC_FORGOT_PASSWORD_CONFIRMATION = "forgotPasswordConfirmation";
        public const string ACC_LOGIN = "login";

        // Event
        public const string EVT_ADMINISTRATE = "administrate";

        // User
        public const string USR_UNVERIFIED = "unverified";
    }
}
