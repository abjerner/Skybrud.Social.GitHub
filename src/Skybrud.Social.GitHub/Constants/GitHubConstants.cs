using Skybrud.Essentials.Time.Iso8601;

namespace Skybrud.Social.GitHub.Constants {

    /// <summary>
    /// Static class with various constants used throughout the package.
    /// </summary>
    public static class GitHubConstants {

        /// <summary>
        /// Gets the datetime format used by the GitHub API.
        /// </summary>
        public const string DateTimeFormat = Iso8601Constants.DateTimeSeconds;

        /// <summary>
        /// Enum ordinal value used to indicate an unrecognized value.
        /// </summary>
        public const int Unrecognized = -1;

        /// <summary>
        /// Enum ordinal value used to indicate an unspecified value.
        /// </summary>
        public const int Unspecified = 0;

    }

}