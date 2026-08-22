using System.Diagnostics.CodeAnalysis;
using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Newtonsoft.Extensions;
using Skybrud.Essentials.Time;
using Skybrud.Social.GitHub.Extensions;
using Skybrud.Social.GitHub.Models.Issues;
using Skybrud.Social.GitHub.Models.Users;

namespace Skybrud.Social.GitHub.Models.Milestones;

/// <summary>
/// Class representing a GitHub milestone.
/// </summary>
public class GitHubMilestone : GitHubObject {

    #region Properties

    /// <summary>
    /// Gets the API URL of the milestone.
    /// </summary>
    public string Url { get; }

    // TODO: Add support for the "html_url" property

    // TODO: Add support for the "labels_url" property

    /// <summary>
    /// Gets the ID of the milestone.
    /// </summary>
    public long Id { get; }

    /// <summary>
    /// Gets the node ID of the milestone.
    /// </summary>
    public string NodeId { get; }

    /// <summary>
    /// Gets the number of the milestone.
    /// </summary>
    public int Number { get; }

    /// <summary>
    /// Gets the state of the milestone, indicating whether the milestone is open or closed.
    /// </summary>
    public GitHubMilestoneState State { get; }

    /// <summary>
    /// Gets the title of the milestone.
    /// </summary>
    public string Title { get; }

    /// <summary>
    /// Gets the description of the milestone.
    /// </summary>
    public string? Description { get; }

    /// <summary>
    /// Gets whether a description has been specified for the milestone.
    /// </summary>
    [MemberNotNullWhen(true, nameof(Description))]
    public bool HasDescription => !string.IsNullOrWhiteSpace(Description);

    /// <summary>
    /// Gets a reference to the user who created the milestone.
    /// </summary>
    public GitHubUser? Creator { get; }

    /// <summary>
    /// Gets the amount of open issues in the milestone.
    /// </summary>
    public int OpenIssues { get; }

    /// <summary>
    /// Gets the amount of closed issues in the milestone.
    /// </summary>
    public int ClosedIssues { get; }

    /// <summary>
    /// Gets a timestamp for when the issue was created.
    /// </summary>
    public EssentialsTime CreatedAt { get; }

    /// <summary>
    /// Gets a timestamp for when the issue was last updated.
    /// </summary>
    public EssentialsTime UpdatedAt { get; }

    /// <summary>
    /// Gets a timestamp for when the milestone was closed. If <see cref="State"/> is
    /// <see cref="GitHubIssueState.Open"/>, this property will return <see langword="null"/>.
    /// </summary>
    public EssentialsTime? ClosedAt { get; }

    /// <summary>
    /// Gets whether the milestone has a closed date.
    /// </summary>
    [MemberNotNullWhen(true, nameof(ClosedAt))]
    public bool HasClosedAt => ClosedAt is not null;

    /// <summary>
    /// Gets a timestamp for when the milestone is due, or <see langword="null"/> if the milestone doesn't have a due date.
    /// </summary>
    public EssentialsTime? DueOn { get; }

    /// <summary>
    /// Gets whether a due date has been specified for the milestone.
    /// </summary>
    [MemberNotNullWhen(true, nameof(DueOn))]
    public bool HasDueOn => DueOn is not null;

    #endregion

    #region Constructors

    private GitHubMilestone(JObject json) : base(json) {
        Url = json.GetRequiredString("url");
        Id = json.GetRequiredInt64("id");
        NodeId = json.GetRequiredString("node_id");
        Number = json.GetRequiredInt32("number");
        State = json.GetRequiredEnum<GitHubMilestoneState>("state");
        Title = json.GetRequiredString("title");
        Description = json.GetString("description");
        Creator = json.GetObject("creator", GitHubUser.Parse);
        OpenIssues = json.GetRequiredInt32("open_issues");
        ClosedIssues = json.GetRequiredInt32("closed_issues");
        CreatedAt = json.GetRequiredEssentialsTime("created_at");
        UpdatedAt = json.GetRequiredEssentialsTime("updated_at");
        ClosedAt = json.GetEssentialsTime("closed_at");
        DueOn = json.GetEssentialsTime("due_on");
    }

    #endregion

    #region Static methods

    /// <summary>
    /// Parses the specified <paramref name="json"/> object into an instance of <see cref="GitHubMilestone"/>.
    /// </summary>
    /// <param name="json">The instance of <see cref="JObject"/> to be parsed.</param>
    /// <returns>An instance of <see cref="GitHubMilestone"/>.</returns>
    public static GitHubMilestone Parse(JObject json) {
        return new GitHubMilestone(json);
    }

    #endregion

}