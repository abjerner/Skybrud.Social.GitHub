using Skybrud.Essentials.Time;

namespace Skybrud.Social.GitHub.Constants {

    /// <summary>
    /// Static class with various constants used throughout the package.
    /// </summary>
    public static class GitHubConstants {

        /// <summary>
        /// Gets the datetime format used by the GitHub API.
        /// </summary>
        public const string DateTimeFormat = TimeUtils.Iso8601DateFormat;

        public const int Unspecified = 0;

        public const int Unrecognized = -1;

    }

}