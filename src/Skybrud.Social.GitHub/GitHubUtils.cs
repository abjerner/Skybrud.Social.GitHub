using System;
using Skybrud.Essentials.Time;

namespace Skybrud.Social.GitHub {

    /// <summary>
    /// Various utility methods used throughout the GitHub API implementation.
    /// </summary>
    public static class GitHubUtils {

        /// <summary>
        /// Formats the specified <paramref name="timestamp"/> as specified according to the GitHub API documentation.
        /// </summary>
        /// <param name="timestamp">The timestamp to be formatted.</param>
        /// <returns>A string representing <paramref name="timestamp"/>.</returns>
        public static string FormatDate(DateTime timestamp) {
            return timestamp.ToUniversalTime().ToString(Constants.GitHubConstants.DateTimeFormat);
        }

        /// <summary>
        /// Formats the specified <paramref name="timestamp"/> as specified according to the GitHub API documentation.
        /// </summary>
        /// <param name="timestamp">The timestamp to be formatted.</param>
        /// <returns>A string representing <paramref name="timestamp"/>.</returns>
        public static string FormatDate(EssentialsDateTime timestamp) {
            if (timestamp == null) throw new ArgumentNullException(nameof(timestamp));
            return FormatDate(timestamp.DateTime);
        }

    }

}