using System;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Http;
using Skybrud.Essentials.Strings.Extensions;
using Skybrud.Social.GitHub.Http;
using Skybrud.Social.GitHub.Models.Teams;

namespace Skybrud.Social.GitHub.Options.Organizations.Teams {

    /// <summary>
    /// Class with options for creating a GitHub team.
    /// </summary>
    /// <see>
    ///     <cref>https://docs.github.com/en/rest/reference/teams#create-a-team</cref>
    /// </see>
    public class GitHubCreateTeamOptions : GitHubHttpRequestOptions {

        #region Properties

        /// <summary>
        /// Gets or sets the alias/slug of the parent organization.
        /// </summary>
        public string Org { get; set; }

        /// <summary>
        /// Gets or sets the name of the team.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the description of the team.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets a list of GitHub IDs for organization members who will become team maintainers.
        /// </summary>
        public List<int> Maintainers { get; set; }

        /// <summary>
        /// Gets or sets the level of privacy this team should have.
        /// </summary>
        public GitHubTeamPrivacy Privacy { get; set; }

        /// <summary>
        /// Gets or sets the ID of a team to set as the parent team.
        /// </summary>
        public int ParentTeamId { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance with default options.
        /// </summary>
        public GitHubCreateTeamOptions() {
            Maintainers = new List<int>();
        }

        /// <summary>
        /// Initializes a new instance based on the specified <paramref name="org"/> and <paramref name="name"/>.
        /// </summary>
        /// <param name="org">The alias or slug of the parent organization.</param>
        /// <param name="name">The name of the organization.</param>
        public GitHubCreateTeamOptions(string org, string name) {
            Maintainers = new List<int>();
            Org = org;
            Name = name;
        }

        /// <summary>
        /// Initializes a new instance based on the specified <paramref name="org"/> and <paramref name="name"/>.
        /// </summary>
        /// <param name="org">The alias or slug of the parent organization.</param>
        /// <param name="name">The name of the organization.</param>
        /// <param name="privacy">The privacy level of the team.</param>
        public GitHubCreateTeamOptions(string org, string name, GitHubTeamPrivacy privacy) {
            Maintainers = new List<int>();
            Org = org;
            Name = name;
            Privacy = privacy;
        }

        /// <summary>
        /// Initializes a new instance based on the specified <paramref name="org"/>, <paramref name="name"/> and <paramref name="description"/>.
        /// </summary>
        /// <param name="org">The alias or slug of the parent organization.</param>
        /// <param name="name">The name of the organization.</param>
        /// <param name="description">The description of the organization.</param>
        public GitHubCreateTeamOptions(string org, string name, string description) {
            Maintainers = new List<int>();
            Org = org;
            Name = name;
            Description = description;
        }

        /// <summary>
        /// Initializes a new instance based on the specified <paramref name="org"/>, <paramref name="name"/> and <paramref name="description"/>.
        /// </summary>
        /// <param name="org">The alias or slug of the parent organization.</param>
        /// <param name="name">The name of the organization.</param>
        /// <param name="description">The description of the organization.</param>
        /// <param name="privacy">The privacy level of the team.</param>
        public GitHubCreateTeamOptions(string org, string name, string description, GitHubTeamPrivacy privacy) {
            Maintainers = new List<int>();
            Org = org;
            Name = name;
            Description = description;
            Privacy = privacy;
        }

        #endregion

        #region Member methods

        /// <inheritdoc />
        public override IHttpRequest GetRequest() {

            // Validate required parameters
            if (string.IsNullOrWhiteSpace(Org)) throw new ArgumentNullException(nameof(Org));
            if (string.IsNullOrWhiteSpace(Name)) throw new ArgumentNullException(nameof(Name));

            // Initialize and construct the POST body
            JObject body = new JObject { { "name", Name } };
            if (Description.HasValue()) body.Add("description", Description);
            if (Maintainers != null && Maintainers.Count > 0) body.Add("maintainers", new JArray(Maintainers));
            if (Privacy != GitHubTeamPrivacy.Unspecified) body.Add("privacy", Privacy.ToLower());
            if (ParentTeamId > 0) body.Add("parent_team_id", ParentTeamId);

            // Initialize the request
            return HttpRequest
                .Post($"/orgs/{Org}/teams", body)
                .SetAcceptHeader(MediaTypes);

        }

        #endregion

    }

}