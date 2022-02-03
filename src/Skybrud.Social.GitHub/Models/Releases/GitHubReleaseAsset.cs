using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Extensions;
using Skybrud.Essentials.Time;
using Skybrud.Social.GitHub.Models.Users;

namespace Skybrud.Social.GitHub.Models.Releases {

    /// <summary>
    /// Class describing an asset of a GitHub release.
    /// </summary>
    public class GitHubReleaseAsset : GitHubObject {

        #region Properties

        /// <summary>
        /// Gets the API URL of the asset.
        /// </summary>
        public string Url { get; }

        /// <summary>
        /// Gets the numeric ID of the asset.
        /// </summary>
        public long Id { get; }

        /// <summary>
        /// Gets the node ID of the asset.
        /// </summary>
        public string NodeId { get; }

        /// <summary>
        /// Gets the name of the asset.
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Gets the label of the asset.
        /// </summary>
        public string Label { get; }

        /// <summary>
        /// Gets a reference to the user who uploaded the asset.
        /// </summary>
        public GitHubUserItem Uploader { get; }

        /// <summary>
        /// Gets the content type of the asset.
        /// </summary>
        public string ContentType { get; }

        /// <summary>
        /// Gets the state of the asset.
        /// </summary>
        public string State { get; }

        /// <summary>
        /// Gets the file size of the asset.
        /// </summary>
        public long Size { get; }

        /// <summary>
        /// Gets the download count of the asset.
        /// </summary>
        public long DownloadCount { get; }

        /// <summary>
        /// Gets the time asset was created.
        /// </summary>
        public EssentialsTime CreatedAt { get; }

        /// <summary>
        /// Gets the time this asset was updated.
        /// </summary>
        public EssentialsTime UpdatedAt { get; }

        /// <summary>
        /// Gets the browser download URL of the asset.
        /// </summary>
        public string BrowserDownloadUrl { get; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance from the specified <paramref name="json"/>.
        /// </summary>
        /// <param name="json">The instance of <see cref="JObject"/> representing the organizationt.</param>
        protected GitHubReleaseAsset(JObject json) : base(json) {
            Url = json.GetString("url");
            Id = json.GetInt64("id");
            NodeId = json.GetString("node_id");
            Name = json.GetString("name");
            Label = json.GetString("label");
            Uploader = json.GetObject("uploader", GitHubUserItem.Parse);
            ContentType = json.GetString("content_type");
            State = json.GetString("state");
            Size = json.GetInt64("size");
            DownloadCount = json.GetInt64("download_count");
            CreatedAt = json.GetString("created_at", EssentialsTime.Parse);
            UpdatedAt = json.GetString("updated_at", EssentialsTime.Parse);
            BrowserDownloadUrl = json.GetString("browser_download_url");
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <paramref name="json"/> into an instance of <see cref="GitHubReleaseAsset"/>.
        /// </summary>
        /// <param name="json">The instance of <see cref="JObject"/> to be parsed.</param>
        /// <returns>An instance of <see cref="GitHubReleaseAsset"/>.</returns>
        public static GitHubReleaseAsset Parse(JObject json) {
            return json == null ? null : new GitHubReleaseAsset(json);
        }

        #endregion

    }

}