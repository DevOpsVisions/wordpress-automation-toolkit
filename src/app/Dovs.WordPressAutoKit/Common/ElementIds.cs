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
        public const string USER_NAME_INPUT = "user_login";

        /// <summary>
        /// The HTML element ID for the password (user_pass) field in the login form.
        /// </summary>
        public const string USER_PASS_INPUT = "user_pass";

        /// <summary>
        /// The HTML element ID for the login button in the login form.
        /// </summary>
        public const string LOGIN_BUTTON = "wp-submit";

        /// <summary>
        /// The HTML element ID for the email field in the registration form.
        /// </summary>
        public const string EMAIL_INPUT = "email";

        /// <summary>
        /// The HTML element ID for the first name field in the registration form.
        /// </summary>
        public const string FIRST_NAME_INPUT = "first_name";

        /// <summary>
        /// The HTML element ID for the last name field in the registration form.
        /// </summary>
        public const string LAST_NAME_INPUT = "last_name";

        /// <summary>
        /// The HTML element ID for the new user password field in the registration form.
        /// </summary>
        public const string NEW_USER_PASSWORD_INPUT = "pass1";

        /// <summary>
        /// The HTML element ID for the role selection dropdown in the registration form.
        /// </summary>
        public const string ROLE_SELECTION = "role";

        /// <summary>
        /// The HTML element ID for the create user button in the registration form.
        /// </summary>
        public const string CREATE_USER_BUTTON = "createusersub";

        /// <summary>
        /// The HTML element ID for the confirmation message div.
        /// </summary>
        public const string CONFIRMATION_DIV = "message";

        /// <summary>
        /// The HTML element ID for the first button to add membership.
        /// </summary>
        public const string ADD_MEMBERSHIP_FIRST_BUTTON = "a.button.button-secondary[href*='pmpro_member_edit_panel=memberships']";

        /// <summary>
        /// The HTML element ID for the second button to add membership.
        /// </summary>
        public const string ADD_MEMBERSHIP_SECOND_BUTTON = "a.pmpro-member-change-level";

        /// <summary>
        /// The HTML element ID for the save button to add membership.
        /// </summary>
        public const string ADD_MEMBERSHIP_SAVE_BUTTON = "button.button.button-primary";

        /// <summary>
        /// The HTML element ID for the membership level dropdown.
        /// </summary>
        public const string MEMBERSHIP_LEVEL_DROP = "pmpro-member-edit-memberships-panel-add_level_to_group_1[level_id]";

        /// <summary>
        /// The HTML element ID for the update user button.
        /// </summary>
        public const string UPDATE_USER_BUTTON = "submit";

        /// <summary>
        /// The HTML tag name for anchor tags.
        /// </summary>
        public const string ANCHOR_TAG_NAME = "a";

        /// <summary>
        /// The HTML attribute name for the href attribute in anchor tags.
        /// </summary>
        public const string ANCHOR_TAG_ATTRIBUTE = "href";
    }
}
