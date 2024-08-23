using OpenQA.Selenium.DevTools.V125.Storage;

namespace Dovs.WordPressAutoKit.Common
{
    /// <summary>
    /// Contains constants for HTML element IDs used in the application.
    /// </summary>
    public static class ElementIds
    {
        /// <summary>
        /// The HTML element ID for the username (user_login) field in the registration form.
        /// </summary>
        public const string USERNAMEINPUT = "user_login";

        /// <summary>
        /// The HTML element ID for the password (user_pass) field in the login form.
        /// </summary>
        public const string LOGINPASSWORDINPUT = "user_pass";

        /// <summary>
        /// The HTML element ID for the login button in the login form.
        /// </summary>
        public const string LOGINBUTTON = "wp-submit";

        /// <summary>
        /// The HTML element ID for the email field in the registration form.
        /// </summary>
        public const string EMAILINPUT = "email";

        /// <summary>
        /// The HTML element ID for the first name field in the registration form.
        /// </summary>
        public const string FIRSTNAMEINPUT = "first_name";

        /// <summary>
        /// The HTML element ID for the last name field in the registration form.
        /// </summary>
        public const string LASTNAMEINPUT = "last_name";

        /// <summary>
        /// The HTML element ID for the new user password field in the registration form.
        /// </summary>
        public const string NEWUSERPASSWORDINPUT = "pass1";

        /// <summary>
        /// The HTML element ID for the role selection dropdown in the registration form.
        /// </summary>
        public const string ROLESELECTION = "role";

        /// <summary>
        /// The HTML element ID for the create user button in the registration form.
        /// </summary>
        public const string CREATEUSERBUTTON = "createusersub";

        /// <summary>
        /// The HTML element ID for the confirmation message div.
        /// </summary>
        public const string CONFIMATIONDIV = "message";

        /// <summary>
        /// The HTML element ID for the membership level dropdown.
        /// </summary>
        public const string MEMBERSHIPLEVELDROP = "membership_level";

        /// <summary>
        /// The HTML element ID for the update user button.
        /// </summary>
        public const string UPDATEUSERBUTTON = "submit";

        /// <summary>
        /// The HTML tag name for anchor tags.
        /// </summary>
        public const string ANCHORTAGNAME = "a";

        /// <summary>
        /// The HTML attribute name for the href attribute in anchor tags.
        /// </summary>
        public const string ANCHORTAGaATTRIBUTE = "href";
    }
}
