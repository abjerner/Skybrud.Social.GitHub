using System;
using System.Diagnostics.CodeAnalysis;
using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Common;
using Skybrud.Essentials.Http;
using Skybrud.Essentials.Strings.Extensions;
using Skybrud.Social.GitHub.Http;
using Skybrud.Social.GitHub.Models.Repositories;

namespace Skybrud.Social.GitHub.Options.Repositories.Content;

/// <summary>
/// Class with options for creating a new file in a repository.
/// </summary>
/// <see>
///     <cref>https://docs.github.com/en/rest/reference/repos#create-or-update-file-contents</cref>
/// </see>
public class GitHubCreateRepositoryContentOptions : GitHubHttpRequestOptions {

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
    /// Gets or sets the commit message.
    /// </summary>
#if NET8_0_OR_GREATER
    public required string Message { get; set; }
#else
    public string? Message { get; set; }
#endif

    /// <summary>
    /// Gets or sets the new file content, using Base64 encoding.
    /// </summary>
#if NET8_0_OR_GREATER
    public required string Content { get; set; }
#else
    public string? Content { get; set; }
#endif

    /// <summary>
    /// Gets or sets the name of the branch name. Uses the default branch if not specified.
    /// </summary>
    public string? Branch { get; set; }

    #endregion

    #region Constructors

    /// <summary>
    /// Initializes a new instance with default options.
    /// </summary>
    public GitHubCreateRepositoryContentOptions() { }

    /// <summary>
    /// Initializes a new instance based on the specified <paramref name="owner"/> and <paramref name="repositoryAlias"/>.
    /// </summary>
    /// <param name="owner">The alias of the repository owner.</param>
    /// <param name="repositoryAlias">The alias/slug of the repository.</param>
    /// <param name="path">The path to the file or directory.</param>
    /// <param name="message">The commit message.</param>
    /// <param name="content">The new file content, using Base64 encoding.</param>
    [SetsRequiredMembers]
    public GitHubCreateRepositoryContentOptions(string owner, string repositoryAlias, string path, string message, string content) {
        OwnerAlias = owner;
        RepositoryAlias = repositoryAlias;
        Path = path;
        Message = message;
        Content = content;
    }

    /// <summary>
    /// Initializes a new instance based on the specified <paramref name="owner"/> and <paramref name="repositoryAlias"/>.
    /// </summary>
    /// <param name="owner">The alias of the repository owner.</param>
    /// <param name="repositoryAlias">The alias/slug of the repository.</param>
    /// <param name="path">The path to the file or directory.</param>
    /// <param name="message">The commit message.</param>
    /// <param name="content">The new file content, using Base64 encoding.</param>
    /// <param name="branch">The name of the branch name.</param>
    [SetsRequiredMembers]
    public GitHubCreateRepositoryContentOptions(string owner, string repositoryAlias, string path, string message, string content, string? branch) {
        OwnerAlias = owner;
        RepositoryAlias = repositoryAlias;
        Path = path;
        Message = message;
        Content = content;
        Branch = branch;
    }

    /// <summary>
    /// Initializes a new instance based on the specified <paramref name="repository"/>.
    /// </summary>
    /// <param name="repository">The repository.</param>
    /// <param name="path">The path to the file or directory.</param>
    /// <param name="message">The commit message.</param>
    /// <param name="content">The new file content, using Base64 encoding.</param>
    [SetsRequiredMembers]
    public GitHubCreateRepositoryContentOptions(GitHubRepositoryBase repository, string path, string message, string content) {
        if (repository == null) throw new ArgumentNullException(nameof(repository));
        OwnerAlias = repository.Owner.Login;
        RepositoryAlias = repository.Name;
        Path = path;
        Message = message;
        Content = content;
    }

    /// <summary>
    /// Initializes a new instance based on the specified <paramref name="repository"/>.
    /// </summary>
    /// <param name="repository">The repository.</param>
    /// <param name="path">The path to the file or directory.</param>
    /// <param name="message">The commit message.</param>
    /// <param name="content">The new file content, using Base64 encoding.</param>
    /// <param name="branch">The name of the branch name.</param>
    [SetsRequiredMembers]
    public GitHubCreateRepositoryContentOptions(GitHubRepositoryBase repository, string path, string message, string content, string? branch) {
        if (repository == null) throw new ArgumentNullException(nameof(repository));
        OwnerAlias = repository.Owner.Login;
        RepositoryAlias = repository.Name;
        Path = path;
        Message = message;
        Content = content;
        Branch = branch;
    }

    #endregion

    #region Member methods

    /// <inheritdoc />
    public override IHttpRequest GetRequest() {

        // Input validation
        if (string.IsNullOrWhiteSpace(OwnerAlias)) throw new PropertyNotSetException(nameof(OwnerAlias));
        if (string.IsNullOrWhiteSpace(RepositoryAlias)) throw new PropertyNotSetException(nameof(RepositoryAlias));
        if (string.IsNullOrWhiteSpace(Path)) throw new PropertyNotSetException(nameof(Path));
        if (string.IsNullOrWhiteSpace(Message)) throw new PropertyNotSetException(nameof(Message));
        if (string.IsNullOrWhiteSpace(Content)) throw new PropertyNotSetException(nameof(Content));

        // Initialize the request body
        JObject body = new() {
            {"message", Message},
            {"content", Content}
        };

        // Append any optional parameters
        if (Branch.HasValue()) body.Add("branch", Branch);

        // Initialize a new PUT request
        return HttpRequest
            .Put($"/repos/{OwnerAlias}/{RepositoryAlias}/contents/{Path}", body)
            .SetAcceptHeader(MediaTypes);

    }

    #endregion

}