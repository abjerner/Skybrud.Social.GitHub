using System;
using Skybrud.Essentials.Enums;
using Skybrud.Essentials.Strings.Extensions;
using Skybrud.Social.GitHub.Options;
using Skybrud.Social.GitHub.Options.Organizations.Members;
using Skybrud.Social.GitHub.Options.Repositories;

namespace Skybrud.Social.GitHub;

/// <summary>
/// Various utility methods used throughout the GitHub API implementation.
/// </summary>
public static class GitHubUtils {

    /// <summary>
    /// Returns a string representation of the specified <paramref name="filter"/>.
    /// </summary>
    /// <param name="filter">The filter.</param>
    /// <returns>A string representation of <paramref name="filter"/>.</returns>
    public static string ToString(GitHubMemberFilter filter) {
        return filter switch {
            GitHubMemberFilter.TwoFactorDisabled => "2fa_disabled",
            GitHubMemberFilter.All => "all",
            _ => string.Empty
        };
    }

    /// <summary>
    /// Returns a string representation of the specified enum <paramref name="value"/>.
    /// </summary>
    /// <param name="value">The enum value.</param>
    /// <returns>The string representation of the enum value.</returns>
    public static string ToString(GitHubSortDirection value) {
        return value switch {
            GitHubSortDirection.Ascending => "asc",
            GitHubSortDirection.Descending => "desc",
            _ => string.Empty
        };
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
        return value switch {
            GitHubMemberFilter filter => ToString(filter),
            GitHubSortDirection direction => ToString(direction),
            GitHubRepositoryAffiliation affiliation => ToString(affiliation),
            _ => value.ToUnderscore()
        };
    }

}