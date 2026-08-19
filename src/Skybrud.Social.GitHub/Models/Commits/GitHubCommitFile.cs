using System;
using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Newtonsoft.Extensions;

namespace Skybrud.Social.GitHub.Models.Commits {

    /// <summary>
    /// Class representing a file of a commit.
    /// </summary>
    public class GitHubCommitFile : GitHubObject {

        #region Properties

        // TODO: add support for "sha" (string?)

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

        // TODO: add support for "previous_filename" (string) (not sure if this is nullable)

        #endregion

        #region Constructors

        private GitHubCommitFile(JObject obj) : base(obj) {
            Filename = obj.GetRequiredString("filename");
            Status = obj.GetRequiredString("status", ParseFileStatus);
            Additions = obj.GetRequiredInt32("additions");
            Deletions = obj.GetRequiredInt32("deletions");
            Changes = obj.GetRequiredInt32("changes");
            BlobUrl = obj.GetRequiredString("blob_url");
            RawUrl = obj.GetRequiredString("raw_url");
            ContentsUrl = obj.GetRequiredString("contents_url");
            Patch = obj.GetRequiredString("patch");
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <paramref name="obj"/> into an instance of <see cref="GitHubCommitFile"/>.
        /// </summary>
        /// <param name="obj">The instance of <see cref="JObject"/> to be parsed.</param>
        /// <returns>An instance of <see cref="GitHubCommitFile"/>.</returns>
        public static GitHubCommitFile Parse(JObject obj) {
            return new GitHubCommitFile(obj);
        }

        private static GitHubCommitFileStatus ParseFileStatus(string value) {
            return value switch {
                "added" => GitHubCommitFileStatus.Added,
                "removed" => GitHubCommitFileStatus.Removed,
                "modified" => GitHubCommitFileStatus.Modified,
                "renamed" => GitHubCommitFileStatus.Renamed,
                "copied" => GitHubCommitFileStatus.Copied,
                "changed" => GitHubCommitFileStatus.Changed,
                "unchanged" => GitHubCommitFileStatus.Unchanged,
                _ => throw new Exception($"Unknown status '{value}' - please create an issue it can be fixed https://github.com/abjerner/Skybrud.Social.GitHub/issues/new")
            };
        }

        #endregion

    }

}