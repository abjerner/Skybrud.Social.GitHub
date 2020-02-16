using System;
using System.Collections.Generic;
using Skybrud.Social.GitHub.Http;

namespace Skybrud.Social.GitHub.Extensions {
    
    /// <summary>
    /// Various extension methods for <see cref="GitHubHttpOptionsBase"/>.
    /// </summary>
    public static class GitHubHttpOptionsBaseExtensions {
        
        /// <summary>
        /// Adds the specified <paramref name="mediaType"/> to the <strong>Accept</strong> header of the request.
        /// </summary>
        /// <param name="options">The options.</param>
        /// <param name="mediaType">The media type to be added.</param>
        public static T AddMediaType<T>(this T options, string mediaType) where T : GitHubHttpOptionsBase {
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
        public static T RemoveMediaType<T>(this T options, string mediaType) where T : GitHubHttpOptionsBase {
            if (string.IsNullOrWhiteSpace(mediaType)) throw new ArgumentNullException(nameof(mediaType));
            options?.MediaTypes?.Remove(mediaType);
            return options;
        }

    }

}