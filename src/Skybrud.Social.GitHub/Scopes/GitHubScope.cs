using System.Collections.Generic;

namespace Skybrud.Social.GitHub.Scopes {

    /// <summary>
    /// Class representing a scope of the GitHub API.
    /// </summary>
    public class GitHubScope {

        #region Private fields

        private static readonly Dictionary<string, GitHubScope> Scopes = new Dictionary<string, GitHubScope>();

        #endregion

        #region Properties

        /// <summary>
        /// Gets the alias of the scope.
        /// </summary>
        public string Alias { get; }

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
        /// Initializes a new scope with the specified <paramref name="alias"/>.
        /// </summary>
        /// <param name="alias">The alias of the scope.</param>
        internal GitHubScope(string alias) {
            Alias = alias;
        }

        /// <summary>
        /// Initializes a new scope with the specified <paramref name="alias"/>, <paramref name="name"/> and <paramref name="description"/>.
        /// </summary>
        /// <param name="alias">The alias of the scope.</param>
        /// <param name="name">The name of the scope.</param>
        /// <param name="description">The description of the scope.</param>
        internal GitHubScope(string alias, string name, string description) {
            Alias = alias;
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
            return Alias;
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Registers a scope in the internal dictionary.
        /// </summary>
        /// <param name="alias">The alias of the scope.</param>
        /// <param name="name">The name of the scope.</param>
        /// <param name="description">The description of the scope.</param>
        internal static GitHubScope RegisterScope(string alias, string name, string description) {
            GitHubScope scope = new GitHubScope(alias, name, description);
            Scopes.Add(scope.Alias, scope);
            return scope;
        }

        /// <summary>
        /// Attempts to get a scope with the specified <paramref name="alias"/>.
        /// </summary>
        /// <param name="alias">The name of the alias.</param>
        /// <returns>A scope matching the specified <paramref name="alias"/>, or <c>null</c> if not found.</returns>
        public static GitHubScope GetScope(string alias) {
            return Scopes.TryGetValue(alias, out var scope) ? scope : null;
        }

        /// <summary>
        /// Gets whether the scope is a known scope.
        /// </summary>
        /// <param name="alias">The name of the scope.</param>
        /// <returns><c>true</c> if the specified <paramref name="alias"/> matches a known scope, otherwise <c>false</c>.</returns>
        public static bool ScopeExists(string alias) {
            return Scopes.ContainsKey(alias);
        }

        /// <summary>
        /// Gets the scope with the specified <paramref name="alias"/>.
        /// </summary>
        /// <param name="alias">The alias of the scope.</param>
        /// <param name="result">When this method returns, contains the scope with specified <paramref name="alias"/>, if the scope is found; otherwise, <c>null</c>. This parameter is passed uninitialized.</param>
        /// <returns><c>true</c> if the a scope with the specified <paramref name="alias"/> exists; otherwise, false.</returns>
        public static bool TryGetScope(string alias, out GitHubScope result) {
            return Scopes.TryGetValue(alias, out result);
        }

        #endregion

        #region Operators

        /// <summary>
        /// Adding two instances of <see cref="GitHubScope"/> will result in a <see cref="GitHubScopeList"/> containing both scopes.
        /// </summary>
        /// <param name="left">The left scope.</param>
        /// <param name="right">The right scope.</param>
        public static GitHubScopeList operator +(GitHubScope left, GitHubScope right) {
            return new GitHubScopeList(left, right);
        }

        #endregion

    }

}