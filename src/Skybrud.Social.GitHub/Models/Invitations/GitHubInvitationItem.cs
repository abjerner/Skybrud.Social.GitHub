using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Extensions;

namespace Skybrud.Social.GitHub.Models.Invitations {
    
    /// <summary>
    /// Class representing a GitHub invitation.
    /// </summary>
    public class GitHubInvitationItem : GitHubObject {

        #region Properties

        /// <summary>
        /// Gets the ID of the user.
        /// </summary>
        public int Id { get; }

        /// <summary>
        /// Gets the login (username) of the user.
        /// </summary>
        public string Login { get; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance from the specified <paramref name="json"/> object.
        /// </summary>
        /// <param name="json">The instance of <see cref="JObject"/> representing the user.</param>
        protected GitHubInvitationItem(JObject json) : base(json) {
            Id = json.GetInt32("id");
            Login = json.GetString("login");
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <paramref name="json"/> object into an instance of <see cref="GitHubInvitationItem"/>.
        /// </summary>
        /// <param name="json">The instance of <see cref="JObject"/> to be parsed.</param>
        /// <returns>An instance of <see cref="GitHubInvitationItem"/>.</returns>
        public static GitHubInvitationItem Parse(JObject json) {
            return json == null ? null : new GitHubInvitationItem(json);
        }

        #endregion

    }

}