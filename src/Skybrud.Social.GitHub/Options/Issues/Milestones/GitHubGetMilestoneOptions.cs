using System.Diagnostics.CodeAnalysis;
using Skybrud.Essentials.Common;
using Skybrud.Essentials.Http;
using Skybrud.Social.GitHub.Http;

namespace Skybrud.Social.GitHub.Options.Issues.Milestones;

/// <summary>
/// Options for getting about a milestone of a GitHub repository.
/// </summary>
/// <see>
///     <cref>https://developer.github.com/v3/issues/milestones/#get-a-single-milestone</cref>
/// </see>
public class GitHubGetMilestoneOptions : GitHubHttpRequestOptions {

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
    /// Gets or sets the number of the milestone.
    /// </summary>
#if NET8_0_OR_GREATER
    public required int Number { get; set; }
#else
    public int Number { get; set; }
#endif

    #endregion

    #region Constructors

    /// <summary>
    /// Initializes a new instance with default options.
    /// </summary>
    public GitHubGetMilestoneOptions() { }

    /// <summary>
    /// Initializes a new instance based on the specified <paramref name="owner"/> and <paramref name="repository"/>.
    /// </summary>
    /// <param name="owner">The username (login) of the owner of the repository.</param>
    /// <param name="repository">The slug of the repository.</param>
    /// <param name="number">The number of the milestone.</param>
    [SetsRequiredMembers]
    public GitHubGetMilestoneOptions(string owner, string repository, int number) {
        Owner = owner;
        Repository = repository;
        Number = number;
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

        // Initialize the request
        return HttpRequest
            .Get($"/repos/{Owner}/{Repository}/milestones/{Number}")
            .SetAcceptHeader(MediaTypes);

    }

    #endregion

}