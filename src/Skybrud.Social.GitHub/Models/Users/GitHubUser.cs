using System;
using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Extensions;

namespace Skybrud.Social.GitHub.Models.Users {

    /// <summary>
    /// Class representing a GitHub user.
    /// </summary>
    public class GitHubUser : GitHubUserItem {

        #region Properties
        
        /// <summary>
        /// Gets the name of the user.
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Gets the company name of the user.
        /// </summary>
        public string Company { get; }

        /// <summary>
        /// Gets the location of the user.
        /// </summary>
        public string Location { get; }

        /// <summary>
        /// Gets the primary email address of the user.
        /// </summary>
        public string Email { get; }

        /// <summary>
        /// Gets whether the user is available for hire.
        /// </summary>
        public string IsHireable { get; }

        /// <summary>
        /// Gets the bio of the user.
        /// </summary>
        public string Bio { get; }

        /// <summary>
        /// Gets the amount of public repositories of the user.
        /// </summary>
        public int PublicRepos { get; }

        /// <summary>
        /// Gets the amount of public gists of the user.
        /// </summary>
        public int PublicGists { get; }

        /// <summary>
        /// Gets the amount of followers of the user.
        /// </summary>
        public int Followers { get; }

        /// <summary>
        /// Gets the amount of other users the user is following.
        /// </summary>
        public int Following { get; }

        /// <summary>
        /// Gets a timestamp for when the user was created.
        /// </summary>
        public DateTime CreatedAt { get; }

        /// <summary>
        /// Gets a timestamp for when the user was last updated.
        /// </summary>
        public DateTime UpdatedAt { get; }

        #endregion

        #region Constructors

        private GitHubUser(JObject obj) : base(obj) {
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
        /// Parses the specified <paramref name="obj"/> into an instance of <see cref="GitHubUser"/>.
        /// </summary>
        /// <param name="obj">The instance of <see cref="JObject"/> to be parsed.</param>
        /// <returns>An instance of <see cref="GitHubUser"/>.</returns>
        public new static GitHubUser Parse(JObject obj) {
            return obj == null ? null : new GitHubUser(obj);
        }

        #endregion

    }

}