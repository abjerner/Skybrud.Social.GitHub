using Skybrud.Essentials.Common;
using Skybrud.Essentials.Http;
using Skybrud.Social.GitHub.Http;

namespace Skybrud.Social.GitHub.Options.Organizations.Teams {

    /// <summary>
    /// Options for getting information about a team, indentified by the organization and team slugs respectively.
    /// </summary>
    /// <see>
    ///     <cref>https://docs.github.com/en/rest/reference/teams#get-a-team-by-name</cref>
    /// </see>
    public class GitHubGetTeamByNameOptions : GitHubHttpRequestOptions {

        #region Properties

        /// <summary>
        /// Gets or sets the alias of the organization.
        /// </summary>
        public string Organization { get; set; }

        /// <summary>
        /// Gets or sets the alias of the team.
        /// </summary>
        public string Team { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instacne with default options.
        /// </summary>
        public GitHubGetTeamByNameOptions() { }

        /// <summary>
        /// Initializes a new instance based on the specified <paramref name="organization"/> and <paramref name="team"/>.
        /// </summary>
        /// <param name="organization">The alias (username) of the organization.</param>
        /// <param name="team">The alias of the team.</param>
        public GitHubGetTeamByNameOptions(string organization, string team) {
            Organization = organization;
            Team = team;
        }

        #endregion

        #region Member methods

        /// <inheritdoc />
        public override IHttpRequest GetRequest() {

            // Validate required parameters
            if (string.IsNullOrWhiteSpace(Organization)) throw new PropertyNotSetException(nameof(Organization));
            if (string.IsNullOrWhiteSpace(Team)) throw new PropertyNotSetException(nameof(Team));

            // Initialize and return a new GET request
            return HttpRequest
                .Get($"/orgs/{Organization}/teams/{Team}")
                .SetAcceptHeader(MediaTypes);

        }

        #endregion

    }

}