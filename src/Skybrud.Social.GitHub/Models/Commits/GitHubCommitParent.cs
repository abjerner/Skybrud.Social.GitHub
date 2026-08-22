using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Newtonsoft.Extensions;

namespace Skybrud.Social.GitHub.Models.Commits;

/// <summary>
/// Class representing the parent commit of a given commit.
/// </summary>
public class GitHubCommitParent : GitHubObject {

    #region Properties

    /// <summary>
    /// Gets the SHA hash of the commit.
    /// </summary>
    public string Sha { get; }

    /// <summary>
    /// Gets the API URL of the commit.
    /// </summary>
    public string Url { get; }

    /// <summary>
    /// Gets the HTML (website) URL of the commit.
    /// </summary>
    public string HtmlUrl { get; }

    #endregion

    #region Constructors

    private GitHubCommitParent(JObject obj) : base(obj) {
        Sha = obj.GetRequiredString("sha");
        Url = obj.GetRequiredString("url");
        HtmlUrl = obj.GetRequiredString("html_url");
    }

    #endregion

    #region Static methods

    /// <summary>
    /// Parses the specified <paramref name="json"/> object into an instance of <see cref="GitHubCommitParent"/>.
    /// </summary>
    /// <param name="json">The instance of <see cref="JObject"/> to be parsed.</param>
    /// <returns>An instance of <see cref="GitHubCommitParent"/>.</returns>
    public static GitHubCommitParent Parse(JObject json) {
        return new GitHubCommitParent(json);
    }

    #endregion

}