using System;
using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Extensions;

namespace Skybrud.Social.GitHub.Models.Commits {

    /// <summary>
    /// Class representing a file of a commit.
    /// </summary>
    public class GitHubCommitFile : GitHubObject {

        #region Properties

        /// <summary>
        /// Gets the filename (path) of the file.
        /// </summary>
        public string Filename { get; }

        /// <summary>
        /// Gets the amount of lines that were added in the file.
        /// </summary>
        public int Additions { get; }

        /// <summary>
        /// Gets the amount of lines that were deleted in the file.
        /// </summary>
        public int Deletions { get; }

        /// <summary>
        /// Gets the amount of lines that were changed in the file.
        /// </summary>
        public int Changes { get; }

        /// <summary>
        /// Gets the status of the file.
        /// </summary>
        public GitHubCommitFileStatus Status { get; }

        /// <summary>
        /// Gets the website (blog) URL of the file.
        /// </summary>
        public string BlobUrl { get; }

        /// <summary>
        /// Gets the API URL for getting the raw contents of the file.
        /// </summary>
        public string RawUrl { get; }

        /// <summary>
        /// Gets the API URL for getting the contents of the file.
        /// </summary>
        public string ContentsUrl { get; }

        /// <summary>
        /// Gets the patch notes of the commit.
        /// </summary>
        public string Patch { get; }

        #endregion

        #region Constructors

        private GitHubCommitFile(JObject obj) : base(obj) {

            // Parse the file status
            GitHubCommitFileStatus status;
            string strStatus = obj.GetString("status");
            switch (strStatus) {
                case "added": status = GitHubCommitFileStatus.Added; break;
                case "modified": status = GitHubCommitFileStatus.Modified; break;
                case "renamed": status = GitHubCommitFileStatus.Renamed; break;
                case "removed": status = GitHubCommitFileStatus.Removed; break;
                default: throw new Exception("Unknown status \"" + strStatus + "\" - please create an issue it can be fixed https://github.com/abjerner/Skybrud.Social.GitHub/issues/new");
            }

            Filename = obj.GetString("filename");
            Additions = obj.GetInt32("additions");
            Deletions = obj.GetInt32("deletions");
            Changes = obj.GetInt32("changes");
            Status = status;
            BlobUrl = obj.GetString("blob_url");
            RawUrl = obj.GetString("raw_url");
            ContentsUrl = obj.GetString("contents_url");
            Patch = obj.GetString("patch");

        }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <paramref name="obj"/> into an instance of <see cref="GitHubCommitFile"/>.
        /// </summary>
        /// <param name="obj">The instance of <see cref="JObject"/> to be parsed.</param>
        /// <returns>An instance of <see cref="GitHubCommitFile"/>.</returns>
        public static GitHubCommitFile Parse(JObject obj) {
            return obj == null ? null : new GitHubCommitFile(obj);
        }

        #endregion

    }

}