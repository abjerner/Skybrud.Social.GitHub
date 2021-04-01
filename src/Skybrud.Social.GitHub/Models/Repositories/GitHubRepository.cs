using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Extensions;
using Skybrud.Essentials.Time;
using Skybrud.Social.GitHub.Extensions;
using Skybrud.Social.GitHub.Models.Users;

namespace Skybrud.Social.GitHub.Models.Repositories {

    /// <summary>
    /// Class representing a GitHub repository.
    /// </summary>
    public class GitHubRepository : GitHubObject {

        #region Properties

        /// <summary>
        /// Gets the ID of the repository.
        /// </summary>
        public int Id { get; }

        /// <summary>
        /// Gets the name of the repository - eg. <c>Skybrud.Social</c>.
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Gets the full name of the repository - eg. <c>abjerner/Skybrud.Social</c>.
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

        /// <summary>
        /// Gets the network count of the repository.
        /// </summary>
        public int NetworkCount { get; }

        /// <summary>
        /// Gets the amount of users who have subscribed (watchers) to the repository.
        /// </summary>
        public int SubscribersCount { get; }

        #endregion

        #region Constructors

        private GitHubRepository(JObject obj) : base(obj) {
            Id = obj.GetInt32("id");
            Name = obj.GetString("name");
            FullName = obj.GetString("full_name");
            Owner = obj.GetObject("owner", GitHubUserItem.Parse);
            IsPrivate = obj.GetBoolean("private");
            Urls = GitHubRepositoryUrls.Parse(obj);
            Description = obj.GetString("description");
            IsFork = obj.GetBoolean("fork");
            CreatedAt = obj.GetEssentialsTime("created_at");
            UpdatedAt = obj.GetEssentialsTime("updated_at");
            PushedAt = obj.GetEssentialsTime("pushed_at");
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
        /// <returns>An instance of <see cref="GitHubRepository"/>.</returns>
        public static GitHubRepository Parse(JObject obj) {
            return obj == null ? null : new GitHubRepository(obj);
        }

        #endregion

    }

}