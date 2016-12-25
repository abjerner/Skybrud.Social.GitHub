using System;
using Newtonsoft.Json.Linq;
using Skybrud.Social.GitHub.Enums;
using Skybrud.Essentials.Json.Extensions;

namespace Skybrud.Social.GitHub.Objects.Users {

    /// <summary>
    /// Class representing a summary of a GitHub user.
    /// </summary>
    public class GitHubUserSummary : GitHubObject {

        #region Properties

        /// <summary>
        /// Gets the login (username) of the user.
        /// </summary>
        public string Login { get; private set; }

        /// <summary>
        /// Gets the ID of the user.
        /// </summary>
        public int Id { get; private set; }

        /// <summary>
        /// Gets the avatar URL of the user.
        /// </summary>
        public string AvatarUrl { get; private set; }

        /// <summary>
        /// Gets the collection of URLs related to the user.
        /// </summary>
        public GitHubUserUrlCollection Urls { get; private set; }

        /// <summary>
        /// Gets the type of the user.
        /// </summary>
        public GitHubUserType Type { get; private set; }

        /// <summary>
        /// Gets whether the user is a site admin.
        /// </summary>
        public bool IsSiteAdmin { get; private set; }

        #endregion

        #region Constructor

        private GitHubUserSummary(JObject obj) : base(obj) {

            string strType = obj.GetString("type");
            GitHubUserType type;
            switch (strType) {
                case "User": type = GitHubUserType.User; break;
                case "Organization": type = GitHubUserType.Organization; break;
                default: throw new Exception("Unknown user type \"" + strType + "\".");
            }

            Login = obj.GetString("login");
            Id = obj.GetInt32("id");
            AvatarUrl = obj.GetString("avatar_url");
            Urls = GitHubUserUrlCollection.Parse(obj);
            Type = type;
            IsSiteAdmin = obj.GetBoolean("site_admin");

        }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <code>obj</code> into an instance of <code>GitHubUserSummary</code>.
        /// </summary>
        /// <param name="obj">The instance of <code>JObject</code> to be parsed.</param>
        /// <returns>Returns an instance of <code>GitHubUserSummary</code>.</returns>
        public static GitHubUserSummary Parse(JObject obj) {
            return obj == null ? null : new GitHubUserSummary(obj);
        }

        #endregion

    }

}