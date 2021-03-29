using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Extensions;
using Skybrud.Social.GitHub.Extensions;

namespace Skybrud.Social.GitHub.Models.Users {

    /// <summary>
    /// Class representing a GitHub user.
    /// </summary>
    public class GitHubUserItem : GitHubObject {

        #region Properties

        /// <summary>
        /// Gets the login (username) of the user.
        /// </summary>
        public string Login { get; }

        /// <summary>
        /// Gets the ID of the user.
        /// </summary>
        public int Id { get; }

        /// <summary>
        /// Gets the avatar URL of the user.
        /// </summary>
        public string AvatarUrl { get; }

        /// <summary>
        /// Gets the gravatar ID of the user.
        /// </summary>
        public string GravatarId { get; }

        /// <summary>
        /// Gets the collection of URLs related to the user.
        /// </summary>
        public GitHubUserUrlCollection Urls { get; }

        /// <summary>
        /// Gets the type of the user.
        /// </summary>
        public GitHubUserType Type { get; }

        /// <summary>
        /// Gets whether the user is a site admin.
        /// </summary>
        public bool IsSiteAdmin { get; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance from the specified <paramref name="json"/> object.
        /// </summary>
        /// <param name="json">The instance of <see cref="JObject"/> representing the user.</param>
        protected GitHubUserItem(JObject json) : base(json) {
            Login = json.GetString("login");
            Id = json.GetInt32("id");
            AvatarUrl = json.GetString("avatar_url");
            GravatarId = json.GetString("gravatar_id");
            Urls = GitHubUserUrlCollection.Parse(json);
            Type = json.GetEnumWithFallbacks<GitHubUserType>("type");
            IsSiteAdmin = json.GetBoolean("site_admin");
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <paramref name="json"/> object into an instance of <see cref="GitHubUserItem"/>.
        /// </summary>
        /// <param name="json">The instance of <see cref="JObject"/> to be parsed.</param>
        /// <returns>An instance of <see cref="GitHubUserItem"/>.</returns>
        public static GitHubUserItem Parse(JObject json) {
            return json == null ? null : new GitHubUserItem(json);
        }

        #endregion

    }

}