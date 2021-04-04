using Skybrud.Essentials.Http.Collections;
using System;

namespace Skybrud.Social.GitHub.Extensions {
    
    /// <summary>
    /// Various extension methods for the GitHub implementation.
    /// </summary>
    public static class GitHubExtensions {

        /// <summary>
        /// Adds a new item to <paramref name="query"/> with the specified <paramref name="key"/> and enum <paramref name="value"/>.
        /// </summary>
        /// <param name="query">The query.</param>
        /// <param name="key">The key.</param>
        /// <param name="value">The enum value.</param>
        public static void AddEnumValue(this IHttpQueryString query, string key, Enum value) {
            query?.Add(key, GitHubUtils.ToString(value));
        }

    }

}