using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Extensions;
using Skybrud.Essentials.Time;
using Skybrud.Social.GitHub.Extensions;

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
        public EssentialsTime CreatedAt { get; }

        /// <summary>
        /// Gets a timestamp for when the user was last updated.
        /// </summary>
        public EssentialsTime UpdatedAt { get; }

        #endregion

        #region Constructors

        private GitHubUser(JObject json) : base(json) {
            Name = json.GetString("name");
            Company = json.GetString("company");
            Location = json.GetString("location");
            Email = json.GetString("email");
            IsHireable = json.GetString("hireable");
            Bio = json.GetString("bio");
            PublicRepos = json.GetInt32("public_repos");
            PublicGists = json.GetInt32("public_gists");
            Followers = json.GetInt32("followers");
            Following = json.GetInt32("following");
            CreatedAt = json.GetEssentialsTime("created_at");
            UpdatedAt = json.GetEssentialsTime("updated_at");
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <paramref name="json"/> object into an instance of <see cref="GitHubUser"/>.
        /// </summary>
        /// <param name="json">The instance of <see cref="JObject"/> to be parsed.</param>
        /// <returns>An instance of <see cref="GitHubUser"/>.</returns>
        public static new GitHubUser Parse(JObject json) {
            return json == null ? null : new GitHubUser(json);
        }

        #endregion

    }

}