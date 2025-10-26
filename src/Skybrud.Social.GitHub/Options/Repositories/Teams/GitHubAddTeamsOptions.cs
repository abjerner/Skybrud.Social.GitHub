using System;
using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Http;
using Skybrud.Essentials.Strings.Extensions;
using Skybrud.Social.GitHub.Http;
using Skybrud.Social.GitHub.Models.Repositories;
using Skybrud.Social.GitHub.Models.Teams;

namespace Skybrud.Social.GitHub.Options.Repositories.Teams;

/// <summary>
/// Options class describing a request for adding a team to a repository.
/// </summary>
/// <see>
///     <cref>https://docs.github.com/en/rest/teams/teams?apiVersion=2022-11-28#add-or-update-team-repository-permissions</cref>
/// </see>
public class GitHubAddTeamsOptions : GitHubHttpRequestOptions {

    #region Properties

    /// <summary>
    /// Gets or sets the alias/slug of the organization name. The alias is not case-sensitive.
    /// </summary>

#if NET8_0_OR_GREATER
    public required string OrganizationAlias { get; set; }
#else
        public string? OrganizationAlias { get; set; }
#endif

    /// <summary>
    /// Gets or sets the alias of the repository owner. The alias is not case-sensitive.
    /// </summary>
#if NET8_0_OR_GREATER
    public required string RepositoryOwner { get; set; }
#else
        public string? RepositoryOwner { get; set; }
#endif

    /// <summary>
    /// Gets or sets the alias of the repository without the <c>.git</c> extension. The name is not case-sensitive.
    /// </summary>
#if NET8_0_OR_GREATER
    public required string RepositoryAlias { get; set; }
#else
        public string? RepositoryAlias { get; set; }
#endif

    /// <summary>
    /// Gets or set the alias/slug of the team name.
    /// </summary>
#if NET8_0_OR_GREATER
    public required string TeamAlias { get; set; }
#else
        public string? TeamAlias { get; set; }
#endif

    /// <summary>
    /// gets or sets the permission to grant the team on this repository.
    /// </summary>
#if NET8_0_OR_GREATER
    public required GitHubTeamPermission Permission { get; set; }
#else
        public GitHubTeamPermission Permission { get; set; }
#endif

    #endregion

    #region Constructors

    /// <summary>
    /// Initialize a new instance with default options.
    /// </summary>
    public GitHubAddTeamsOptions() { }
    
    /// <summary>
    /// Initializes a new instance based on the specified <paramref name="repositoryOwner"/>,
    /// <paramref name="repositoryAlias"/>, <paramref name="teamAlias"/> and <paramref name="permission"/>.
    /// </summary>
    /// <param name="repositoryOwner">The alias of the repository owner.</param>
    /// <param name="repositoryAlias">The alias of the repository.</param>
    /// <param name="teamAlias">The alias of the team.</param>
    /// <param name="permission">The permission to set for the team.</param>
#if NET8_0_OR_GREATER
    [System.Diagnostics.CodeAnalysis.SetsRequiredMembers]
#endif
    public GitHubAddTeamsOptions(string repositoryOwner, string repositoryAlias, string teamAlias, GitHubTeamPermission permission) {
        OrganizationAlias = repositoryOwner;
        RepositoryOwner = repositoryOwner;
        RepositoryAlias = repositoryAlias;
        TeamAlias = teamAlias;
        Permission = permission;
    }

    /// <summary>
    /// Initializes a new instance based on the specified <paramref name="repository"/>, <paramref name="team"/> and <paramref name="permission"/>.
    /// </summary>
    /// <param name="repository">The repository.</param>
    /// <param name="team">The team.</param>
    /// <param name="permission">The permission.</param>
#if NET8_0_OR_GREATER
    [System.Diagnostics.CodeAnalysis.SetsRequiredMembers]
#endif
    public GitHubAddTeamsOptions(GitHubRepositoryBase repository, GitHubTeamBase team, GitHubTeamPermission permission) {
        OrganizationAlias = repository.Owner.Login;
        RepositoryOwner = repository.Owner.Login;
        RepositoryAlias = repository.Name;
        TeamAlias = team.Slug;
        Permission = permission;
    }


    #endregion

    #region Member methods

    /// <inheritdoc />
    public override IHttpRequest GetRequest() {

        // Determine the URL either from the ID or the alias
        if (string.IsNullOrWhiteSpace(OrganizationAlias)) throw new ArgumentNullException(nameof(OrganizationAlias));
        if (string.IsNullOrWhiteSpace(TeamAlias)) throw new ArgumentNullException(nameof(TeamAlias));
        if (string.IsNullOrWhiteSpace(RepositoryOwner)) throw new ArgumentNullException(nameof(RepositoryOwner));
        if (string.IsNullOrWhiteSpace(RepositoryAlias)) throw new ArgumentNullException(nameof(RepositoryAlias));
        string url = $"/orgs/{OrganizationAlias}/teams/{TeamAlias}/repos/{RepositoryOwner}/{RepositoryAlias}";

        JObject body = new() {
            { "permission", Permission.ToKebabCase() }
        };

        // Initialize and return a new GET request
        return HttpRequest
            .Put(url, body)
            .SetAcceptHeader(MediaTypes);

    }

    #endregion

}