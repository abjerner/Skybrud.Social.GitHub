using System;
using System.Diagnostics.CodeAnalysis;
using Skybrud.Essentials.Common;
using Skybrud.Essentials.Http;
using Skybrud.Essentials.Http.Collections;
using Skybrud.Social.GitHub.Http;
using Skybrud.Social.GitHub.Models.Repositories;

namespace Skybrud.Social.GitHub.Options.Repositories.Content;

/// <summary>
/// Class with options for getting the contents of a file in a GitHub repository.
/// </summary>
/// <see>
///     <cref>https://docs.github.com/en/rest/reference/repos#get-repository-content</cref>
/// </see>
public class GitHubGetRepositoryContentOptions : GitHubHttpRequestOptions {

    #region Properties

    /// <summary>
    /// Gets or sets the alias of the user or organization who own the repository.
    /// </summary>
#if NET8_0_OR_GREATER
    public required string OwnerAlias { get; set; }
#else
    public string? OwnerAlias { get; set; }
#endif

    /// <summary>
    /// Gets or set the alias/slug of the repository.
    /// </summary>
#if NET8_0_OR_GREATER
    public required string RepositoryAlias { get; set; }
#else
    public string? RepositoryAlias { get; set; }
#endif

    /// <summary>
    /// Gets or sets the path to the file or directory.
    /// </summary>
#if NET8_0_OR_GREATER
    public required string Path { get; set; }
#else
    public string? Path { get; set; }
#endif

    /// <summary>
    /// Gets or sets the name of the commit/branch/tag. Uses the default branch if not specified.
    /// </summary>
    public string? Ref { get; set; }

    #endregion

    #region Constructors

    /// <summary>
    /// Initializes a new instance with default options.
    /// </summary>
    public GitHubGetRepositoryContentOptions() { }

    /// <summary>
    /// Initializes a new instance based on the specified <paramref name="owner"/> and <paramref name="repositoryAlias"/> alias.
    /// </summary>
    /// <param name="owner">The alias of the repository owner.</param>
    /// <param name="repositoryAlias">The alias/slug of the repository.</param>
    /// <param name="path">The path to the file or directory.</param>
    /// <param name="ref">The name of the commit/branch/tag. Uses the default branch if not specified.</param>
    [SetsRequiredMembers]
    public GitHubGetRepositoryContentOptions(string owner, string repositoryAlias, string path, string? @ref = null) {
        OwnerAlias = owner;
        RepositoryAlias = repositoryAlias;
        Path = path;
        Ref = @ref;
    }

    /// <summary>
    /// Initializes a new instance based on the specified <paramref name="repository"/>.
    /// </summary>
    /// <param name="repository">The repository.</param>
    /// <param name="path">The path to the file or directory.</param>
    /// <param name="ref">The name of the commit/branch/tag. Uses the default branch if not specified.</param>
    [SetsRequiredMembers]
    public GitHubGetRepositoryContentOptions(GitHubRepositoryBase repository, string path, string? @ref = null) {
        if (repository == null) throw new ArgumentNullException(nameof(repository));
        OwnerAlias = repository.Owner.Login;
        RepositoryAlias = repository.Name;
        Path = path;
        Ref = @ref;
    }

    #endregion

    #region Member methods

    /// <inheritdoc />
    public override IHttpRequest GetRequest() {

        if (string.IsNullOrWhiteSpace(OwnerAlias)) throw new PropertyNotSetException(nameof(OwnerAlias));
        if (string.IsNullOrWhiteSpace(RepositoryAlias)) throw new PropertyNotSetException(nameof(RepositoryAlias));
        if (string.IsNullOrWhiteSpace(Path)) throw new PropertyNotSetException(nameof(Path));

        HttpQueryString query = new();
        if (!string.IsNullOrWhiteSpace(Ref)) query.Add("ref", Ref!);

        return HttpRequest
            .Get($"/repos/{OwnerAlias}/{RepositoryAlias}/contents/{Path}", query)
            .SetAcceptHeader(MediaTypes);

    }

    #endregion

}