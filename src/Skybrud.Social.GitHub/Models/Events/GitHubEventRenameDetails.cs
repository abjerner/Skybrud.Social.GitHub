using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Newtonsoft.Extensions;

namespace Skybrud.Social.GitHub.Models.Events;

/// <summary>
/// Class representing rename details from an event.
/// </summary>
public class GitHubEventRenameDetails : GitHubObject {

    #region Properties

    /// <summary>
    /// Gets the title or name before the rename.
    /// </summary>
    public string From { get; }

    /// <summary>
    /// Gets the title or name after the rename.
    /// </summary>
    public string To { get; }

    #endregion

    #region Constructors

    private GitHubEventRenameDetails(JObject json) : base(json) {
        From = json.GetRequiredString("from");
        To = json.GetRequiredString("to");
    }

    #endregion

    #region Static methods

    /// <summary>
    /// Parses the specified <paramref name="json"/> object into an instance of <see cref="GitHubEventRenameDetails"/>.
    /// </summary>
    /// <param name="json">The instance of <see cref="JObject"/> to be parsed.</param>
    /// <returns>An instance of <see cref="GitHubEventRenameDetails"/>.</returns>
    public static GitHubEventRenameDetails Parse(JObject json) {
        return new GitHubEventRenameDetails(json);
    }

    #endregion

}