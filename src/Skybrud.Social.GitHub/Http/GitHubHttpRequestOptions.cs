using Skybrud.Essentials.Http;
using Skybrud.Essentials.Http.Options;
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

    }

}