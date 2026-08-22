using System;
using System.Diagnostics.CodeAnalysis;
using Skybrud.Essentials.Http;
using Skybrud.Essentials.Http.Collections;
using Skybrud.Social.GitHub.Http;
using Skybrud.Social.GitHub.Models.Repositories;

namespace Skybrud.Social.GitHub.Options.Repositories.Teams;

/// <summary>
/// Options class for returning a list of teams of a GitHub repository.
/// </summary>
/// <see>
///     <cref>https://docs.github.com/en/rest/reference/repos#list-repository-teams</cref>
/// </see>
public class GitHubGetTeamsOptions : GitHubHttpRequestOptions {

    #region Properties

    /// <summary>
    /// Gets or sets the alias of the repository owner.
    /// </summary>
#if NET8_0_OR_GREATER
    public required string OwnerAlias { get; set; }
#else
    public string? OwnerAlias { get; set; }
#endif

    /// <summary>
    /// Gets or sets the alias of the repository.
    /// </summary>
#if NET8_0_OR_GREATER
    public required string RepositoryAlias { get; set; }
#else
    public string? RepositoryAlias { get; set; }
#endif

    /// <summary>
    /// Gets or sets the maximum amount of results per page (max is <c>100</c>).
    /// </summary>
    public int? PerPage { get; set; }

    /// <summary>
    /// Gets or sets the page to fetch.
    /// </summary>
    public int? Page { get; set; }

    #endregion

    #region Constructors

    /// <summary>
    /// Initialize a new instance with default options.
    /// </summary>
    public GitHubGetTeamsOptions() { }

    /// <summary>
    /// Initializes a new instance based on the specified <paramref name="owner"/> and <paramref name="repositoryAlias"/>.
    /// </summary>
    /// <param name="owner">The alias of the repository owner.</param>
    /// <param name="repositoryAlias">The alias/slug of the repository.</param>
    [SetsRequiredMembers]
    public GitHubGetTeamsOptions(string owner, string repositoryAlias) {
        OwnerAlias = owner;
        RepositoryAlias = repositoryAlias;
    }

    /// <summary>
    /// Initializes a new instance based on the specified <paramref name="owner"/> and <paramref name="repositoryAlias"/>.
    /// </summary>
    /// <param name="owner">The alias of the repository owner.</param>
    /// <param name="repositoryAlias">The alias/slug of the repository.</param>
    /// <param name="perPage">The maximum amount of teams to returned by each page. Maximum is <c>100</c>.</param>
    /// <param name="page">The page to be returned.</param>
    [SetsRequiredMembers]
    public GitHubGetTeamsOptions(string owner, string repositoryAlias, int? perPage = null, int? page = null) {
        OwnerAlias = owner;
        RepositoryAlias = repositoryAlias;
        PerPage = perPage;
        Page = page;
    }

    /// <summary>
    /// Initializes a new instance based on the specified <paramref name="repository"/>.
    /// </summary>
    /// <param name="repository">The repository.</param>
    [SetsRequiredMembers]
    public GitHubGetTeamsOptions(GitHubRepositoryBase repository) {
        if (repository == null) throw new ArgumentNullException(nameof(repository));
        OwnerAlias = repository.Owner.Login;
        RepositoryAlias = repository.Name;
    }

    /// <summary>
    /// Initializes a new instance based on the specified <paramref name="repository"/>.
    /// </summary>
    /// <param name="repository">The repository.</param>
    /// <param name="perPage">The maximum amount of teams to returned by each page. Maximum is <c>100</c>.</param>
    /// <param name="page">The page to be returned.</param>
    [SetsRequiredMembers]
    public GitHubGetTeamsOptions(GitHubRepositoryBase repository, int? perPage = null, int? page = null) {
        if (repository == null) throw new ArgumentNullException(nameof(repository));
        OwnerAlias = repository.Owner.Login;
        RepositoryAlias = repository.Name;
        PerPage = perPage;
        Page = page;
    }

    #endregion

    #region Member methods

    /// <inheritdoc />
    public override IHttpRequest GetRequest() {

        // Determine the URL either from the ID or the alias
        if (string.IsNullOrWhiteSpace(OwnerAlias)) throw new ArgumentNullException(nameof(OwnerAlias));
        if (string.IsNullOrWhiteSpace(RepositoryAlias)) throw new ArgumentNullException(nameof(RepositoryAlias));
        string url = $"/repos/{OwnerAlias}/{RepositoryAlias}/teams";

        // Initialize a new query string
        HttpQueryString query = new();

        // Append optional parameters
        if (PerPage > 0) query.Add("per_page", PerPage);
        if (Page > 0) query.Add("page", Page);

        // Initialize and return a new GET request
        return HttpRequest
            .Get(url, query)
            .SetAcceptHeader(MediaTypes);

    }

    #endregion

}