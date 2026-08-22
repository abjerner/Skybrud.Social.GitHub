using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Newtonsoft.Extensions;

namespace Skybrud.Social.GitHub.Models.Milestones;

/// <summary>
/// Class representing a GitHub milestone.
/// </summary>
public class GitHubMilestoneReference : GitHubObject {

    #region Properties

    /// <summary>
    /// Gets the title of the milestone.
    /// </summary>
    public string Title { get; }

    #endregion

    #region Constructors

    private GitHubMilestoneReference(JObject json) : base(json) {
        Title = json.GetRequiredString("title");
    }

    #endregion

    #region Static methods

    /// <summary>
    /// Parses the specified <paramref name="json"/> object into an instance of <see cref="GitHubMilestoneReference"/>.
    /// </summary>
    /// <param name="json">The instance of <see cref="JObject"/> to be parsed.</param>
    /// <returns>An instance of <see cref="GitHubMilestoneReference"/>.</returns>
    public static GitHubMilestoneReference Parse(JObject json) {
        return new GitHubMilestoneReference(json);
    }

    #endregion

}