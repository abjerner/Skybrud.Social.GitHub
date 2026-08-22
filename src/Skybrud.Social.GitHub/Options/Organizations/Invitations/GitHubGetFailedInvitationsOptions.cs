using System;
using System.Diagnostics.CodeAnalysis;
using Skybrud.Essentials.Common;
using Skybrud.Essentials.Http;
using Skybrud.Essentials.Http.Collections;
using Skybrud.Social.GitHub.Http;
using Skybrud.Social.GitHub.Models.Organizations;

namespace Skybrud.Social.GitHub.Options.Organizations.Invitations;

/// <summary>
/// Class with options for getting a list of failed invitations of a GitHub organization.
/// </summary>
public class GitHubGetFailedInvitationsOptions : GitHubHttpRequestOptions {

    #region Properties

    /// <summary>
    /// Gets or sets the alias/slug of the organization.
    /// </summary>
#if NET8_0_OR_GREATER
    public required string OrganizationAlias { get; set; }
#else
    public string? OrganizationAlias { get; set; }
#endif

    /// <summary>
    /// Gets or sets the maximum amount of invites to be returned by each page. Default is <c>30</c>. Max is <c>100</c>.
    /// </summary>
    public int? PerPage { get; set; }

    /// <summary>
    /// Gets or sets the page to be returned. Default is <c>1</c>, indicating the first page.
    /// </summary>
    public int? Page { get; set; }

    #endregion

    #region Constructors

    /// <summary>
    /// Initializes a new instance with default options.
    /// </summary>
    public GitHubGetFailedInvitationsOptions() { }

    /// <summary>
    /// Initializes a new instance based on the specified <paramref name="organizationAlias"/>.
    /// </summary>
    /// <param name="organizationAlias">The alias of the organization.</param>
    [SetsRequiredMembers]
    public GitHubGetFailedInvitationsOptions(string organizationAlias) {
        OrganizationAlias = organizationAlias;
    }

    /// <summary>
    /// Initializes a new instance based on the specified <paramref name="organizationAlias"/>.
    /// </summary>
    /// <param name="organizationAlias">The alias of the organization.</param>
    /// <param name="perPage">The amount of invites to be returned on each page.</param>
    /// <param name="page">The page to be returned.</param>
    [SetsRequiredMembers]
    public GitHubGetFailedInvitationsOptions(string organizationAlias, int? perPage = null, int? page = null) {
        OrganizationAlias = organizationAlias;
        PerPage = perPage;
        Page = page;
    }

    /// <summary>
    /// Initializes a new instance based on the specified <paramref name="organization"/>.
    /// </summary>
    /// <param name="organization">The organization.</param>
    [SetsRequiredMembers]
    public GitHubGetFailedInvitationsOptions(GitHubOrganizationItem organization) {
        if (organization == null) throw new ArgumentNullException(nameof(organization));
        OrganizationAlias = organization.Login;
    }

    /// <summary>
    /// Initializes a new instance based on the specified <paramref name="organization"/>.
    /// </summary>
    /// <param name="organization">The organization.</param>
    /// <param name="perPage">The amount of invites to be returned on each page.</param>
    /// <param name="page">The page to be returned.</param>
    [SetsRequiredMembers]
    public GitHubGetFailedInvitationsOptions(GitHubOrganizationItem organization, int? perPage = null, int? page = null) {
        if (organization == null) throw new ArgumentNullException(nameof(organization));
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
        if (PerPage > 0) query.Add("per_page", PerPage);
        if (Page > 0) query.Add("page", Page);

        // Initialize the request
        return HttpRequest
            .Get($"/orgs/{OrganizationAlias}/failed_invitations", query)
            .SetAcceptHeader(MediaTypes);

    }

    #endregion

}