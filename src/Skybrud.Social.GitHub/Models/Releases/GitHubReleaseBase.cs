using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Newtonsoft.Extensions;
using Skybrud.Essentials.Time;
using Skybrud.Social.GitHub.Extensions;
using Skybrud.Social.GitHub.Models.Users;

namespace Skybrud.Social.GitHub.Models.Releases {

    /// <summary>
    /// Class describing a GitHub release.
    /// </summary>
    public class GitHubReleaseBase : GitHubObject {

        /*
         * SCHEMA:
         *
         * url                      string (uri)
         * html_url                 string (uri)
         * assets_url               string (uri)
         * upload_url               string (uri)
         * tarball_url              string? (uri)
         * zipball_url              string? (uri)
         * id                       integer
         * node_id                  string
         * tag_name                 string
         * target_commitish         string
         * name                     string?
         * body                     string?
         * draft                    boolean
         * prelease                 boolean
         * immutable                boolean
         * created_at               string (date-time)
         * published_at             string? (date-time)
         * updated_at               string? (date-time)
         * author                   SimpleUser
         * assets                   array of <see cref="GitHubReleaseAsset"/>
         * body_html                string
         * body_text                string
         * mentions_count           integer
         * discussion_url           string (uri)
         * reactions                ReactionRollup
         */

        #region Properties

        /// <summary>
        /// Gets the API URL of the release.
        /// </summary>
        public string Url { get; }

        /// <summary>
        /// Gets the HTML URL of the release.
        /// </summary>
        public string HtmlUrl { get; }

        /// <summary>
        /// Gets the API assets URL of the release.
        /// </summary>
        public string AssetsUrl { get; }

        /// <summary>
        /// Gets the API upload URL of the release.
        /// </summary>
        public string UploadUrl { get; }

        /// <summary>
        /// Gets the tarball URL of this release.
        /// </summary>
        public string? TarballUrl { get; }

        /// <summary>
        /// Gets the zipball URL of this release.
        /// </summary>
        public string? ZipballUrl { get; }

        /// <summary>
        /// Gets the numeric ID of the release.
        /// </summary>
        public long Id { get; }

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
        public string? Name { get; }

        /// <summary>
        /// Gets the markdown body of this release.
        /// </summary>
        public string? Body { get; }

        /// <summary>
        /// Gets whether this release is a draft.
        /// </summary>
        public bool IsDraft { get; }

        /// <summary>
        /// Gets whether this release is a pre-release.
        /// </summary>
        public bool IsPreRelease { get; }

        // TODO: add support for the "immutable" property (boolean)

        /// <summary>
        /// Gets the time release was created.
        /// </summary>
        public EssentialsTime CreatedAt { get; }

        /// <summary>
        /// Gets the time this release was published.
        /// </summary>
        public EssentialsTime? PublishedAt { get; }

        /// <summary>
        /// Gets a timestamp for when the release was last updated.
        /// </summary>
        public EssentialsTime? UpdatedAt { get; }

        /// <summary>
        /// Gets a reference to the author of the release.
        /// </summary>
        public GitHubUserItem Author { get; }

        /// <summary>
        /// Gets an array of assets uploaded for the release.
        /// </summary>
        public IReadOnlyList<GitHubReleaseAsset> Assets { get; }

        // TODO: add support for the "body_html" property (string)

        // TODO: add support for the "body_text" property (string)

        /// <summary>
        /// Gets the amount of mentions in this release.
        /// </summary>
        public int MentionsCount { get; }

        // TODO: add support for the "discussion_url" property (string)

        // TODO: add support for the "reactions" property (ReactionRollup)

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance from the specified <paramref name="json"/>.
        /// </summary>
        /// <param name="json">The instance of <see cref="JObject"/> representing the organization.</param>
        protected GitHubReleaseBase(JObject json) : base(json) {
            Url = json.GetRequiredString("url");
            HtmlUrl = json.GetRequiredString("html_url");
            AssetsUrl = json.GetRequiredString("assets_url");
            UploadUrl = json.GetRequiredString("upload_url");
            TarballUrl = json.GetString("tarball_url");
            ZipballUrl = json.GetString("zipball_url");
            Id = json.GetInt64("id");
            NodeId = json.GetRequiredString("node_id");
            TagName = json.GetRequiredString("tag_name");
            TargetCommitish = json.GetRequiredString("target_commitish");
            Name = json.GetString("name");
            Body = json.GetString("body");
            IsDraft = json.GetRequiredBoolean("draft");
            IsPreRelease = json.GetRequiredBoolean("prerelease");
            // TODO: add support for the "immutable" property (boolean)
            CreatedAt = json.GetRequiredEssentialsTime("created_at");
            PublishedAt = json.GetEssentialsTime("published_at");
            UpdatedAt = json.GetEssentialsTime("updated_at");
            Author = json.GetRequiredObject("author", GitHubUserItem.Parse);
            Assets = json.GetArrayItems("assets", GitHubReleaseAsset.Parse);
            // TODO: add support for the "body_html" property (string)
            // TODO: add support for the "body_text" property (string)
            MentionsCount = json.GetInt32("mentions_count");
            // TODO: add support for the "discussion_url" property (string)
            // TODO: add support for the "reactions" property (ReactionRollup)
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <paramref name="json"/> into an instance of <see cref="GitHubReleaseBase"/>.
        /// </summary>
        /// <param name="json">The instance of <see cref="JObject"/> to be parsed.</param>
        /// <returns>An instance of <see cref="GitHubReleaseBase"/>.</returns>
        public static GitHubReleaseBase Parse(JObject json) {
            return new GitHubReleaseBase(json);
        }

        #endregion

    }

}