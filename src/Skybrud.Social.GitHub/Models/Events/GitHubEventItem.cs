using Newtonsoft.Json.Linq;

namespace Skybrud.Social.GitHub.Models.Events;

/// <summary>
/// Class representing a GitHub event.
/// </summary>
public class GitHubEventItem : GitHubEventBase {

    #region Constructors

    /// <summary>
    /// Initializes a new instance from the specified <paramref name="json"/> object.
    /// </summary>
    /// <param name="json">The instance of <see cref="JObject"/> representing the event.</param>
    protected GitHubEventItem(JObject json) : base(json) { }

    #endregion

    #region Static methods

    /// <summary>
    /// Parses the specified <paramref name="obj"/> object into an instance of <see cref="GitHubEventItem"/>.
    /// </summary>
    /// <param name="obj">The instance of <see cref="JObject"/> to be parsed.</param>
    /// <returns>An instance of <see cref="GitHubEventItem"/>.</returns>
    public static GitHubEventItem Parse(JObject obj) {
        return new GitHubEventItem(obj);
    }

    #endregion

}