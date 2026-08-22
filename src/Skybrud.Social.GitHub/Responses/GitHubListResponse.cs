using System.Collections.Generic;
using Skybrud.Essentials.Http;
using Skybrud.Social.GitHub.Models;

namespace Skybrud.Social.GitHub.Responses;

/// <summary>
/// Class representing a response from the GitHub API.
/// </summary>
public class GitHubListResponse<T> : GitHubResponse {

    #region Properties

    /// <summary>
    /// Gets a reference to the <c>Link</c> header of the response.
    /// </summary>
    public GitHubLinkHeader? Link { get; }

    /// <summary>
    /// Gets the body of the response.
    /// </summary>
    public IReadOnlyList<T> Body { get; protected set; }

    #endregion

    #region Constructors

    /// <summary>
    /// Initializes a new instance from the specified <paramref name="response"/>.
    /// </summary>
    /// <param name="response">The raw response the instance should be based on.</param>
    protected GitHubListResponse(IHttpResponse response) : base(response) {
        Link = GitHubLinkHeader.Parse(response);
        Body = null!; // TODO: can we do this in a better way?
    }

    /// <summary>
    /// Initializes a new instance from the specified <paramref name="response"/>.
    /// </summary>
    /// <param name="response">The raw response the instance should be based on.</param>
    /// <param name="body">The body of the response.</param>
    protected GitHubListResponse(IHttpResponse response, IReadOnlyList<T> body) : base(response) {
        Link = GitHubLinkHeader.Parse(response);
        Body = body;
    }

    #endregion

}