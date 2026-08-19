using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Newtonsoft.Extensions;
using Skybrud.Essentials.Time;
using Skybrud.Social.GitHub.Extensions;
using Skybrud.Social.GitHub.Models.Labels;
using Skybrud.Social.GitHub.Models.Milestones;
using Skybrud.Social.GitHub.Models.Users;

namespace Skybrud.Social.GitHub.Models.Issues;

/// <summary>
/// Class representing a GitHub issue.
/// </summary>
public abstract class GitHubIssueBase : GitHubObject {

    #region Properties

    /// <summary>
    /// Gets the ID of the issue.
    /// </summary>
    public long Id { get; }

    /// <summary>
    /// Gets the node ID of the issue.
    /// </summary>
    public string NodeId { get; }

    /// <summary>
    /// Gets the API URL of the user.
    /// </summary>
    public string Url { get; }

    /// <summary>
    /// Gets the API URL for getting the repository of the issue.
    /// </summary>
    public string RepositoryUrl { get; }

    /// <summary>
    /// Gets the API URL for getting a list of labels of the issue.
    /// </summary>
    public string LabelsUrl { get; }

    /// <summary>
    /// Gets the API URL for getting a list of comments of the issue.
    /// </summary>
    public string CommentsUrl { get; }

    /// <summary>
    /// Gets the API URL for getting a list of events of the issue.
    /// </summary>
    public string EventsUrl { get; }

    /// <summary>
    /// Gets the website URL of the issue.
    /// </summary>
    public string HtmlUrl { get; }

    /// <summary>
    /// Gets the umber uniquely identifying the issue within its repository.
    /// </summary>
    public int Number { get; }

    /// <summary>
    /// Gets the state of the issue, indicating whether the issue is open or closed.
    /// </summary>
    public GitHubIssueState State { get; }

    // TODO: add support for the "state_reason" property (string/enum) (nullable)

    /// <summary>
    /// Gets the title of the issue.
    /// </summary>
    public string Title { get; }

    /// <summary>
    /// Gets the body of the issue.
    /// </summary>
    public string? Body { get; }

    /// <summary>
    /// Gets whether a body has been specified for the issue.
    /// </summary>
    public bool HasBody => !string.IsNullOrWhiteSpace(Body);

    /// <summary>
    /// Gets a reference to the user who created the issue.
    /// </summary>
    public GitHubUserItem? User { get; }

    /// <summary>
    /// Gets an array of the labels of the issue.
    /// </summary>
    public IReadOnlyList<GitHubLabel> Labels { get; }

    /// <summary>
    /// Gets a reference to the (first) user the issue is assigned to, or <see langword="null"/> if the issue is not
    /// assigned to any users.
    /// </summary>
    public GitHubUserItem? Assignee { get; }

    /// <summary>
    /// Gets an array of the users the issue is assigned to.
    /// </summary>
    public IReadOnlyList<GitHubUserItem> Assignees { get; }

    /// <summary>
    /// Gets a reference to the milestone of the issue, or <see langword="null"/> if the issue is not part of a milestone.
    /// </summary>
    public GitHubMilestone? Milestone { get; }

    /// <summary>
    /// Gets whether the issue is part of a milestone.
    /// </summary>
    [MemberNotNullWhen(true, nameof(Milestone))]
    public bool HasMilestone => Milestone != null;

    /// <summary>
    /// Gets whether the issue has been locked.
    /// </summary>
    public bool IsLocked { get; }

    // TODO: add support for the "active_lock_reason" property (string) (nullable)

    /// <summary>
    /// Gets the number of comment.
    /// </summary>
    public int Comments { get; }

    // TODO: add support for the "pull_request" property (object)

    /// <summary>
    /// Gets a timestamp for when the issue was closed. If <see cref="State"/> is
    /// <see cref="GitHubIssueState.Open"/>, this property will return <see langword="null"/>.
    /// </summary>
    public EssentialsTime? ClosedAt { get; }

    /// <summary>
    /// Gets a timestamp for when the issue was created.
    /// </summary>
    public EssentialsTime CreatedAt { get; }

    /// <summary>
    /// Gets a timestamp for when the issue was last updated.
    /// </summary>
    public EssentialsTime UpdatedAt { get; }

    // TODO: add support for the "draft" property (boolean)

    // TODO: add support for the "closed_by" property (SimpleUser) (nullable)

    // TODO: add support for the "body_html" property (string)

    // TODO: add support for the "body_text" property (string)

    // TODO: add support for the "timeline_url" property (string)

    // TODO: add support for the "type" property (object) (nullable)

    // TODO: add support for the "repository" property (Repository) (is this always included? schema says so ¯\_(ツ)_/¯)

    // TODO: add support for the "performed_via_github_app" property (object) (nullable)

    // TODO: add support for the "reactions" property (ReactionRollup)

    // TODO: add support for the "sub_issues_summary" property (SubIssuesSummary)

    // TODO: add support for the "parent_issue_url" property (string) (nullable)

    // TODO: add support for the "issue_dependencies_summary" property (IssueDependenciesSummary)

    // TODO: add support for the "issue_field_values" property (array of IssueFieldValue)

    #endregion

    #region Constructors

    /// <summary>
    /// Initializes a new instance from the specified <paramref name="json"/>.
    /// </summary>
    /// <param name="json">The instance of <see cref="JObject"/> representing the issue.</param>
    protected GitHubIssueBase(JObject json) : base(json) {
        Id = json.GetRequiredInt64("id");
        NodeId = json.GetRequiredString("node_id");
        Url = json.GetRequiredString("url");
        RepositoryUrl = json.GetRequiredString("repository_url");
        LabelsUrl = json.GetRequiredString("labels_url");
        CommentsUrl = json.GetRequiredString("comments_url");
        EventsUrl = json.GetRequiredString("events_url");
        HtmlUrl = json.GetRequiredString("html_url");
        Number = json.GetRequiredInt32("number");
        State = json.GetRequiredEnum<GitHubIssueState>("state");
        // TODO: add support for the "state_reason" property (string/enum) (nullable)
        Title = json.GetRequiredString("title");
        Body = json.GetString("body");
        User = json.GetObject("user", GitHubUserItem.Parse);
        Labels = json.GetArrayItems("labels", GitHubLabel.Parse);
        Assignee = json.GetObject("assignee", GitHubUserItem.Parse);
        Assignees = json.GetArrayItems("assignees", GitHubUserItem.Parse);
        Milestone = json.GetObject("milestone", GitHubMilestone.Parse);
        IsLocked = json.GetRequiredBoolean("locked");
        // TODO: add support for the "active_lock_reason" property (string) (nullable)
        Comments = json.GetRequiredInt32("comments");
        // TODO: add support for the "pull_request" property (object)
        ClosedAt = json.GetEssentialsTime("closed_at");
        CreatedAt = json.GetRequiredEssentialsTime("created_at");
        UpdatedAt = json.GetRequiredEssentialsTime("updated_at");
        // TODO: add support for the "draft" property (boolean)
        // TODO: add support for the "closed_by" property (SimpleUser) (nullable)
        // TODO: add support for the "body_html" property (string)
        // TODO: add support for the "body_text" property (string)
        // TODO: add support for the "timeline_url" property (string)
        // TODO: add support for the "type" property (object) (nullable)
        // TODO: add support for the "repository" property (Repository) (is this always included? schema says so ¯\_(ツ)_/¯)
        // TODO: add support for the "performed_via_github_app" property (object) (nullable)
        // TODO: add support for the "reactions" property (ReactionRollup)
        // TODO: add support for the "sub_issues_summary" property (SubIssuesSummary)
        // TODO: add support for the "parent_issue_url" property (string) (nullable)
        // TODO: add support for the "issue_dependencies_summary" property (IssueDependenciesSummary)
        // TODO: add support for the "issue_field_values" property (array of IssueFieldValue)
    }

    #endregion

}