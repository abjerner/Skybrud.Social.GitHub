using System;
using Skybrud.Essentials.Time;
using Skybrud.Social.GitHub.Options.Organizations.Members;

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

        /// <summary>
        /// Returns a string representation of the specified <paramref name="filter"/>.
        /// </summary>
        /// <param name="filter">The filter.</param>
        /// <returns>A string representation of <paramref name="filter"/>.</returns>
        public static string ToString(GitHubMemberFilter filter) {

            switch (filter) {

                case GitHubMemberFilter.TwoFactorDisabled:
                    return "2fa_disabled";

                case GitHubMemberFilter.All:
                    return "all";

                default:
                    return string.Empty;

            }

        }

    }

}