using Skybrud.Essentials.Http;
using Skybrud.Essentials.Http.Options;
using System;
using System.Collections.Generic;

namespace Skybrud.Social.GitHub.Http {

    /// <summary>
    /// Class describing basic options for a HTTP request to the GitHub API.
    /// </summary>
    public abstract class GitHubHttpRequestOptions : IHttpRequestOptions {

        /// <summary>
        /// Gets or sets the media types that should make up the <strong>Accept</strong> header of requests made using this instance.
        /// </summary>
        public List<string> MediaTypes = new List<string>();

        /// <inheritdoc />
        public abstract IHttpRequest GetRequest();
        
        /// <summary>
        /// Returns a string representation of the specified enum <paramref name="value"/>.
        /// </summary>
        /// <param name="value">The enum value.</param>
        /// <returns>The string representation of the enum value.</returns>
        public static string ToString(Enum value) {
            return GitHubUtils.ToString(value);
        }

    }

}