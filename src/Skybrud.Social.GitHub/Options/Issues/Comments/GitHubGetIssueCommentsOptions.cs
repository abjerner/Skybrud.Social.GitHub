using System;
using System.Diagnostics.CodeAnalysis;
using Skybrud.Essentials.Common;
using Skybrud.Essentials.Http;
using Skybrud.Essentials.Http.Collections;
using Skybrud.Essentials.Time;
using Skybrud.Social.GitHub.Http;
using Skybrud.Social.GitHub.Models.Issues;
using Skybrud.Social.GitHub.Models.PullRequests;

namespace Skybrud.Social.GitHub.Options.Issues.Comments;

/// <summary>
/// Options for a request to get comments of a given GitHub issue.
/// </summary>
/// <see>
///     <cref>https://developer.github.com/v3/issues/comments/#list-comments-on-an-issue</cref>
/// </see>
public class GitHubGetIssueCommentsOptions : GitHubHttpRequestOptions {

    #region Properties

    /// <summary>
    /// Gets or sets the username (login) of the owner of the repository.
    /// </summary>
#if NET8_0_OR_GREATER
    public required string Owner { get; set; }
#else
    public string? Owner { get; set; }
#endif

    /// <summary>
    /// Gets or sets the slug of the repository.
    /// </summary>
#if NET8_0_OR_GREATER
    public required string Repository { get; set; }
#else
    public string? Repository { get; set; }
#endif

    /// <summary>
    /// Gets or sets the number of the issue.
    /// </summary>
#if NET8_0_OR_GREATER
    public required int Number { get; set; }
#else
    public int Number { get; set; }
#endif

    /// <summary>
    /// Only comments updated at or after this time are returned.
    /// </summary>
    public EssentialsTime? Since { get; set; }

    /// <summary>
    /// Gets or sets the page to be returned. Default is <c>0</c>, indicating the first page.
    /// </summary>
    public int? Page { get; set; }

    /// <summary>
    /// Gets or sets the maximum amount of comments to be returned by each page.
    /// </summary>
    public int? PerPage { get; set; }

    #endregion

    #region Constructors

    /// <summary>
    /// Initializes a new instance with default options.
    /// </summary>
    public GitHubGetIssueCommentsOptions() { }

    /// <summary>
    /// Initializes a new instance based on the specified <paramref name="owner"/>, <paramref name="repository"/> and
    /// <paramref name="number"/>.
    /// </summary>
    /// <param name="owner">The username (login) of the owner of the repository.</param>
    /// <param name="repository">The slug of the repository.</param>
    /// <param name="number">The number of the issue.</param>
    [SetsRequiredMembers]
    public GitHubGetIssueCommentsOptions(string owner, string repository, int number) {
        Owner = owner;
        Repository = repository;
        Number = number;
    }

    /// <summary>
    /// Initializes a new instance based on the specified <paramref name="issue"/>.
    /// </summary>
    /// <param name="issue">The issue for which to get comments.</param>
    [SetsRequiredMembers]
    public GitHubGetIssueCommentsOptions(GitHubIssueBase issue) {
        if (issue == null) throw new ArgumentNullException(nameof(issue));
        // TODO: fix me ("GitHubIssueBase" no longer has a reference to the repository)
        throw new Exception("BAAAAAAAAAAAAAH\r\n\r\n" + issue.JObject);
        //Owner = issue..Repository.Owner.Login;;
        //Repository = issue.Repository.Name;
        Number = issue.Number;
    }

    /// <summary>
    /// Initializes a new instance based on the specified <paramref name="pullRequest"/>.
    /// </summary>
    /// <param name="pullRequest">The pull request for which to get comments.</param>
    [SetsRequiredMembers]
    public GitHubGetIssueCommentsOptions(GitHubPullRequestBase pullRequest) {
        if (pullRequest == null) throw new ArgumentNullException(nameof(pullRequest));
        // TODO: fix me ("GitHubPullRequestBase" no longer has a reference to the repository)
        throw new Exception("BAAAAAAAAAAAAAH\r\n\r\n" + pullRequest.JObject);
        //Owner = issue..Repository.Owner.Login;;
        //Repository = issue.Repository.Name;
        Number = pullRequest.Number;
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

        // Initialize and construct the query string
        HttpQueryString query = new();
        if (Since != null) query.Add("since", Since.Iso8601);
        if (Page > 0) query.Add("page", Page);
        if (PerPage > 0) query.Add("per_page", PerPage);

        // Initialize the request
        return HttpRequest
            .Get($"/repos/{Owner}/{Repository}/issues/{Number}/comments", query)
            .SetAcceptHeader(MediaTypes);

    }

    #endregion

}