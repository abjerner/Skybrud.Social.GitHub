using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using Skybrud.Social.GitHub.Extensions;

namespace Skybrud.Social.GitHub.Models.Topics;

/// <summary>
/// Class representing a list of topic names.
/// </summary>
public class GitHubTopicList : GitHubObject {

    #region Properties

    /// <summary>
    /// Gets a list of the topic names.
    /// </summary>
    public IReadOnlyList<string> Names { get; }

    #endregion

    #region Constructors

    /// <summary>
    /// Initializes a new instance from the specified <paramref name="json"/> object.
    /// </summary>
    /// <param name="json">The instance of <see cref="JObject"/> representing the user.</param>
    protected GitHubTopicList(JObject json) : base(json) {
        Names = json.GetRequiredStringArray("names");
    }

    #endregion

    #region Static methods

    /// <summary>
    /// Parses the specified <paramref name="json"/> object into an instance of <see cref="GitHubTopicList"/>.
    /// </summary>
    /// <param name="json">The instance of <see cref="JObject"/> to be parsed.</param>
    /// <returns>An instance of <see cref="GitHubTopicList"/>.</returns>
    public static GitHubTopicList Parse(JObject json) {
        return new GitHubTopicList(json);
    }

    #endregion

}