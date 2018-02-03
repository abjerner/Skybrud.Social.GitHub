namespace Skybrud.Social.GitHub.Scopes {

    /// <summary>
    /// Class representing a scope of the GitHub API.
    /// </summary>
    public class GitHubScope {

        #region Properties

        /// <summary>
        /// Gets the name of the scope.
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Gets the description of the scope.
        /// </summary>
        public string Description { get; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new scope with the specified <paramref name="name"/>.
        /// </summary>
        /// <param name="name">The name of the scope.</param>
        internal GitHubScope(string name) {
            Name = name;
        }

        /// <summary>
        /// Initializes a new scope with the specified <paramref name="name"/> and <paramref name="description"/>.
        /// </summary>
        /// <param name="name">The name of the scope.</param>
        /// <param name="description">The description of the scope.</param>
        internal GitHubScope(string name, string description) {
            Name = name;
            Description = description;
        }

        #endregion

        #region Member methods

        /// <summary>
        /// Returns a string representation (the name) of the scope.
        /// </summary>
        /// <returns>A string representation of the scope.</returns>
        public override string ToString() {
            return Name;
        }

        #endregion

        #region Operators

        /// <summary>
        /// Adding two instances of <see cref="GitHubScope"/> will result in a <see cref="GitHubScopeCollection"/> containing both scopes.
        /// </summary>
        /// <param name="left">The left scope.</param>
        /// <param name="right">The right scope.</param>
        public static GitHubScopeCollection operator +(GitHubScope left, GitHubScope right) {
            return new GitHubScopeCollection(left, right);
        }

        #endregion

    }

}