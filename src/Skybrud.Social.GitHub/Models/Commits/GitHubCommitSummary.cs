using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Newtonsoft.Extensions;
using Skybrud.Social.GitHub.Models.Users;

namespace Skybrud.Social.GitHub.Models.Commits;

/// <summary>
/// Class representing a summary about a given commit.
/// </summary>
public class GitHubCommitSummary : GitHubObject {

    #region Properties

    /// <summary>
    /// Gets the SHA hash of the commit.
    /// </summary>
    public string Sha { get; }

    /// <summary>
    /// Gets details about the commit.
    /// </summary>
    public GitHubCommitDetails Commit { get; }

    /// <summary>
    /// Gets a reference to a collection of URLs related to the commit.
    /// </summary>
    public GitHubCommitUrls Urls { get; }

    /// <summary>
    /// Gets information about the author of the commit.
    /// </summary>
    public GitHubUserItem Author { get; }

    /// <summary>
    /// Gets information about the user who committed the commit.
    /// </summary>
    public GitHubUserItem Committer { get; }

    /// <summary>
    /// Gets information about the parent commits.
    /// </summary>
    public IReadOnlyList<GitHubCommitParent> Parents { get; }

    #endregion

    #region Constructors

    private GitHubCommitSummary(JObject json) : base(json) {
        Sha = json.GetRequiredString("sha");
        Commit = json.GetRequiredObject("commit", GitHubCommitDetails.Parse);
        Urls = GitHubCommitUrls.Parse(json);
        Author = json.GetRequiredObject("author", GitHubUserItem.Parse);
        Committer = json.GetRequiredObject("committer", GitHubUserItem.Parse);
        Parents = json.GetRequiredArray("parents", GitHubCommitParent.Parse);
    }

    #endregion

    #region Static methods

    /// <summary>
    /// Parses the specified <paramref name="json"/> object into an instance of <see cref="GitHubCommitSummary"/>.
    /// </summary>
    /// <param name="json">The instance of <see cref="JObject"/> to be parsed.</param>
    /// <returns>An instance of <see cref="GitHubCommitSummary"/>.</returns>
    public static GitHubCommitSummary Parse(JObject json) {
        return new GitHubCommitSummary(json);
    }

    #endregion

}