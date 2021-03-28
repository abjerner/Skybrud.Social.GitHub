using Skybrud.Essentials.Strings;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Skybrud.Social.GitHub.Scopes {

    /// <summary>
    /// Class representing a list of scopes of the GitHub API.
    /// </summary>
    public class GitHubScopeList : IEnumerable<GitHubScope> {

        #region Private fields

        private readonly List<GitHubScope> _list = new List<GitHubScope>();

        #endregion

        #region Properties

        /// <summary>
        /// Gets an array of all scopes added to the list.
        /// </summary>
        public GitHubScope[] Items => _list.ToArray();

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new list with the specified array of <paramref name="scopes"/>.
        /// </summary>
        /// <param name="scopes">The array of scopes the list should be based on.</param>
        public GitHubScopeList(params GitHubScope[] scopes) {
            _list.AddRange(scopes);
        }

        #endregion

        #region Member methods

        /// <summary>
        /// Adds the specified <paramref name="scope"/> to the list.
        /// </summary>
        /// <param name="scope">The scope to be added.</param>
        public void Add(GitHubScope scope) {
            _list.Add(scope);
        }

        /// <summary>
        /// Converts the list of scopes into an array of <see cref="GitHubScope"/>.
        /// </summary>
        /// <returns>Returns an array of <see cref="GitHubScope"/>.</returns>
        public GitHubScope[] ToArray() {
            return _list.ToArray();
        }

        /// <summary>
        /// Returns a string array representing the list.
        /// </summary>
        /// <returns>Returns an array of <see cref="String"/>.</returns>
        public string[] ToStringArray() {
            return (from scope in _list where scope.Alias.Length > 0 select scope.Alias).ToArray();
        }

        /// <summary>
        /// Returns an enumerator that iterates through the list.
        /// </summary>
        /// <returns>An enumerator that can be used to iterate through the list.</returns>
        public IEnumerator<GitHubScope> GetEnumerator() {
            return _list.GetEnumerator();
        }

        /// <summary>
        /// Returns a string representation of the list. The string will consist of the names of scopes added to the list, each separated by a comma.
        /// </summary>
        /// <returns>Returns a string representation of the list.</returns>
        public override string ToString() {
            return string.Join(",", ToStringArray());
        }

        /// <summary>
        /// Returns an enumerator that iterates through the list.
        /// </summary>
        /// <returns>An enumerator that can be used to iterate through the list.</returns>
        IEnumerator IEnumerable.GetEnumerator() {
            return GetEnumerator();
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <paramref name="input"/> string into an instance of <see cref="GitHubScopeList"/>.
        /// </summary>
        /// <param name="input">The input string.</param>
        /// <returns>An instance of <see cref="GitHubScopeList"/>.</returns>
        public static GitHubScopeList Parse(string input) {

            GitHubScopeList scopes = new GitHubScopeList();

            foreach (string alias in StringUtils.ParseStringArray(input)) {
                scopes.Add(GitHubScope.TryGetScope(alias, out GitHubScope scope) ? scope : GitHubScope.RegisterScope(alias, null, null));
            }

            return scopes;

        }

        #endregion

        #region Operator overloading

        /// <summary>
        /// Initializes a new list based on a single <paramref name="scope"/>.
        /// </summary>
        /// <param name="scope">The scope the list should be based on.</param>
        /// <returns>Returns a new list based on a single <paramref name="scope"/>.</returns>
        public static implicit operator GitHubScopeList(GitHubScope scope) {
            return new GitHubScopeList(scope);
        }

        /// <summary>
        /// Initializes a new list based on the specified <paramref name="array"/> of scopes.
        /// </summary>
        /// <param name="array">The array the list should be based on.</param>
        /// <returns>Returns a new instance of <see cref="GitHubScopeList"/>.</returns>
        public static implicit operator GitHubScopeList(GitHubScope[] array) {
            return new GitHubScopeList(array ?? new GitHubScope[0]);
        }

        /// <summary>
        /// Adds the specified <paramref name="scope"/> to <paramref name="list"/>.
        /// </summary>
        /// <param name="list">The list.</param>
        /// <param name="scope">The scope to be added.</param>
        /// <returns>Returns the list.</returns>
        public static GitHubScopeList operator +(GitHubScopeList list, GitHubScope scope) {
            list.Add(scope);
            return list;
        }

        #endregion

    }

}