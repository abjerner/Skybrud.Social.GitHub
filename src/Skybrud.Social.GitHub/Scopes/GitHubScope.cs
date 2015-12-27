namespace Skybrud.Social.GitHub.Scopes {

    /// <summary>
    /// Class representing a scope of the GitHub API.
    /// </summary>
    public class GitHubScope {

        #region Properties

        /// <summary>
        /// Gets the name of the scope.
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// Gets the description of the scope.
        /// </summary>
        public string Description { get; private set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new scope with the specified <code>name</code> and <code>description</code>.
        /// </summary>
        /// <param name="name">The name of the scope.</param>
        /// <param name="description">The description of the scope.</param>
        internal GitHubScope(string name, string description = null) {
            Name = name;
            Description = description;
        }

        #endregion

        #region Member methods

        public override string ToString() {
            return Name;
        }

        #endregion

        #region Operators

        /// <summary>
        /// Adding two instance of <code>GitHubScope</code> will result in a <code>GitHubScopeCollection</code> containing both scopes.
        /// </summary>
        /// <param name="left">The left scope.</param>
        /// <param name="right">The right scope.</param>
        public static GitHubScopeCollection operator +(GitHubScope left, GitHubScope right) {
            return new GitHubScopeCollection(left, right);
        }

        #endregion

    }

}