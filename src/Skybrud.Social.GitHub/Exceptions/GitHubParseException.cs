namespace Skybrud.Social.GitHub.Exceptions {

    /// <summary>
    /// Class representing an exception occured when parsing data from the GitHub API.
    /// </summary>
    public class GitHubParseException : GitHubException {

        /// <summary>
        /// Initializes a new exception with the specified <paramref name="message"/>.
        /// </summary>
        /// <param name="message">The message of the exception.</param>
        public GitHubParseException(string message) : base(message) { }

    }

}