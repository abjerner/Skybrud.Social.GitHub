using Skybrud.Essentials.Enums;
using Skybrud.Essentials.Strings.Extensions;
using System;
using Skybrud.Essentials.Time;
using Skybrud.Social.GitHub.Options;
using Skybrud.Social.GitHub.Options.Organizations.Members;
using Skybrud.Social.GitHub.Options.Repositories;

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

        /// <summary>
        /// Returns a string representation of the specified enum <paramref name="value"/>.
        /// </summary>
        /// <param name="value">The enum value.</param>
        /// <returns>The string representation of the enum value.</returns>
        public static string ToString(GitHubSortDirection value) {

            switch (value) {

                case GitHubSortDirection.Ascending: return "asc";

                case GitHubSortDirection.Descending: return "desc";

                default: return string.Empty;

            }

        }

        /// <summary>
        /// Returns a string representation of the specified enum <paramref name="value"/>.
        /// </summary>
        /// <param name="value">The enum value.</param>
        /// <returns>The string representation of the enum value.</returns>
        public static string ToString(GitHubRepositoryAffiliation value) {
            return value == 0 ? string.Empty : value.GetFlags().ToUnderscore();
        }

        /// <summary>
        /// Returns a string representation of the specified enum <paramref name="value"/>.
        /// </summary>
        /// <param name="value">The enum value.</param>
        /// <returns>The string representation of the enum value.</returns>
        public static string ToString(Enum value) {

            switch (value) {

                case GitHubMemberFilter filter:
                    return ToString(filter);

                case GitHubSortDirection direction:
                    return ToString(direction);

                case GitHubRepositoryAffiliation affiliation:
                    return ToString(affiliation);

                default:
                    return value.ToUnderscore();

            }

        }

    }

}