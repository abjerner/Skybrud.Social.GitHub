using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Newtonsoft.Extensions;

namespace Skybrud.Social.GitHub.Models.Common;

/// <summary>
/// Class representing an error as returned by the GitHub API.
/// </summary>
public class GitHubError : GitHubObject {

    #region Properties

    /// <summary>
    /// Gets the error message.
    /// </summary>
    public string Message { get; }

    /// <summary>
    /// Gets an array of errors.
    /// </summary>
    public IReadOnlyList<GitHubErrorItem> Errors { get; }

    /// <summary>
    /// Gets whether the <see cref="Errors"/> property has any items.
    /// </summary>
    public bool HasErrors => Errors.Count > 0;

    /// <summary>
    /// Gets an URL with information about the error.
    /// </summary>
    public string DocumentationUrl { get; }

    #endregion

    #region Constructors

    /// <summary>
    /// Initializes a new instance based on the specified <paramref name="json"/> object.
    /// </summary>
    /// <param name="json">The instance of <see cref="JObject"/> representing the error.</param>
    protected GitHubError(JObject json) : base(json) {
        Message = json.GetRequiredString("message");
        Errors = json.GetArrayItems("errors", GitHubErrorItem.Parse);
        DocumentationUrl = json.GetRequiredString("documentation_url");
    }

    #endregion

    #region Static methods

    /// <summary>
    /// Parses the specified <paramref name="json"/> object into an instance of <see cref="GitHubError"/>.
    /// </summary>
    /// <param name="json">The instance of <see cref="JObject"/> to be parsed.</param>
    /// <returns>An instance of <see cref="GitHubError"/>.</returns>
    public static GitHubError Parse(JObject json) {
        return new GitHubError(json);
    }

    #endregion

}