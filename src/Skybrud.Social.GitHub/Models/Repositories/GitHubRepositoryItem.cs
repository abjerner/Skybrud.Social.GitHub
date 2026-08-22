using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Newtonsoft.Extensions;
using Skybrud.Essentials.Time;
using Skybrud.Social.GitHub.Extensions;

namespace Skybrud.Social.GitHub.Models.Repositories;

/// <summary>
/// Class representing a summary about a given repository.
/// </summary>
public class GitHubRepositoryItem : GitHubRepositoryBase {

    #region Properties

    /// <summary>
    /// Gets the URL for the website behind project.
    /// </summary>
    public string? Homepage { get; }

    /// <summary>
    /// Gets the language of repository.
    /// </summary>
    public string? Language { get; }

    /// <summary>
    /// Gets the amount of forks of the repository.
    /// </summary>
    public int ForksCount { get; }

    /// <summary>
    /// Gets the amount of users who have starred the repository.
    /// </summary>
    public int StargazersCount { get; }

    /// <summary>
    /// Gets the amount of users watching the repository.
    /// </summary>
    public int WatchersCount { get; }

    /// <summary>
    /// Gets the size of the repository.
    /// </summary>
    public long Size { get; }

    /// <summary>
    /// Gets the name of the default branch.
    /// </summary>
    public string DefaultBranch { get; }

    /// <summary>
    /// Gets the amount of open issues.
    /// </summary>
    public int OpenIssuesCount { get; }

    /// <summary>
    /// Gets whether the repository is a template repository.
    /// </summary>
    public bool IsTemplate { get; }

    /// <summary>
    /// Gets the topics associated with repository.
    /// </summary>
    public IReadOnlyList<string> Topics { get; }

    /// <summary>
    /// Gets whether the repository has any issues.
    /// </summary>
    public bool HasIssues { get; }

    /// <summary>
    /// Gets whether the repository has any projects.
    /// </summary>
    public bool HasProjects { get; }

    /// <summary>
    /// Gets whether the repository has a Wiki.
    /// </summary>
    public bool HasWiki { get; }

    /// <summary>
    /// Gets whether the repository has any pages.
    /// </summary>
    public bool HasPages { get; }

    /// <summary>
    /// Gets whether the repository has any downloads.
    /// </summary>
    public bool HasDownloads { get; }

    /// <summary>
    /// Gets whether the repository has any discussions.
    /// </summary>
    public bool HasDiscussions { get; }

    /// <summary>
    /// Gets whether the repository has any pull requests.
    /// </summary>
    public bool HasPullRequests { get; }

    /// <summary>
    /// Gets whether the repository is archived.
    /// </summary>
    public bool IsArchived { get; }

    /// <summary>
    /// Gets whether the repository is disabled.
    /// </summary>
    public bool IsDisabled { get; }

    /// <summary>
    /// Gets the visibility of the repository.
    /// </summary>
    public string Visibility { get; }

    /// <summary>
    /// Gets a timestamp for when the repository was created.
    /// </summary>
    public EssentialsTime CreatedAt { get; }

    /// <summary>
    /// Gets a timestamp for when the repository was last updated.
    /// </summary>
    public EssentialsTime UpdatedAt { get; }

    /// <summary>
    /// Gets the timestamp for when a user last pushed to the repository.
    /// </summary>
    public EssentialsTime? PushedAt { get; }

    /// <summary>
    /// Gets the number of users watching the repository.
    /// </summary>
    public int SubscribersCount { get; }

    /// <summary>
    /// Gets the number of forks of the repository.
    /// </summary>
    public int NetworkCount { get; }

    // TODO: license (object?) - The license of the repository.

    /// <summary>
    /// Gets the amount of forks of the repository.
    /// </summary>
    public int Forks { get; }

    /// <summary>
    /// Gets the amount of open issues.
    /// </summary>
    public int OpenIssues { get; }

    /// <summary>
    /// Gets the amount of users who have subscribed (watchers) to the repository.
    /// </summary>
    public int Watchers { get; }

    /// <summary>
    /// Gets whether the repository allows forking.
    /// </summary>
    public bool AllowForking { get; }

    #endregion

    #region Constructors

    /// <summary>
    /// Initializes a new instance from the specified <paramref name="json"/> object.
    /// </summary>
    /// <param name="json">The instance of <see cref="JObject"/> representing the repository.</param>
    protected GitHubRepositoryItem(JObject json) : base(json) {
        Homepage = json.GetString("homepage");
        Language = json.GetString("language");
        ForksCount = json.GetInt32("forks_count");
        StargazersCount = json.GetInt32("stargazers_count");
        WatchersCount = json.GetInt32("watchers_count");
        Size = json.GetRequiredInt64("size");
        DefaultBranch = json.GetRequiredString("default_branch");
        OpenIssuesCount = json.GetRequiredInt32("open_issues_count");
        IsTemplate = json.GetRequiredBoolean("is_template");
        Topics = json.GetStringArray("topics");
        HasIssues = json.GetBoolean("has_issues");
        HasProjects = json.GetBoolean("has_projects");
        HasWiki = json.GetBoolean("has_wiki");
        HasPages = json.GetBoolean("has_pages");
        HasDownloads = json.GetBoolean("has_downloads");
        HasDiscussions = json.GetBoolean("has_discussions");
        HasPullRequests = json.GetBoolean("has_pull_requests");
        IsArchived = json.GetRequiredBoolean("archived");
        IsDisabled = json.GetRequiredBoolean("disabled");
        Visibility = json.GetRequiredString("visibility");
        CreatedAt = json.GetRequiredEssentialsTime("created_at");
        UpdatedAt = json.GetRequiredEssentialsTime("updated_at");
        PushedAt = json.GetEssentialsTime("pushed_at");
        SubscribersCount = json.GetRequiredInt32("subscribers_count");
        NetworkCount = json.GetRequiredInt32("network_count");
        // TODO: license (object?) - The license of the repository.
        Forks = json.GetRequiredInt32("forks");
        OpenIssues = json.GetRequiredInt32("open_issues");
        Watchers = json.GetRequiredInt32("watchers");
        AllowForking = json.GetRequiredBoolean("allow_forking");
    }

    #endregion

    #region Static methods

    /// <summary>
    /// Parses the specified <paramref name="json"/> object into an instance of <see cref="GitHubRepositoryItem"/>.
    /// </summary>
    /// <param name="json">The instance of <see cref="JObject"/> to be parsed.</param>
    /// <returns>An instance of <see cref="GitHubRepositoryItem"/>.</returns>
    public static new GitHubRepositoryItem Parse(JObject json) {
        return new GitHubRepositoryItem(json);
    }

    #endregion

}