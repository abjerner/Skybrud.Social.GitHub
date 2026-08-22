using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Newtonsoft.Extensions;

namespace Skybrud.Social.GitHub.Models.Common;

/// <summary>
/// Class representing an individual error of an error response.
/// </summary>
public class GitHubErrorItem : GitHubObject {

    #region Properties

    // TODO: which properties are nullable?

    /// <summary>
    /// Gets the message.
    /// </summary>
    public string? Message { get; }

    /// <summary>
    /// Gets the name of the affected resource.
    /// </summary>
    public string? Resource { get; }

    /// <summary>
    /// Gets the code of the error.
    /// </summary>
    public string? Code { get; }

    /// <summary>
    /// Gets the name of the affected field.
    /// </summary>
    public string? Field { get; }

    #endregion

    #region Constructors

    /// <summary>
    /// Initializes a new instance based on the specified <paramref name="json"/>.
    /// </summary>
    /// <param name="json">The instance of <see cref="JObject"/> representing the error.</param>
    protected GitHubErrorItem(JObject json) : base(json) {
        Message = json.GetString("message");
        Resource = json.GetString("resource");
        Code = json.GetString("code");
        Field = json.GetString("field");
    }

    #endregion

    #region Static methods

    /// <summary>
    /// Parses the specified <paramref name="json"/> object into an instance of <see cref="GitHubErrorItem"/>.
    /// </summary>
    /// <param name="json">The instance of <see cref="JObject"/> to be parsed.</param>
    /// <returns>An instance of <see cref="GitHubErrorItem"/>.</returns>
    public static GitHubErrorItem Parse(JObject json) {
        return new GitHubErrorItem(json);
    }

    #endregion

}