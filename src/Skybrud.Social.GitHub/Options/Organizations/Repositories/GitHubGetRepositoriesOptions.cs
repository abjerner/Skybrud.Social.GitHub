using System.Diagnostics.CodeAnalysis;
using Skybrud.Essentials.Common;
using Skybrud.Essentials.Http;
using Skybrud.Essentials.Http.Collections;
using Skybrud.Social.GitHub.Extensions;
using Skybrud.Social.GitHub.Http;
using Skybrud.Social.GitHub.Models.Organizations;
using Skybrud.Social.GitHub.Options.Repositories;

namespace Skybrud.Social.GitHub.Options.Organizations.Repositories;

/// <summary>
/// Options for getting repositories of a GitHub organization.
/// </summary>
/// <see>
///     <cref>https://docs.github.com/en/rest/reference/repos#list-organization-repositories</cref>
/// </see>
public class GitHubGetRepositoriesOptions : GitHubHttpRequestOptions {

    #region Properties

    /// <summary>
    /// Gets or sets the organization alias.
    /// </summary>
#if NET8_0_OR_GREATER
    public required string OrganizationAlias { get; set; }
#else
    public string? OrganizationAlias { get; set; }
#endif

    /// <summary>
    /// Gets or sets the field to be sorted by.
    /// </summary>
    public GitHubRepositorySortField Sort { get; set; }

    /// <summary>
    /// Gets or sets the sort direction of the returned results. Default: when using
    /// <see cref="GitHubRepositorySortField.FullName"/>: <see cref="GitHubSortDirection.Ascending"/>, otherwise
    /// <see cref="GitHubSortDirection.Descending"/>.
    /// </summary>
    public GitHubSortDirection Direction { get; set; }

    /// <summary>
    /// Gets or sets the maximum amount of repositories to returned by each page. Maximum is <c>100</c>.
    /// </summary>
    public int? PerPage { get; set; }

    /// <summary>
    /// Gets or sets the page to be returned.
    /// </summary>
    public int? Page { get; set; }

    #endregion

    #region Constructors

    /// <summary>
    /// Initializes a new instance of the <see cref="GitHubGetRepositoriesOptions"/> class.
    /// </summary>
    public GitHubGetRepositoriesOptions() { }

    /// <summary>
    /// Initializes a new instance of the <see cref="GitHubGetRepositoriesOptions"/> class.
    /// </summary>
    /// <param name="organizationAlias">The alias of the organization.</param>
    /// <param name="perPage">The number of repositories to return per page.</param>
    /// <param name="page">The page number to return.</param>
    [SetsRequiredMembers]
    public GitHubGetRepositoriesOptions(string organizationAlias, int? perPage = null, int? page = null) {
        OrganizationAlias = organizationAlias;
        PerPage = perPage;
        Page = page;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="GitHubGetRepositoriesOptions"/> class.
    /// </summary>
    /// <param name="organization">The organization.</param>
    /// <param name="perPage">The number of repositories to return per page.</param>
    /// <param name="page">The page number to return.</param>
    [SetsRequiredMembers]
    public GitHubGetRepositoriesOptions(GitHubOrganizationBase organization, int? perPage = null, int? page = null) {
        OrganizationAlias = organization.Login;
        PerPage = perPage;
        Page = page;
    }

    #endregion

    #region Member methods

    /// <inheritdoc />
    public override IHttpRequest GetRequest() {

        // Validate required parameters
        if (string.IsNullOrWhiteSpace(OrganizationAlias)) throw new PropertyNotSetException(nameof(OrganizationAlias));

        // Initialize and construct the query string
        HttpQueryString query = new();
        if (Sort != GitHubRepositorySortField.Unspecified) query.AddEnumValue("sort", Sort);
        if (Direction != GitHubSortDirection.Unspecified) query.AddEnumValue("direction", Direction);
        if (PerPage > 0) query.Add("per_page", PerPage);
        if (Page > 0) query.Add("page", Page);

        // Initialize the request
        return HttpRequest
            .Get($"/orgs/{OrganizationAlias}/repos", query)
            .SetAcceptHeader(MediaTypes);

    }

    #endregion

}