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
/// Class with options for updating an existing file in a repository.
/// </summary>
/// <see>
///     <cref>https://docs.github.com/en/rest/reference/repos#create-or-update-file-contents</cref>
/// </see>
public class GitHubUpdateRepositoryContentOptions : GitHubHttpRequestOptions {

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
    /// Gets or set alias/slug of the repository.
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
    /// Gets or sets the blob SHA of the file being replaced.
    /// </summary>
#if NET8_0_OR_GREATER
    public required string Sha { get; set; }
#else
    public string? Sha { get; set; }
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
    public GitHubUpdateRepositoryContentOptions() { }

    /// <summary>
    /// Initializes a new instance based on the specified <paramref name="repository"/>.
    /// </summary>
    /// <param name="repository">The repository.</param>
    /// <param name="path">The path to the file or directory.</param>
    /// <param name="message">The commit message.</param>
    /// <param name="content">The new file content, using Base64 encoding.</param>
    /// <param name="sha">The blob SHA of the file being replaced.</param>
    [SetsRequiredMembers]
    public GitHubUpdateRepositoryContentOptions(GitHubRepositoryBase repository, string path, string message, string content, string sha) {
        if (repository == null) throw new ArgumentNullException(nameof(repository));
        OwnerAlias = repository.Owner.Login;
        RepositoryAlias = repository.Name;
        Path = path;
        Message = message;
        Content = content;
        Sha = sha;
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
        if (string.IsNullOrWhiteSpace(Sha)) throw new PropertyNotSetException(nameof(Sha));

        // Initialize the response body
        JObject body = new() {
            {"message", Message},
            {"content", Content},
            {"sha", Sha}
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