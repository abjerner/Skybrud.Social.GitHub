using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Newtonsoft.Extensions;

namespace Skybrud.Social.GitHub.Models.Commits;

/// <summary>
/// Class representing the tree of a given commit.
/// </summary>
public class GitHubCommitTree : GitHubObject {

    #region Properties

    /// <summary>
    /// Gets the SHA hash of the tree.
    /// </summary>
    public string Sha { get; }

    /// <summary>
    /// Gets the API URL of the tree.
    /// </summary>
    public string Url { get; }

    #endregion

    #region Constructors

    private GitHubCommitTree(JObject json) : base(json) {
        Sha = json.GetRequiredString("sha");
        Url = json.GetRequiredString("url");
    }

    #endregion

    #region Static methods

    /// <summary>
    /// Parses the specified <paramref name="json"/> object into an instance of <see cref="GitHubCommitTree"/>.
    /// </summary>
    /// <param name="json">The instance of <see cref="JObject"/> to be parsed.</param>
    /// <returns>An instance of <see cref="GitHubCommitTree"/>.</returns>
    public static GitHubCommitTree Parse(JObject json) {
        return new GitHubCommitTree(json);
    }

    #endregion

}