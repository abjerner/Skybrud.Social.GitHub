using System;
using System.Diagnostics.CodeAnalysis;
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

    /// <summary>
    /// Attempts to parse the specified <paramref name="value"/> as a GitHub repository URL and extract the owner and repository aliases.
    /// </summary>
    /// <param name="value">The value to parse.</param>
    /// <param name="ownerAlias">The owner alias.</param>
    /// <param name="repositoryAlias">The repository alias.</param>
    /// <returns><see langword="true"/> if the value was successfully parsed; otherwise, <see langword="false"/>.</returns>
    public static bool TryParseRepositoryUrl(string? value, [NotNullWhen(true)] out string? ownerAlias, [NotNullWhen(true)] out string? repositoryAlias) {

        ownerAlias = null;
        repositoryAlias = null;

        if (!Uri.TryCreate(value, UriKind.Absolute, out Uri? uri)) return false;

        string[] segments = uri.AbsolutePath.Trim('/').Split('/');
        if (segments.Length < 2) return false;

        ownerAlias = segments[0];
        repositoryAlias = segments[1];
        return true;

    }

}