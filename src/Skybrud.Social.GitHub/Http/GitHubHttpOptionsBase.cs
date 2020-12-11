using System.Collections.Generic;

namespace Skybrud.Social.GitHub.Http {

    /// <summary>
    /// Class describing basic options for a HTTP request to the GitHub API.
    /// </summary>
    public class GitHubHttpOptionsBase {

        /// <summary>
        /// Gets or sets the media types that should make up the <strong>Accept</strong> header of requests made using this instance.
        /// </summary>
        public List<string> MediaTypes = new List<string>();

    }

}