using System;
using Newtonsoft.Json.Linq;
using Skybrud.Social.GitHub.Objects.Users;
using Skybrud.Essentials.Json.Extensions;

namespace Skybrud.Social.GitHub.Objects.Repositories {

    /// <summary>
    /// Class representing a GitHub repository.
    /// </summary>
    public class GitHubRepository : GitHubObject {

        #region Properties

        /// <summary>
        /// Gets the ID of the repository.
        /// </summary>
        public int Id { get; private set; }

        /// <summary>
        /// Gets the name of the repository - eg. <code>Skybrud.Social</code>.
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// Gets the full name of the repository - eg. <code>abjerner/Skybrud.Social</code>.
        /// </summary>
        public string FullName { get; private set; }

        /// <summary>
        /// Gets information about the owner of the repository.
        /// </summary>
        public GitHubUserSummary Owner { get; private set; }

        /// <summary>
        /// Gets whether the repository is private.
        /// </summary>
        public bool IsPrivate { get; private set; }

        /// <summary>
        /// Gets a reference to a collection of URLs related to the repository.
        /// </summary>
        public GitHubRepositoryUrlCollection Urls { get; private set; }

        /// <summary>
        /// Gets the description of the repository.
        /// </summary>
        public string Description { get; private set; }

        /// <summary>
        /// Gets whether the repository is a fork.
        /// </summary>
        public bool IsFork { get; private set; }

        /// <summary>
        /// Gets a timestamp for when the repository was created.
        /// </summary>
        public DateTime CreatedAt { get; private set; }

        /// <summary>
        /// Gets a timestamp for when the repository was last updated.
        /// </summary>
        public DateTime UpdatedAt { get; private set; }

        /// <summary>
        /// Gets the timestamp for when a user last pushed to the repository.
        /// </summary>
        public DateTime PushedAt { get; private set; }

        /// <summary>
        /// Gets the URL for the website behind project.
        /// </summary>
        public string Homepage { get; private set; }

        /// <summary>
        /// Gets the size of the repository.
        /// </summary>
        public long Size { get; private set; }
        
        /// <summary>
        /// Gets the amount of users who have starred the repository.
        /// </summary>
        public int StargazersCount { get; private set; }
        
        /// <summary>
        /// Gets the amount of users watching the repository.
        /// </summary>
        public int WatchersCount { get; private set; }

        /// <summary>
        /// Gets the language of repository.
        /// </summary>
        public string Language { get; private set; }

        /// <summary>
        /// Gets whether the repository has any issues.
        /// </summary>
        public bool HasIssues { get; private set; }

        /// <summary>
        /// Gets whether the repository has any available downloads.
        /// </summary>
        public bool HasDownloads { get; private set; }

        /// <summary>
        /// Gets whether the repository has a wiki.
        /// </summary>
        public bool HasWiki { get; private set; }

        /// <summary>
        /// Gets whether the repository has any pages.
        /// </summary>
        public bool HasPages { get; private set; }
        
        /// <summary>
        /// Gets the amount of forks of the repository.
        /// </summary>
        public int ForksCount { get; private set; }

        /// <summary>
        /// Gets the amount of open issues.
        /// </summary>
        public int OpenIssuesCount { get; private set; }

        /// <summary>
        /// Gets the amount of forks of the repository.
        /// </summary>
        public int Forks { get; private set; }
        
        /// <summary>
        /// Gets the amount of open issues.
        /// </summary>
        public int OpenIssues { get; private set; }

        /// <summary>
        /// Gets the amount of users who have subscribed (watchers) to the repository.
        /// </summary>
        public int Watchers { get; private set; }

        /// <summary>
        /// Gets the name of the default branch.
        /// </summary>
        public string DefaultBranch { get; private set; }

        /// <summary>
        /// Gets the network count of the repository.
        /// </summary>
        public int NetworkCount { get; private set; }

        /// <summary>
        /// Gets the amount of users who have subscribed (watchers) to the repository.
        /// </summary>
        public int SubscribersCount { get; private set; }

        #endregion

        #region Constructor

        private GitHubRepository(JObject obj) : base(obj) {
            Id = obj.GetInt32("id");
            Name = obj.GetString("name");
            FullName = obj.GetString("full_name");
            Owner = obj.GetObject("owner", GitHubUserSummary.Parse);
            IsPrivate = obj.GetBoolean("private");
            Urls = GitHubRepositoryUrlCollection.Parse(obj);
            Description = obj.GetString("description");
            IsFork = obj.GetBoolean("fork");
            CreatedAt = obj.GetDateTime("created_at");
            UpdatedAt = obj.GetDateTime("updated_at");
            PushedAt = obj.GetDateTime("pushed_at");
            Homepage = obj.GetString("homepage");
            Size = obj.GetInt64("size");
            StargazersCount = obj.GetInt32("stargazers_count");
            WatchersCount = obj.GetInt32("watchers_count");
            Language = obj.GetString("language");
            HasIssues = obj.GetBoolean("has_issues");
            HasDownloads = obj.GetBoolean("has_downloads");
            HasWiki = obj.GetBoolean("has_wiki");
            HasPages = obj.GetBoolean("has_pages");
            ForksCount = obj.GetInt32("forks_count");
            OpenIssuesCount = obj.GetInt32("open_issues_count");
            Forks = obj.GetInt32("forks");
            OpenIssues = obj.GetInt32("open_issues");
            Watchers = obj.GetInt32("watchers");
            DefaultBranch = obj.GetString("default_branch");
            NetworkCount = obj.GetInt32("network_count");
            SubscribersCount = obj.GetInt32("subscribers_count");
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <paramref name="obj"/> into an instance of <see cref="GitHubRepository"/>.
        /// </summary>
        /// <param name="obj">The instance of <see cref="JObject"/> to be parsed.</param>
        /// <returns>Returns an instance of <see cref="GitHubRepository"/>.</returns>
        public static GitHubRepository Parse(JObject obj) {
            return obj == null ? null : new GitHubRepository(obj);
        }

        #endregion

    }

}