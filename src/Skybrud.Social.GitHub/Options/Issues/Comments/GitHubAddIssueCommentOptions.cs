using System;
using System.Diagnostics.CodeAnalysis;
using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Common;
using Skybrud.Essentials.Http;
using Skybrud.Social.GitHub.Http;
using Skybrud.Social.GitHub.Models.Issues;

namespace Skybrud.Social.GitHub.Options.Issues.Comments;

/// <summary>
/// Class representing the options for adding a comment to a GitHub issue.
/// </summary>
public class GitHubAddIssueCommentOptions : GitHubHttpRequestOptions {

    #region Properties

    /// <summary>
    /// Mandatory: Gets or sets the username (login) of the owner of the repository.
    /// </summary>
#if NET8_0_OR_GREATER
    public required string Owner { get; set; }
#else
    public string? Owner { get; set; }
#endif

    /// <summary>
    /// Mandatory: Gets or sets the slug of the repository.
    /// </summary>
#if NET8_0_OR_GREATER
    public required string Repository { get; set; }
#else
    public string? Repository { get; set; }
#endif

    /// <summary>
    /// Gets or sets the number of the issue to which the comment should be added.
    /// </summary>
#if NET8_0_OR_GREATER
    public required int Number { get; set; }
#else
    public int Number { get; set; }
#endif

    /// <summary>
    /// Gets or sets the Markdown-based body of the comment.
    /// </summary>
    /// <see>
    ///     <cref>https://guides.github.com/features/mastering-markdown/</cref>
    /// </see>
#if NET8_0_OR_GREATER
    public required string Body { get; set; }
#else
    public string? Body { get; set; }
#endif

    #endregion

    #region Constructors

    /// <summary>
    /// Initializes a new instance with default options.
    /// </summary>
    public GitHubAddIssueCommentOptions() { }

    /// <summary>
    /// Initializes a new instance based on the specified <paramref name="owner"/>, <paramref name="repository"/>,
    /// <paramref name="number"/> and <paramref name="body"/>.
    /// </summary>
    /// <param name="owner">The username (login) of the owner of the repository.</param>
    /// <param name="repository">The slug of the repository.</param>
    /// <param name="number">The number of the issue.</param>
    /// <param name="body">The Markdown-based body of the comment.</param>
    [SetsRequiredMembers]
    public GitHubAddIssueCommentOptions(string owner, string repository, int number, string body) {
        Owner = owner;
        Repository = repository;
        Number = number;
        Body = body;
    }

    /// <summary>
    /// Initializes a new instance based on the specified <paramref name="issue"/> and <paramref name="body"/>.
    /// </summary>
    /// <param name="issue">The issue to which the comment will be added.</param>
    /// <param name="body">The Markdown-based body of the comment.</param>
    [SetsRequiredMembers]
    public GitHubAddIssueCommentOptions(GitHubIssue issue, string body) {
        if (issue == null) throw new ArgumentNullException(nameof(issue));
        Owner = issue.Repository.Owner.Login;
        Repository = issue.Repository.Name;
        Number = issue.Number;
        Body = body;
    }

    #endregion

    #region Member methods

    /// <summary>
    /// Returns a new <see cref="IHttpRequest"/> instance for this options instance.
    /// </summary>
    /// <returns>An instance of <see cref="IHttpRequest"/>.</returns>
    public override IHttpRequest GetRequest() {

        // Validate required parameters
        if (string.IsNullOrWhiteSpace(Owner)) throw new PropertyNotSetException(nameof(Owner));
        if (string.IsNullOrWhiteSpace(Repository)) throw new PropertyNotSetException(nameof(Repository));
        if (Number == 0) throw new PropertyNotSetException(nameof(Number));
        if (string.IsNullOrWhiteSpace(Body)) throw new PropertyNotSetException(nameof(Body));

        // Generate the payload for the request body
        JObject body = new() {
            {"body", Body}
        };

        // Initialize the request
        return HttpRequest
            .Post($"/repos/{Owner}/{Repository}/issues/{Number}/comments", body)
            .SetAcceptHeader(MediaTypes);

    }

    #endregion

}