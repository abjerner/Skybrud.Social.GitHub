using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Extensions;

namespace Skybrud.Social.GitHub.Objects.Emails {

    /// <summary>
    /// Class representing an email address of a given user.
    /// </summary>
    public class GitHubEmail : GitHubObject {

        #region Properties

        /// <summary>
        /// Gets the email address.
        /// </summary>
        public string Email { get; private set; }

        /// <summary>
        /// Gets whether the email address has been verified.
        /// </summary>
        public bool IsVerified { get; private set; }

        /// <summary>
        /// Gets whether the email address is the primary email address of the user.
        /// </summary>
        public bool IsPrimary { get; private set; }

        #endregion

        #region Constructor

        private GitHubEmail(JObject obj) : base(obj) {
            Email = obj.GetString("email");
            IsVerified = obj.GetBoolean("verified");
            IsPrimary = obj.GetBoolean("primary");
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <paramref name="obj"/> into an instance of <see cref="GitHubEmail"/>.
        /// </summary>
        /// <param name="obj">The instance of <see cref="JObject"/> to be parsed.</param>
        /// <returns>Returns an instance of <see cref="GitHubEmail"/>.</returns>
        public static GitHubEmail Parse(JObject obj) {
            return obj == null ? null : new GitHubEmail(obj);

        }

        #endregion

    }

}