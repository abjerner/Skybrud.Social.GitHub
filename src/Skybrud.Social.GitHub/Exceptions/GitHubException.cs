using System;

namespace Skybrud.Social.GitHub.Exceptions {
    
    /// <summary>
    /// Class representing a basic GitHub exception.
    /// </summary>
    public class GitHubException : Exception {

        /// <summary>
        /// Initializes a new exception with the specified <paramref name="message"/>.
        /// </summary>
        /// <param name="message">The message of the exception.</param>
        public GitHubException(string message) : base(message) { }

    }

}