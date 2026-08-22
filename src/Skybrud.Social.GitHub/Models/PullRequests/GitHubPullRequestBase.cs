using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Newtonsoft.Extensions;
using Skybrud.Essentials.Time;
using Skybrud.Social.GitHub.Exceptions;
using Skybrud.Social.GitHub.Extensions;
using Skybrud.Social.GitHub.Models.Issues;
using Skybrud.Social.GitHub.Models.Labels;
using Skybrud.Social.GitHub.Models.Milestones;
using Skybrud.Social.GitHub.Models.Users;

namespace Skybrud.Social.GitHub.Models.PullRequests;

/// <summary>
/// Class representing a GitHub pull request.
/// </summary>
public class GitHubPullRequestBase : GitHubObject {

    #region Properties

    /// <summary>
    /// Gets the API URL of the user.
    /// </summary>
    public string Url { get; }

    /// <summary>
    /// Gets the owner of the repository the pull request belongs to.
    /// </summary>
    public string OwnerAlias { get; }

    /// <summary>
    /// Gets the slug of the repository the pull request belongs to.
    /// </summary>
    public string RepositoryAlias { get; }

    /// <summary>
    /// Gets the ID of the pull request.
    /// </summary>
    public long Id { get; }

    /// <summary>
    /// Gets the node ID of the pull request.
    /// </summary>
    public string NodeId { get; }

    /// <summary>
    /// Gets the pull request number.
    /// </summary>
    public int Number { get; }

    /// <summary>
    /// Gets the state of the pull request, indicating whether the pull request is open or closed.
    /// </summary>
    public GitHubIssueState State { get; }

    /// <summary>
    /// Gets whether the pull request has been locked.
    /// </summary>
    public bool IsLocked { get; }

    // TODO: Add support for the "active_lock_reason"

    /// <summary>
    /// Gets the title of the pull request.
    /// </summary>
    public string Title { get; }

    /// <summary>
    /// Gets a reference to the user who created the pull request.
    /// </summary>
    public GitHubUserItem? User { get; }

    /// <summary>
    /// Gets the body of the pull request.
    /// </summary>
    public string? Body { get; }

    /// <summary>
    /// Gets whether a body has been specified for the pull request.
    /// </summary>
    [MemberNotNullWhen(true, nameof(Body))]
    public bool HasBody => !string.IsNullOrWhiteSpace(Body);

    /// <summary>
    /// Gets an array of the labels associated with the pull request.
    /// </summary>
    public IReadOnlyList<GitHubLabel> Labels { get; }

    /// <summary>
    /// Gets the milestone of the pull request, or <see langword="null"/> if the pull request is not part of any milestones.
    /// </summary>
    public GitHubMilestone? Milestone { get; }

    /// <summary>
    /// Gets whether pull request has been added to a milestone.
    /// </summary>
    [MemberNotNullWhen(true, nameof(Milestone))]
    public bool HasMilestone => Milestone is not null;

    /// <summary>
    /// Gets a timestamp for when the pull request was created.
    /// </summary>
    public EssentialsTime CreatedAt { get; }

    /// <summary>
    /// Gets a timestamp for when the pull request was last updated.
    /// </summary>
    public EssentialsTime UpdatedAt { get; }

    /// <summary>
    /// Gets a timestamp for when the pull request was closed, or <see langword="null"/> if the pull request hasn't yet been closed.
    /// </summary>
    public EssentialsTime? ClosedAt { get; }

    /// <summary>
    /// Gets whether the pull request has been closed.
    /// </summary>
    [MemberNotNullWhen(true, nameof(ClosedAt))]
    public bool IsClosed => ClosedAt != null;

    /// <summary>
    /// Gets a timestamp for when the pull request was merged, or <see langword="null"/> if the pull request hasn't yet been merged.
    /// </summary>
    public EssentialsTime? MergedAt { get; }

    /// <summary>
    /// Gets whether the pull request has been merged.
    /// </summary>
    [MemberNotNullWhen(true, nameof(MergedAt))]
    public bool IsMerged => MergedAt != null;

    /// <summary>
    /// Gets the SHA hash of the last commit of the pull request.
    /// </summary>
    public string? MergeCommitSha { get; }

    /// <summary>
    /// Gets the user assigned to the pull requests, or <c>null</c> if no user is assigned to the pull request.
    ///
    /// Notice that more than one user can be assigned to a pull request, so it's recommended to use the
    /// <see cref="Assignees"/> property instead, as it returns an array of the assigned users.
    /// </summary>
    public GitHubUserItem? Assignee { get; }

    /// <summary>
    /// Gets an array of users assigned to the pull request.
    /// </summary>
    public IReadOnlyList<GitHubUserItem> Assignees { get; }

    /// <summary>
    /// Gets whether any users are assigned to the pull request.
    /// </summary>
    public bool HasAssignees => Assignees.Count > 0;

    // TODO: Add support for the "requested_reviewers" property (array of SimpleUser) (nullable)

    // TODO: Add support for the "requested_teams" property (array of Team) (nullable)

    // TODO: Add support for the "head" property (object)

    // TODO: Add support for the "base" property (object)

    // TODO: Add support for the "_links" property (object)

    // TODO: Add support for the "author_association" property (string/enum)

    // TODO: Add support for the "auto_merge" property (boolean) (nullable)

    /// <summary>
    /// Gets whether the pull request is a draft.
    /// </summary>
    public bool IsDraft { get; }

    /// <summary>
    /// Gets a collection of URLs related to the pull request.
    /// </summary>
    public GitHubPullRequestUrls Urls { get; }

    #endregion

    #region Constructors

    /// <summary>
    /// Initializes a new instance from the specified <paramref name="json"/> object.
    /// </summary>
    /// <param name="json">The instance of <see cref="JObject"/> representing the pull request.</param>
    protected GitHubPullRequestBase(JObject json) : base(json) {

        Url = json.GetRequiredString("url");
        if (!GitHubUtils.TryParseRepositoryUrl(Url, out string? ownerAlias, out string? repositoryAlias)) throw new GitHubParseException("Failed parsing 'url' property from pull request.");
        OwnerAlias = ownerAlias!;
        RepositoryAlias = repositoryAlias!;
        Id = json.GetRequiredInt64("id");
        NodeId = json.GetRequiredString("node_id");
        Number = json.GetRequiredInt32("number");
        State = json.GetRequiredEnum<GitHubIssueState>("state");
        IsLocked = json.GetRequiredBoolean("locked");
        Title = json.GetRequiredString("title");
        User = json.GetObject("user", GitHubUserItem.Parse);
        Body = json.GetString("body");
        CreatedAt = json.GetRequiredEssentialsTime("created_at");
        UpdatedAt = json.GetRequiredEssentialsTime("updated_at");
        ClosedAt = json.GetEssentialsTime("closed_at");
        MergedAt = json.GetEssentialsTime("merged_at");
        MergeCommitSha = json.GetString("merge_commit_sha");
        Assignee = json.GetObject("assignee", GitHubUserItem.Parse);
        Assignees = json.GetRequiredArray("assignees", GitHubUserItem.Parse);
        Labels = json.GetRequiredArray("labels", GitHubLabel.Parse);
        Milestone = json.GetObject("milestone", GitHubMilestone.Parse);
        IsDraft = json.GetBoolean("draft");
        Urls = GitHubPullRequestUrls.Parse(json);
    }

    #endregion

    #region Static methods

    /// <summary>
    /// Parses the specified <paramref name="json"/> object into an instance of <see cref="GitHubPullRequestBase"/>.
    /// </summary>
    /// <param name="json">The instance of <see cref="JObject"/> to be parsed.</param>
    /// <returns>An instance of <see cref="GitHubPullRequestBase"/>.</returns>
    public static GitHubPullRequestBase Parse(JObject json) {
        return new GitHubPullRequestBase(json);
    }

    #endregion

}