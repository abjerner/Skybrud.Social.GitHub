using System;
using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Extensions;
using Skybrud.Essentials.Time;
using Skybrud.Social.GitHub.Extensions;
using Skybrud.Social.GitHub.Models.Users;

namespace Skybrud.Social.GitHub.Models.Repositories {

    /// <summary>
    /// Class representing a summary about a given repository.
    /// </summary>
    public class GitHubRepositoryBase : GitHubObject {

        #region Properties

        /// <summary>
        /// Gets the ID of the repository.
        /// </summary>
        public int Id { get; }

        /// <summary>
        /// Gets the name of the repository - eg. <code>Skybrud.Social</code>.
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Gets the full name of the repository - eg. <code>abjerner/Skybrud.Social</code>.
        /// </summary>
        public string FullName { get; }

        /// <summary>
        /// Gets information about the owner of the repository.
        /// </summary>
        public GitHubUserItem Owner { get; }

        /// <summary>
        /// Gets whether the repository is private.
        /// </summary>
        public bool IsPrivate { get; }

        /// <summary>
        /// Gets a reference to a collection of URLs related to the repository.
        /// </summary>
        public GitHubRepositoryUrls Urls { get; }

        /// <summary>
        /// Gets the description of the repository.
        /// </summary>
        public string Description { get; }

        /// <summary>
        /// Gets whether the repository is a fork.
        /// </summary>
        public bool IsFork { get; }

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
        public EssentialsTime PushedAt { get; }

        /// <summary>
        /// Gets the URL for the website behind project.
        /// </summary>
        public string Homepage { get; }

        /// <summary>
        /// Gets the size of the repository.
        /// </summary>
        public long Size { get; }

        /// <summary>
        /// Gets the amount of users who have starred the repository.
        /// </summary>
        public int StargazersCount { get; }

        /// <summary>
        /// Gets the amount of users watching the repository.
        /// </summary>
        public int WatchersCount { get; }

        /// <summary>
        /// Gets the language of repository.
        /// </summary>
        public string Language { get; }

        /// <summary>
        /// Gets whether the repository has any issues.
        /// </summary>
        public bool HasIssues { get; }

        /// <summary>
        /// Gets whether the repository has any available downloads.
        /// </summary>
        public bool HasDownloads { get; }

        /// <summary>
        /// Gets whether the repository has a wiki.
        /// </summary>
        public bool HasWiki { get; }

        /// <summary>
        /// Gets whether the repository has any pages.
        /// </summary>
        public bool HasPages { get; }

        /// <summary>
        /// Gets the amount of forks of the repository.
        /// </summary>
        public int ForksCount { get; }

        /// <summary>
        /// Gets the amount of open issues.
        /// </summary>
        public int OpenIssuesCount { get; }

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
        /// Gets the name of the default branch.
        /// </summary>
        public string DefaultBranch { get; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance from the specified <paramref name="json"/> object.
        /// </summary>
        /// <param name="json">The instance of <see cref="JObject"/> representing the repository.</param>
        protected GitHubRepositoryBase(JObject json) : base(json) {
            Id = json.GetInt32("id");
            Owner = json.GetObject("owner", GitHubUserItem.Parse);
            Name = json.GetString("name");
            FullName = json.GetString("full_name");
            IsPrivate = json.GetBoolean("private");
            Urls = GitHubRepositoryUrls.Parse(json);
            Description = json.GetString("description");
            IsFork = json.GetBoolean("fork");
            CreatedAt = json.GetEssentialsTime("created_at");
            UpdatedAt = json.GetEssentialsTime("updated_at");
            PushedAt = json.GetEssentialsTime("pushed_at");
            Homepage = json.GetString("homepage");
            Size = json.GetInt64("size");
            StargazersCount = json.GetInt32("stargazers_count");
            WatchersCount = json.GetInt32("watchers_count");
            Language = json.GetString("language");
            HasIssues = json.GetBoolean("has_issues");
            HasDownloads = json.GetBoolean("has_downloads");
            HasWiki = json.GetBoolean("has_wiki");
            HasPages = json.GetBoolean("has_pages");
            ForksCount = json.GetInt32("forks_count");
            OpenIssuesCount = json.GetInt32("open_issues_count");
            Forks = json.GetInt32("forks");
            OpenIssues = json.GetInt32("open_issues");
            Watchers = json.GetInt32("watchers");
            DefaultBranch = json.GetString("default_branch");
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <paramref name="json"/> object into an instance of <see cref="GitHubRepositoryBase"/>.
        /// </summary>
        /// <param name="json">The instance of <see cref="JObject"/> to be parsed.</param>
        /// <returns>An instance of <see cref="GitHubRepositoryBase"/>.</returns>
        public static GitHubRepositoryBase Parse(JObject json) {
            return json == null ? null : new GitHubRepositoryBase(json);
        }

        #endregion

    }

}