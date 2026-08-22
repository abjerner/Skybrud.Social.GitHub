using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Newtonsoft.Extensions;

namespace Skybrud.Social.GitHub.Models.Commits;

/// <summary>
/// Class representing the details of a commit. Nested object of <see cref="GitHubCommit"/>.
/// </summary>
public class GitHubCommitDetails : GitHubObject {

    #region Properties

    /// <summary>
    /// Gets information about the author of the commit.
    /// </summary>
    public GitHubCommitAuthor? Author { get; }

    /// <summary>
    /// Gets information about the user who committed the commit.
    /// </summary>
    public GitHubCommitAuthor? Committer { get; }

    /// <summary>
    /// Gets the message of the commit.
    /// </summary>
    public string Message { get; }

    /// <summary>
    /// Gets information about the tree behind the commit.
    /// </summary>
    public GitHubCommitTree Tree { get; }

    /// <summary>
    /// Gets the API URL of the commit.
    /// </summary>
    public string Url { get; }

    /// <summary>
    /// Gets the amount of comments the commit has received.
    /// </summary>
    public int CommentCount { get; }

    #endregion

    #region Constructors

    private GitHubCommitDetails(JObject json) : base(json) {
        Author = json.GetObject("author", GitHubCommitAuthor.Parse);
        Committer = json.GetObject("committer", GitHubCommitAuthor.Parse);
        Message = json.GetRequiredString("message");
        Tree = json.GetRequiredObject("tree", GitHubCommitTree.Parse);
        Url = json.GetRequiredString("url");
        CommentCount = json.GetRequiredInt32("comment_count");
    }

    #endregion

    #region Static methods

    /// <summary>
    /// Parses the specified <paramref name="json"/> object into an instance of <see cref="GitHubCommitDetails"/>.
    /// </summary>
    /// <param name="json">The instance of <see cref="JObject"/> to be parsed.</param>
    /// <returns>An instance of <see cref="GitHubCommitDetails"/>.</returns>
    public static GitHubCommitDetails Parse(JObject json) {
        return new GitHubCommitDetails(json);
    }

    #endregion

}