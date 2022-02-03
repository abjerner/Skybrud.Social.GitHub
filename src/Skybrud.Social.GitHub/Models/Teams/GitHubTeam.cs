using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Extensions;
using Skybrud.Essentials.Time;
using Skybrud.Social.GitHub.Extensions;
using Skybrud.Social.GitHub.Models.Organizations;

namespace Skybrud.Social.GitHub.Models.Teams {

    /// <summary>
    /// Class representing a GitHub team.
    /// </summary>
    public class GitHubTeam : GitHubTeamItem {

        #region Properties

        /// <summary>
        /// Gets a timestamp for when the team was created.
        /// </summary>
        public EssentialsTime CreatedAt { get; }

        /// <summary>
        /// Gets a timestamp for when the team was last updated.
        /// </summary>
        public EssentialsTime UpdatedAt { get; }

        /// <summary>
        /// Gets the amount of members in the team.
        /// </summary>
        public int MembersCount { get; }

        /// <summary>
        /// Gets the amount of repositories in the team.
        /// </summary>
        public int ReposCount { get; }

        /// <summary>
        /// Gets the organization to which the team belongs.
        /// </summary>
        public GitHubOrganization Organization { get; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance from the specified <paramref name="json"/>.
        /// </summary>
        /// <param name="json">The instance of <see cref="JObject"/> representing the team.</param>
        protected GitHubTeam(JObject json) : base(json) {
            CreatedAt = json.GetEssentialsTime("created_at");
            UpdatedAt = json.GetEssentialsTime("updated_at");
            MembersCount = json.GetInt32("members_count");
            ReposCount = json.GetInt32("repos_count");
            Organization = json.GetObject("organization", GitHubOrganization.Parse);
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <paramref name="json"/> into an instance of <see cref="GitHubTeam"/>.
        /// </summary>
        /// <param name="json">The instance of <see cref="JObject"/> to be parsed.</param>
        /// <returns>An instance of <see cref="GitHubTeam"/>.</returns>
        public static new GitHubTeam Parse(JObject json) {
            return json == null ? null : new GitHubTeam(json);
        }

        #endregion

    }

}