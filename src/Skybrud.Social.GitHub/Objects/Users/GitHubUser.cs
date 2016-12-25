using System;
using Newtonsoft.Json.Linq;
using Skybrud.Social.GitHub.Enums;
using Skybrud.Essentials.Json.Extensions;

namespace Skybrud.Social.GitHub.Objects.Users {

    /// <summary>
    /// Class representing a GitHub user.
    /// </summary>
    public class GitHubUser : GitHubObject {

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

        /// <summary>
        /// Gets the name of the user.
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// Gets the company name of the user.
        /// </summary>
        public string Company { get; private set; }

        /// <summary>
        /// Gets the location of the user.
        /// </summary>
        public string Location { get; private set; }

        /// <summary>
        /// Gets the primary email address of the user.
        /// </summary>
        public string Email { get; private set; }

        /// <summary>
        /// Gets whether the user is available for hire.
        /// </summary>
        public string IsHireable { get; private set; }

        /// <summary>
        /// Gets the bio of the user.
        /// </summary>
        public string Bio { get; private set; }

        /// <summary>
        /// Gets the amount of public repositories of the user.
        /// </summary>
        public int PublicRepos { get; private set; }

        /// <summary>
        /// Gets the amount of public gists of the user.
        /// </summary>
        public int PublicGists { get; private set; }

        /// <summary>
        /// Gets the amount of followers of the user.
        /// </summary>
        public int Followers { get; private set; }

        /// <summary>
        /// Gets the amount of other users the user is following.
        /// </summary>
        public int Following { get; private set; }

        /// <summary>
        /// Gets a timestamp for when the user was created.
        /// </summary>
        public DateTime CreatedAt { get; private set; }

        /// <summary>
        /// Gets a timestamp for when the user was last updated.
        /// </summary>
        public DateTime UpdatedAt { get; private set; }

        #endregion

        #region Constructor

        private GitHubUser(JObject obj) : base(obj) {

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
            Name = obj.GetString("name");
            Company = obj.GetString("company");
            Location = obj.GetString("location");
            Email = obj.GetString("email");
            IsHireable = obj.GetString("hireable");
            Bio = obj.GetString("bio");
            PublicRepos = obj.GetInt32("public_repos");
            PublicGists = obj.GetInt32("public_gists");
            Followers = obj.GetInt32("followers");
            Following = obj.GetInt32("following");
            CreatedAt = obj.GetDateTime("created_at");
            UpdatedAt = obj.GetDateTime("updated_at");

        }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <code>obj</code> into an instance of <code>GitHubUser</code>.
        /// </summary>
        /// <param name="obj">The instance of <code>JObject</code> to be parsed.</param>
        /// <returns>Returns an instance of <code>GitHubUser</code>.</returns>
        public static GitHubUser Parse(JObject obj) {
            return obj == null ? null : new GitHubUser(obj);
        }

        #endregion

    }

}