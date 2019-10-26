using System;
using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Extensions;

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

        // TODO: Add support for the "gravatar_id" property

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
        /// Initializes a new instance from the specified <paramref name="obj"/>.
        /// </summary>
        /// <param name="obj">The instance of <see cref="JObject"/> representing the user.</param>
        protected GitHubUserItem(JObject obj) : base(obj) {

            string strType = obj.GetString("type");
            GitHubUserType type;
            switch (strType) {
                case "User": type = GitHubUserType.User; break;
                case "Organization": type = GitHubUserType.Organization; break;
                case "Bot": type = GitHubUserType.Bot; break;
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
        /// Parses the specified <paramref name="obj"/> into an instance of <see cref="GitHubUserItem"/>.
        /// </summary>
        /// <param name="obj">The instance of <see cref="JObject"/> to be parsed.</param>
        /// <returns>An instance of <see cref="GitHubUserItem"/>.</returns>
        public static GitHubUserItem Parse(JObject obj) {
            return obj == null ? null : new GitHubUserItem(obj);
        }

        #endregion

    }

}