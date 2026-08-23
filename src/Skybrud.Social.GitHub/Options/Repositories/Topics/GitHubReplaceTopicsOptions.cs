using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Common;
using Skybrud.Essentials.Http;
using Skybrud.Social.GitHub.Http;
using Skybrud.Social.GitHub.Models.Repositories;

namespace Skybrud.Social.GitHub.Options.Repositories.Topics;

/// <summary>
/// Options describing a request to replace the topics of a GitHub repository.
/// </summary>
/// <see href="https://docs.github.com/en/rest/repos/repos?apiVersion=2026-03-10#replace-all-repository-topics"/>
public class GitHubReplaceTopicsOptions : GitHubHttpRequestOptions {

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
    /// Gets or sets a list of topics to add to the repository. Pass one or more topics to replace the set of existing topics. Send an empty list to clear all topics from the repository.
    ///
    /// Note: Topic names will be saved as lowercase.
    /// </summary>
#if NET8_0_OR_GREATER
    public required List<string> Names { get; set; }
#else
    public List<string> Names { get; set; } = [];
#endif

    #endregion

    #region Constructors

    /// <summary>
    /// Initialize a new instance with default options.
    /// </summary>
    public GitHubReplaceTopicsOptions() { }

    /// <summary>
    /// Initializes a new instance based on the specified <paramref name="owner"/> and <paramref name="repositoryAlias"/>.
    /// </summary>
    /// <param name="owner">The alias of the repository owner.</param>
    /// <param name="repositoryAlias">The alias/slug of the repository.</param>
    /// <param name="names">The list of topics to set for the repository.</param>
    [SetsRequiredMembers]
    public GitHubReplaceTopicsOptions(string owner, string repositoryAlias, IReadOnlyList<string> names) {
        OwnerAlias = owner;
        RepositoryAlias = repositoryAlias;
        Names = [.. names];
    }

    /// <summary>
    /// Initializes a new instance based on the specified <paramref name="owner"/> and <paramref name="repositoryAlias"/>.
    /// </summary>
    /// <param name="owner">The alias of the repository owner.</param>
    /// <param name="repositoryAlias">The alias/slug of the repository.</param>
    /// <param name="names">The list of topics to set for the repository.</param>
    [SetsRequiredMembers]
    public GitHubReplaceTopicsOptions(string owner, string repositoryAlias, IEnumerable<string> names) {
        OwnerAlias = owner;
        RepositoryAlias = repositoryAlias;
        Names = [.. names];
    }

    /// <summary>
    /// Initializes a new instance based on the specified <paramref name="repository"/>.
    /// </summary>
    /// <param name="repository">The repository.</param>
    /// <param name="names">The list of topics to set for the repository.</param>
    [SetsRequiredMembers]
    public GitHubReplaceTopicsOptions(GitHubRepositoryBase repository, IReadOnlyList<string> names) {
        if (repository == null) throw new ArgumentNullException(nameof(repository));
        OwnerAlias = repository.Owner.Login;
        RepositoryAlias = repository.Name;
        Names = [.. names];
    }

    /// <summary>
    /// Initializes a new instance based on the specified <paramref name="repository"/>.
    /// </summary>
    /// <param name="repository">The repository.</param>
    /// <param name="names">The list of topics to set for the repository.</param>
    [SetsRequiredMembers]
    public GitHubReplaceTopicsOptions(GitHubRepositoryBase repository, IEnumerable<string> names) {
        if (repository == null) throw new ArgumentNullException(nameof(repository));
        OwnerAlias = repository.Owner.Login;
        RepositoryAlias = repository.Name;
        Names = [.. names];
    }

    #endregion

    #region Member methods

    /// <inheritdoc />
    public override IHttpRequest GetRequest() {

        // Validate required parameters
        if (string.IsNullOrWhiteSpace(OwnerAlias)) throw new PropertyNotSetException(nameof(OwnerAlias));
        if (string.IsNullOrWhiteSpace(RepositoryAlias)) throw new PropertyNotSetException(nameof(RepositoryAlias));

        // Initialize the request body
        JObject body = new() {
            { "names", new JArray(Names) }
        };

        // Initialize the request
        return HttpRequest
            .Put($"/repos/{OwnerAlias}/{RepositoryAlias}/topics", body)
            .SetAcceptHeader(MediaTypes);

    }

    #endregion

}