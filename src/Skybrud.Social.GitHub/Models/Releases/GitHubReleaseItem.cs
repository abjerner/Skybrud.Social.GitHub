using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Extensions;
using Skybrud.Essentials.Time;
using Skybrud.Social.GitHub.Models.Users;

namespace Skybrud.Social.GitHub.Models.Releases {

    /// <summary>
    /// Class describing a GitHub release.
    /// </summary>
    public class GitHubReleaseItem : GitHubObject {

        #region Properties

        /// <summary>
        /// Gets the API URL of the release.
        /// </summary>
        public string Url { get; }

        /// <summary>
        /// Gets the API assets URL of the release.
        /// </summary>
        public string AssetsUrl { get; }

        /// <summary>
        /// Gets the API upload URL of the release.
        /// </summary>
        public string UploadUrl { get; }

        /// <summary>
        /// Gets the HTML URL of the release.
        /// </summary>
        public string HtmlUrl { get; }

        /// <summary>
        /// Gets the numeric ID of the release.
        /// </summary>
        public long Id { get; }

        /// <summary>
        /// Gets a reference to the author of the release.
        /// </summary>
        public GitHubUserItem Author { get; }

        /// <summary>
        /// Gets the node ID of the release.
        /// </summary>
        public string NodeId { get; }

        /// <summary>
        /// Gets the tag name of the release.
        /// </summary>
        public string TagName { get; }

        /// <summary>
        /// Gets the name of the branch the release is based on.
        /// </summary>
        public string TargetCommitish { get; }

        /// <summary>
        /// Gets the name of the release.
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Gets whether this release is a draft.
        /// </summary>
        public string IsDraft { get; }

        /// <summary>
        /// Gets whether this release is a pre-release.
        /// </summary>
        public string IsPreRelease { get; }

        /// <summary>
        /// Gets the time release was created.
        /// </summary>
        public EssentialsTime CreatedAt { get; }

        /// <summary>
        /// Gets the time this release was published.
        /// </summary>
        public EssentialsTime PublishedAt { get; }

        /// <summary>
        /// Gets an array of assets uploaded for the release.
        /// </summary>
        public GitHubReleaseAsset[] Assets { get; }

        /// <summary>
        /// Gets the tarball URL of this release.
        /// </summary>
        public string TarballUrl { get; }

        /// <summary>
        /// Gets the zipball URL of this release.
        /// </summary>
        public string ZipballUrl { get; }

        /// <summary>
        /// Gets the markdown body of this release.
        /// </summary>
        public string Body { get; }

        /// <summary>
        /// Gets the amount of mentions in this release.
        /// </summary>
        public int MentionsCount { get; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance from the specified <paramref name="json"/>.
        /// </summary>
        /// <param name="json">The instance of <see cref="JObject"/> representing the organizationt.</param>
        protected GitHubReleaseItem(JObject json) : base(json) {
            Url = json.GetString("url");
            AssetsUrl = json.GetString("assets_url");
            UploadUrl = json.GetString("upload_url");
            HtmlUrl = json.GetString("html_url");
            Id = json.GetInt64("id");
            Author = json.GetObject("author", GitHubUserItem.Parse);
            NodeId = json.GetString("node_id");
            TagName = json.GetString("tag_name");
            TargetCommitish = json.GetString("target_commitish");
            Name = json.GetString("name");
            IsDraft = json.GetString("draft");
            IsPreRelease = json.GetString("prerelease");
            CreatedAt = json.GetString("created_at", EssentialsTime.Parse);
            PublishedAt = json.GetString("published_at", EssentialsTime.Parse);
            Assets = json.GetArrayItems("assets", GitHubReleaseAsset.Parse);
            TarballUrl = json.GetString("tarball_url");
            ZipballUrl = json.GetString("zipball_url");
            Body = json.GetString("body");
            MentionsCount = json.GetInt32("mentions_count");
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <paramref name="json"/> into an instance of <see cref="GitHubReleaseItem"/>.
        /// </summary>
        /// <param name="json">The instance of <see cref="JObject"/> to be parsed.</param>
        /// <returns>An instance of <see cref="GitHubReleaseItem"/>.</returns>
        public static GitHubReleaseItem Parse(JObject json) {
            return json == null ? null : new GitHubReleaseItem(json);
        }

        #endregion

    }

}