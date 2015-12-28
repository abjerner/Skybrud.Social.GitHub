using System;

namespace Skybrud.Social.GitHub.Exceptions {
    
    /// <summary>
    /// Class representing a basic exception returned by the GitHub API.
    /// </summary>
    public class GitHubException : Exception {

        /// <summary>
        /// Initializes a new exception with the specified <code>message</code>.
        /// </summary>
        /// <param name="message">The message of the exception.</param>
        public GitHubException(string message) : base(message) { }

    }

}