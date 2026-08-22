using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Newtonsoft.Extensions;

namespace Skybrud.Social.GitHub.Models.Emails;

/// <summary>
/// Class representing an email address of a given user.
/// </summary>
public class GitHubEmail : GitHubObject {

    #region Properties

    /// <summary>
    /// Gets the email address.
    /// </summary>
    public string Email { get; }

    /// <summary>
    /// Gets whether the email address has been verified.
    /// </summary>
    public bool IsVerified { get; }

    /// <summary>
    /// Gets whether the email address is the primary email address of the user.
    /// </summary>
    public bool IsPrimary { get; }

    #endregion

    #region Constructors

    private GitHubEmail(JObject json) : base(json) {
        Email = json.GetRequiredString("email");
        IsVerified = json.GetRequiredBoolean("verified");
        IsPrimary = json.GetRequiredBoolean("primary");
    }

    #endregion

    #region Static methods

    /// <summary>
    /// Parses the specified <paramref name="json"/> object into an instance of <see cref="GitHubEmail"/>.
    /// </summary>
    /// <param name="json">The instance of <see cref="JObject"/> to be parsed.</param>
    /// <returns>An instance of <see cref="GitHubEmail"/>.</returns>
    public static GitHubEmail Parse(JObject json) {
        return new GitHubEmail(json);
    }

    #endregion

}