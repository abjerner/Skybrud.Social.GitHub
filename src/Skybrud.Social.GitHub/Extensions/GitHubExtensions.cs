using Skybrud.Essentials.Http.Collections;
using Skybrud.Social.GitHub.Http;
using System;
using System.Collections.Generic;

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

        /// <summary>
        /// Returns the specified enum has a value. The enum is considered having a value when it differs from the enum's default value.
        /// </summary>
        /// <typeparam name="T">The enum type.</typeparam>
        /// <param name="value">The enum value.</param>
        /// <returns><c>true</c> if the enum has a value; otherwise <c>false</c>.</returns>
        public static bool HasValue<T>(this T value) where T : Enum {
            return !Equals(value, default(T));
        }

        /// <summary>
        /// Returns wether the specified integer has a value (not equal to <c>0</c>). 
        /// </summary>
        /// <param name="value">The integer value to check.</param>
        /// <returns><c>true</c> if the integer has a value; otherwise <c>false</c>.</returns>
        public static bool HasValue(this int value) {
            return value != 0;
        }
        
        /// <summary>
        /// Adds the specified <paramref name="mediaType"/> to the <strong>Accept</strong> header of the request.
        /// </summary>
        /// <param name="options">The options.</param>
        /// <param name="mediaType">The media type to be added.</param>
        public static T AddMediaType<T>(this T options, string mediaType) where T : GitHubHttpRequestOptions {
            if (string.IsNullOrWhiteSpace(mediaType)) throw new ArgumentNullException(nameof(mediaType));
            if (options != null) {
                if (options.MediaTypes == null) options.MediaTypes = new List<string>();
                options.MediaTypes.Add(mediaType);
            }
            return options;
        }

        /// <summary>
        /// Removes the specified <paramref name="mediaType"/> from the <strong>Accept</strong> header of the request.
        /// </summary>
        /// <param name="options">The options.</param>
        /// <param name="mediaType">The media type to be removed.</param>
        public static T RemoveMediaType<T>(this T options, string mediaType) where T : GitHubHttpRequestOptions {
            if (string.IsNullOrWhiteSpace(mediaType)) throw new ArgumentNullException(nameof(mediaType));
            options?.MediaTypes?.Remove(mediaType);
            return options;
        }

    }

}