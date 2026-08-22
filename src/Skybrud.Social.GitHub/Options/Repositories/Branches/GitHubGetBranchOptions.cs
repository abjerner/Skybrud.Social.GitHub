using System;
using System.Diagnostics.CodeAnalysis;
using Skybrud.Essentials.Common;
using Skybrud.Essentials.Http;
using Skybrud.Social.GitHub.Http;
using Skybrud.Social.GitHub.Models.Repositories;

namespace Skybrud.Social.GitHub.Options.Repositories.Branches;

/// <summary>
/// Options for getting a single branch of a GitHub repository.
/// </summary>
/// <see>
///     <cref>https://docs.github.com/en/rest/reference/repos#get-a-branch</cref>
/// </see>
public class GitHubGetBranchOptions : GitHubHttpRequestOptions {

    #region Properties

    /// <summary>
    /// Gets or sets the alias of the owner.
    /// </summary>
#if NET8_0_OR_GREATER
    public required string OwnerAlias { get; set; }
#else
    public string? OwnerAlias { get; set; }
#endif

    /// <summary>
    /// Gets or sets the alias/slug of the repository.
    /// </summary>
#if NET8_0_OR_GREATER
    public required string RepositoryAlias { get; set; }
#else
    public string? RepositoryAlias { get; set; }
#endif

    /// <summary>
    /// Gets or sets the name of the label.
    /// </summary>
#if NET8_0_OR_GREATER
    public required string Name { get; set; }
#else
    public string? Name { get; set; }
#endif

    #endregion

    #region Constructors

    /// <summary>
    /// Initialize a new instance with default options.
    /// </summary>
    public GitHubGetBranchOptions() { }

    /// <summary>
    /// Initializes a new instance based on the specified <paramref name="owner"/>, <paramref name="repositoryAlias"/> slug and branch <paramref name="name"/>.
    /// </summary>
    /// <param name="owner">The alias of the repository owner.</param>
    /// <param name="repositoryAlias">The alias/slug of the repository.</param>
    /// <param name="name">The name of the branch.</param>
    [SetsRequiredMembers]
    public GitHubGetBranchOptions(string owner, string repositoryAlias, string name) {
        OwnerAlias = owner;
        RepositoryAlias = repositoryAlias;
        Name = name;
    }

    /// <summary>
    /// Initializes a new instance based on the specified <paramref name="repository"/> and branch <paramref name="name"/>.
    /// </summary>
    /// <param name="repository">The repository.</param>
    /// <param name="name">The name of the branch.</param>
    [SetsRequiredMembers]
    public GitHubGetBranchOptions(GitHubRepositoryBase repository, string name) {
        if (repository == null) throw new ArgumentNullException(nameof(repository));
        OwnerAlias = repository.Owner.Login;
        RepositoryAlias = repository.Name;
        Name = name;
    }

    #endregion

    #region Member methods

    /// <inheritdoc />
    public override IHttpRequest GetRequest() {

        // Validate required parameters
        if (string.IsNullOrWhiteSpace(OwnerAlias)) throw new PropertyNotSetException(nameof(OwnerAlias));
        if (string.IsNullOrWhiteSpace(RepositoryAlias)) throw new PropertyNotSetException(nameof(RepositoryAlias));
        if (string.IsNullOrWhiteSpace(Name)) throw new PropertyNotSetException(nameof(Name));

        // Initialize the request
        return HttpRequest
            .Get($"/repos/{OwnerAlias}/{RepositoryAlias}/branches/{Name}")
            .SetAcceptHeader(MediaTypes);

    }

    #endregion

}