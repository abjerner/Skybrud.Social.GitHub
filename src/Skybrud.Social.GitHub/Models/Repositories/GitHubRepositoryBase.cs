using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Newtonsoft.Extensions;
using Skybrud.Essentials.Time;
using Skybrud.Social.GitHub.Extensions;
using Skybrud.Social.GitHub.Models.Users;

namespace Skybrud.Social.GitHub.Models.Repositories {

    /// <summary>
    /// Class representing a summary about a given repository.
    /// </summary>
    public class GitHubRepositoryBase : GitHubObject {

        /*
         * SCHEMA:
         * id                               integer (int64)
         * node_id                          string
         * name                             string
         * full_name                        string
         * owner                            SimpleUser
         * private                          boolean
         * html_url                         string (uri)
         * description                      string?
         * fork                             boolean
         * url                              string (uri)
         * archive_url                      string (uri)
         * assignees_url                    string (uri)
         * blobs_url                        string (uri)
         * branches_url                     string (uri)
         * collaborators_url                string (uri)
         * comments_url                     string (uri)
         * commits_comment_url              string (uri)
         * compare_url                      string (uri)
         * contents_url                     string (uri)
         * contributors_url                 string (uri)
         * deployments_url                  string (uri)
         * downloads_url                    string (uri)
         * events_url                       string (uri)
         * forks_url                        string (uri)
         * git_commits_url                  string (uri)
         * git_refs_url                     string (uri)
         * git_tags_url                     string (uri)
         * git_url                          string (uri)
         * issue_comment_url                string (uri)
         * issue_events_url                 string (uri)
         * issues_url                       string (uri)
         * keys_url                         string (uri)
         * labels_url                       string (uri)
         * languages_url                    string (uri)
         * merges_url                       string (uri)
         * milestones_url                   string (uri)
         * notifications_url                string (uri)
         * pulls_url                        string (uri)
         * releases_url                     string (uri)
         * ssh_url                          string (uri)
         * stargazers_url                   string (uri)
         * statuses_url                     string (uri)
         * subscribers_url                  string (uri)
         * tags_url                         string (uri)
         * teams_url                        string (uri)
         * trees_url                        string (uri)
         * clone_url                        string (uri)
         * mirror_url                       string (uri)
         * hooks_url                        string (uri)
         * svn_url                          string (uri)
         * homepage                         string?
         * language                         string?
         * forks_count                      integer
         * stargazers_count                 integer
         * watchers_count                   integer
         * size                             integer
         * default_branch                   string
         * open_issues_count                integer
         * is_template                      boolean
         * topics                           array of string
         * has_issues                       boolean
         * has_projects                     boolean
         * has_wiki                         boolean
         * has_pages                        boolean
         * has_downloads                    boolean
         * has_discussions                  boolean
         * archived                         boolean
         * disabled                         boolean
         * visibility                       string
         * pushed_at                        string? (date-time)
         * created_at                       string? (date-time)
         * updated_at                       string? (date-time)
         * permission                       object
         * role_name                        string
         * temp_clone_token                 string
         * delete_branch_on_merge           boolean
         * subscribers_count                integer
         * network_count                    integer
         * code_of_conduct                  CodeOfConduct
         * license                          object?
         * forks                            integer
         * open_issues                      integer
         * watchers                         integer
         * allow_forking                    boolean
         * web_commit_signoff_required      boolean
         * security_and_analysis            object
         * custom_properties                object
         */

        #region Properties

        /// <summary>
        /// Gets the ID of the repository.
        /// </summary>
        public int Id { get; }

        /// <summary>
        /// Gets the node ID of the repository.
        /// </summary>
        public string NodeId { get; }

        /// <summary>
        /// Gets the name of the repository - e.g. <code>Skybrud.Social</code>.
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
        public string? Description { get; }

        /// <summary>
        /// Gets whether the repository is a fork.
        /// </summary>
        public bool IsFork { get; }

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

        // TODO: add support for the "is_template" property (boolean)

        // TODO: add support for the "topics" property (string[])

        /// <summary>
        /// Gets whether the repository has any issues.
        /// </summary>
        public bool HasIssues { get; }

        // TODO: add support for the "has_projects" property (boolean)

        /// <summary>
        /// Gets whether the repository has a wiki.
        /// </summary>
        public bool HasWiki { get; }

        /// <summary>
        /// Gets whether the repository has any pages.
        /// </summary>
        public bool HasPages { get; }

        /// <summary>
        /// Gets whether the repository has any available downloads.
        /// </summary>
        public bool HasDownloads { get; }

        // TODO: add support for the "has_discussions" property (boolean)

        // TODO: add support for the "archived" property (boolean)

        // TODO: add support for the "disabled" property (boolean)

        // TODO: add support for the "visibility" property (string)

        /// <summary>
        /// Gets a timestamp for when the repository was created.
        /// </summary>
        public EssentialsTime? CreatedAt { get; }

        /// <summary>
        /// Gets a timestamp for when the repository was last updated.
        /// </summary>
        public EssentialsTime? UpdatedAt { get; }

        /// <summary>
        /// Gets the timestamp for when a user last pushed to the repository.
        /// </summary>
        public EssentialsTime? PushedAt { get; }

        // TODO: add support for the "permissions" property (object)

        // TODO: add support for the "role_name" property (string)

        // TODO: add support for the "temp_clone_token" property (string)

        // TODO: add support for the "delete_branch_on_merge" property (boolean)

        // TODO: add support for the "subscribers_count" property (integer)

        // TODO: add support for the "network_count" property (integer)

        // TODO: add support for the "code_of_conduct" property (object)

        // TODO: add support for the "license" property (object?)

        // TODO: add support for the "role_name" property (string)

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

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance from the specified <paramref name="json"/> object.
        /// </summary>
        /// <param name="json">The instance of <see cref="JObject"/> representing the repository.</param>
        protected GitHubRepositoryBase(JObject json) : base(json) {
            Id = json.GetRequiredInt32("id");
            NodeId = json.GetRequiredString("node_id");
            Name = json.GetRequiredString("name");
            FullName = json.GetRequiredString("full_name");
            Owner = json.GetRequiredObject("owner", GitHubUserItem.Parse);
            IsPrivate = json.GetRequiredBoolean("private");
            Urls = GitHubRepositoryUrls.Parse(json);
            Description = json.GetString("description");
            IsFork = json.GetRequiredBoolean("fork");
            Homepage = json.GetString("homepage");
            Language = json.GetString("language");
            ForksCount = json.GetRequiredInt32("forks_count");
            StargazersCount = json.GetRequiredInt32("stargazers_count");
            WatchersCount = json.GetRequiredInt32("watchers_count");
            Size = json.GetRequiredInt64("size");
            DefaultBranch = json.GetRequiredString("default_branch");
            OpenIssuesCount = json.GetRequiredInt32("open_issues_count");
            // TODO: add support for the "is_template" property (boolean)
            // TODO: add support for the "topics" property (string[])
            HasIssues = json.GetBoolean("has_issues");
            // TODO: add support for the "has_projects" property (boolean)
            HasWiki = json.GetBoolean("has_wiki");
            HasPages = json.GetBoolean("has_pages");
            HasDownloads = json.GetBoolean("has_downloads");
            // TODO: add support for the "has_discussions" property (boolean)
            // TODO: add support for the "archived" property (boolean)
            // TODO: add support for the "disabled" property (boolean)
            // TODO: add support for the "visibility" property (string)
            PushedAt = json.GetEssentialsTime("pushed_at");
            CreatedAt = json.GetEssentialsTime("created_at");
            UpdatedAt = json.GetEssentialsTime("updated_at");
            // TODO: add support for the "permissions" property (object)
            // TODO: add support for the "role_name" property (string)
            // TODO: add support for the "temp_clone_token" property (string)
            // TODO: add support for the "delete_branch_on_merge" property (boolean)
            // TODO: add support for the "subscribers_count" property (integer)
            // TODO: add support for the "network_count" property (integer)
            // TODO: add support for the "code_of_conduct" property (object)
            // TODO: add support for the "license" property (object?)
            // TODO: add support for the "role_name" property (string)
            Forks = json.GetRequiredInt32("forks");
            OpenIssues = json.GetRequiredInt32("open_issues");
            Watchers = json.GetRequiredInt32("watchers");
            // TODO: add support for the "allow_forking" property (boolean)
            // TODO: add support for the "web_commit_signoff_required" property (boolean)
            // TODO: add support for the "security_and_analysis" property (object)
            // TODO: add support for the "custom_properties" property (object)
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <paramref name="json"/> object into an instance of <see cref="GitHubRepositoryBase"/>.
        /// </summary>
        /// <param name="json">The instance of <see cref="JObject"/> to be parsed.</param>
        /// <returns>An instance of <see cref="GitHubRepositoryBase"/>.</returns>
        public static GitHubRepositoryBase Parse(JObject json) {
            return new GitHubRepositoryBase(json);
        }

        #endregion

    }

}