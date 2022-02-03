using Skybrud.Essentials.Common;
using Skybrud.Essentials.Http;
using Skybrud.Social.GitHub.Http;

namespace Skybrud.Social.GitHub.Options.Organizations.Teams {

    /// <summary>
    /// Options for getting information about a team, indentified by the organization and team IDs respectively.
    /// </summary>
    public class GitHubGetTeamOptions : GitHubHttpRequestOptions {

        #region Properties

        /// <summary>
        /// Gets or sets the ID of the organization.
        /// </summary>
        public int OrganizationId { get; set; }

        /// <summary>
        /// Gets or sets the ID of the team.
        /// </summary>
        public int TeamId { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instacne with default options.
        /// </summary>
        public GitHubGetTeamOptions() { }

        /// <summary>
        /// Initializes a new instance based on the specified <paramref name="organizationId"/> and <paramref name="teamId"/>.
        /// </summary>
        /// <param name="organizationId">The alias (username) of the organization.</param>
        /// <param name="teamId">The alias of the team.</param>
        public GitHubGetTeamOptions(int organizationId, int teamId) {
            OrganizationId = organizationId;
            TeamId = teamId;
        }

        #endregion

        #region Member methods

        /// <inheritdoc />
        public override IHttpRequest GetRequest() {

            // Validate required parameters
            if (OrganizationId == 0) throw new PropertyNotSetException(nameof(OrganizationId));
            if (TeamId == 0) throw new PropertyNotSetException(nameof(OrganizationId));

            // Initialize the request
            return HttpRequest
                .Get($"/organizations/{OrganizationId}/team/{TeamId}")
                .SetAcceptHeader(MediaTypes);

        }

        #endregion

    }

}